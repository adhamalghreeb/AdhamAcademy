using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class StudentSubject : BaseEntity
    {
        public Guid StudentId { get; set; }
        public Student Student { get; set; }

        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }

        public decimal PriceAssigned { get; set; }
    }

}
