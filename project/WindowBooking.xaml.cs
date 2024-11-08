using Microsoft.EntityFrameworkCore;
using project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
    /// Interaction logic for WindowBooking.xaml
    /// </summary>
    public partial class WindowBooking : Window
    {
        Projectprn212Context context = new Projectprn212Context();

        public string UserName { get; set; }
        public string Password { get; set; }
    
        public WindowBooking(string userName, string password)
        {
            InitializeComponent();
            UserName = userName;
            Password = password;
            loadRoom();
            loadDom();
        }
        private void loadDom()
        {
            var dom = context.Doms.Select(x => x.Name).Distinct().ToList();
            cbxDom.ItemsSource = dom;
            cbxDom.SelectedIndex = 0;
        }
        private void loadRoom()
        {
            var room = context.Rooms.Include(x => x.Dom).GroupBy(g => g.Name).Select(k => k.First()).ToList();
            dgvDisplay.ItemsSource = room;
        }


        private void dgvDisplay_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

            Room room = dgvDisplay.SelectedItem as Room;
            if (room != null)
            {
                txtRoomName.Text = room.Name.ToString();
                txtCapity.Text = room.Capacity.ToString();
                txtFloorRoom.Text = room.FloorRoom.ToString();
                SelectDom(room.Dom);
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

        private Room getDataRoom()
        {
            try
            {
                string name = txtRoomName.Text;
                int Capacity = int.Parse(txtCapity.Text);
                int FloorRoom = int.Parse(txtFloorRoom.Text);
                string domName = cbxDom.SelectedItem.ToString();
              

                Dom dom = context.Doms.Where(x => x.Name.Equals(domName)).FirstOrDefault();
                Account acc = context.Accounts.Where(x => x.Username.Equals(UserName)).FirstOrDefault();

                return new Room
                {
                    Name = name,
                    Capacity = Capacity,
                    FloorRoom = FloorRoom,
                    DomId = dom.DomId,
                    AccountId = acc.AccountId
                };

            }
            catch
            {
                return null;

            }
        }
        private void btnBooking_Click(object sender, RoutedEventArgs e)
        {
            Room room = getDataRoom();

            Room r = context.Rooms.Where(x => x.Name.Equals(room.Name)).FirstOrDefault();
            if (room == null)
            {
                MessageBox.Show("Data not valid");
                return;
            }
            else
            {
                int sumRoom = context.Rooms.Where(x => x.Name.Equals(room.Name)).GroupBy(x => x.Name).Select(g => g.Count()).Sum();

                DateOnly start = DateOnly.Parse(dpkstart.Text);
                DateOnly end = DateOnly.Parse(dpkend.Text);
                int totalDay = end.DayNumber - start.DayNumber;
                if (totalDay >= 120)
                {
                    if (sumRoom <= room.Capacity)
                    {

                        RoomAssignment roomAssignment = new RoomAssignment
                        {
                            AccountId = room.AccountId,
                            RoomId = r.Roomid,
                            DomId = room.DomId,
                            Note = txtNote.Text,
                            StartDate = DateOnly.Parse(dpkstart.Text),
                            EndDate = DateOnly.Parse(dpkend.Text),
                            StatusId = 2
                        };
                        if (roomAssignment.StartDate == roomAssignment.EndDate)
                        {
                            MessageBox.Show("Dont't duplicated");
                        }

                        else
                        {
                            context.RoomAssignments.Add(roomAssignment);
                            context.SaveChanges();
                            MessageBox.Show("Booking room successful!");

                        }
                    }
                    else
                    {
                        MessageBox.Show("The room is full!");
                    }
                }
                else
                {
                    MessageBoxResult messageBoxResult = MessageBox.Show("Please choose day for with 4 month!");
                }
             

                }
            }
        

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            WindowLogin login = new WindowLogin();
            login.Show();
        }
        private void logout_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            WindowLogin login = new WindowLogin();
            login.Show();
        }

        private void history_Click(object sender, RoutedEventArgs e)
        {
            string roomName = txtRoomName.Text;
            Account acc = context.Accounts.Where(x => x.Username.Equals(UserName)).FirstOrDefault();
            int studentId = acc.AccountId;
            this.Hide();
            WindowHistoryBooking history = new WindowHistoryBooking(roomName, studentId);
            history.Show();
        }
    }
}
