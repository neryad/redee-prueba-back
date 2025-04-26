using System.ComponentModel.DataAnnotations;

namespace redee_prueba_back.Entities
{
    public class Company
    {
        public int Id { get; set; }
        [Required]
        public string Rnc { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string CommercialName { get; set; }
        [Required]
        public string Status { get; set; }
        public string Category { get; set; }
        [Required]
        public string Payment { get; set; }
        [Required]
        public string Activity { get; set; }
        [Required]
        public string Branch { get; set; }
    }
}
