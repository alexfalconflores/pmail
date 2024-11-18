using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Pmail.Helpers;

using Windows.ApplicationModel.DataTransfer;
using Windows.ApplicationModel.DataTransfer.ShareTarget;

namespace Pmail.ViewModels;

public partial class SharedDataWebLinkViewModel : SharedDataViewModelBase
{
    [ObservableProperty]
    private Uri uri;

    public SharedDataWebLinkViewModel()
    {
    }

    public override async Task LoadDataAsync(ShareOperation shareOperation)
    {
        await base.LoadDataAsync(shareOperation);

        PageTitle = "ShareTarget_WebLinkTitle".GetLocalized();
        DataFormat = StandardDataFormats.WebLink;
        Uri = await shareOperation.GetWebLinkAsync();
    }
}
