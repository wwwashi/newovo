﻿using ClosedXML.Excel;
using iText.Kernel.Pdf;
using iText.Layout;
using Microsoft.Win32;
using newOvo.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        public Model1 context = new Model1();
        public Admin()
        {
            InitializeComponent();
            var ppl = context.Users.ToList();
            LViewPpl.ItemsSource = ppl;
        }

        private void AddEmployer_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NewEmployee());
        }
        private void Selector_OnSelectionChanged(object sender, RoutedEventArgs e)
        {
            var selectedUser = (Users)LViewPpl.SelectedItem;

            // Check if a user is selected:
            if (selectedUser != null)
            {
                // Navigate to the Redact page with the selected user:
                //NavigationService.Navigate(new Redact(selectedUser));
            }
            else
            {
                // Handle the case where no user is selected:
                MessageBox.Show("Please select a user to edit.");
            }
        }
        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = txtSearch.Text;

            if (searchText.Length == 0)
            {
                var ppl = context.Users.ToList();
                LViewPpl.ItemsSource = ppl;
            }
            else
            {
                if (cmbSorting.SelectedIndex == 0)//по возр
                {
                    switch (cmbFilter.SelectedIndex)
                    {
                        // Должность
                        case 0:
                            var filteredAndSortedPpl = context.Users.Where(u => u.UsersRole.NameRole.Contains(searchText))
                                                      .OrderBy(u => u.UsersRole.NameRole)
                                                      .ToList();
                            LViewPpl.ItemsSource = filteredAndSortedPpl;
                            break;

                        // Фамилия
                        case 1:
                            var filteredAndSortedPpl1 = context.Users.Where(u => u.Surname.Contains(searchText))
                                                      .OrderBy(u => u.Surname)
                                                      .ToList();
                            LViewPpl.ItemsSource = filteredAndSortedPpl1;
                            break;
                        // Имя
                        case 2:
                            var filteredAndSortedPpl2 = context.Users.Where(u => u.Name.Contains(searchText))
                                                      .OrderBy(u => u.Name)
                                                      .ToList();
                            LViewPpl.ItemsSource = filteredAndSortedPpl2;
                            break;
                        // Отчество
                        case 3:
                            var filteredAndSortedPpl3 = context.Users.Where(u => u.Midname.Contains(searchText))
                                                      .OrderBy(u => u.Midname)
                                                      .ToList();
                            LViewPpl.ItemsSource = filteredAndSortedPpl3;
                            break;
                    }
                }
                if (cmbSorting.SelectedIndex == 1)//по убыв
                {
                    switch (cmbFilter.SelectedIndex)
                    {
                        // Должность
                        case 0:
                            var filteredAndSortedPpl = context.Users.Where(u => u.UsersRole.NameRole.Contains(searchText))
                                                      .OrderByDescending(u => u.UsersRole.NameRole)
                                                      .ToList();
                            LViewPpl.ItemsSource = filteredAndSortedPpl;
                            break;

                        // Фамилия
                        case 1:
                            var filteredAndSortedPpl1 = context.Users.Where(u => u.Surname.Contains(searchText))
                                                      .OrderByDescending(u => u.Surname)
                                                      .ToList();
                            LViewPpl.ItemsSource = filteredAndSortedPpl1;
                            break;
                        // Имя
                        case 2:
                            var filteredAndSortedPpl2 = context.Users.Where(u => u.Name.Contains(searchText))
                                .OrderByDescending(u => u.Name)
                                .ToList();
                            LViewPpl.ItemsSource = filteredAndSortedPpl2;
                            break;
                        // Отчество
                        case 3:
                            var filteredAndSortedPpl3 = context.Users.Where(u => u.Midname.Contains(searchText))
                                                      .OrderByDescending(u => u.Midname)
                                                      .ToList();
                            LViewPpl.ItemsSource = filteredAndSortedPpl3;
                            break;
                    }

                }
            }
        }

        private void btnSaveToExcel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Создаем диалоговое окно для сохранения файла
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel Workbook|*.xlsx",
                    Title = "Save an Excel File"
                };

                // Проверяем, нажата ли кнопка "Сохранить" в диалоговом окне
                if (saveFileDialog.ShowDialog() == true)
                {
                    // Получаем список пользователей из базы данных
                    var users = context.Users.ToList();

                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Users");

                        // Добавляем заголовки
                        worksheet.Cell(1, 1).Value = "Name";
                        worksheet.Cell(1, 2).Value = "Surname";
                        worksheet.Cell(1, 3).Value = "Midname";
                        worksheet.Cell(1, 4).Value = "Role";

                        // Добавляем пользователей в таблицу
                        int row = 2;
                        foreach (var user in users)
                        {
                            worksheet.Cell(row, 1).Value = user.Name;
                            worksheet.Cell(row, 2).Value = user.Surname;
                            worksheet.Cell(row, 3).Value = user.Midname;
                            worksheet.Cell(row, 4).Value = user.UsersRole.NameRole;

                            row++;
                        }

                        // Сохраняем файл
                        workbook.SaveAs(saveFileDialog.FileName);
                    }

                    MessageBox.Show("Excel file saved successfully!");
                }
            }
            catch (Exception ex)
            {
                string message = $"An unexpected error occurred: {ex.Message}\n\n";
                message += $"Stack trace:\n{ex.StackTrace}";
                MessageBox.Show(message);
            }
        }
    }
}
