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
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        MemberCRUDManager cm = new MemberCRUDManager();
        public Registration()
        {
            InitializeComponent();
        }

        private void SumbitBtn_Click(object sender, RoutedEventArgs e)
        {
            var firstname = FirstNametxt.Text.Trim();
            var lastname = LastNametxt.Text.Trim();
            var email = Emailtxt.Text.Trim();
            var phone = Phonetxt.Text.Trim();
            var housenum = HouseNumbertxt.Text.Trim();
            var street = Streettxt.Text.Trim();
            var city = Citytxt.Text.Trim();
            var postcode = Postalcodetxt.Text.Trim();
            var password = Passwordtxt.Password.Trim();
            var cpassword = ConfirmedPasswordtxt.Password.Trim();
            var username = Usernametxt.Text.Trim();

            if
               (
              String.IsNullOrEmpty(firstname) ||
              String.IsNullOrEmpty(lastname) ||
               String.IsNullOrEmpty(email) ||
              String.IsNullOrEmpty(postcode) ||
               String.IsNullOrEmpty(housenum) ||
               String.IsNullOrEmpty(street) ||
               String.IsNullOrEmpty(city) ||
                String.IsNullOrEmpty(username) ||
             String.IsNullOrEmpty(password) ||
               String.IsNullOrEmpty(cpassword)
               )
            {
                MessageBox.Show("Fill in all fields", "Empty Fields");
            }
            else
            {
                if (password == cpassword)
                {
                    if (cm.IsValidEmailAddress(email)) { 
                    var enc = Crypto.Encrypt(password);
             
                   
                    cm.CreateMember(firstname,lastname,username,email,phone,housenum,street,city,postcode,enc);

                    MessageBox.Show("Account has been created", "Account");
                    }
                    else
                    {
                        MessageBox.Show("Input valid Email", "Invalid Input");
                    }
                }
                else
                {
                    MessageBox.Show("Confirmed password does not match password", "Invalid Input");
                }
            }
          
        }
    }
}
