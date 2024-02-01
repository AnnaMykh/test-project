using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WpfAppTTTest.Models;

public partial class Result
{
    public int Id { get; set; }
    public int ClassId { get; set; }
    public int TopicId { get; set; }
    public int Points { get; set; }
    public string? Username { get; set; }
    public string? Time { get; set; }
}
