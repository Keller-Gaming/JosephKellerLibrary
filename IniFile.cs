// IniFile.cs
// compile with: /doc:IniFile.xml
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace JosephKellerLibrary
{
    /// <summary>
    /// Create a New INI file to store or load data
    /// </summary>
    public class IniFile
    {
        /// <summary>
        /// The Path of the INI file.
        /// </summary>
        public string path;
        /// <summary>
        /// The Capacity of the INI file reader.
        /// </summary>
        public int capacity;

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section,
            string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section,
                 string key, string def, StringBuilder retVal,
            int size, string filePath);

        /// <summary>
        /// INIFile Constructor.
        /// </summary>
        /// <PARAM name="INIPath">The path of the INI file.</PARAM>
        public IniFile(string INIPath)
        {
            path = INIPath;
            capacity = 255;
        }
        /// <summary>
        /// INIFile Constructor.
        /// </summary>
        /// <PARAM name="INIPath">The path of the INI file.</PARAM>
        /// <PARAM name="INIcapacity">The maximum number of characters to be read.</PARAM>
        public IniFile(string INIPath, int INIcapacity)
        {
            path = INIPath;
            capacity = INIcapacity;
        }
        /// <summary>
        /// Write Data to the INI File
        /// </summary>
        /// <PARAM name="Section">Section name</PARAM>
        /// <PARAM name="Key">Key Name</PARAM>
        /// <PARAM name="Value">Value to write</PARAM>
        public void IniWriteValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, this.path);
        }

        /// <summary>
        /// Read Data Value From the INI File
        /// </summary>
        /// <PARAM name="Section">Section name</PARAM>
        /// <PARAM name="Key">Key Name</PARAM>
        /// <returns>Returns the read data in string format.</returns>
        public string IniReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(capacity);
            int i = GetPrivateProfileString(Section, Key, "", temp,
                                            capacity, this.path);
            return temp.ToString();

        }
    }
}