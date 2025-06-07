namespace Hesol.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

        
    public class Leitura
    {
        public Leitura()
        {
        }

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

        public string Resultado { get; set; }

        public Leitura(int idLeitura, int idUsuario, int idSensor, double temperatura, double co2, double umidade, double poluicao, string resultado)
        {
            IdLeitura = idLeitura;
            IdUsuario = idUsuario;
            IdSensor = idSensor;
            Temperatura = temperatura;
            Co2 = co2;
            Umidade = umidade;
            Poluicao = poluicao;
            Resultado = resultado;
        }
    }

}
