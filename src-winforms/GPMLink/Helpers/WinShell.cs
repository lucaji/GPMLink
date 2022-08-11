/*
 * [File purpose]
 * Author: Phillip Piper
 * Date: 1 May 2007 7:44 PM
 * 
 * CHANGE LOG:
 * 2009-07-08  JPP  Don't cache the image collections
 * 1 May 2007  JPP  Initial Version
 * 
 * April 2016 added sanitize file name and other statics
 * 
 */

/*
 * 
    Licensed under the MIT license:

    http://www.opensource.org/licenses/mit-license.php

    Copyright(c) 2013 - 2021, Luca Cipressi(lucaji.github.io) lucaji()mail.ru


    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in
    all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
    THE SOFTWARE.
*
*/

using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;

#nullable enable

namespace WinShell {

    /// <summary>
    /// FileUtils contains routines to interact with the Windows Shell and File Dialogs, Pathnames...
    /// </summary>
    public static class FileShellUtils {


        public static string? GetTempFileNameWithDotExtension(string extension) {
            try { 
                return Path.ChangeExtension(Path.GetTempPath() + Guid.NewGuid().ToString(), extension);
            } catch (Exception ex) {
                Console.WriteLine(ex);
            }
            return null;
        }


        public static string? SanitizeFileName(string name) {
            try {
                var invalids = System.IO.Path.GetInvalidFileNameChars();
                return string.Join("_", name.Split(invalids, StringSplitOptions.RemoveEmptyEntries)).TrimEnd('.');
            } catch (Exception ex) {
                Console.WriteLine(ex);
            }
            return null;
        }


        /// <summary>
        /// Returns the last path component of a given string
        /// </summary>
        /// <param name="s"></param>
        /// <returns>returns an empty string is the given string is null</returns>
        public static string LastPathComponent(this string s) {
            var n = s!.LastIndexOf(Path.DirectorySeparatorChar);
            if (n < 1) return string.Empty;
            return s.Substring(n + 1);
        }


        public static string? GetFilename(this string s) {
            return Path.GetFileName(s);
        }

        public static string? GetFilenameWithoutExtension(this string s) {
            return Path.GetFileNameWithoutExtension(s);
        }

       

        public static string StartPathComponent(string s) {
            var n = s.LastIndexOf(Path.DirectorySeparatorChar);
            if (n < 0) { return string.Empty; }
            return s.Substring(0, n);
        }

        /// <summary>
        /// Returns the file extension including the dot
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public static string? FileExtension(this string f) {
            try {
                return Path.GetExtension(f);
            } catch (Exception ex) {
                Console.WriteLine(ex);
            }
            return null;
        }

        static public string? LetUserToPickADirectory() {
            try {
                var fbd = new CommonOpenFileDialog {
                    IsFolderPicker = true
                };

                CommonFileDialogResult result = fbd.ShowDialog();
                if (result == CommonFileDialogResult.Ok)
                    return fbd.FileName;
            } catch (Exception ex) {
                Console.WriteLine(ex);
            }
            return null;
        }

        static public string? DisplaySaveDialog(string defaultName, string defaultExtension, List<(string, string)> extensionFilters) {
            if (string.IsNullOrWhiteSpace(defaultExtension)) {
                Console.WriteLine("LJShellUtils: DisplaySaveDialog - null default extension");
                return null;
            }
            try {
                var fsd = new CommonSaveFileDialog {
                    DefaultExtension = defaultExtension,
                    DefaultFileName = defaultName,
                    AlwaysAppendDefaultExtension = true
                };
                foreach (var t in extensionFilters) {
                    var name = t.Item1;
                    var ext = t.Item2;
                    if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(ext)) {
                        Console.WriteLine("LJShellUtils: DisplaySaveDialog - filter tuple error " + name + ext);
                        return null;
                    }
                    var cfdf = new CommonFileDialogFilter(t.Item1, t.Item2);
                    fsd.Filters.Add(cfdf);
                }
                CommonFileDialogResult result = fsd.ShowDialog();
                if (result == CommonFileDialogResult.Ok)
                    return fsd.FileName;
            } catch (Exception ex) {
                Console.WriteLine(ex);
            }
            return null;
        }

        /// <summary>
        /// Execute the given operation on the file or directory identified by the given path.
        /// Example operations are "edit", "print", "explore".
        /// </summary>
        /// <param name="path">The file or directory to be operated on</param>
        /// <param name="operation">What operation should be performed</param>
        /// <returns>Values <= 31 indicate some sort of error. See ShellExecute() documentation for specifics.</returns>
        /// <remarks>The same effect can be achieved by <code>System.Diagnostics.Process.Start(path)</code>.</remarks>
        public static int ExecuteAtPath(string path, string operation = "") {
            IntPtr result = FileShellUtils.ShellExecute(0, operation, path, "", "", SW_SHOWNORMAL);
            return result.ToInt32();
        }

