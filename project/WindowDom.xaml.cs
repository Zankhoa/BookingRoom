
using project.Models;
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

namespace project
{
    /// <summary>
    /// Interaction logic for WindowDom.xaml
    /// </summary>
    public partial class WindowDom : Window
    {
        Projectprn212Context context = new Projectprn212Context();
        public WindowDom()
        {
            InitializeComponent();
            loadData();
        }

        private void loadData()
        {
            var data = context.Doms.ToList();
            dgvDisplay.ItemsSource = data;
        }

        private void dgvDisplay_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

        }

        private void BtnInsert_Click(object sender, RoutedEventArgs e)
        {
            Dom dom = new Dom()
            {
                
                Name = txtDomName.Text,
                TotalRooms = int.Parse(txtTotalRooms.Text),
                ManageDom = txtManageDom.Text
            };

            context.Doms.Add(dom);
            context.SaveChanges();
            loadData();

        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Dom dom = context.Doms.Find(int.Parse(txtDomId.Text));
            if (dom != null)
            {
                dom.DomId = int.Parse(txtDomId.Text);
                dom.Name = txtDomName.Text;
                dom.TotalRooms = int.Parse(txtTotalRooms.Text);
                dom.ManageDom = txtManageDom.Text;
                context.Doms.Update(dom);
                context.SaveChanges();
                loadData();
            }
        }



        private void btndelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = int.Parse(txtDomId.Text);
                Dom dom = context.Doms.Find(id);
                if (dom != null)
                {
                    var result = System.Windows.MessageBox.Show("Are you sure that delete", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        context.Doms.Remove(dom);
                        context.SaveChanges();
                        loadData();
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show("Id is invalide");
            }
        }


        private void search_Click(object sender, RoutedEventArgs e)
        {
            string result = txtName.Text.ToString();
            var dom = context.Doms.Where(x => x.ManageDom.ToLower().Contains(result)).ToList();
            dgvDisplay.ItemsSource = dom;

        }

        private void ManageRoom_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            WindowManageRoom room = new WindowManageRoom();
            room.Show();

        }

        private void ManageAccount_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            WindowAccount account = new WindowAccount();
            account.Show();
        }

        private void ManageDom_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            WindowDom dom = new WindowDom();
            dom.Show();
        }

        private void ManageRoomAssignment_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            WindowRoomAssignment roomAssignment = new WindowRoomAssignment();
            roomAssignment.Show();
        }
        private void logout_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            WindowLogin login = new WindowLogin();
            login.Show();
        }
    }
}
