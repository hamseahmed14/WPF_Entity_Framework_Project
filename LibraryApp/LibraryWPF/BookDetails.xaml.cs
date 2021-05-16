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
    /// Interaction logic for BookDetails.xaml
    /// </summary>
    public partial class BookDetails : Window
    {
        private MemberCRUDManager cm = new MemberCRUDManager();
        private Object bookobject;
        private string cred;
        private int _bookId;

        public BookDetails(Object book, string cred)

        {
            InitializeComponent();
            this.bookobject = book;
            this.cred = cred;
            PopulateFields();
            PendingState();
        }



        private void PopulateFields()
        {
            //  var book = cm.GetBookDetails(bookId);
            var book = cm.TransferObject(bookobject);
            var uri = new Uri(book.ImageSrc,UriKind.Relative);
           ImageContent.Source = new BitmapImage(uri);
            Descriptiontxt.Text = book.Description;
            Authortxt.Text = book.Author.Name;
            Genretxt.Text = book.Genre;
            Titletxt.Text = book.Title;
            _bookId = book.BookId;
        }

        private void RequestButton_Click(object sender, RoutedEventArgs e)
        {
            int memberid = cm.GetMemberId(cred);

            switch (RequestButton.Content)
            {
                case "Pending":
                    RequestButton.Content = "Request";
                    cm.RemoveLoan(memberid,_bookId);
                    MessageBox.Show(memberid+ " " + _bookId);
                    break;
                case "Approved":
                    RequestButton.Content = "Approved";
                    RequestButton.Background = Brushes.DarkGreen;
                    RequestButton.IsEnabled = false;
                    break;
                case "Request":
                    cm.CreateLoanRequest(memberid, _bookId);
                    RequestButton.Content = "Pending";
                    break;
                default:
                    break;
            }
           
        }

        private void PendingState()
        {
            int memberid = cm.GetMemberId(cred);
            var requestState = cm.RequestedState(memberid, _bookId);

            switch (requestState)
            {
                case "Pending":
                    RequestButton.Content = "Pending";
                    RequestButton.Background = Brushes.Orange;
                    break;
                case "Approved":
                    RequestButton.Content = "Approved";
                    RequestButton.Background = Brushes.DarkGreen;
                    break;
                default:
                    break;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Home windowHome = new Home(cred);
            windowHome.Show();
        }
    }   
}
