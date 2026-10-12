using System;
using System.Collections.Generic;
using Avalonia.Collections;
using CommunityToolkit.Mvvm.DependencyInjection;

namespace TimeTransport.Models;

public class Schedule
{
    public Dictionary<string, List<string>> Weekday { get; set; } = [];
    public Dictionary<string, List<string>> Weekend { get; set; } = [];
}

public class Stop
{
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public Schedule Schedule { get; set; } = new();
}

public class Direction
{
    public List<Stop> Stops { get; set; } = [];
}

public class Route
{
    public string Number { get; set; } = "";
    public Direction Forward { get; set; } = new();
    public Direction Backward { get; set; } = new();
}

public class Timetable
{
    public List<Route> Routes { get; set; } = [];
}

public class DisplayType
{
    public string Number { get; set; } = "";
    public string Destination { get; set; } = "";

}
