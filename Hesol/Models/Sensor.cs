namespace Hesol.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text.Json.Serialization;

    public class Sensor
        {

            [Key]
            public int IdSensor { get; set; }

            [Required]
            [MaxLength(100)]
            public string Modelo { get; set; }

            [ForeignKey("Local")]
            public int IdLocal { get; set; }

            [Required]
            [MaxLength(1)]
            public string AtivoChar { get; set; }  // Armazena "S" ou "N" no banco

            [JsonIgnore]
            [NotMapped]  
            public bool Ocupado
            {
                get => AtivoChar == "S";
                set => AtivoChar = value ? "S" : "N";
            }

        }

}
