﻿using GetStoreApp.Contracts.Services.Root;
using GetStoreApp.Helpers;
using GetStoreApp.ViewModels.Controls.Settings;
using Microsoft.UI.Xaml.Controls;

namespace GetStoreApp.UI.Controls.Settings
{
    public sealed partial class TopMostControl : UserControl
    {
        public IResourceService ResourceService { get; } = IOCHelper.GetService<IResourceService>();

        public TopMostViewModel ViewModel { get; } = IOCHelper.GetService<TopMostViewModel>();

        public TopMostControl()
        {
            InitializeComponent();
        }
    }
}
