using System;
using System.Collections.Generic;
using System.Text;

namespace CoursesLibrary.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateModified { get; set; }

        public BaseModel()
        {
            DateAdded = DateTime.Now;
            DateModified = DateTime.Now;
        }
    }
}
