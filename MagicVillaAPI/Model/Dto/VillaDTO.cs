using System.ComponentModel.DataAnnotations;

namespace MagicVillaAPI.Model.Dto
{
    public class VillaDTO
    {
        //Dto provide a wrapper between the entity or database model
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public int occupancy { get; set; }
        public int sqft { get; set; }
    }
}
