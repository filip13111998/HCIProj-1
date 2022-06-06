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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Serbia_Train.models;

namespace Serbia_Train.pages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {

        MainWindow Mw { get; set; }


        public LoginPage(MainWindow mw)
        {
            InitializeComponent();

            Username_Filed.GotFocus += RemoveTextUsername;
            Username_Filed.LostFocus += AddTextUsername;

            Password_Filed.GotFocus += RemoveTextPassword;
            Password_Filed.LostFocus += AddTextPassword;

            this.Mw = mw;

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {   

            List<Manager> mns = Manager.managerList.Where(m => m.UserName.Equals(this.Username_Filed.Text) && m.Password.Equals(this.Password_Filed.Password)).ToList();
            
            if (mns.Count != 0)
            {
                Manager.CurrentManager = mns[0];
            }
            else
            {
                return;
            }

            
            this.Mw.Set_Home_Page();
        }


        #region username password field add-delete text placeholder
        public void RemoveTextUsername(object sender, EventArgs e)
        {
            if (Username_Filed.Text == "Enter Username")
            {
                Username_Filed.Text = "";
            }
        }

        public void AddTextUsername(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Username_Filed.Text))
                Username_Filed.Text = "Enter Username";
        }

        public void RemoveTextPassword(object sender, EventArgs e)
        {
            if (Password_Filed.Password == "Enter Password")
            {
                Password_Filed.Password = "";
            }
        }

        public void AddTextPassword(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Password_Filed.Password))
                Password_Filed.Password = "Enter Password";
        }
        #endregion

        
    }
}
