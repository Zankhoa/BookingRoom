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
    /// Interaction logic for WindowAccount.xaml
    /// </summary>
    public partial class WindowAccount : Window
    {
        public WindowAccount()
        {
            InitializeComponent();
            loadAccount();
            loadRole();
        }

        Projectprn212Context context = new Projectprn212Context();

        private void loadAccount()
        {
            var acc = context.Accounts.Include(x => x.Role).ToList();
            dgvDisplay.ItemsSource = acc;

        }

        private void loadRole()
        {
            var acc = context.Roles.Select(x => x.RoleName.ToString()).ToList();
            cbxRole.ItemsSource = acc;
            cbxRole.SelectedIndex = 0;
        }

        private void dgvDisplay_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            Account acc = dgvDisplay.SelectedItem as Account;
            if (acc != null)
            {
                txtAccountId.Text = acc.AccountId.ToString();
                txtUserName.Text = acc.Username.ToString();
                txtPassword.Text = acc.Password.ToString();
                SelectRole(acc.Role);
                txtFullname.Text = acc.FullName.ToString();
                dpDob.Text = acc.Dob.ToString();
                txtEmail.Text = acc.Email.ToString();
                txtPhone.Text = acc.PhoneNumber.ToString();

            }
        }

        private void SelectRole(Role role)

        {
            foreach (var item in cbxRole.Items)
            {
                if (item is ComboBoxItem comboxitem)
                {

                    if (comboxitem.Content.ToString() == role.RoleName)
                    {

                        cbxRole.SelectedItem = comboxitem;
                        break;
                    }
                }
                else if (item is string doomName)
                {
                    if (doomName == role.RoleName)
                    {
                        cbxRole.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        private Account getdataAccount()
        {
            try
            {
                int accountId = int.Parse(txtAccountId.Text);
                string username = txtUserName.Text;
                string password = txtPassword.Text;
                string roleName = cbxRole.SelectedItem.ToString();
                string fullName = txtFullname.Text;
                string email = txtEmail.Text;
                string numberPhone = txtPhone.Text;
                DateOnly dob = DateOnly.Parse(dpDob.Text);

                Role role = context.Roles.Where(x => x.RoleName.Equals(roleName)).FirstOrDefault();
                return new Account
                {
                    AccountId = accountId,
                    Username = username,
                    Password = password,
                    RoleId = role.RoleId,
                    FullName = fullName,
                    Dob = dob,
                    Email = email,
                    PhoneNumber = numberPhone
                };

            }
            catch
            {
                return null;
            }
        }

        private void BtnInsert_Click(object sender, RoutedEventArgs e)
        {
            Account acc = getdataAccount();
            if (acc == null)
            {
                MessageBox.Show("Account data is invalid!");
                return;
            }
            if (string.IsNullOrWhiteSpace(acc.Username))
            {
                MessageBox.Show("UserName cannot be empty!");
                return;
            }
            if (string.IsNullOrWhiteSpace(acc.FullName))
            {
                MessageBox.Show("FullName name cannot be empty!");
                return;
            }
            if (string.IsNullOrWhiteSpace(acc.Email))
            {
                MessageBox.Show("Email name cannot be empty!");
                return;
            }
            if (string.IsNullOrWhiteSpace(acc.Password))
            {
                MessageBox.Show("Password name cannot be empty!");
                return;
            }
            Account a = context.Accounts.Find(acc.AccountId);
            if (a == null)
            {
                Account accInsert = new Account
                {
                    
                    Username = acc.Username,
                    Password = acc.Password,
                    RoleId = acc.RoleId,
                    FullName = acc.FullName,
                    Dob = acc.Dob,
                    Email = acc.Email,
                    PhoneNumber = acc.PhoneNumber,
                };
                context.Accounts.Add(accInsert);
                context.SaveChanges();
                loadAccount();
            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Account acc = getdataAccount();
            if (acc == null)
            {
                MessageBox.Show("Account data is invalid!");
                return;
            }
            Account account = context.Accounts.Find(acc.AccountId);
            if (account != null)
            {
                account.AccountId = acc.AccountId;
                account.Username = acc.Username;
                account.Password = acc.Password;
                account.RoleId = acc.RoleId;
                account.FullName = acc.FullName;
                account.PhoneNumber = acc.PhoneNumber;
                account.Dob = acc.Dob;
                account.Email = acc.Email;
                account.PhoneNumber = acc.PhoneNumber;
                account.Dob = acc.Dob;

                context.Accounts.Update(account);
                context.SaveChanges();
                loadAccount();
            }
        }

        private void btndelete_Click(object sender, RoutedEventArgs e)
        {
            Account acc = getdataAccount();
            if (acc == null)
            {
                MessageBox.Show("Account data is invalid!");
                return;
            }
            Account account = context.Accounts.Find(acc.AccountId);
            context.Accounts.Remove(account);
            context.SaveChanges();
            loadAccount();
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            string username = txtSearch.Text.ToString();
            var resultSearch = context.Accounts.Include(x => x.Role).Where(x => x.Username.ToLower().Contains(username)).ToList();
            dgvDisplay.ItemsSource = resultSearch;
            if (resultSearch.Count == 0)

            {
                MessageBox.Show("No students found.");
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
