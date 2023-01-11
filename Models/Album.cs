using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using DecaStore.Data.IRepository;

namespace DecaStore.Models
{
    public class Album : IEntityBase
    {
        public Guid Id { get; set; }

        [Display(Name = " Album Title")]
        [Required(ErrorMessage = "Album Title  is Required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Price  is Required")]
        public decimal Price { get; set; }
        public DateTime DateReleased { get; set; }
        [Display(Name = "Album Art")]
        [Required(ErrorMessage = "Album Artis Required")]
        public string AlbumArtUrl { get; set; }

        //Genre One -> Many Relationship
        //The Genre foreign key
        //Genre
        //The one to many relationship between the Genre and the Album
        public Guid GenreId { get; set; }
        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }

        //Artist One -> Many Relationship
        //The Artist foreign key
        //Artist
        //The one to many relationship between the Artist and the Album
        public Guid ArtistId { get; set; }
        [ForeignKey("ArtistId")]
        public Artist Artist { get; set; }
    }
}
