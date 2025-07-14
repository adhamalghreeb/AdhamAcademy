using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Student : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? TelegramName { get; set; }

        public decimal TotalAmountAssigned { get; set; }
        public decimal TotalAmountPaid { get; set; }

        // Navigation properties
        public ICollection<StudentSubject> StudentSubjects { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }

}
