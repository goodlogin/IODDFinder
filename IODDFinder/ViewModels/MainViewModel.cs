﻿using CommunityToolkit.Mvvm.ComponentModel;
using IODDFinder.Services;

namespace IODDFinder.ViewModels;

public class MainViewModel : ObservableObject
{
    private readonly APIService _apiService;

    private string? _searchText;
    public string? SearchText
    {
        get => _searchText;
        set
        {
            SetProperty(ref _searchText, value);
            OnPropertyChanged(nameof(Vendors));
        }
    }

    public List<string>? _vendors;
    public List<string>? Vendors
    {
        get => _vendors?.Where(x => x.Contains(SearchText ?? "",
            StringComparison.InvariantCultureIgnoreCase)).ToList();
        set => SetProperty(ref _vendors, value);
    }

    private string? _selectedVendor;
    public string? SelectedVendor
    {
        get => null;
        set => SetProperty(ref _selectedVendor, value);
    }

    public MainViewModel(APIService apiService)
    {
        _apiService = apiService;
    }

    public async Task FetchVendorsAsync()
    {
        var vendors = await _apiService.GetVendorsAsync();
        Vendors = vendors.Vendors
            .OrderBy(x => x).ToList();
    }
}

