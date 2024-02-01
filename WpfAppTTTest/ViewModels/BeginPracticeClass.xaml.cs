using System;
using System.Collections.Generic;
using System.Formats.Asn1;
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
using WpfAppTTTest.ViewModels;


namespace WpfAppTTTest.ViewModels
{
    /// <summary>
    /// Логика взаимодействия для BeginPracticeClass.xaml
    /// </summary>
    public partial class BeginPracticeClass : Page
    {
        private List<TaskClass> TaskList;
        public BeginPracticeClass(String TopicName)
        {
            InitializeComponent();
            //Назва теми
            TopicLabel.Content = "Тестування з теми:\n" + TopicName;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            //Поточний номер теми
            int TopicNumber = Globals.TheoryFail;
            //Клас школяра
            int ClassNumber = Globals.Classes;
            //Отримуємо дані з БД
            TaskList = SQLiteClass.SQLiteGetTasks(TopicNumber, ClassNumber);
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            //Якщо ввели ім'я і фільтри ок
            if ((NameInputTextBox.Text != "") && (Regex.IsMatch(NameInputTextBox.Text, @"\p{IsCyrillic}")) && (!Regex.IsMatch(NameInputTextBox.Text, @"[\d-]")))
            {
                //Ставимо прапорець, що почали тестування
                Globals.isTestProcessing = true;
                String UserName = NameInputTextBox.Text;
                //Перемішування питань
                TaskList = TaskList.OrderBy(a => Guid.NewGuid()).ToList();
                PracticeClass newPractice = new PracticeClass(UserName, TaskList, 0, 5);
                NavigationService.Navigate(newPractice);
            }
            else
            {
                MessageBox.Show("Для продовження роботи введіть ПІБ українською");
            }
        }
    }
}
