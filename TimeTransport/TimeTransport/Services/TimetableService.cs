using System.Data.Common;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using TimeTransport.Models;


namespace TimeTransport.Services;

public class TimetableService
{
    private static Timetable _data;

    public TimetableService(Timetable data)
    {
        _data = data;
    }

    public static async Task<Timetable> LoadAsync()
    {
        var assembly = Assembly.GetExecutingAssembly();
        using var stream = assembly.GetManifestResourceStream(
            "TimeTransport.Data.timetable.json");
        var data = await JsonSerializer.DeserializeAsync<Timetable>(stream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        return data;
    }

    public static async Task CreateAsync()
    {
        var timetable = await LoadAsync();
        _data = timetable;
    }
}
