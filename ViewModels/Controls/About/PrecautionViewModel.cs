﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GetStoreApp.UI.Dialogs;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Threading.Tasks;

namespace GetStoreApp.ViewModels.Controls.About
{
    public class PrecautionViewModel : ObservableRecipient
    {
        public IAsyncRelayCommand RecognizeCommand { get; set; }

        public PrecautionViewModel()
        {
            RecognizeCommand = new AsyncRelayCommand(async () =>
            {
                await ShowDesktopAppsDialogAsync();
            });
        }

        /// <summary>
        /// 传统桌面应用详细信息对话框
        /// </summary>
        public async Task<ContentDialogResult> ShowDesktopAppsDialogAsync()
        {
            DesktopAppsDialog dialog = new DesktopAppsDialog { XamlRoot = App.MainWindow.Content.XamlRoot };
            return await dialog.ShowAsync();
        }
    }
}
