﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GetStoreApp.Contracts.Services.Settings;
using GetStoreApp.Contracts.Services.Shell;
using GetStoreApp.Helpers;
using GetStoreApp.Models;
using GetStoreApp.ViewModels.Pages;
using Microsoft.UI.Xaml.Media.Animation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GetStoreApp.ViewModels.Controls.Settings
{
    public class LanguageViewModel : ObservableRecipient
    {
        private ILanguageService LanguageService { get; } = IOCHelper.GetService<ILanguageService>();

        private INavigationService NavigationService { get; } = IOCHelper.GetService<INavigationService>();

        private LanguageModel _language;

        public LanguageModel Language
        {
            get { return _language; }

            set { SetProperty(ref _language, value); }
        }

        public List<LanguageModel> LanguageList { get; set; }

        public IAsyncRelayCommand LanguageTipCommand { get; }

        public IAsyncRelayCommand LanguageSelectCommand { get; }

        public LanguageViewModel()
        {
            Language = LanguageService.AppLanguage;
            LanguageList = LanguageService.LanguageList;

            LanguageTipCommand = new AsyncRelayCommand(async () =>
            {
                NavigationService.NavigateTo(typeof(AboutViewModel).FullName, null, new DrillInNavigationTransitionInfo());
                await Task.CompletedTask;
            });

            LanguageSelectCommand = new AsyncRelayCommand(async () =>
            {
                await LanguageService.SetLanguageAsync(Language);
            });
        }
    }
}
