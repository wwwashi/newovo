using newOvo.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace newOvo.Pages
{
    public partial class Autho : Page
    {
        public Autho()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(tbLogin.Text) && !String.IsNullOrEmpty(tbPassword.Text))
                LoginUser();
            else
                MessageBox.Show("Введите логин и пароль", "Предупреждение");
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Register());
        }
        private void LoginUser()
        {
            Model1 dbContext = new Model1();
            Users user = new Users();

            string Login = tbLogin.Text.Trim();
            string pass = tbPassword.Text.Trim();
            string Password = HashPassword.HashPassword.Hash(pass.Replace("\"", ""));

            user = dbContext.Users.Where(p => p.Login == Login).FirstOrDefault();
            if (user != null)
            {
                if (user?.Password == Password)
                {
                    LoadForm(user.RoleID.ToString(), user);
                    tbLogin.Text = "";
                }
                else
                    MessageBox.Show("Неверный пароль", "Предупреждение");
            }
            else
            {
                MessageBox.Show("Пользователя с логином '" + Login + "' не существует", "Предупреждение");
                return;
            }
        }
        private void LoadForm(string _role, Users user)
        {
            switch (_role)
            {
                //клиент -- посмотреть свои данные и обьекты 
                case "1":
                    //NavigationService.Navigate(new Client());
                    break;
                //админ -- умеет все 
                case "2":
                    NavigationService.Navigate(new Admin());
                    break;
                //Сотрудник отдела вневедомственной охраны -- составляет договоры 
                case "3":
                    //NavigationService.Navigate(new Employee(user));
                    break;
            }
        }

    }
}
