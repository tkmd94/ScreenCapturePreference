using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.IO;

namespace ScreenCapturePreference
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public string exportFilePath;
        public string preferenceFilePath;
        public bool fullScreenFlag;

        public MainWindow()
        {
            InitializeComponent();


        }
        /// <summary>
        /// Set output filename and folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetFolderButton_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = exportFilePath;
            fbd.ShowNewFolderButton = true;
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                exportFilePath = fbd.SelectedPath;
                pathTextBlock.Text = exportFilePath;
            }
        }

        /// <summary>
        /// Open output folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openFolderButton_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(exportFilePath);
        }
        /// <summary>
        /// Save Preference
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SavePreferenceButton_Click(object sender, RoutedEventArgs e)
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

                System.Windows.MessageBox.Show("Saved.");
            }
        }

        private void FullScreenRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            fullScreenFlag = true;
        }
        private void ActiveWindowRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            fullScreenFlag = false;
        }


    }
}
