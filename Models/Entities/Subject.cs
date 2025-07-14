using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Subject : BaseEntity
    {
        public string Name { get; set; }
        public decimal DefaultPrice { get; set; }

        // Navigation property
        public ICollection<StudentSubject> StudentSubjects { get; set; }
    }
}
