using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppTTTest.Models
{
    public class TaskClass
    {

        public int TaskId;
        public int TopicId;
        public int ClassId;
        public int TypeId;
        public String Text;
        public String Photo;
        public String Option1;
        public String Option2;
        public String Option3;
        public String Option4;

        public TaskClass(String TaskId, String TopicId, String ClassId, String TypeId, String Text, String Photo, String Option1, String Option2, String Option3, String Option4)
        {
            this.TaskId = Int32.Parse(TaskId);
            this.TopicId = Int32.Parse(TopicId);
            this.ClassId = Int32.Parse(ClassId);
            this.TypeId = Int32.Parse(TypeId);
            this.Text = Text;
            this.Photo = Photo;
            this.Option1 = Option1;
            this.Option2 = Option2;
            this.Option3 = Option3;
            this.Option4 = Option4;
        }


    }
}
