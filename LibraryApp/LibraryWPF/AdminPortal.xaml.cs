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
using System.Windows.Shapes;

namespace LibraryWPF
{
    /// <summary>
    /// Interaction logic for AdminPortal.xaml
    /// </summary>



    public partial class AdminPortal : Window
    {
        MemberCRUDManager cm = new MemberCRUDManager();
        public AdminPortal()
        {
      
            InitializeComponent();
            AdminListBox.ItemsSource = cm.GetAllLoans();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            var loanDetailId = cm.SelectedLoan.LoanDetailId;
            var memberId = cm.SelectedLoan.Loan.Member.MemberId;
            var bookId = cm.SelectedLoan.BookId;
            switch (ComboBoxBookCount.SelectedItem)
            {
                case "Approve":
                    cm.ApproveLoan(loanDetailId);
                    break;
                case "Deny":
                    cm.DenyLoan(loanDetailId);
                    break;
                default:
                    break;
            }

            
        }

        private void AdminListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AdminListBox.SelectedItem != null)
            {
                cm.SetSelectedLoanDetail(AdminListBox.SelectedItem);
                if (cm.SelectedLoan != null)
                {
                    List<string> RequestDetail = new List<string>();
                    RequestDetail.Add("Deny");
                    RequestDetail.Add("Approve");
                    ComboBoxBookCount.ItemsSource = RequestDetail;

                    MemberNametxt.Text = $"{cm.SelectedLoan.Loan.Member.FirstName} {cm.SelectedLoan.Loan.Member.LastName}";
                    BookNametxt.Text = cm.SelectedLoan.Book.Title;
                    AvailableCounttxt.Text = cm.SelectedLoan.Book.Available.ToString();
                  
                }
            }
        }

        private void ComboBoxBookCount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (ComboBoxBookCount.SelectedItem)
            {
                case "Approve":
                    ComboBoxBookCount.Background = Brushes.LightSeaGreen;
                    break;
                case "Deny":
                    ComboBoxBookCount.Background = Brushes.PaleVioletRed;
                    break;
                default:
                    break;
            }
        }

        private void SignOut_Button_Click(object sender, RoutedEventArgs e)
        {           
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();     
        }
    }
}
