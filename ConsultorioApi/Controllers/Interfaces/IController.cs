using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsultorioApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConsultorioApi.Controllers.Interfaces;

public interface IController<Model,GetDto, PostDto, PutDto>
{
   

    [HttpGet]
    Task<ActionResult<IEnumerable<GetDto>>> GetAll();
    
    [HttpGet("{id}")]
    Task<ActionResult<GetDto>> GetById(int id);
    
    [HttpPost]
    Task<ActionResult<Model>> Add(PostDto obj);

    [HttpPut("{id}")]
    Task<ActionResult> Modify(int id, PutDto obj);

    [HttpDelete("{id}")]
    Task<ActionResult> Delete(int id);
}
