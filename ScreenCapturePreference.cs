using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using VMS.TPS.Common.Model.API;
using VMS.TPS.Common.Model.Types;
using System.IO;
using Microsoft.Win32;

// TODO: Replace the following version attributes by creating AssemblyInfo.cs. You can do this in the properties of the Visual Studio project.
[assembly: AssemblyVersion("1.0.0.1")]
[assembly: AssemblyFileVersion("1.0.0.1")]
[assembly: AssemblyInformationalVersion("1.0")]

// TODO: Uncomment the following line if the script requires write access.
// [assembly: ESAPIScript(IsWriteable = true)]

namespace VMS.TPS
{
    public class Script
    {
        public Script()
        {
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void Execute(ScriptContext context/*, Window window /*, ScriptEnvironment environment*/)
        {
            // TODO : Add here the code that is called when the script is launched from Eclipse.
            var mainWindow = new ScreenCapturePreference.MainWindow();

            mainWindow.Title = "ScreenCapture Preference";

            string defaultPath = @"\\172.16.10.181\va_transfer\MLC\--- ESAPI ---\ScreenCapturePreference\";
            string preferenceFilePath = defaultPath + context.CurrentUser.Name + "_ScreenCapturePreference.txt";
            string exportFilePath = @"C:\Users\vms\Desktop";
            bool fullScreenFlag = false;

            mainWindow.preferenceFilePath = preferenceFilePath;
            mainWindow.exportFilePath = exportFilePath;
            mainWindow.fullScreenFlag = fullScreenFlag;

            if (File.Exists(preferenceFilePath))
            {
                StreamReader sr = new StreamReader(preferenceFilePath, Encoding.GetEncoding("Shift_JIS"));
                string[] subString = sr.ReadLine().Split(',');
                sr.Close();

                if (subString.Length == 2)
                {
                    exportFilePath = subString[0];

                    if (subString[1] == "FullScreen")
                    {
                        fullScreenFlag = true;
                    }
                    else
                    {
                        fullScreenFlag = false;
                    }
                    mainWindow.preferenceFilePath = preferenceFilePath;
                    mainWindow.exportFilePath = exportFilePath;
                    mainWindow.fullScreenFlag = fullScreenFlag;
                }
            }
            else
            {
                using (StreamWriter sr = new StreamWriter(preferenceFilePath, false))
                {
                    string captureWindowType;
                    if (fullScreenFlag == true)
                    {
                        captureWindowType = "FullScreen";
                    }
                    else
                    {
                        captureWindowType = "ActiveWindow";
                    }
                    sr.WriteLine(exportFilePath + "," + captureWindowType);
                    sr.Flush();
                }
            }
            mainWindow.pathTextBlock.Text = mainWindow.exportFilePath;
            if (mainWindow.fullScreenFlag == true)
            {
                mainWindow.FullScreenRadioButton.IsChecked = true;
                mainWindow.ActiveWindowRadioButton.IsChecked = false;
            }
            else
            {
                mainWindow.FullScreenRadioButton.IsChecked = false;
                mainWindow.ActiveWindowRadioButton.IsChecked = true;
            }

            mainWindow.ShowDialog();
        }
    }
}
