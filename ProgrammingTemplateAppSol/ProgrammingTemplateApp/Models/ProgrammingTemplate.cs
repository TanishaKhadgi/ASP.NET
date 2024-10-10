using System.ComponentModel.DataAnnotations;

namespace ProgrammingTemplateApp.Models
{
    public class ProgrammingTemplate
    {
        public int ProgrammingTemplateId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal? Price { get; set; }
        public string? ProgrammingLanguage { get; set; }
        public DateTime? CreatedDate { get; set; }
        public ICollection<Purchase>? Purchases { get; set; }
    }
}
