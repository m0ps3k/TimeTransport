using System.Net.Http.Headers;
using System.Security.Cryptography;
using CommunityToolkit.Mvvm.ComponentModel;
using TimeTransport.Services;

namespace TimeTransport.ViewModels;

public partial class MainWindowModel : ViewModelBase
{
    [ObservableProperty]
    private ViewModelBase contentValue;

    public TimetableService _timetableService;

    public MainWindowModel(TimetableService timetableService)
    {
        _timetableService = timetableService;
        contentValue = new MainViewModel(_timetableService);
    }
}
