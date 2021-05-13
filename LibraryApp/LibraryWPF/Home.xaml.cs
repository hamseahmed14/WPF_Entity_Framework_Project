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
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        private string cred;

    
        MemberCRUDManager cm = new MemberCRUDManager();

        

        public Home(string cred)
        {
            InitializeComponent();
            this.cred = cred;
         

            BookListView.ItemsSource = cm.RetrieveAllBooks();
            
            

          //  var d = cm.RetrieveAllBooks();

      
        }


        private void BookListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BookListView.SelectedItem != null)
            {
                cm.SetSelectedBook(BookListView.SelectedItem);
                if (cm.SelectedBook != null)
                {
                    var authorname = cm.SelectedBook.Author.Name;
                    MessageBox.Show(authorname);
                }
            }
        }

        private void Search_click(object sender, RoutedEventArgs e)
        {
            
            var searchtext = searchField.Text;
            var booklist = cm.RetrieveAllBooks();

            var list = cm.Search(booklist,searchtext);

            BookListView.ItemsSource = list;
        }
    }

 

 
}
