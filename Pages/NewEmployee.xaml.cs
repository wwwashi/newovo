using HashPassword;
using iText.Kernel.Pdf;
using iText.Layout;
using newOvo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using iText.Kernel.Exceptions;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using Paragraph = iText.Layout.Element.Paragraph;

namespace newOvo.Pages
{
    public partial class NewEmployee : Page
    {
        Users newuser = new Users();
        public NewEmployee()
        {
            InitializeComponent();
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            newuser.Surname = tbFam.Text;
            newuser.Name = tbName.Text;
            newuser.Midname = tbOtch.Text;
            newuser.Phone = tbPhone.Text;
            int role = 1;
            if (tbRole.SelectedIndex == 0)
                role = 2;
            if (tbRole.SelectedIndex == 1)
                role = 3;
            newuser.RoleID = role;

            int gender = 1;
            if (tbGender.SelectedIndex == 0)
                gender = 1;
            if (tbGender.SelectedIndex == 1)
                gender = 2;
            newuser.GenderID = gender;

            newuser.Login = tbLogin.Text;
            newuser.Password = HashPassword.HashPassword.Hash(tbPass.Text.Replace("\"", ""));
            // Проверка валидации
            var validationResults = newuser.Validate(new ValidationContext(newuser));
            if (validationResults.Any())
            {
                string errorMessage = string.Join("\n", validationResults.Select(r => r.ErrorMessage)); MessageBox.Show("Ошибка при сохранении данных: " + errorMessage);
                return;
            }
            else
            {
                var dbContext = new Model1();
                dbContext.Users.AddOrUpdate(newuser);
                pr14(newuser);
                dbContext.SaveChanges();
                NavigationService.Navigate(new Admin());
            }

        }
        private void pr14(Users employee) // создание трудового договора
        {
            var Detalis = new Dictionary<string, string>
            {
                { "CompanyName", "Otdel vnevedomstvennoj ohrany" },
                { "CompanyAddress", "Dzerzhinskogo, 18" },
                { "CompanyPhone", "+8 (283) 279-08-10" }
            };

            // Poluchaem put' k papke "Zagruzki" dlya tekuschego pol'zovatelya
            string downloadsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Ubedites', chto papka sushchestvuet
            if (!Directory.Exists(downloadsPath))
            {
                Directory.CreateDirectory(downloadsPath);
            }

            // Formiruem polnyy put' k failu
            string outputPath = System.IO.Path.Combine(downloadsPath, $"Trudovoy_dogovor_{employee.Surname}_{employee.Name}_{employee.Midname}.pdf");

            using (FileStream fs = new FileStream(outputPath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                PdfWriter writer = new PdfWriter(fs);
                PdfDocument pdf = new PdfDocument(writer);
                Document document = new Document(pdf);

                document.Add(new Paragraph($"FIO: {employee.Surname} {employee.Name} {employee.Midname}"));
                document.Add(new Paragraph($"Dolzhnost': {employee?.UsersRole?.NameRole}"));
                document.Add(new Paragraph($"Nazvanie kompanii: {Detalis["CompanyName"]}"));
                document.Add(new Paragraph($"Adress kompanii: {Detalis["CompanyAddress"]}"));
                document.Add(new Paragraph($"Telefon kompanii: {Detalis["CompanyPhone"]}"));

                document.Add(new Paragraph($"g. Novosibirsk                                                                                       \"{DateTime.Now.ToString("dd MM yyyy", System.Globalization.CultureInfo.GetCultureInfo("ru-RU"))}\""));
                document.Add(new Paragraph($"{Detalis["CompanyName"]} «{Detalis["CompanyAddress"]}», dalee imenuemoe «Rabotodatel'», v lice direktora Semenova Olega Antonovicha, s odnoj storony, "));
                document.Add(new Paragraph($"i {employee.Surname} {employee.Name} {employee.Midname}, dalee imenuemyj «Rabotnik», s drugoj storony, zaklyuchili nastoyashchij trudovoj dogovor o nizhesleduyushchem."));
                document.Add(new Paragraph(""));

                document.Add(new Paragraph("1. Predmet Trudovogo dogovora"));
                document.Add(new Paragraph($"1.1. Rabotnik prinimayetsya na rabotu v {Detalis["CompanyName"]} na dolzhnost':  {employee.UsersRole.NameRole}")); ;
                document.Add(new Paragraph($"1.2. Mesto raboty: {Detalis["CompanyName"]}"));
                document.Add(new Paragraph("1.3. Nastoyashchiy Trudovoy dogovor yavlyaetsya dogovorom po osnovnoy rabote."));
                document.Add(new Paragraph("1.4. Nastoyashchiy Trudovoy dogovor zaklyuchen na neopredelennyy srok."));
                document.Add(new Paragraph($"1.5. Data nachala raboty \"{DateTime.Now.ToString("dd MM yyyy", System.Globalization.CultureInfo.GetCultureInfo("ru-RU"))}\" года."));
                document.Add(new Paragraph("1.6. Prodolzhitelnost' ispytaniya pri prieme na rabotu 3 mes."));



                document.Close();
            }

            MessageBox.Show($"Трудовой договор для {employee.Surname} {employee.Name} {employee.Midname} успешно сгенерирован.");
        }
    }
}
