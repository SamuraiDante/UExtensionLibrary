
using System;
using System.IO;
using Microsoft.VisualBasic.Devices;

namespace UExtensionLibrary.Extensions
{
    public static class IO
    {
        /// <summary>
        /// Copies the directory to the specified path
        /// </summary>
        /// <param name="diSourceDirectory">Directory to copy</param>
        /// <param name="strDestinationPath">Path to copy to</param>
        public static void Copy(this DirectoryInfo diSourceDirectory, string strDestinationPath)
        {
            Computer MyComputer = new Computer();
            MyComputer.FileSystem.CopyDirectory(diSourceDirectory.FullName, strDestinationPath);
        }
        /// <summary>
        /// Copies the directory to the specified directory
        /// </summary>
        /// <param name="diSourceDirectory">Directory to copy</param>
        /// <param name="diDestinationPath">Destination directory</param>
        public static void Copy(this DirectoryInfo diSourceDirectory, DirectoryInfo diDestinationPath)
        {
            Computer MyComputer = new Computer();
            MyComputer.FileSystem.CopyDirectory(diSourceDirectory.FullName, diDestinationPath.FullName);
        }
        /// <summary>
        /// Copies the directory at <paramref name="strSourceDirectory"/> to the specified destination path
        /// </summary>
        /// <param name="strSourceDirectory">Path to directory to copy</param>
        /// <param name="strDestinationPath">Destination directory</param>
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
