using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UExtensionLibrary.Classes.CConsole
{
    public static class CConsole
    {
        //Get a console for debugging
        // Import the AllocConsole function from kernel32.dll
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool AllocConsole();

        // Import the FreeConsole function from kernel32.dll
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool FreeConsole();

        // Import the GetConsoleWindow function from kernel32.dll
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetConsoleWindow();

        // Import the ShowWindow function from user32.dll
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        // Define the constants for ShowWindow function
        private const int SW_HIDE = 0;

        private const int SW_SHOWNORMAL = 1;
        private const int SW_SHOWMINIMIZED = 2;
        private const int SW_SHOWMAXIMIZED = 3;
        private const int SW_MAXIMIZE = 3;
        private const int SW_SHOWNOACTIVATE = 4;
        private const int SW_RESTORE = 9;
        public static bool ConsoleAllocated = false;
        public static bool IsEnabled = false;

        public enum DebugLevel
        {
            Error,
            Basic,
            Verbose
        }

        public static DebugLevel DebugSeverity = CConsole.DebugLevel.Basic;

        /// <summary>
        ///
        /// </summary>
        /// <param name="Title">Ttitle for the console window</param>
        /// <returns>boolean indicating if console was ceated or not</returns>
        public static bool InitializeConsole(string Title)
        {
            if (ConsoleAllocated)
            {
                FreeConsole();
            }
            // Allocate a new console for the calling process
            if (AllocConsole())
            {
                // Get the console window handle
                IntPtr consoleHandle = GetConsoleWindow();

                // Maximize the console window
                ShowWindow(consoleHandle, SW_MAXIMIZE);

                StreamWriter standardOutput = new StreamWriter(Console.OpenStandardOutput());
                standardOutput.AutoFlush = true;
                Console.Title = Title;
                Console.SetOut(standardOutput);
                Console.SetError(standardOutput);
                //Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
                //Console.SetWindowPosition(0, 0);
                ConsoleAllocated = true;
            }
            else
            {
                return false;
            }
            return true;
        }

        public static void Write(string Text, DebugLevel Severity = DebugLevel.Verbose)
        {
            if (!IsEnabled) return;

            if (Severity <= DebugSeverity)
                Console.Write(Text);
        }

        public static void WriteLine(string Text, DebugLevel Severity = DebugLevel.Verbose)
        {
            Write(Text + Environment.NewLine, Severity);
        }

        public static void Error(string Text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            CConsole.WriteLine(Text);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}