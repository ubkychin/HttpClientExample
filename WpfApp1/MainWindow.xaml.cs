using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using WpfApp1.Models;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        HttpClient client = new HttpClient();

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            client.BaseAddress = new Uri("http://jsonplaceholder.typicode.com/");

            HttpResponseMessage httpResponseMessage = await client.GetAsync("posts");
            
            var content = await httpResponseMessage.Content.ReadAsStringAsync();

            var posts = JsonConvert.DeserializeObject<List<Post>>(content);

            Post p = new Post { Username = 1, Id = 90000, Body = "Jar Jar Binks", Title = "The shit Star Wars Movie" };
            Post p2 = new Post { Username = 1, Id = 91000, Body = ": (", Title = "Dragan doesn't know what he's talking about" };

            string json = JsonConvert.SerializeObject(p);


        }


    }
}
