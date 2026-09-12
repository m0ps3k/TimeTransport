using CommunityToolkit.Mvvm.ComponentModel;

namespace TimeTransport.ViewModels;

public partial class ViewModelBase : ObservableObject
{
    [ObservableProperty]
    public object contentValue = new MainViewModel();
}
