using System.ComponentModel.DataAnnotations;

namespace ProgrammingTemplateApp.Models
{
    public class Purchase
    {
        public int PurchaseId { get; set; } // Auto-assigned primary key for the Purchase entity

        [Required(ErrorMessage = "PurchaseName is required"), MaxLength(80)]
        public string PurchaseName { get; set; } // Name of the purchase 

        public DateTime PurchaseDate { get; set; } // Date when the purchase was made

        [DisplayFormat(DataFormatString = "{0:c}")]
        [Required(ErrorMessage = "PurchasedAmount with tax is required")]
        public decimal PurchaseAmountWithTax { get; set; } // Total amount with tax, formatted as currency

        public int ProgrammingTemplateId { get; set; } // Foreign key referencing entity
        public ProgrammingTemplate? ProgrammingTemplate { get; set; } // Navigation property for the related ProgrammingTemplate

    }
}
