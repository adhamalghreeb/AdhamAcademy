using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos
{
    public class StudentCreateDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? TelegramName { get; set; }
        public List<SubjectAssignmentDto> Subjects { get; set; }
    }

    public class StudentReadDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string TelegramName { get; set; }
        public decimal TotalAmount { get; set; } // Total amount the student needs to pay
        public decimal AmountPaid { get; set; } // Total amount the student has paid
        public decimal AmountLeftToPay { get; set; } // Total amount left to pay
        public List<PaymentDto>? Payments { get; set; }
    }

    public class StudentUpdateDto
    {
        // Basic info
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? TelegramName { get; set; }

        // Subject Management
        public List<Guid>? SubjectIdsToAdd { get; set; }
        public List<Guid>? SubjectIdsToRemove { get; set; }

        // Payment update
        public decimal? PaymentAmount { get; set; } // optional: if filled, assume a new payment at current date
    }

}