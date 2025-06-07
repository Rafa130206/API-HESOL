namespace Hesol.Models
{
    using System.ComponentModel.DataAnnotations;
    
    public class Usuario
    {
       
        [Key]
        public int IdUsuario { get; set; }
            
        [Required]            
        [MaxLength(100)]           
        public string Nome { get; set; }
           
        [Required]           
        [MaxLength(100)]
        
        public string Email { get; set; }
           
        [Required]       
        [MaxLength(100)]       
        public string Senha { get; set; }

    }


}
