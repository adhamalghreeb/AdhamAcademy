using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Payment : BaseEntity
    {
        public Guid StudentId { get; set; }
        public Student Student { get; set; }

        public decimal AmountPaid { get; set; }
        public DateTime PaymentDate { get; set; }

        public string? BillPdfPath { get; set; }
        public string? Note { get; set; }
    }

}
