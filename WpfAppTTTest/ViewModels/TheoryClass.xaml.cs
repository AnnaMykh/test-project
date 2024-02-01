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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfAppTTTest.Models;

namespace WpfAppTTTest.ViewModels
{
    /// <summary>
    /// Логика взаимодействия для TheoryClass.xaml
    /// </summary>
    public partial class TheoryClass : Page
    {
        private String TopicName;
        public TheoryClass(String TopicName)
        {
            InitializeComponent();

            this.TopicName = TopicName;
            //MessageBox.Show("TheoryClass! this.TopicName", this.TopicName);
            if (Globals.TheoryFail != 0)
            {
                //Отримуєпо поточну папку
                String CurrentDir = Globals.CurrentDirFormater();
                //MessageBox.Show("CurrentDir", CurrentDir);
                //Поточний номер завдання
                String TaskNumber = Globals.TheoryFail.ToString();
                //MessageBox.Show("TaskNumber", TaskNumber);
                //Класс школяра
                String TaskClass = Globals.Classes.ToString();
                //MessageBox.Show("TaskClass", TaskClass);
                TheoryItem.Navigate(CurrentDir + @"\Theory\" + TaskClass + "_" + TaskNumber + ".html");

            }
        }

        private void StartPracticeButton_Click(object sender, RoutedEventArgs e)
        {
            if ((Prim1.IsChecked == true) && (Prim2.IsChecked == true))
            {
                BeginPracticeClass nextPage = new BeginPracticeClass(this.TopicName);
                NavigationService.Navigate(nextPage);
            }
            else
            {
                MessageBox.Show("Для початку тестування ознайомтеся з примітками");
            }
        }
    }
}
