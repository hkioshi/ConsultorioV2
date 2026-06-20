using System.ComponentModel.DataAnnotations;

namespace ConsultorioApi.Models;

public class Procedimento
{
    [Key] [Required] 
    public int Id { get; set; }
    public string Nome { get; set; }
    public double Valor { get; set; }
    
}