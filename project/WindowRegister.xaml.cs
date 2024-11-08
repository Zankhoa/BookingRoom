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
    /// Interaction logic for WindowRegister.xaml
    /// </summary>
    public partial class WindowRegister : Window
    {
        public WindowRegister()
        {
            InitializeComponent();
        }
        Projectprn212Context context = new Projectprn212Context();
        private Account getdataAccount()
        {
            try
            {
                string username = txtUsername.Text;
                string password = txtPassword.Password;
                int roleName = 2;
                string fullName = txtFullName.Text;
                string email = txtEmail.Text;
                string numberPhone = txtphoneNumber.Text;
                DateOnly dob = DateOnly.Parse(dpkDob.Text);

                return new Account
                {
                    Username = username,
                    Password = password,
                    RoleId = roleName,
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Account acc = getdataAccount();

            Account account = context.Accounts.Where(x => x.Username.Equals(acc.Username) && x.Password.Equals(acc.Password)).FirstOrDefault();
            if (account == null)
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
                MessageBox.Show("Register successful");
            }
            else
            {
                MessageBox.Show("Account existed !");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            WindowLogin window = new WindowLogin();
            window.Show();
        }
    }
    }

