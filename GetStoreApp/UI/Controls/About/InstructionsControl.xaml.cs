﻿using GetStoreApp.Contracts.Root;
using GetStoreApp.Helpers.Root;
using GetStoreApp.ViewModels.Controls.About;
using Microsoft.UI.Xaml.Controls;

namespace GetStoreApp.UI.Controls.About
{
    public sealed partial class InstructionsControl : UserControl
    {
        public IResourceService ResourceService { get; } = ContainerHelper.GetInstance<IResourceService>();

        public InstructionsViewModel ViewModel { get; } = ContainerHelper.GetInstance<InstructionsViewModel>();

        public InstructionsControl()
        {
            InitializeComponent();
        }
    }
}
