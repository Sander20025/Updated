using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartFunds.Ui.Webapp.Models
{
    [Table(nameof(Organization))]
    public class Organization
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        [DisplayName("Type of Company")]
        public string Type { get; set; } = null!;

        [Required]
        [Display(Name = "Company Number")]
        public string CompanyNumber { get; set; } = null!;

        [EmailAddress]
        public string? Email { get; set; }

        public IList<Transaction> Transactions { get; set; } = new List<Transaction>();

    }
}
