using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows;

namespace GoogleBooksAPIDataClientMitTemplates
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Volumeinfo> Books { get; set; } = new ObservableCollection<Volumeinfo>();

        public MainWindow()
        {
            InitializeComponent();
            myGrid.ItemsSource = Books;
            lb.ItemsSource = Books;

        }

        private void AddBook(object sender, RoutedEventArgs e)
        {
            Books.Add(new Volumeinfo() { title = "NEU NEU NEU" });
        }

        private void RemoveBook(object sender, RoutedEventArgs e)
        {
            Books.Remove(myGrid.SelectedItem as Volumeinfo);
        }


        private void LoadBooks(object sender, RoutedEventArgs e)
        {
            using (var wc = new WebClient())
            {
                wc.Encoding = Encoding.UTF8;
                string json = wc.DownloadString("https://www.googleapis.com/books/v1/volumes?q=wpf");
                //tb.Text = json;
                BooksResult br = JsonConvert.DeserializeObject<BooksResult>(json);

                //var query = from i in br.items
                //            where i.saleInfo.listPrice.amount < 3000
                //            orderby i.saleInfo
                //            select i.volumeInfo;

                br.items.Where(aaaaaa => aaaaaa.saleInfo?.listPrice?.amount < 3000)
                        .Select(x => x.volumeInfo)
                        .OrderBy(x => x.publishedDate)
                        .ToList()
                        .ForEach(x => Books.Add(x));

                //   foreach (var item in br.items.Where(aaaaaa => aaaaaa.saleInfo?.listPrice?.amount < 3000)
                //          .Select(x => x.volumeInfo)
                //          .OrderBy(x => x.publishedDate))
                //   {
                //       Books.Add(item);
                //   }
            }
        }



    }
}
