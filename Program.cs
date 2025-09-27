using System;
using System.Collections.Generic;
using System.Linq;

public class Meeting
{
    public int Start { get; set; }
    public int End { get; set; }
}

public class Program
{
    public static bool CanAttendAllMeetings(List<Meeting> meetings)
    {
        if (meetings == null || meetings.Count == 0)
            return true;

        // Sort meetings by start time
        meetings = meetings.OrderBy(m => m.Start).ToList();

        for (int i = 1; i < meetings.Count; i++)
        {
            // If current meeting starts before previous one ends → overlap
            if (meetings[i].Start < meetings[i - 1].End)
                return false;
        }
        return true;
    }

    public static void Main()
    {
        var meetings1 = new List<Meeting> {
            new Meeting { Start = 9, End = 10 },
            new Meeting { Start = 10, End = 11 },
            new Meeting { Start = 11, End = 12 }
        };
        Console.WriteLine(CanAttendAllMeetings(meetings1)); // true

        var meetings2 = new List<Meeting> {
            new Meeting { Start = 9, End = 11 },
            new Meeting { Start = 10, End = 12 }
        };
        Console.WriteLine(CanAttendAllMeetings(meetings2)); // false
    }
}
