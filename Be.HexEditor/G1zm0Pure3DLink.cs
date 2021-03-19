using Be.HexEditor.Properties;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Be.HexEditor
{
    public class G1zm0Pure3DLink
    {
        
        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        public static void CreateLink(byte[] Data)
        {
            FormHexEditor ApplictionForm;

            if (!Settings.Default.UseSystemLanguage)
            {
                string l = Settings.Default.SelectedLanguage;
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(l);
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(l);
            }



            ApplictionForm = new FormHexEditor();

            string _dumpDirectory = Path.Combine(AssemblyDirectory, "G1zDumps");

            if (!Directory.Exists(_dumpDirectory))
                Directory.CreateDirectory(_dumpDirectory);

            string _filename = Path.Combine(_dumpDirectory, Guid.NewGuid().ToString() +  ".g1z");

         
            File.WriteAllBytes(_filename, Data);

            ApplictionForm.OpenFile(_filename);

            ApplictionForm.Show();
        }


        public static void Clear()
        {
            string _dumpDirectory = Path.Combine(AssemblyDirectory, "G1zDumps");

            string[] filePaths = Directory.GetFiles(_dumpDirectory);

            foreach (string filePath in filePaths)
                File.Delete(filePath);
        }
    }
}
