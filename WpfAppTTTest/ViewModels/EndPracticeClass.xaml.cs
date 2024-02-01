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
    /// Логика взаимодействия для EndPracticeClass.xaml
    /// </summary>
    public partial class EndPracticeClass : Page
    {
        private String UserName;
        private int TotalPoints;
        public EndPracticeClass(String UserName, int TotalPoints, int QuestionsCount)
        {
            InitializeComponent();

            Globals.isTestProcessing = false;
            //Вивід на екран
            ResultsLabel.Content = "Ваш результат: " + TotalPoints.ToString() + "/" + QuestionsCount;


            this.TotalPoints = TotalPoints;
            this.UserName = UserName;
        }

        private void DownloadButton_Click(object sender, RoutedEventArgs e)
        {
            String TimeNow = DateTime.Now.ToString("ddMMyyyy HHmmss");
            //List<UserResultsClass> UserResults = SQLiteClass.SQLiteGetUserResults(this.UserName);
            UserResultsClass UserResults = new UserResultsClass(Globals.Classes.ToString(), Globals.TheoryFail.ToString(), TotalPoints.ToString(), UserName, DateTime.Now.ToString(@"dd\/MM\/yyyy HH:mm:ss"));
            PDFCreatorClass PdfObject = new PDFCreatorClass("Export " + TimeNow + ".pdf", this.UserName, UserResults);
        }

        //Запис результату в БД
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //Поточний 
            String TopicNumber = Globals.TheoryFail.ToString();

            //Обраний клас школяра
            String TaskClass = Globals.Classes.ToString();

            //поточний час
            String TimeNow = DateTime.Now.ToString(@"dd\/MM\/yyyy HH:mm:ss");

            //запис в SQLite
            String SQLString = String.Format("INSERT INTO Results(class_id, topic_id, points,username, time) VALUES ({0},{1},{2},'{3}','{4}')", TaskClass, TopicNumber, this.TotalPoints, this.UserName, TimeNow);
            SQLiteClass.SQLiteExecute(SQLString);
        }
    }
}
