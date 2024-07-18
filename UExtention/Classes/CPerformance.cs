using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UExtensionLibrary.Extensions;




namespace UExtensionLibrary.Classes.CPerformance
{
    //public static class CPerformance
    //{
    //    public static bool IsEnabled = false;
    //    public static Stopwatch Stopwatch = new Stopwatch();
    //    public static List<Run> Runs = new List<Run>();
    //    public static int OutputSize = 80;
    //    private static int LongestText = 0;
    //    private static Run CurrentRun { get; set; }
    //    public class Marker
    //    {
    //        public TimeSpan TimeSinceLastMarker;
    //        public TimeSpan Elapsed;
    //        public string Text;
    //    } 

    //    public class Run
    //    {
    //        public string Text;
    //        public List<Marker> Markers = new List<Marker>();
    //        public Marker LastMarker = null;
            
    //    }

    //    public static void StartRun(string Text)
    //    {
    //        if (!IsEnabled) return;

    //        if (CurrentRun != null)
    //        {
    //            StopRun();
    //        }
    //        CurrentRun = new Run() { Text = Text };
    //        Stopwatch.Start();
    //    }

    //    public static void StopRun()
    //    {
    //        if (!IsEnabled) return;

    //        Stopwatch.Stop();
    //        Mark("End of Run");
    //        Runs.Add(CurrentRun);
    //        CurrentRun = null;
    //        Stopwatch.Reset();
    //    }




    //    public static void Mark()
    //    {
    //        Mark("");
    //    }

    //    public static void Mark(string Text)
    //    {
    //        if (!IsEnabled) return;

    //        Stopwatch.Stop();
    //        if(Text.Length > LongestText) LongestText = Text.Length;
    //        Marker marker = new Marker()
    //        {
    //            Elapsed = Stopwatch.Elapsed,
    //            Text = Text
    //        };
            
    //        if (CurrentRun.LastMarker != null)
    //        {
    //            marker.TimeSinceLastMarker = Stopwatch.Elapsed - CurrentRun.LastMarker.Elapsed;
    //        }
    //        else
    //        {
    //            marker.TimeSinceLastMarker = Stopwatch.Elapsed;
    //        }
    //        CurrentRun.Markers.Add(marker);
    //        CurrentRun.LastMarker = marker;
    //        Stopwatch.Start();
    //    }

    //    public static void OutputToCCConsole()
    //    {
    //        if (!IsEnabled) return;

    //        foreach (Run run in Runs)
    //        {

    //            CConsole.CConsole.WriteLine(run.Text.PadEquallyWith('_', LongestText + 48));
    //            foreach (Marker marker in run.Markers)
    //            {
    //                if (marker != run.LastMarker)
    //                    CConsole.CConsole.WriteLine(marker.Text.PadRight(LongestText, '_') + "| Total: " + marker.Elapsed + " | Since Last: " + marker.TimeSinceLastMarker.Duration().TotalMilliseconds);
    //                else CConsole.CConsole.WriteLine(marker.Text);
    //            }
    //            CConsole.CConsole.WriteLine("Total Time: " + run.LastMarker.Elapsed);
    //        }
    //    }


    //}
}
