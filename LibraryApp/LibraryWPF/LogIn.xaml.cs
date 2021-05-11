using LibraryBusiness;
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

namespace LibraryWPF
{
    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Page
    {
        public string Cred { get; set; }

        public LogIn()
        {
            InitializeComponent();
        }

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            var username = UserName.Text.Trim();
            var password = Password.Password.Trim();

            AuthenticationManager auth = new AuthenticationManager();
            var decPassword = Crypto.Encrypt(password);
            var authCred = auth.AuthIsCorrect(username, decPassword);


            if (authCred == "Incorrect Credentials")
            {
                MessageBox.Show(decPassword);
                MessageBox.Show("Incorrect Credentials. Please input valid credentials");
                UserName.Text = "";
                Password.Clear();
            }
            else
            {
                Cred = authCred;

                switch (auth.GetRole(Cred))
                {
                    case 'M':
                        Home windowHome = new Home();
                        Application.Current.MainWindow.Close();
                        windowHome.Show();
                        break;
                    //case 'A':
                    //    Portal windowPortal = new Portal();
                    //    Application.Current.MainWindow.Close();
                    //    windowPortal.Show();
                    //    break;
                  
                }



            }


        }
    }
}
