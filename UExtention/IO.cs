
using System;
using System.IO;
using Microsoft.VisualBasic.Devices;

namespace UExtensionLibrary.IO
{
    public static class IO
    {

        public static void Copy(this DirectoryInfo diSourceDirectory, string strDestinationPath)
        {
            Computer MyComputer = new Computer();
            MyComputer.FileSystem.CopyDirectory(diSourceDirectory.FullName, strDestinationPath);
        }
        public static void Copy(this DirectoryInfo diSourceDirectory, DirectoryInfo diDestinationPath)
        {
            Computer MyComputer = new Computer();
            MyComputer.FileSystem.CopyDirectory(diSourceDirectory.FullName, diDestinationPath.FullName);
        }
        public static void CopyDirectory(string strSourceDirectory, string strDestinationPath)
        {
            Computer MyComputer = new Computer();
            MyComputer.FileSystem.CopyDirectory(strSourceDirectory, strSourceDirectory);
        }
        public static void CopyDirectory(DirectoryInfo diSourceDirectory, DirectoryInfo diDestinationPath)
        {
            Computer MyComputer = new Computer();
            MyComputer.FileSystem.CopyDirectory(diSourceDirectory.FullName, diDestinationPath.FullName);
        }
        public static void CopyDirectory(DirectoryInfo diSourceDirectory, string strDestinationPath)
        {
            Computer MyComputer = new Computer();
            MyComputer.FileSystem.CopyDirectory(diSourceDirectory.FullName, strDestinationPath);
        }
        public static void CopyDirectory(string strSourceDirectory, DirectoryInfo diDestinationPath)
        {
            Computer MyComputer = new Computer();
            MyComputer.FileSystem.CopyDirectory(strSourceDirectory, diDestinationPath.FullName);
        }
        
    }
}
