using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Serbia_Train
{
    /// <summary>
    /// Interaction logic for HelpViewer.xaml
    /// </summary>
    public partial class HelpViewer : Window
    {
        private JavaScriptControlHelper ch;
        public HelpViewer(string key, MainWindow originator)
        {
            InitializeComponent();
            //Console.WriteLine(Directory.GetCurrentDirectory());
            //string curDir = "C:/Users/vaske/Desktop/help/HELP/HELP";
            string curDir = Directory.GetCurrentDirectory();

            curDir = curDir.Replace('\\', '/');

            string[] lines = Regex.Split(curDir, "/bin");
            curDir = lines[0];
            //Console.WriteLine("k"+key);
            //Console.WriteLine("p" + curDir);
            string path = String.Format("{0}/Help/{1}.html", curDir, key);
            Console.WriteLine(path);
            if (!File.Exists(path))
            {
                key = "error";
            }

            Uri u = new Uri(String.Format("file:///{0}/Help/{1}.html", curDir, key));
            ch = new JavaScriptControlHelper(originator);

            wbHelp.ObjectForScripting = ch;
            //Console.WriteLine("PRE"+u);
            wbHelp.Navigate(u);
            //Console.WriteLine("STIGO");
        }

        private void BrowseBack_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((wbHelp != null) && (wbHelp.CanGoBack));
        }

        private void BrowseBack_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            wbHelp.GoBack();
        }

        private void BrowseForward_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((wbHelp != null) && (wbHelp.CanGoForward));
        }

        private void BrowseForward_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            wbHelp.GoForward();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

        private void wbHelp_Navigating(object sender, System.Windows.Navigation.NavigatingCancelEventArgs e)
        {
        }
    }
}
