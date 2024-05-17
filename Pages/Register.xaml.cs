using HashPassword;
using newOvo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Migrations;
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
    /// <summary>
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    public partial class Register : Page
    {
        public Register()
        {
            InitializeComponent();
        }

        Model1 dbContext = new Model1();
        Users newuser = new Users();

        private void btnSign_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(tbxLogin.Text) && !String.IsNullOrEmpty(tbxPassword.Text))
                LoginUser();
            else
                MessageBox.Show("Введите логин и пароль", "Предупреждение");
            
        }
        private void SaveUser(string login, string password, string name, string surname, string phone, string midname, int? gender)
        {
            newuser.Login = login;
            newuser.Password = password;
            newuser.Name = name;
            newuser.Surname = surname;
            newuser.Midname = midname;
            newuser.Phone = phone;
            newuser.GenderID = gender;
            newuser.RoleID = 1;

            dbContext.Users.Add(newuser);
            dbContext.SaveChanges();
            MessageBox.Show("Пользователь успешно зарегистрирован");
            NavigationService.Navigate(new Autho());
        }

        private void LoginUser()
        {
            string login = tbxLogin.Text;
            string password = HashPassword.HashPassword.Hash(tbxPassword.Text.Replace("\"", ""));
            string name = tbxName.Text;
            string surname = tbxSurname.Text;
            string phone = tbxPhone.Text;
            string midname = tbxMidname.Text;
            int? gender;
            if (cbGender.SelectedIndex == 0)
                gender = 1;
            if (cbGender.SelectedIndex == 1)
                gender = 2;
            else
                gender = null;

            if (!CheckUserLoginExists(login))
                SaveUser(login, password, name, surname, phone, midname, gender);
            else
                MessageBox.Show("Пользователь с таким логином уже существует");
        }
        private bool CheckUserLoginExists(string login)//проверка не существует ли пользователя с таким же логином
        {
            using (var dbContext = new Model1())
            {
                return dbContext.Users.Where(p => p.Login == login).Any();
            }
        }
    }
}
