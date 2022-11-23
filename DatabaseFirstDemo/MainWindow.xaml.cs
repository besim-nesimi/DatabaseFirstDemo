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
using DatabaseFirstDemo.Models;

namespace DatabaseFirstDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            using (HarryPotterDbContext context = new()) // Skapar en instans av databasen
            {

                // R:et i CRUD / (READ)
                var houses = context.Houses.ToList(); // Hämtar Houses och lägger dem i en lista av House

                foreach (var house in houses)
                {
                    ListViewItem item = new();
                    item.Content = house.Name;
                    item.Tag = house;
                    lvHouses.Items.Add(item);
                }

            } 
        }

        // C:et i CRUD / (CREATE)
        private void btnHouse_Click(object sender, RoutedEventArgs e)
        {
            string houseName = txtHouse.Text;

            House house = new();
            house.Name = houseName;

            using (HarryPotterDbContext context = new())
            {
                context.Houses.Add(house);
                context.SaveChanges();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            ListViewItem selectedItem = lvHouses.SelectedItem as ListViewItem;
            House selectedHouse = selectedItem.Tag as House;

            using (HarryPotterDbContext context = new())
            {
                // R:et i CRUD (Remove)
                House houseToRemove = context.Houses.Where(h => h.HouseId == selectedHouse.HouseId).FirstOrDefault();

                context.Houses.Remove(houseToRemove);
                context.SaveChanges();
            }
        }
    }
}
