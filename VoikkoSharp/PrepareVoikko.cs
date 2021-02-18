#region License
/*
VoikkoSharp

A wrapper library for the Voikko (Free linguistic software and data for Finnish).
Copyright © 2021 VPKSoft, Petteri Kautonen

Contact: vpksoft@vpksoft.net

This file is part of VoikkoSharp.

VoikkoSharp is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

VoikkoSharp is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with VoikkoSharp.  If not, see <http://www.gnu.org/licenses/>.
*/
#endregion

using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using libvoikko;

namespace VoikkoSharp
{
    /// <summary>
    /// A static class to prepare the libvoikko library.
    /// </summary>
    public static class PrepareVoikko
    {
        /// <summary>
        /// Prepares the voikko.dll to be used in both 32 and 64 bit applications.
        /// </summary>
        public static void Prepare()
        {
            const string voikkoDllName = "voikko.dll";

            var voikkoDllPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if (voikkoDllPath == null)
            {
                return;
            }

            var architectureFolder = Environment.Is64BitProcess ? "win64" : "win32";

            var result = LoadLibrary(Path.Combine(voikkoDllPath, architectureFolder, voikkoDllName));
        }

        /// <summary>
        /// Prepares the voikko.dll to be used in both 32 and 64 bit applications.
        /// </summary>
        /// <param name="language">The language to use with Voikko (use: fi).</param>
        /// <param name="path">The spelling data path where the Voikko.</param>
        /// <returns>A new <see cref="Voikko"/> class instance prepared with the specified language and the path containing the spelling data.</returns>
        public static Voikko PrepareInstance(string language, string path)
        {
            try
            {
                Prepare();
                return new Voikko(language, path);
            }
            catch
            {
                return null;
            }

        }

        /// <summary>
        /// Prepares the voikko.dll to be used in both 32 and 64 bit applications.
        /// </summary>
        /// <param name="language">The language to use with Voikko (use: fi).</param>
        /// <returns>A new <see cref="Voikko"/> class instance prepared with the specified language. The library location for the spelling data is used.</returns>
        public static Voikko PrepareInstance(string language)
        {
            return PrepareInstance(language, Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }

        /// <summary>
        /// Prepares the voikko.dll to be used in both 32 and 64 bit applications.
        /// </summary>
        /// <returns>A new <see cref="Voikko"/> class instance prepared with Finnish language and the library location for the spelling data is used.</returns>
        public static Voikko PrepareInstance()
        {
            return PrepareInstance("fi", Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }

        /// <summary>
        /// Loads the specified module into the address space of the calling process. The specified module may cause other modules to be loaded.
        /// </summary>
        /// <param name="lpLibFileName">
        /// The name of the module. This can be either a library module (a .dll file) or an executable module (an .exe file).
        /// The name specified is the file name of the module and is not related to the name stored in the library module itself,
        /// as specified by the LIBRARY keyword in the module-definition (.def) file.
        /// </param>
        /// <returns> If the function succeeds, the return value is a handle to the module. If the function fails, the return value is NULL.</returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr LoadLibrary(string lpLibFileName);
    }
}
