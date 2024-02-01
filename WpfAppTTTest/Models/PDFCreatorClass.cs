using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MigraDocCore.DocumentObjectModel.Tables;
using Column = MigraDoc.DocumentObjectModel.Tables.Column;
using Row = MigraDoc.DocumentObjectModel.Tables.Row;
using Table = MigraDoc.DocumentObjectModel.Tables.Table;


namespace WpfAppTTTest.Models
{
    class PDFCreatorClass
    {
        private Table table;
        private Document document;
        private String FileName;
        private String UserName;
        private List<UserResultsClass> ResultsList;
        private UserResultsClass RresultsList;

        public PDFCreatorClass(String FileName, String UserName, List<UserResultsClass> ResultsList)
        {
            this.FileName = FileName;
            this.UserName = UserName;
            this.ResultsList = ResultsList;
            this.CreateDocument();
        }

        public PDFCreatorClass(String FileName, String UserName, UserResultsClass ResultsList)
        {
            this.FileName = FileName;
            this.UserName = UserName;
            this.RresultsList = ResultsList;
            this.CreateDocument();
        }
       

        //Метод создания документа
        private void CreateDocument()
        {
            //створоюємо документ
            this.document = new Document();

            DefineStyles();

            CreatePage();

            //заповнюємо даними
            FillContent();

            MigraDoc.DocumentObjectModel.IO.DdlWriter.WriteToFile(document, "MigraDoc.mdddl");
           
            //PdfDocumentRenderer renderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always);
            PdfDocumentRenderer renderer = new PdfDocumentRenderer();
            renderer.Document = document;
            //renderer.Document = document;

            renderer.RenderDocument();
           
            //Зберігаємо
            //String filename = Globals.CurrentDirFormater() + "/" + this.FileName;
            string filename = Globals.CurrentDirFormater() + "\\" + this.FileName;

            renderer.PdfDocument.Save(filename);

            // Шлях до виконуваного файлу Adobe Acrobat Reader
            string acrobatPath = @"C:\Program Files (x86)\Adobe\Acrobat Reader DC\Reader\AcroRd64.exe";

            // Відкриття PDF-файлу через Adobe Acrobat Reader
            //try
            //{
            //    Process.Start(acrobatPath, filename);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Не вдалося відкрити PDF-файл через Adobe Acrobat Reader. Помилка: {ex.Message}");
            //    Console.WriteLine($"Не вдалося відкрити PDF-файл через Adobe Acrobat Reader. Помилка: {ex.Message}");
            //}
            //try
            //{
            //    Process.Start(filename);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Не вдалося відкрити PDF-файл. Помилка: {ex.Message}");
            //    Console.WriteLine($"Не вдалося відкрити PDF-файл. Помилка: {ex.Message}");
            //}

        }

        //Выставление форматирование и задание общего стиля для PDF-документа
        private void DefineStyles()
        {
           
            MigraDoc.DocumentObjectModel.Style style = this.document.Styles["Normal"];
            style.Font.Name = "Verdana";

            style = this.document.Styles[StyleNames.Header];
            style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right);

            style = this.document.Styles[StyleNames.Footer];
            style.ParagraphFormat.AddTabStop("8cm", TabAlignment.Center);

            style = this.document.Styles.AddStyle("Table", "Normal");
            style.Font.Name = "Verdana";
            style.Font.Name = "Times New Roman";
            style.Font.Size = 9;

            style = this.document.Styles.AddStyle("Reference", "Normal");
            style.ParagraphFormat.SpaceBefore = "5mm";
            style.ParagraphFormat.SpaceAfter = "5mm";
            style.ParagraphFormat.TabStops.AddTabStop("16cm", TabAlignment.Right);
        }

        //Объявление и создание основных элементов таблицы
        private void CreatePage()
        {
            // Добавляем новую секцию в документе
            Section section = this.document.AddSection();

            // Данные выше таблицы
            Paragraph paragraph = section.AddParagraph();
            paragraph.Format.SpaceBefore = "8cm";
            paragraph.Style = "Reference";
            paragraph.AddFormattedText("Результат користувача: " + this.UserName, TextFormat.Bold);
            paragraph.AddTab();
            paragraph.AddText("Дата формування звіту: ");
            paragraph.AddDateField("dd.MM.yyyy");

            // Создаем таблицу
            this.table = section.AddTable();
            this.table.Style = "Table";
            this.table.Borders.Width = 0.25;
            this.table.Borders.Left.Width = 0.5;
            this.table.Borders.Right.Width = 0.5;
            this.table.Rows.LeftIndent = 0;


            Column column1 = table.AddColumn("8cm");
            column1.Format.Alignment = ParagraphAlignment.Left;
            Column column2 = table.AddColumn("8cm");
            column2.Format.Alignment = ParagraphAlignment.Left;

            Row row1 = table.AddRow();
            row1.Cells[0].AddParagraph("Клас");
            Row row2 = table.AddRow();
            row2.Cells[0].AddParagraph("Тема");
            Row row3 = table.AddRow();
            row3.Cells[0].AddParagraph("Кількість правильних відповідей");
            Row row4 = table.AddRow();
            row4.Cells[0].AddParagraph("Дата/час");

            UserResultsClass thisResult = RresultsList;

            row1.Cells[1].AddParagraph(thisResult.classId);
            row2.Cells[1].AddParagraph(thisResult.topicId);
            row3.Cells[1].AddParagraph(thisResult.points);
            row4.Cells[1].AddParagraph(thisResult.time);

        }

        //Заполнение таблицы данными
        private void FillContent()
        {
            MessageBox.Show("FillContent");
           
        }


    }
}
