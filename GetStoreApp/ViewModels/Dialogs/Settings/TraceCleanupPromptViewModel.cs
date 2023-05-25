﻿using GetStoreApp.Extensions.DataType.Enums;
using GetStoreApp.Models.Dialogs.Settings;
using GetStoreApp.Services.Controls.Settings.Advanced;
using GetStoreApp.Services.Root;
using GetStoreApp.ViewModels.Base;
using Microsoft.UI.Xaml.Controls;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace GetStoreApp.ViewModels.Dialogs.Settings
{
    /// <summary>
    /// 痕迹清理对话框视图模型
    /// </summary>
    public sealed class TraceCleanupPromptViewModel : ViewModelBase
    {
        public List<TraceCleanupModel> TraceCleanupList { get; set; } = new List<TraceCleanupModel>();

        private bool _isFirstInitialize = true;

        public bool IsFirstInitialize
        {
            get { return _isFirstInitialize; }

            set
            {
                _isFirstInitialize = value;
                OnPropertyChanged();
            }
        }

        private bool _isSelected;

        public bool IsSelected
        {
            get { return _isSelected; }

            set
            {
                _isSelected = value;
                OnPropertyChanged();
            }
        }

        private bool _isCleaning = false;

        public bool IsCleaning
        {
            get { return _isCleaning; }

            set
            {
                _isCleaning = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 痕迹清理
        /// </summary>
        public async void OnCleanupNowClicked(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            args.Cancel = true;

            IsFirstInitialize = false;
            TraceCleanupList.ForEach(traceCleanupItem => traceCleanupItem.IsCleanFailed = false);
            IsCleaning = true;
            TraceCleanup();
            await Task.Delay(1000);
            IsCleaning = false;
        }

        /// <summary>
        /// 初始化清理列表信息
        /// </summary>
        public void InitializeTraceCleanupList()
        {
            ResourceService.TraceCleanupList.ForEach(traceCleanupItem =>
            {
                traceCleanupItem.IsSelected = false;
                traceCleanupItem.IsCleanFailed = false;
                traceCleanupItem.PropertyChanged += OnPropertyChanged;

                TraceCleanupList.Add(traceCleanupItem);
            });
        }

        /// <summary>
        /// 痕迹清理
        /// </summary>
        private void TraceCleanup()
        {
            List<CleanArgs> SelectedCleanList = new List<CleanArgs>(TraceCleanupList.Where(item => item.IsSelected is true).Select(item => item.InternalName));

            SelectedCleanList.ForEach(async cleanupArgs =>
            {
                // 清理并反馈回结果，修改相应的状态信息
                bool CleanReusult = await TraceCleanupService.CleanAppTraceAsync(cleanupArgs);

                TraceCleanupList[TraceCleanupList.IndexOf(TraceCleanupList.First(item => item.InternalName == cleanupArgs))].IsCleanFailed = !CleanReusult;
            });
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            IsSelected = TraceCleanupList.Exists(item => item.IsSelected);
        }
    }
}
