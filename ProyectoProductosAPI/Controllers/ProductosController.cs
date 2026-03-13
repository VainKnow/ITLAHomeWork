
using Microsoft.AspNetCore.Mvc;
using ProyectoProductosAPI.DTOs;
using ProyectoProductosAPI.Domain.Entities;
using ProyectoProductosAPI.Infrastructure.Interfaces;

namespace ProyectoProductosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoRepository _repository;

        public ProductosController(IProductoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var productosDb = await _repository.GetAll();

            var productos = productosDb.Select(p => new ProductoDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Precio = p.Precio,
                Stock = p.Stock
            });

            return Ok(productos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var producto = await _repository.GetById(id);

            if (producto == null)
                return NotFound();

            var dto = new ProductoDto
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                Stock = producto.Stock
            };

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductoCreateDto dto)
        {
            var producto = new Producto
            {
                Nombre = dto.Nombre,
                Precio = dto.Precio,
                Stock = dto.Stock
            };

            await _repository.Add(producto);

            return Ok(producto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ProductoUpdateDto dto)
        {
            var producto = await _repository.GetById(id);

            if (producto == null)
                return NotFound();

            producto.Nombre = dto.Nombre;
            producto.Precio = dto.Precio;
            producto.Stock = dto.Stock;

            await _repository.Update(producto);

            return Ok(producto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _repository.Delete(id);

            if (!eliminado)
                return NotFound();

            return NoContent();
        }
    }
}

