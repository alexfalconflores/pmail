using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

using Windows.ApplicationModel.DataTransfer.ShareTarget;

namespace Pmail.ViewModels;

public partial class SharedDataViewModelBase : ObservableObject
{
    [ObservableProperty]
    private string dataFormat;
    [ObservableProperty]
    private string pageTitle;
    [ObservableProperty]
    private string title;

    public SharedDataViewModelBase()
    {
    }

    public virtual async Task LoadDataAsync(ShareOperation shareOperation)
    {
        Title = shareOperation.Data.Properties.Title;
        await Task.CompletedTask;
    }
}
