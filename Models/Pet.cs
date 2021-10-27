using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace pet_hotel.Models
{
    public enum PetBreedType
    {
        Shepherd,
        Poodle,
        Beagle,
        Bulldog,
        Terrier,
        Boxer,
        Labrador,
        Retriever
    }
    public enum PetColorType
    {
        White,
        Black,
        Golden,
        Tricolor,
        Spotted
    }
    public class Pet
    {
        public int id { get; set; }

        [Required]
        public string name { get; set; }
        public string color { get; set; }
        public DateTime checkedInAt { get; set; }
        public string breed { get; set; }
        [ForeignKey("PetOwners")]
        public int ownerId { get; set; }
        public PetOwner ownedBy {get; set;}

    }
}
