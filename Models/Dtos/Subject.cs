using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos
{
    public class SubjectReadDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal DefaultPrice { get; set; }
    }

    public class SubjectCreateOrUpdateDto
    {
        public string Name { get; set; }
        public decimal DefaultPrice { get; set; }
    }

    public class SubjectAssignmentDto
    {
        public Guid SubjectId { get; set; }
        public decimal PriceAssigned { get; set; }
    }

}
