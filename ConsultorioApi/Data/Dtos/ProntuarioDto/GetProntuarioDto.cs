using System.ComponentModel.DataAnnotations;
using ConsultorioApi.Data.Dtos.PagamentoDto;
using ConsultorioApi.Data.Dtos.TratamentoDto;
using ConsultorioApi.Models;

namespace ConsultorioApi.Data.Dtos.ProntuarioDto;

public class GetProntuarioDto
{
    public int Id { get; set; }
    [Required] public int PacienteId { get; set; }
    public virtual IEnumerable<GetTratamentoDto> Tratamentos { get; set; } = [];
    public virtual IEnumerable<GetPagamentoDto> Pagamentos { get; set; } = [];
}

