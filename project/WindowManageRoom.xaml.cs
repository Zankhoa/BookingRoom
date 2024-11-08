using Microsoft.EntityFrameworkCore;
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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace project
{
    /// <summary>
    /// Interaction logic for WindowManageRoom.xaml
    /// </summary>
    public partial class WindowManageRoom : Window
    {
        Projectprn212Context context = new Projectprn212Context();
        public WindowManageRoom()
        {
            InitializeComponent();
            loadRoom();
            loadDom();
            loadAccount();
        }

        private void loadRoom()
        {
            var room = context.Rooms.Include(x => x.Dom).Include(x => x.Account).ToList();
            dgvDisplay.ItemsSource = room;
        }

        private void loadDom()
        {
            var dom = context.Doms.Select(x => x.Name.ToString()).ToList();
            cbxDom.ItemsSource = dom;
            cbxDom.SelectedIndex = 0;
        }

        private void loadAccount()
        {
            var st = context.Accounts.Select(x => x.FullName.ToString()).ToList();
            cbxStudent.ItemsSource = st;
            cbxStudent.SelectedIndex = 0;
        }


        private void dgvDisplay_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            Room room = dgvDisplay.SelectedItem as Room;
            if (room != null)
            {

                txtId.Text = room.Roomid.ToString();
                txtRoomName.Text = room.Name.ToString();
                txtCapity.Text = room.Capacity.ToString();
                txtFloorRoom.Text = room.FloorRoom.ToString();
                txtDescription.Text = room.Description.ToString();
                SelectDom(room.Dom);
                SelectStudent(room.Account);

            }
        }

        private void SelectDom(Dom dom)

        {
            foreach (var item in cbxDom.Items)
            {
                if (item is ComboBoxItem comboxitem)
                {

                    if (comboxitem.Content.ToString() == dom.Name)
                    {

                        cbxDom.SelectedItem = comboxitem;
                        break;
                    }
                }
                else if (item is string doomName)
                {
                    if (doomName == dom.Name)
                    {
                        cbxDom.SelectedItem = item;
                        break;
                    }
                }
            }
        }
        private void SelectStudent(Account acc)
        {
            foreach (var item in cbxStudent.Items)
            {
                if (item is ComboBoxItem comboxitem)
                {
                    if (comboxitem.Content.ToString() == acc.FullName)
                    {
                        cbxStudent.SelectedItem = comboxitem;
                        break;
                    }
                }
                else if (item is string StudentName)
                {
                    if (StudentName == acc.FullName)
                    {
                        cbxStudent.SelectedItem = item;
                        break;
                    }
                }
            }
        }


        private Room getDataRoom()
        {
            try
            {
                int roomId = int.Parse(txtId.Text);
                string name = txtRoomName.Text;
                int Capacity = int.Parse(txtCapity.Text);
                int FloorRoom = int.Parse(txtFloorRoom.Text);
                string roomDescript = txtDescription.Text;
                string domName = cbxDom.SelectedItem.ToString();
                string student = cbxStudent.SelectedItem.ToString();

                Dom dom = context.Doms.Where(x => x.Name.Equals(domName)).FirstOrDefault();
                Account acc = context.Accounts.Where(x => x.FullName.Equals(student)).FirstOrDefault();

                return new Room
                {
                    Roomid = roomId,
                    Name = name,
                    Capacity = Capacity,
                    FloorRoom = FloorRoom,
                    Description = roomDescript,
                    DomId = dom.DomId,
                    AccountId = acc.AccountId
                };

            }
            catch
            {
                return null;

            }
        }

        private void BtnInsert_Click(object sender, RoutedEventArgs e)
        {
            Room room = getDataRoom();
            if (room == null)
            {
                System.Windows.MessageBox.Show("Room data is invalid!");
                return;
            }
            if (string.IsNullOrWhiteSpace(room.Name))
            {
                System.Windows.MessageBox.Show("Room name cannot be empty!");
                return;
            }
           
            if (room.Capacity <= 0)
            {
                System.Windows.MessageBox.Show("Capacity must to greater than 0!");
                return;
            }
            if (room.FloorRoom <= 0)
            {
                System.Windows.MessageBox.Show("FloorRoom must to greater than 0!");
                return;
            }
            if (room.Roomid <= 0)
            {
                System.Windows.MessageBox.Show("roomId must to greater than 0!");
                return;
            }
            Room roomInsert = new Room()
            {
               
                Name = room.Name,
                Description = room.Description,
                Capacity = room.Capacity,
                FloorRoom = room.FloorRoom,
                DomId = room.DomId,

            };

            context.Rooms.Add(roomInsert);
            context.SaveChanges();
            loadRoom();


        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Room room = getDataRoom();
            if (room == null)
            {
                System.Windows.MessageBox.Show("Room data is invalid!");
                return;
            }

            Room roomToUpdate = context.Rooms.Find(room.Roomid);
            if (roomToUpdate != null)
            {
                roomToUpdate.Description = room.Description;
                roomToUpdate.Capacity = room.Capacity;
                roomToUpdate.FloorRoom = room.FloorRoom;
                roomToUpdate.DomId = room.DomId;
                roomToUpdate.AccountId = room.AccountId;

                context.Rooms.Update(roomToUpdate);
                context.SaveChanges();
                loadRoom();
            }
        }

        private void btndelete_Click(object sender, RoutedEventArgs e)
        {
            Room room = getDataRoom();
            try
            {
              
                Room roomDelete = context.Rooms.Find(room.Roomid);
                if (roomDelete != null)
                {
                    var result = System.Windows.MessageBox.Show("Are you sure that delete", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        context.Rooms.Remove(roomDelete);
                        context.SaveChanges();
                        loadRoom();
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
            string roonName = txtSearch.Text.ToString();
            var result = context.Rooms.Include(x => x.Dom).Include(x => x.Account).Where(x => x.Name.ToLower().Contains(roonName)).ToList();
            if(result.Count != 0)
            {
                dgvDisplay.ItemsSource = result;
            }   else
            {
                System.Windows.MessageBox.Show("No found room name");
            }

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

