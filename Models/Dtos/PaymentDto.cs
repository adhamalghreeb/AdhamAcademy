namespace Models.Dtos
{
    public class PaymentDto
    {
        public Guid Id { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime Date { get; set; }
        public string BillPdfPath { get; set; } // Path to the generated bill PDF, if available
    }

}