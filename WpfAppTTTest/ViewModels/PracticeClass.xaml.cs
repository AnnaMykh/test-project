using System;
using System.Collections.Generic;
using System.Formats.Asn1;
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
using System.Windows.Threading;
using WpfAppTTTest.Models;
using WpfAppTTTest.ViewModels;

namespace WpfAppTTTest.ViewModels
{
    /// <summary>
    /// Логика взаимодействия для PracticeClass.xaml
    /// </summary>
    public partial class PracticeClass : Page
    {

        private string TaskKey;
        private List<TaskClass> TaskList;
        private TaskClass CurrentTask;
        private int GoodAnswersCount;
        private String UserName;
        private int QuestionsCount;

        private DispatcherTimer timer;
        private int secondsRemaining;

        public PracticeClass(String UserName, List<TaskClass> TaskList, int GoodAnswersCount, int QuestionsCount)
        {
            InitializeComponent();
            //Поточне завдання
            this.CurrentTask = TaskList[0];
            //MessageBox.Show("CurrentTask", CurrentTask.ToString());
            //Видаляємо завдання зі списку, яке відображається
            TaskList.RemoveAt(0);
            //Виставляємо інші поля
            this.TaskList = TaskList;
            this.GoodAnswersCount = GoodAnswersCount;
            this.UserName = UserName;
            this.QuestionsCount = QuestionsCount;
            //Викликаємо метод форматування інтерфейсу
            this.PageFormater();

            // Initialize timer
            secondsRemaining = 10;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            secondsRemaining--;

            if (secondsRemaining <= 0)
            {
                // Time's up, simulate a click on the "Далее" button
                //NextButton_Click(null, null);
            }
            else
            {
                // Update the CountdownLabel
                //CountdownLabel.Content = "Час на відповідь:" + secondsRemaining.ToString();
            }
        }


        private void MoveToNextQuestion()
        {
            timer.Stop();

            // Reset timer for the next question
            secondsRemaining = 10;
            //CountdownLabel.Content = "Час на відповідь:" + secondsRemaining.ToString();
            timer.Start();
        }

        //Метод для візуального оформлення елементів в залежності від поточного завдання
        private void PageFormater()
        {
            //Прогрес
            PointsLabel.Content = "Кількість набраних балів: " + this.GoodAnswersCount + "/" + this.QuestionsCount;

            //Поточний номер теми
            int TopicNumber = Globals.TheoryFail;
            //Клас школяра
            int ClassNumber = Globals.Classes;

            TaskClass CurrentTask = this.CurrentTask;
            string CurrentDir = Globals.CurrentDirFormater();

            //Текст завдання
            TaskLabel.Content = CurrentTask.Text;

            //Виставляємо правльну відповідь
            this.TaskKey = CurrentTask.Option4;
 
            //Якшо тип завдання без вибору відповідей, то деактивуємо радіобаттонс
            if (CurrentTask.TypeId == 2)
            {
                TaskRadioButton1.Visibility = Visibility.Hidden;
                TaskRadioButton2.Visibility = Visibility.Hidden;
                TaskRadioButton3.Visibility = Visibility.Hidden;
                TaskRadioButton4.Visibility = Visibility.Hidden;
                TaskInputTextBox.Visibility = Visibility.Visible;
            }

            //В іншому випадку це тип з вибором RadioButtons
            else
            {
                //Перемішуємо відповіді
                String[] OfferArray = { CurrentTask.Option1, CurrentTask.Option2, CurrentTask.Option3, CurrentTask.Option4 };
                Random r = new Random();
                OfferArray = OfferArray.OrderBy(x => r.Next()).ToArray();

                //Перемішування вірної відповіді
                TaskRadioButton1.Visibility = Visibility.Visible;
                TaskRadioButton1.Content = OfferArray[0];

                TaskRadioButton2.Visibility = Visibility.Visible;
                TaskRadioButton2.Content = OfferArray[1];

                TaskRadioButton3.Visibility = Visibility.Visible;
                TaskRadioButton3.Content = OfferArray[2];

                TaskRadioButton4.Visibility = Visibility.Visible;
                TaskRadioButton4.Content = OfferArray[3];

                TaskInputTextBox.Visibility = Visibility.Hidden;
            }

            //Якщо є фото - відображаємо
            if (CurrentTask.Photo != null)
            {
                TaskImage.Visibility = Visibility.Visible;
                String ImageString = CurrentDir + CurrentTask.Photo;
                TaskImage.Source = new BitmapImage(new Uri(ImageString));
            }
            //якщо ні, то не відображаємо
            else
                TaskImage.Visibility = Visibility.Hidden;

        }

        // Отримання значень з елементів завдання
        private String GetTaskAnswer(TextBox TextBox, RadioButton radio1, RadioButton radio2, RadioButton radio3, RadioButton radio4)
        {
            String result = "NONE";
            //Якщо вибно текстбокс, то відповідь беремо звідти
            if ((TextBox.Visibility == Visibility.Visible) && (TextBox.Text != ""))
            {
                result = TextBox.Text;
            }

            //якщо ні, то відповідь у радіобаттонах
            else
            {
                if (radio1.IsChecked == true)
                {
                    result = radio1.Content.ToString();
                }
                else if (radio2.IsChecked == true)
                {
                    result = radio2.Content.ToString();
                }
                else if (radio3.IsChecked == true)
                {
                    result = radio3.Content.ToString();
                }
                else if (radio4.IsChecked == true)
                {
                    result = radio4.Content.ToString();
                }
            }

            return result;
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {

            //Отримуємо відповіді з елементів
            String Task1Answer = GetTaskAnswer(TaskInputTextBox, TaskRadioButton1, TaskRadioButton2, TaskRadioButton3, TaskRadioButton4);

            //Перевірка чи не пуста відповідь
            if (Task1Answer == "NONE")
                MessageBox.Show("Необхідно надати відповідь на питання");

            //Якщо відповідь є
            else
            {
                //+1
                if (TaskKey.ToLower() == Task1Answer.ToLower())
                    this.GoodAnswersCount++;

                //Якщо більше немає питань, відкриваємо форму фінальних тестів
                if (this.TaskList.Count == 0)
                {
                    EndPracticeClass nextPage = new EndPracticeClass(this.UserName, this.GoodAnswersCount, this.QuestionsCount);
                    NavigationService.Navigate(nextPage);
                }

                //Якщо ще є питання, відкриваємо нову форму
                else
                {
                    PracticeClass nextPage = new PracticeClass(this.UserName, this.TaskList, this.GoodAnswersCount, this.QuestionsCount);
                    NavigationService.Navigate(nextPage);
                }
            }
            MoveToNextQuestion();
        }
    }
}
