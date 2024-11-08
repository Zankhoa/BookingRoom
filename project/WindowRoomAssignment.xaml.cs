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

namespace project
{
    /// <summary>
    /// Interaction logic for WindowRoomAssignment.xaml
    /// </summary>
    public partial class WindowRoomAssignment : Window
    {
        Projectprn212Context context = new Projectprn212Context();
        public WindowRoomAssignment()
        {
            InitializeComponent();
            data();
            loadRoom();
            loadAccount();
            loadDom();
            LoadStaus();
        }
        private void data()
        {
            var ra = context.RoomAssignments.Include(x => x.Account).Include(x => x.Room).Include(x => x.Dom).Include(x => x.Status).ToList();
            dgvDisplay.ItemsSource = ra;
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

        private void search_Click(object sender, RoutedEventArgs e)
        {
            string student = txtStudent.Text;
            var result = context.RoomAssignments.Include(x => x.Account).Include(x => x.Room).Include(x => x.Dom).Where(x => x.Account.FullName.ToLower().Contains(student)).ToList();
            if (result.Count != 0) { 
            dgvDisplay.ItemsSource = result;
            } 
        }

        private RoomAssignment getdataRoomAssign()
        {
            try
            {
                int id = int.Parse(txtAssignmentId.Text);
                string room = cbxRoomId.SelectedItem.ToString();
                string account = cbxAccountId.SelectedItem.ToString();
                string dom = cbxDom.SelectedItem.ToString();
                string status = cbxStatus.SelectedItem.ToString();
                string note = txtNote.Text.ToString();
                DateOnly start = DateOnly.Parse(dpkstart.Text);
                DateOnly end = DateOnly.Parse(dpkend.Text);

                Status st = context.Statuses.Where(x => x.Name.Equals(status)).FirstOrDefault();
                Room roomm = context.Rooms.Where(x => x.Name.Equals(room)).FirstOrDefault();
                Account acc = context.Accounts.Where(x => x.FullName.Equals(account)).FirstOrDefault();
                Dom dom1 = context.Doms.Where(x => x.Name.Equals(dom)).FirstOrDefault();

                return new RoomAssignment
                {
                    AssignmentId = id,
                    RoomId = roomm.Roomid,
                    AccountId = acc.AccountId,
                    DomId = dom1.DomId,
                    StatusId = st.StatusId,
                    Note = note,
                    StartDate = start,
                    EndDate = end,

                };

            }
            catch
            {
                return null;
            }
        }
        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            RoomAssignment room = getdataRoomAssign();
            Room r = context.Rooms.Where(x => x.Roomid.Equals(room.RoomId)).FirstOrDefault();

            RoomAssignment roomtoupdate = context.RoomAssignments.Find(room.AssignmentId);
            if (roomtoupdate != null)
            {
                roomtoupdate.AssignmentId = room.AssignmentId;
                roomtoupdate.RoomId = room.RoomId;
                roomtoupdate.AccountId = room.AccountId;
                roomtoupdate.DomId = room.DomId;
                roomtoupdate.StatusId = room.StatusId;
                roomtoupdate.Note = room.Note;
                roomtoupdate.StartDate = room.StartDate;
                roomtoupdate.EndDate = room.EndDate;
                context.RoomAssignments.Update(roomtoupdate);
            }
                
                Room r1 = new Room
                {
                    Name = r.Name,
                    Capacity = r.Capacity,
                    FloorRoom = r.FloorRoom,
                    Description = r.Description,
                    DomId = r.DomId,
                    AccountId = room.AccountId
                };
                
                context.Rooms.Add(r1);
                context.SaveChanges();
                data();

            
            
        }

        private void btndelete_Click(object sender, RoutedEventArgs e)
        {
            RoomAssignment room = getdataRoomAssign();
            try
            {

                RoomAssignment roomdelete = context.RoomAssignments.Find(room.AssignmentId);
                if (roomdelete != null)
                {
                    var result = System.Windows.MessageBox.Show("Are you sure that delete", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        context.RoomAssignments.Remove(roomdelete);
                        context.SaveChanges();
                        data();
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
