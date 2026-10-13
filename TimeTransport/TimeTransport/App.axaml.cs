using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using System.Linq;
using Avalonia.Markup.Xaml;
using TimeTransport.ViewModels;
using TimeTransport.Views;
using TimeTransport.Services;

namespace TimeTransport;

public partial class App : Application
{
    public TimetableService TimetableService { get; private set; } = null!;
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override async void OnFrameworkInitializationCompleted()
    {
        TimetableService = new TimetableService();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowModel(TimetableService)
            };
        }
        else if (ApplicationLifetime is IActivityApplicationLifetime singleViewFactoryApplicationLifetime)
        {
            singleViewFactoryApplicationLifetime.MainViewFactory = () => new MainView { DataContext = new MainViewModel(TimetableService) };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                DataContext = new MainViewModel(TimetableService)
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}

// подгтовка релизных версий для windows и anroid

// win:
// dotnet publish TimeTransport.Desktop/TimeTransport.Desktop.csproj -c Release -r win-x64 --self-contained true -o artifacts/windows

// anroid: первая - дебаг, вторая - релиз
// dotnet build TimeTransport.Android/TimeTransport.Android.csproj -c Debug -p:AndroidPackageFormats=apk -p:AndroidSdkDirectory=/home/kk/Android/Sdk -p:JavaSdkDirectory=/home/kk/android-studio/jbr -o artifacts/android
// dotnet publish TimeTransport.Android/TimeTransport.Android.csproj -c Release -f net10.0-android -p:AndroidPackageFormats=apk -p:AndroidKeyStore=false -p:AndroidSdkDirectory=/home/kk/Android/Sdk -p:JavaSdkDirectory=/home/kk/android-studio/jbr -o artifacts/android-release
