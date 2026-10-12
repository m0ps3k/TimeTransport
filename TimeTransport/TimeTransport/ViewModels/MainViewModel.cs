using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using CommunityToolkit.Mvvm.ComponentModel;
using TimeTransport.Models;

namespace TimeTransport.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    public List<string> stops = new()
        {
            "М. Ломоносовская", "Володарский мост"
        };


    public MainViewModel()
    {

    }
}
