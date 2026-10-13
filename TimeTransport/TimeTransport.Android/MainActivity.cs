using Android.App;
using Android.Content.PM;
using Avalonia;
using Avalonia.Android;

namespace TimeTransport.Android;

[Activity(
    Label = "@string/app_name",
    Theme = "@style/MyTheme.NoActionBar",
    Icon = "@mipmap/ic_launcher",
    MainLauncher = true,
    ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize | ConfigChanges.UiMode)]
public class MainActivity : AvaloniaMainActivity
{
}
