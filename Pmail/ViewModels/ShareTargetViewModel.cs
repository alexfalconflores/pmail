using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Pmail.Helpers;

using Windows.ApplicationModel.DataTransfer;
using Windows.ApplicationModel.DataTransfer.ShareTarget;

namespace Pmail.ViewModels;

public partial class ShareTargetViewModel : ObservableObject
{
    private ShareOperation _shareOperation;
    [ObservableProperty]
    private SharedDataViewModelBase sharedData;

    public ShareTargetViewModel()
    {
    }

    public async Task LoadAsync(ShareOperation shareOperation)
    {
        // TODO: Configure the Share Target Declaration for the formats you require.
        // Share Target declarations are defined in Package.appxmanifest.
        // Current declarations allow to share WebLink and image files with the app.
        // ShareTarget can be tested sharing the WebLink from Microsoft Edge or sharing images from Windows Photos.

        // TODO: Customize SharedDataModelBase or derived classes adding properties for data that you need to extract from _shareOperation
        _shareOperation = shareOperation;
        if (shareOperation.Data.Contains(StandardDataFormats.StorageItems))
        {
            SharedData = new SharedDataStorageItemsViewModel();
        }

        if (shareOperation.Data.Contains(StandardDataFormats.WebLink))
        {
            SharedData = new SharedDataWebLinkViewModel();
        }

        await SharedData?.LoadDataAsync(_shareOperation);
    }

    [RelayCommand]
    private void OnComplete()
    {
        // TODO: Implement any other logic or add a QuickLink before completing the share operation.
        // More details at https://docs.microsoft.com/windows/uwp/app-to-app/receive-data
        _shareOperation.ReportCompleted();
    }
}
