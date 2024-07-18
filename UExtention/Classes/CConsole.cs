using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UExtensionLibrary.Extensions;

namespace UExtensionLibrary.Classes.CConsole
{
    //public static class CConsole
    //{
    //    //Get a console for debugging
    //    // Import the AllocConsole function from kernel32.dll
    //    [DllImport("kernel32.dll", SetLastError = true)]
    //    private static extern bool AllocConsole();

    //    // Import the FreeConsole function from kernel32.dll
    //    [DllImport("kernel32.dll", SetLastError = true)]
    //    private static extern bool FreeConsole();

    //    // Import the GetConsoleWindow function from kernel32.dll
    //    [DllImport("kernel32.dll", SetLastError = true)]
    //    private static extern IntPtr GetConsoleWindow();

    //    // Import the ShowWindow function from user32.dll
    //    [DllImport("user32.dll", SetLastError = true)]
    //    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    //    // Define the constants for ShowWindow function
    //    private const int SW_HIDE = 0;

    //    private const int SW_SHOWNORMAL = 1;
    //    private const int SW_SHOWMINIMIZED = 2;
    //    private const int SW_SHOWMAXIMIZED = 3;
    //    private const int SW_MAXIMIZE = 3;
    //    private const int SW_SHOWNOACTIVATE = 4;
    //    private const int SW_RESTORE = 9;
    //    public static bool ConsoleAllocated = false;
    //    public static bool IsEnabled = false;
    //    public static int PrintSize = 50;

    //    public enum OutputTypes
    //    {
    //        Error,
    //        Log,
    //        Debug,
    //        Traffic
    //    }

        
    //   private static Dictionary<OutputTypes,bool> DisplaySettings = new Dictionary<OutputTypes, bool>
    //    {
    //        {OutputTypes.Error,true},
    //        {OutputTypes.Log,false},
    //        {OutputTypes.Debug,false},
    //        {OutputTypes.Traffic,false}
    //    };
        

    //    /// <summary>
    //    ///
    //    /// </summary>
    //    /// <param name="Title">Ttitle for the console window</param>
    //    /// <returns>boolean indicating if console was ceated or not</returns>
    //    public static bool InitializeConsole(string Title)
    //    {
    //        if (ConsoleAllocated)
    //        {
    //            FreeConsole();
    //        }
    //        // Allocate a new console for the calling process
    //        if (AllocConsole())
    //        {
    //            // Get the console window handle
    //            IntPtr consoleHandle = GetConsoleWindow();

    //            // Maximize the console window
    //            ShowWindow(consoleHandle, SW_MAXIMIZE);

    //            StreamWriter standardOutput = new StreamWriter(Console.OpenStandardOutput());
    //            standardOutput.AutoFlush = true;
    //            Console.Title = Title;
    //            Console.SetOut(standardOutput);
    //            Console.SetError(standardOutput);
    //            //Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
    //            //Console.SetWindowPosition(0, 0);
    //            ConsoleAllocated = true;
    //        }
    //        else
    //        {
    //            return false;
    //        }
    //        return true;
    //    }

    //    public static void Write(string Text, OutputTypes Severity = OutputTypes.Debug)
    //    {
    //        switch(Severity)
    //        {
    //            case OutputTypes.Error:
    //                Console.ForegroundColor = ConsoleColor.Red;
    //                break;
    //            case OutputTypes.Log:
    //                Console.ForegroundColor = ConsoleColor.Blue;
    //                break;
    //            case OutputTypes.Debug:
    //                Console.ForegroundColor = ConsoleColor.Green;
    //                break;
    //            case OutputTypes.Traffic:
    //                Console.ForegroundColor = ConsoleColor.Yellow;
    //                break;
    //        }
    //        if (!IsEnabled) return;
    //        if(ConsoleAllocated == false) InitializeConsole(Application.ProductName + " " + Application.ProductVersion + " Output");
    //            if(DisplaySettings[Severity] == true)
    //            Console.Write(Text);
    //    }

    //    public static void WriteLine(string Text, OutputTypes Severity = OutputTypes.Log)
    //    {
    //        Write(Text + Environment.NewLine, Severity);
    //    }

    //    public static void Error(string Text)
    //    {
    //        if(IsEnabled == false &&ConsoleAllocated == false)
    //        {
    //            IsEnabled = true;
    //            InitializeConsole("ERROR");
    //            DisplaySettings[OutputTypes.Error] = true;
    //        }
           
    //        CConsole.WriteLine(Text,OutputTypes.Error);
            
    //    }

    //    public static void Error(Exception ex)
    //    {
    //        CConsole.Error("".PadEquallyWith('-', PrintSize) + Environment.NewLine +
    //            ex.Message.PadEquallyWith('-', PrintSize) + Environment.NewLine 
    //            + "StackTrace".PadEquallyWith('-', PrintSize) + Environment.NewLine 
    //            + ex.StackTrace);

    //        if(ex.InnerException != null)
    //        {

    //            CConsole.Error("Inner Exception".PadEquallyWith('-', PrintSize) + Environment.NewLine 
    //                + ex.InnerException.Message.PadEquallyWith('-', PrintSize) + Environment.NewLine
    //          + "StackTrace".PadEquallyWith('-', PrintSize) + Environment.NewLine
    //          + ex.InnerException.StackTrace);
    //        }
    //    }

    //    public static void Log(string Text)
    //    {
           
    //        CConsole.WriteLine(Text,OutputTypes.Log);
    //    }

    //    public static void Debug(string Text)
    //    {
           
    //        CConsole.WriteLine(Text, OutputTypes.Log);
    //    }
    //    public static void SetOutputTypeEnabled(OutputTypes Type,bool Enabled)
    //    {
    //        DisplaySettings[Type] = Enabled;
    //    }

    //    public static void SetOutputTypeEnabled(params OutputTypes[] ParamArray)
    //    {
    //        foreach (OutputTypes Type in ParamArray)
    //        {
    //            DisplaySettings[Type] = true;
    //        }
    //    }

    //    public static void EnableAllOutputTypes()
    //    {
    //        foreach (OutputTypes Type in DisplaySettings.Keys)
    //        {
    //            DisplaySettings[Type] = true;
    //        }
    //    }
    //}
}