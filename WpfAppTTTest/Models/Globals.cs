using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfAppTTTest.Models
{
    public partial class Globals
    {
        public static int TheoryFail = 0;
        public static int Classes = 0;
        public static bool isTestProcessing = false;

        //Возвращает полный путь до корневой папки проекта
        public static String CurrentDirFormater()
        {
            //MessageBox.Show("CurrentDirFormater");
            String buffer = Directory.GetCurrentDirectory();
            String[] words = buffer.Split('\\');
            String[] newWords = words.Take(words.Count() - 2).ToArray();
            return String.Join("\\", newWords);

        }


    }
}
