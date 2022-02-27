using System.ComponentModel.DataAnnotations;

namespace NvrOrganizer.Model
{
    public class Nvr
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        
        [StringLength(50)]
        public string LastName { get; set; }
       
        [StringLength(50)]
        public string NvrInfo { get; set; }
    }
}
