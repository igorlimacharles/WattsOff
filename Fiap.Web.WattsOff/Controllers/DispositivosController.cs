using Fiap.Web.WattsOff.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.WattsOff.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DispositivosController : ControllerBase
{
    // Simulação de banco de dados em memória
    private static readonly List<Dispositivo> dispositivos = new();

    // GET: /api/dispositivos
    [HttpGet]
    public ActionResult<IEnumerable<Dispositivo>> GetAll()
    {
        return Ok(dispositivos);
    }

    // GET: /api/dispositivos/{id}
    [HttpGet("{id}")]
    public ActionResult<Dispositivo> GetById(Guid id)
    {
        var dispositivo = dispositivos.FirstOrDefault(d => d.Id == id);
        if (dispositivo == null)
            return NotFound();

        return Ok(dispositivo);
    }

    // POST: /api/dispositivos
    [HttpPost]
    public ActionResult<Dispositivo> Create(Dispositivo dispositivo)
    {
        dispositivo.Id = Guid.NewGuid();
        dispositivos.Add(dispositivo);
        return CreatedAtAction(nameof(GetById), new { id = dispositivo.Id }, dispositivo);
    }

    // PUT: /api/dispositivos/{id}/status
    [HttpPut("{id}/status")]
    public ActionResult UpdateStatus(Guid id, [FromQuery] bool ligado)
    {
        var dispositivo = dispositivos.FirstOrDefault(d => d.Id == id);
        if (dispositivo == null)
            return NotFound();

        dispositivo.StatusLigado = ligado;
        return NoContent();
    }
}
