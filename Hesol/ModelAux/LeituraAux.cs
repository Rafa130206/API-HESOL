using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hesol.ModelAux
{
    public class LeituraAux
    {

        [Key]
        public int IdLeitura { get; set; }

        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }

        [ForeignKey("Sensor")]
        public int IdSensor { get; set; }

        [Required]
        [Range(-90.0, 60.0, ErrorMessage = "Temperatura deve estar entre -90°C e 60°C")]
        public double Temperatura { get; set; }

        [Required]
        public double Co2 { get; set; }

        [Required]
        [Range(0.0, 100.0, ErrorMessage = "Umidade deve estar entre 0% e 100%")]
        public double Umidade { get; set; }

        [Required]
        [Range(0, 100.0, ErrorMessage = "Poluição AQI deve estar entre 0 e 100")]
        public double Poluicao { get; set; }

    }
}
