using System;
using System.Collections.Generic;
using System.Text;

namespace CoursesLibrary.Models
{
    public class Course : BaseModel
    {
        public string Description { get; set; }

        public int SalesTimes { get; set; }

        public List<Author> Authors { get; set; } = new List<Author>();
    }
}
