using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Models;

namespace API.Controllers;

[ApiController]
[Route("api/paciente")]
public class PacienteController : ControllerBase
{
    private readonly AppDataContext _ctx;
    public PacienteController(AppDataContext ctx)
    {
        _ctx = ctx;
    }

    //GET: api/paciente/listar
    [HttpGet]
    [Route("listar")]
    public IActionResult Listar()
    {
        try
        {
            //Include
            List<Paciente> pacientes =
                _ctx.Pacientes.ToList();
            return pacientes.Count == 0 ? NotFound() : Ok(pacientes);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    // POST: api/paciente/cadastrar
    [HttpPost]
    [Route("cadastrar")]
    public ActionResult Cadastrar([FromBody] Paciente paciente)
    {
        try
        {
            _ctx.Pacientes.Add(paciente);
            _ctx.SaveChanges();
            return Created("", paciente);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    [Route("buscarcpf/{cpf}")]
    public IActionResult BuscarCpf([FromRoute] string cpf)
    {
        try
        {
            Paciente? pacienteCadastrado = _ctx.Pacientes.FirstOrDefault(x => x.PacienteCpf == cpf);
            if (pacienteCadastrado != null)
            {
                return Ok(pacienteCadastrado);
            }
            return NotFound();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    [Route("buscarnome/{nome}")]
    public IActionResult BuscarNome([FromRoute] string nome)
    {
        try
        {
            Paciente? pacienteCadastrado = _ctx.Pacientes.FirstOrDefault(x => x.PacienteNome == nome);
            if (pacienteCadastrado != null)
            {
                return Ok(pacienteCadastrado);
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
        [FromBody] Paciente paciente)
    {
        try
        {
            Paciente? pacienteCadastrado =
                _ctx.Pacientes.FirstOrDefault(x => x.PacienteId == id);
            if (pacienteCadastrado != null)
            {
                pacienteCadastrado.PacienteCpf  = paciente.PacienteCpf;
                pacienteCadastrado.PacienteNome = paciente.PacienteNome;
                pacienteCadastrado.PacienteData = paciente.PacienteData;
                pacienteCadastrado.PacienteGenero = paciente.PacienteGenero;
                pacienteCadastrado.PacienteTelefone = paciente.PacienteTelefone;
                pacienteCadastrado.PacienteNotas = paciente.PacienteNotas;
                _ctx.SaveChanges();
                return Ok(paciente);
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
            Paciente? pacienteCadastrado = _ctx.Pacientes.Find(id);
            if (pacienteCadastrado != null)
            {
                _ctx.Pacientes.Remove(pacienteCadastrado);
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