        /// <summary>
        /// Get the string that describes the file's type.
        /// </summary>
        /// <param name="path">The file or directory whose type is to be fetched</param>
        /// <returns>A string describing the type of the file, or an empty string if something goes wrong.</returns>
        public static string? GetFileType(string path) {
            SHFILEINFO shfi = new();
            int flags = SHGFI_TYPENAME;
            IntPtr result = SHGetFileInfo(path, 0, out shfi, Marshal.SizeOf(shfi), flags);
            if (result.ToInt32() == 0) {
                return null;
            } else {
                return shfi.szTypeName;
            }
        }

        /// <summary>
        /// Return the icon for the given file/directory.
        /// </summary>
        /// <param name="path">The full path to the file whose icon is to be returned</param>
        /// <param name="isSmallImage">True if the small (16x16) icon is required, otherwise the 32x32 icon will be returned</param>
        /// <param name="useFileType">If this is true, only the file extension will be considered</param>
        /// <returns>The icon of the given file, or null if something goes wrong</returns>
        public static Icon? GetFileIcon(string path, bool isSmallImage, bool useFileType) {
            int flags = SHGFI_ICON;
            if (isSmallImage)
                flags |= SHGFI_SMALLICON;

            int fileAttributes = 0;
            if (useFileType) {
                flags |= SHGFI_USEFILEATTRIBUTES;
                if (System.IO.Directory.Exists(path))
                    fileAttributes = FILE_ATTRIBUTE_DIRECTORY;
                else
                    fileAttributes = FILE_ATTRIBUTE_NORMAL;
            }

            SHFILEINFO shfi = new();
            IntPtr result = SHGetFileInfo(path, fileAttributes, out shfi, Marshal.SizeOf(shfi), flags);
            if (result.ToInt32() == 0) {
                return null;
            } else {
                return Icon.FromHandle(shfi.hIcon);
            }
        }

        /// <summary>
        /// Return the index into the system image list of the image that represents the given file.
        /// </summary>
        /// <param name="path">The full path to the file or directory whose icon is required</param>
        /// <returns>The index of the icon, or -1 if something goes wrong</returns>
        /// <remarks>This is only useful if you are using the system image lists directly. Since there is
        /// no way to do that in .NET, it isn't a very useful.</remarks>
        public static int GetSysImageIndex(string path) {
            SHFILEINFO shfi = new();
            int flags = SHGFI_ICON | SHGFI_SYSICONINDEX;
            IntPtr result = SHGetFileInfo(path, 0, out shfi, Marshal.SizeOf(shfi), flags);
            if (result.ToInt32() == 0) {
                return -1;
            } else { return shfi.iIcon; }
        }

        #region Native methods

        private const int SHGFI_ICON = 0x00100;             // get icon
        private const int SHGFI_DISPLAYNAME = 0x00200;      // get display name
        private const int SHGFI_TYPENAME = 0x00400;         // get type name
        private const int SHGFI_ATTRIBUTES = 0x00800;       // get attributes
        private const int SHGFI_ICONLOCATION = 0x01000;     // get icon location
        private const int SHGFI_EXETYPE = 0x02000;          // return exe type
        private const int SHGFI_SYSICONINDEX = 0x04000;     // get system icon index
        private const int SHGFI_LINKOVERLAY = 0x08000;      // put a link overlay on icon
        private const int SHGFI_SELECTED = 0x10000;         // show icon in selected state
        private const int SHGFI_ATTR_SPECIFIED = 0x20000;     // get only specified attributes
        private const int SHGFI_LARGEICON = 0x00000;     // get large icon
        private const int SHGFI_SMALLICON = 0x00001;     // get small icon
        private const int SHGFI_OPENICON = 0x00002;     // get open icon
        private const int SHGFI_SHELLICONSIZE = 0x00004;     // get shell size icon
        private const int SHGFI_PIDL = 0x00008;     // pszPath is a pidl
        private const int SHGFI_USEFILEATTRIBUTES = 0x00010;     // use passed dwFileAttribute
        //if (_WIN32_IE >= 0x0500)
        private const int SHGFI_ADDOVERLAYS = 0x00020;     // apply the appropriate overlays
        private const int SHGFI_OVERLAYINDEX = 0x00040;     // Get the index of the overlay

        private const int FILE_ATTRIBUTE_NORMAL = 0x00080;     // Normal file
        private const int FILE_ATTRIBUTE_DIRECTORY = 0x00010;     // Directory

        private const int MAX_PATH = 260;

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        private struct SHFILEINFO {
            public IntPtr hIcon;
            public int iIcon;
            public int dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        }

        private const int SW_SHOWNORMAL = 1;

        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr ShellExecute(int hwnd, string lpOperation, string lpFile,
            string lpParameters, string lpDirectory, int nShowCmd);

        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SHGetFileInfo(string pszPath, int dwFileAttributes,
            out SHFILEINFO psfi, int cbFileInfo, int uFlags);

        #endregion






    }







}
