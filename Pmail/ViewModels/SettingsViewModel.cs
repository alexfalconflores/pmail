﻿using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Pmail.Helpers;
using Pmail.Services;

using Windows.ApplicationModel;
using Windows.System;
using Windows.UI.Xaml;

namespace Pmail.ViewModels;

// TODO: Add other settings as necessary. For help see https://github.com/microsoft/TemplateStudio/blob/main/docs/UWP/pages/settings.md
public partial class SettingsViewModel : ObservableObject
{
    private readonly Package package = Package.Current;
    private readonly PackageId packageId;

    [ObservableProperty]
    private ElementTheme elementTheme = ThemeSelectorService.Theme;
    [ObservableProperty]
    private string versionDescription;
    [ObservableProperty]
    private string appDisplayName = "AppDisplayName".GetLocalized();
    [ObservableProperty]
    private ProcessorArchitecture appArchitecture;

    [RelayCommand]
    private async Task SwitchTheme(ElementTheme elementTheme)
    {
        ElementTheme = elementTheme;
        await ThemeSelectorService.SetThemeAsync(elementTheme);
    }

    [RelayCommand]
    private async Task RateAndReview() => _ = await Launcher.LaunchUriAsync(new("ms-windows-store://review/?ProductId=9NMB3PHQH2B7"));

    [RelayCommand]
    private async Task MyApps() => _ = await Launcher.LaunchUriAsync(new("ms-windows-store://publisher/?name=Alex Falcon Flores"));

    public SettingsViewModel()
    {
        packageId = package.Id;
    }

    public async Task InitializeAsync()
    {
        GetVersionDescription();
        GetProcessorArchitecture();
        await Task.CompletedTask;
    }

    private void GetVersionDescription()
    {
        PackageVersion version = packageId.Version;
        VersionDescription = $"{version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
    }

    private void GetProcessorArchitecture()
    {
        AppArchitecture = packageId.Architecture;
    }

    //private ICommand _switchThemeCommand;

    //public ICommand SwitchThemeCommand
    //{
    //    get
    //    {
    //        if (_switchThemeCommand == null)
    //        {
    //            _switchThemeCommand = new RelayCommand<ElementTheme>(
    //                async (param) =>
    //                {
    //                    ElementTheme = param;
    //                    await ThemeSelectorService.SetThemeAsync(param);
    //                });
    //        }

    //        return _switchThemeCommand;
    //    }
    //}

    //public Visibility FeedbackLinkVisibility => Microsoft.Services.Store.Engagement.StoreServicesFeedbackLauncher.IsSupported() ? Visibility.Visible : Visibility.Collapsed;

    //private ICommand _launchFeedbackHubCommand;

    //public ICommand LaunchFeedbackHubCommand
    //{
    //    get
    //    {
    //        if (_launchFeedbackHubCommand == null)
    //        {
    //            _launchFeedbackHubCommand = new RelayCommand(
    //                async () =>
    //                {
    //                    // This launcher is part of the Store Services SDK https://docs.microsoft.com/windows/uwp/monetize/microsoft-store-services-sdk
    //                    var launcher = Microsoft.Services.Store.Engagement.StoreServicesFeedbackLauncher.GetDefault();
    //                    await launcher.LaunchAsync();
    //                });
    //        }

    //        return _launchFeedbackHubCommand;
    //    }
    //}
}
