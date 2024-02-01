using System.Text;
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

namespace WpfAppTTTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnPage1_Click(object sender, RoutedEventArgs e) // Перехід на перший лист авторизації
        {
            //Якщо зараз не виконується тест
            if (Globals.isTestProcessing == false)
            {
                Globals.TheoryFail = 0;
                Globals.Classes = 2;
                mainframe.Navigate(new TopicsClass());
                BtnPage1.Background = new SolidColorBrush(Colors.Green);
                BtnPage2.Background = new SolidColorBrush(Colors.White);
                BtnPage3.Background = new SolidColorBrush(Colors.White);
            }
            
            else
            {              
                if (MessageBox.Show("Ви дійсно хочете завершити проходження поточного тесту?", "Питання", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    //Виставляємо завершення тесту
                    Globals.isTestProcessing = false;
                    Globals.TheoryFail = 0;
                    Globals.Classes = 2;
                    mainframe.Navigate(new TopicsClass());
                    BtnPage1.Background = new SolidColorBrush(Colors.Green);
                    BtnPage2.Background = new SolidColorBrush(Colors.White);
                    BtnPage3.Background = new SolidColorBrush(Colors.White);
                }

            }
        }

        private void BtnPage2_Click(object sender, RoutedEventArgs e)
        {
            
            if (Globals.isTestProcessing == false)
            {
                Globals.TheoryFail = 0;
                Globals.Classes = 3;
                mainframe.Navigate(new TopicsClass());
                BtnPage1.Background = new SolidColorBrush(Colors.White);
                BtnPage2.Background = new SolidColorBrush(Colors.Green);
                BtnPage3.Background = new SolidColorBrush(Colors.White);
            }

            else
            {

                if (MessageBox.Show("Ви дійсно хочете завершити проходження поточного тесту?", "Питання", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    //Выставляем заавершение теста
                    Globals.isTestProcessing = false;
                    Globals.TheoryFail = 0;
                    Globals.Classes = 3;
                    mainframe.Navigate(new TopicsClass());
                    BtnPage1.Background = new SolidColorBrush(Colors.White);
                    BtnPage2.Background = new SolidColorBrush(Colors.Green);
                    BtnPage3.Background = new SolidColorBrush(Colors.White);
                }

            }

        }

        private void BtnPage3_Click(object sender, RoutedEventArgs e)
        {
  
            if (Globals.isTestProcessing == false)
            {
                Globals.TheoryFail = 0;
                Globals.Classes = 4;
                mainframe.Navigate(new TopicsClass());
                BtnPage1.Background = new SolidColorBrush(Colors.White);
                BtnPage2.Background = new SolidColorBrush(Colors.White);
                BtnPage3.Background = new SolidColorBrush(Colors.Green);
            }
            else
            {

                if (MessageBox.Show("Ви дійсно хочете завершити проходження поточного тесту?", "Питання", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    //Выставляем заавершение теста
                    Globals.isTestProcessing = false;
                    Globals.TheoryFail = 0;
                    Globals.Classes = 4;
                    mainframe.Navigate(new TopicsClass());
                    BtnPage1.Background = new SolidColorBrush(Colors.White);
                    BtnPage2.Background = new SolidColorBrush(Colors.White);
                    BtnPage3.Background = new SolidColorBrush(Colors.Green);
                }
            }
        }

        private void BtnPage4_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Ви дійсно хочете завершити проходження поточного тесту?", "Питання", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Environment.Exit(0);
            }
        }
    }
}