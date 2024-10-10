using System.ComponentModel.DataAnnotations;

namespace ProgrammingTemplateApp.Models
{
    public class Purchase
    {
        public int PurchaseId { get; set; }
        public string? PurchaseName { get; set; }
        public DateTime PurchaseDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal PurchaseAmountWithTax { get; set; }
        public int ProgrammingTemplateId { get; set; }
        public ProgrammingTemplate? ProgrammingTemplate { get; set; }
    }
}
