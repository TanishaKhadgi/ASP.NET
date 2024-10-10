using System.ComponentModel.DataAnnotations;

namespace ProgrammingTemplateApp.Models
{
    public class ProgrammingTemplate
    {
        public int ProgrammingTemplateId { get; set; } // Primary key which will be automatically assigned
        [Required(ErrorMessage = "Title is required"), MaxLength(80)]
        public string Title { get; set; } // Title of the programming template
        [Required(ErrorMessage = "Description is required"), MaxLength(250)]
        public string Description { get; set; } // Description of the template created by users
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal? Price { get; set; } // Price of the template at users want to sell it
        [Required(ErrorMessage = "Programming language is required"), MaxLength(60)]
        public string ProgrammingLanguage { get; set; } // Programming language in which the template is created
        public DateTime? CreatedDate { get; set; } // Date and time in which the template is created
        public ICollection<Purchase>? Purchases { get; set; }
    }
}
