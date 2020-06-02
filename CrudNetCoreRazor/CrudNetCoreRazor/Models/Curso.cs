using System.ComponentModel.DataAnnotations;

namespace CrudNetCoreRazor.Models
{
    public class Curso
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nome do Curso")]
        public string Nome { get; set; }
        [Display(Name = "Quantidade de Classes")]
        public int QuantidadeClasses { get; set; }
        public double Preco { get; set; }
    }
}
