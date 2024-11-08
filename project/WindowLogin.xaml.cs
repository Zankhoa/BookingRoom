
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace project
{
    /// <summary>
    /// Interaction logic for WindowLogin.xaml
    /// </summary>
    public partial class WindowLogin : Window
    {
        public WindowLogin()
        {
            InitializeComponent();
        }

        Projectprn212Context context = new Projectprn212Context();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string userName = txtUserName.Text;
            string passWord = txtPassword.Password;
            Account acc = context.Accounts.Where(x => x.Username.Equals(userName) && x.Password.Equals(passWord)).FirstOrDefault();

            if (acc != null && acc.Password == passWord && acc.RoleId == 1)
            {
                this.Hide();
                WindowManageRoom room = new WindowManageRoom();
                room.Show();
            }
            else if (acc != null && acc.Password == passWord && acc.RoleId == 2)
            {
                this.Hide();
                WindowBooking room = new WindowBooking(userName, passWord);
                room.Show();
            }
            else
            {
                MessageBox.Show("Please enter again username or password!");
            }

        }

        

        private void register_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            WindowRegister res = new WindowRegister();
            res.Show();
        }
    }
}
