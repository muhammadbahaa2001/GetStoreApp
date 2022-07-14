﻿using GetStoreApp.Contracts.Services.App;
using GetStoreApp.ViewModels.Controls.Home;
using Microsoft.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace GetStoreApp.UI.Controls.Home
{
    public sealed partial class ResultControl : UserControl
    {
        public IResourceService ResourceService { get; }

        public ResultViewModel ViewModel { get; }

        public ResultControl()
        {
            ResourceService = App.GetService<IResourceService>();
            ViewModel = App.GetService<ResultViewModel>();
            this.InitializeComponent();
        }

        public string LocalizedCategoryId(string categoryId)
        {
            return string.Format(ResourceService.GetLocalized("/Home/categoryId"), categoryId);
        }

        public string LocalizedResultCountInfo(int count)
        {
            return string.Format(ResourceService.GetLocalized("/Home/ResultCountInfo"), count);
        }
    }
}
