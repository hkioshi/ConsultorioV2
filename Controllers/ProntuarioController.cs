using AutoMapper;
using ConsultorioV2.Data;
using ConsultorioV2.Data.Dtos;
using ConsultorioV2.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConsultorioV2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProntuarioController : ControllerBase
    {
        private ConsultorioContext _context;
        private IMapper _mapper;
        public ProntuarioController(ConsultorioContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpPost]
        public IActionResult AdicionarProntuario([FromBody] CreateProntuarioDto ProntuarioDto)
        {
            try
            {
                var prontuario = _mapper.Map<Prontuario>(ProntuarioDto);
                _context.Prontuarios.Add(prontuario);
                _context.SaveChanges();
                return CreatedAtAction(nameof(AdicionarProntuario), new { id = prontuario.Id }, prontuario);
            }
             catch(Exception e)
            {
                return Problem(e.Message);
            }
            
        }

        //[HttpPost("Tratamento")]
        //public ActionResult AdicionarTratamento([FromBody] CreateTratamentoDto tratamentoDto )
        //{
        //    var tratamento = _mapper.Map<Tratamento>(tratamentoDto);
        //    _context.Tratamentos.Add(tratamento);
        //    _context.SaveChanges();
        //    return CreatedAtAction(nameof(AdicionarTratamento), new { id = tratamento.Id }, tratamento);
        //}

        //[HttpGet("Tratamento")]
        //public ActionResult ValorDevido()
        //{
        //    var valorDevido = _context.Tratamentos.Sum(t => t.Valor) - _context.Pagamentos.Sum(p => p.Valor);
        //    return Ok(new { ValorDevido = valorDevido });
        //}


    }
}
