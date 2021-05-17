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
        
    
        CRUDManager cm = new CRUDManager();

        

        public Home(string cred)
        {
            InitializeComponent();
            this.cred = cred;
         

            BookListView.ItemsSource = cm.RetrieveAllBooks();
            MembersBookList.ItemsSource = cm.GetMemberBooks(cm.GetMemberId(cred));
            

          //  var d = cm.RetrieveAllBooks();

      
        }


        private void BookListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BookListView.SelectedItem != null)
            {
                cm.SetSelectedBook(BookListView.SelectedItem);
                if (cm.SelectedBook != null)
                {
                    var bookId = cm.SelectedBook.BookId;
                    BookDetails windowBook = new BookDetails(cm.SelectedBook,cred);
                    windowBook.Show();
                    this.Close();
                   
                    
                }
            }
        }

        //private void Search_click(object sender, RoutedEventArgs e)
        //{
            
        //    var searchtext = searchField.Text;
        //    var booklist = cm.RetrieveAllBooks();

        //    var list = cm.Search(booklist,searchtext);

        //    BookListView.ItemsSource = list;
        //}

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            List<Object> filteredList = new List<Object>();
            List<CheckBox> checkBoxList = new List<CheckBox> { FantasyCheckBox, MysteryCheckBox, AdventureCheckBox, SciFiCheckBox ,RomanceCheckBox, ThrillerCheckBox, CrimeCheckBox, HorrorCheckBox };
            var list = cm.RetrieveAllBooks();

            foreach (var checkBox in checkBoxList)
            {
                if (checkBox.IsChecked == true)
                {
                    var returnList = cm.FilterGenre(list, checkBox.Content.ToString());

                    foreach (var item in returnList)
                    {
                        filteredList.Add(item);
                    }
                }
            }

            BookListView.ItemsSource = filteredList;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            List<CheckBox> checkBoxList = new List<CheckBox> { FantasyCheckBox, MysteryCheckBox };
            var list = new List<Object>();

            foreach (var checkBox in checkBoxList)
            {
                if (checkBox.IsChecked == false)
                {
                    var returnList = cm.AddGenre(checkBox.Content.ToString());

                    foreach (var book in returnList)
                    {
                        list.Add(book);
                    }
                }
            }

            BookListView.ItemsSource = list;
        }

        private void SignOut_Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }

        private void searchField_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchtext = searchField.Text;
            var booklist = cm.RetrieveAllBooks();

            var list = cm.Search(booklist, searchtext);

            BookListView.ItemsSource = list;
        }
    }

 

 
}
