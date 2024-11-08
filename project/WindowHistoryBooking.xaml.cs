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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace project
{
    /// <summary>
    /// Interaction logic for WindowHistoryBooking.xaml
    /// </summary>
    public partial class WindowHistoryBooking : Window
    {
        public string roomName {  get; set; }   
        public int studentId {  get; set; }

       Projectprn212Context context = new Projectprn212Context();
        public WindowHistoryBooking(string Name, int Accid)
        {
            InitializeComponent();
             roomName = Name;
             studentId = Accid;
            loadRoomAssign();
            loadRoom();
            loadAccount();
            loadDom();
            LoadStaus();
        }

        private void loadRoomAssign()
        {
            var room = context.RoomAssignments.Include(x => x.Room).Include(x => x.Dom).Include(x => x.Status).Include(x => x.Account).Where(x => x.Account.AccountId == studentId).ToList();
            dgvDisplay.ItemsSource = room;

        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Account acc = context.Accounts.Where(x => x.AccountId.Equals(studentId)).FirstOrDefault();
            string userName = acc.Username;
            string password = acc.Password;
            this.Hide();
            WindowBooking booking = new WindowBooking(userName, password);
            booking.Show();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            WindowLogin login = new WindowLogin();
            login.Show();
        }
        private void loadRoom()
        {
            var room = context.Rooms.Select(x => x.Name).ToList();
            cbxRoomId.ItemsSource = room;
            cbxRoomId.SelectedIndex = 0;
        }
        private void loadDom()
        {
            var dom = context.Doms.Select(x => x.Name).ToList();
            cbxDom.ItemsSource = dom;
            cbxDom.SelectedIndex = 0;
        }

        private void loadAccount()
        {
            var account = context.Accounts.Select(x => x.FullName).ToList();
            cbxAccountId.ItemsSource = account;
            cbxAccountId.SelectedIndex = 0;
        }

        private void LoadStaus()
        {
            var status = context.Statuses.Select(x => x.Name).ToList();
            cbxStatus.ItemsSource = status;
            cbxStatus.SelectedIndex = 0;
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
           
         

                RoomAssignment roomdelete = context.RoomAssignments.Find(txtAssignmentId.Text);
                if (roomdelete != null)
                {
                    var result = System.Windows.MessageBox.Show("Are you sure that cancel this booking ", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        context.RoomAssignments.Remove(roomdelete);
                        context.SaveChanges();
                        loadRoomAssign();
                    }
                    else
                    {
                    MessageBox.Show("Cannot this cancel");
                    }
                }
            }
          
        
        private void SelectStatus(Status st)

        {
            foreach (var item in cbxStatus.Items)
            {
                if (item is ComboBoxItem comboxitem)
                {

                    if (comboxitem.Content.ToString() == st.Name)
                    {
                        cbxStatus.SelectedItem = comboxitem;
                        break;
                    }
                }
                else if (item is string statusName)
                {
                    if (statusName == st.Name)
                    {
                        cbxStatus.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        private void SelectAccount(Account acc)

        {
            foreach (var item in cbxAccountId.Items)
            {
                if (item is ComboBoxItem comboxitem)
                {

                    if (comboxitem.Content.ToString() == acc.FullName)
                    {

                        cbxAccountId.SelectedItem = comboxitem;
                        break;
                    }
                }
                else if (item is string accName)
                {
                    if (accName == acc.FullName)
                    {
                        cbxAccountId.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        private void SelectRoom(Room room)

        {
            foreach (var item in cbxRoomId.Items)
            {
                if (item is ComboBoxItem comboxitem)
                {

                    if (comboxitem.Content.ToString() == room.Name)
                    {

                        cbxRoomId.SelectedItem = comboxitem;
                        break;
                    }
                }
                else if (item is string RoomName)
                {
                    if (RoomName == room.Name)
                    {
                        cbxRoomId.SelectedItem = item;
                        break;
                    }
                }
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
        private void dgvDisplay_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            RoomAssignment room = dgvDisplay.SelectedItem as RoomAssignment;
            if (room != null)
            {
                txtAssignmentId.Text = room.AssignmentId.ToString();
                SelectDom(room.Dom);
                SelectAccount(room.Account);
                SelectRoom(room.Room);
                dpkstart.Text = room.StartDate.ToString();
                dpkend.Text = room.EndDate.ToString();
                txtNote.Text = room.Note.ToString();
                SelectStatus(room.Status);
            }
        }
    }
}
