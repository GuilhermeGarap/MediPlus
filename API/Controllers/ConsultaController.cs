using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Models;

namespace API.Controllers;

[ApiController]
[Route("api/consulta")]
public class ConsultaController : ControllerBase
{
    private readonly AppDataContext _ctx;
    public ConsultaController(AppDataContext ctx)
    {
        _ctx = ctx;
    }

    //GET: api/consulta/listar
    [HttpGet]
    [Route("listar")]
    public IActionResult Listar()
    {
        try
        {
            //Include
            List<Consulta> consultas =
                _ctx.Consultas.ToList();
            return consultas.Count == 0 ? NotFound() : Ok(consultas);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    // POST: api/paciente/cadastrar
    [HttpPost]
    [Route("cadastrar")]
    public ActionResult Cadastrar([FromBody] Consulta consulta)
    {
        try 
        {
        Paciente? paciente = _ctx.Pacientes.Find(consulta.PacienteId);
        if(paciente == null) {
            return NotFound();
        }
        consulta.Paciente = paciente;
            _ctx.Consultas.Add(consulta);
            _ctx.SaveChanges();
            return Created("", consulta);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    [Route("buscar/{id}")]
    public IActionResult Buscar([FromRoute] int id)
    {
        try
        {
            Consulta? consultaCadastrada = _ctx.Consultas.FirstOrDefault(x => x.ConsultaId == id);
            if (consultaCadastrada != null)
            {
                return Ok(consultaCadastrada);
            }
            return NotFound();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    // PUT: api/categoria/alterar/5
    [HttpPut]
    [Route("alterar/{id}")]
    public IActionResult Alterar([FromRoute] int id,
        [FromBody] Consulta consulta)
    {
        try
        {
            Consulta? consultaCadastrada =
                _ctx.Consultas.FirstOrDefault(x => x.ConsultaId == id);
            if (consultaCadastrada != null)
            {
                consultaCadastrada.ConsultaData = consulta.ConsultaData;
                consultaCadastrada.ConsultaNotas = consulta.ConsultaNotas;

                _ctx.SaveChanges();
                return Ok(consulta);
            }
            return NotFound();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    // DELETE: api/categoria/deletar/5
    [HttpDelete]
    [Route("deletar/{id}")]
    public IActionResult Deletar([FromRoute] int id)
    {
        try
        {
            Consulta? consultaCadastrada = _ctx.Consultas.Find(id);
            if (consultaCadastrada != null)
            {
                _ctx.Consultas.Remove(consultaCadastrada);
                _ctx.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}