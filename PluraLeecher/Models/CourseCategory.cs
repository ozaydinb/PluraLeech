using System.Collections.Generic;

namespace PluraLeecher.Models
{
    public class CourseCategory
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Course> CourseList { get; set; }
    }
}
