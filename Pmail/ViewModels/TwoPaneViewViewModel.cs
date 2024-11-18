using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Pmail.Core.Models;
using Pmail.Core.Services;
using Pmail.Helpers;

using WinUI = Microsoft.UI.Xaml.Controls;

namespace Pmail.ViewModels;

public partial class TwoPaneViewViewModel : ObservableObject, IBackNavigationHandler
{
    private WinUI.TwoPaneView _twoPaneView;
    [ObservableProperty]
    private SampleOrder selected;
    [ObservableProperty]
    private WinUI.TwoPaneViewPriority twoPanePriority;

    public event EventHandler<bool> OnPageCanGoBackChanged;

    public ObservableCollection<SampleOrder> SampleItems { get; private set; } = [];

    public TwoPaneViewViewModel()
    {
    }

    public void Initialize(WinUI.TwoPaneView twoPaneView)
    {
        _twoPaneView = twoPaneView;
    }

    public async Task LoadDataAsync()
    {
        SampleItems.Clear();

        var data = await SampleDataService.GetTwoPaneViewDataAsync();

        foreach (var item in data)
        {
            SampleItems.Add(item);
        }

        Selected = SampleItems.First();
    }

    public bool TryCloseDetail()
    {
        if (TwoPanePriority == WinUI.TwoPaneViewPriority.Pane2)
        {
            TwoPanePriority = WinUI.TwoPaneViewPriority.Pane1;
            return true;
        }

        return false;
    }
    [RelayCommand]
    private void OnItemClick()
    {
        if (_twoPaneView.Mode == WinUI.TwoPaneViewMode.SinglePane)
        {
            OnPageCanGoBackChanged?.Invoke(this, true);
            TwoPanePriority = WinUI.TwoPaneViewPriority.Pane2;
        }
    }
    [RelayCommand]
    private void OnModeChanged(WinUI.TwoPaneView twoPaneView)
    {
        if (twoPaneView.Mode == WinUI.TwoPaneViewMode.SinglePane)
        {
            OnPageCanGoBackChanged?.Invoke(this, true);
            TwoPanePriority = WinUI.TwoPaneViewPriority.Pane2;
        }
        else
        {
            OnPageCanGoBackChanged?.Invoke(this, false);
            TwoPanePriority = WinUI.TwoPaneViewPriority.Pane1;
        }
    }

    public void GoBack()
    {
        if (TwoPanePriority == WinUI.TwoPaneViewPriority.Pane2)
        {
            TwoPanePriority = WinUI.TwoPaneViewPriority.Pane1;
            OnPageCanGoBackChanged?.Invoke(this, false);
        }
    }
}
