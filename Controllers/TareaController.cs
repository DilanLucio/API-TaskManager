using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
public class TareaController : ControllerBase
{
    ITareaService TareaService;


    public TareaController(ITareaService service)
    {
        TareaService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(TareaService.Get());
    }

    [HttpPost]
    public IActionResult POST([FromBody] Tarea Tarea)
    {
        TareaService.Save(Tarea);
        return Ok();
    }

    [HttpPut("(id)")]
    public IActionResult Put(Guid id, [FromBody] Tarea Tarea)
    {
        TareaService.Update(id, Tarea);
        return Ok();
    }

    [HttpDelete("(id)")]
    public IActionResult Delete(Guid id)
    {
        TareaService.Delete(id);
        return Ok();
    }



}