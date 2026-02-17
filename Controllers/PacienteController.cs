using ConsultorioV2.Data;
using ConsultorioV2.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConsultorioV2.Controllers;

[ApiController]
[Route("[controller]")]
public class PacienteController: ControllerBase
{
    private ConsultorioContext _context;
    public PacienteController(ConsultorioContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IEnumerable<Paciente> ExibirTodosPacientes()
    {
        
        return _context.Pacientes;
    }

}
