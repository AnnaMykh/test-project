using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppTTTest.Models;

public partial class Topic
{
    public int Id { get; set; }
    public int TaskId { get; set; }
    public int TopicId { get; set; }
    public string? Text { get; set; }
}
