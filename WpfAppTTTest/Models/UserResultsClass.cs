using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppTTTest.Models
{
    class UserResultsClass
    {
        public String classId;
        public String topicId;
        public String points;
        public String username;
        public String time;
        public UserResultsClass(String classId, String topicId, String points, String username, String time)
        {
            this.classId = classId;
            this.topicId = topicId;
            this.points = points;
            this.username = username;
            this.time = time;
        }

        public override string ToString()
        {
            return classId.ToString() + " " + topicId.ToString() + " " + points.ToString() + " " + username.ToString() + " " + time.ToString();
        }
    }
}
