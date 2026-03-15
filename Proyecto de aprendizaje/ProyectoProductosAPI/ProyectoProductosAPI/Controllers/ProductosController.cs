using Microsoft.AspNetCore.Mvc;
using ProyectoProductosAPI.DTOs;
using ProyectoProductosAPI.Application.Contract;

namespace ProyectoProductosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoService _service;

        public ProductosController(IProductoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var productos = await _service.GetAll();
            return Ok(productos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var producto = await _service.GetById(id);

            if (producto == null)
                return NotFound();

            return Ok(producto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductoCreateDto dto)
        {
            var producto = await _service.Create(dto);
            return Ok(producto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ProductoUpdateDto dto)
        {
            var producto = await _service.Update(id, dto);

            if (producto == null)
                return NotFound();

            return Ok(producto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _service.Delete(id);

            if (!eliminado)
                return NotFound();

            return NoContent();
        }
    }
}

