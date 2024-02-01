using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppTTTest.Models;

public partial class Task
{
    public int Id { get; set; }
    public int TaskId { get; set; }
    public int TopicId { get; set; }
    public int ClassId { get; set; }
    public int TypeId { get; set; }
    public string? Text { get; set; }
    public string? Photo { get; set; }
    public string? Option1 { get; set; }
    public string? Option2 { get; set; }
    public string? Option3 { get; set; }
    public string? Option4 { get; set; }

    //public Task(string taskId, string topicId, string classId, string typeId, string text, string photo, string option1, string option2, string option3, string option4)
    //{
    //    if (Int32.TryParse(taskId, out int taskIdValue))
    //        TaskId = taskIdValue;
    //    if (Int32.TryParse(topicId, out int topicIdValue))
    //        TopicId = topicIdValue;
    //    if (Int32.TryParse(classId, out int classIdValue))
    //        ClassId = classIdValue;
    //    if (Int32.TryParse(typeId, out int typeIdValue))
    //        TypeId = typeIdValue;

    //    Text = text;
    //    Photo = photo;
    //    Option1 = option1;
    //    Option2 = option2;
    //    Option3 = option3;
    //    Option4 = option4;
    //}
}
