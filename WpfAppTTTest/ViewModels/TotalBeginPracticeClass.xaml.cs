using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using WpfAppTTTest.Models;

namespace WpfAppTTTest.ViewModels
{
    /// <summary>
    /// Логика взаимодействия для TotalBeginPracticeClass.xaml
    /// </summary>
    public partial class TotalBeginPracticeClass : Page
    {
        private List<TaskClass> TaskList;
        public TotalBeginPracticeClass()
        {
            InitializeComponent();
            //Назва теми
            TopicLabel.Content = "Підсумковий тест по класу " + Globals.Classes.ToString();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            //Клас школяра
            int ClassNumber = Globals.Classes;

            //Отримуємо дані з SQLite
            TaskList = SQLiteClass.SQLiteGetTotalTasks(ClassNumber);
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {

            //Якщо ввели ПІБ та фільтри ок
            if ((NameInputTextBox.Text != "") && (Regex.IsMatch(NameInputTextBox.Text, @"\p{IsCyrillic}")) && (!Regex.IsMatch(NameInputTextBox.Text, @"[\d-]")))
            {
                //Галочка, що проходимо тест
                Globals.isTestProcessing = true;
                String UserName = NameInputTextBox.Text;
                //Перемішування питань
                TaskList = TaskList.OrderBy(a => Guid.NewGuid()).ToList();
                PracticeClass newPractice = new PracticeClass(UserName, TaskList, 0, 20);
                NavigationService.Navigate(newPractice);
            }
            else
            {
                MessageBox.Show("Для продовження роботи введіть ПІБ українською");
            }

        }

    }
}
