﻿using GetStoreApp.Contracts.Root;
using GetStoreApp.Helpers.Root;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using System;

namespace GetStoreApp.Converters.Formats
{
    /// <summary>
    /// 安装进度文字提示转换器
    /// </summary>
    public class InstallValueFormatConverter : IValueConverter
    {
        private IResourceService ResourceService { get; } = ContainerHelper.GetInstance<IResourceService>();

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
            {
                return DependencyProperty.UnsetValue;
            }

            return string.Format(ResourceService.GetLocalized("/Download/InstallValue"), value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
