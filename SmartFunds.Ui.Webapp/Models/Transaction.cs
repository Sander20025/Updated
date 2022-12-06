using System.ComponentModel.DataAnnotations.Schema;

namespace SmartFunds.Ui.Webapp.Models
{
    [Table(nameof(Transaction))]
    public class Transaction
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public Organization? Organization { get; set; }

        public required string Owner { get; set; }
        public decimal Amount { get; set; }

        public required string Remarks { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
