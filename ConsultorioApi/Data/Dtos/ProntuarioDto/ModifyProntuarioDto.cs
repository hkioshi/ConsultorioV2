using System.ComponentModel.DataAnnotations;
using ConsultorioApi.Models;

namespace ConsultorioApi.Data.Dtos.ProntuarioDto;

public class ModifyProntuarioDto
{
    [Key] [Required] public int Id { get; set; }

    [Required] public int PacienteId { get; set; }

}
