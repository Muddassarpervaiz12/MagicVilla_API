using System.ComponentModel.DataAnnotations;

namespace MagicVillaAPI.Model.Dto
{
    public class VillaDTO
    {
        //Dto provide a wrapper between the entity or database model
        // working with our Api
        //we do not want created data and updated date in Dto
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public string Details { get; set; }
        public double Rate { get; set; }
        [Required]
        public int Sqft { get; set; }
        public int Occupancy { get; set; }
        public string ImageUrl { get; set; }
        public string Amenity { get; set; }
    }
}
