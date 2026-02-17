using AutoMapper;
using ConsultorioV2.Data;
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



    }
}
