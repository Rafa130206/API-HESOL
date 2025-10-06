namespace Hesol.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

        public class Local
        {

        [Key]
        public int IdLocal { get; set; }

            [Required]
            [Range(-90.0, 90.0, ErrorMessage = "Latitude deve estar entre -90 e 90.")]
            public double Latitude { get; set; }

            [Required]
            [Range(-180.0, 80.0, ErrorMessage = "Longitude deve estar entre -1800 e 80.")]
            public double Longitude { get; set; }

            [Required]
            [MaxLength(100)]
            public string Descricao { get; set; }

            [Required]
            [MaxLength(100)]
            public string Pais { get; set; }


        }

}
