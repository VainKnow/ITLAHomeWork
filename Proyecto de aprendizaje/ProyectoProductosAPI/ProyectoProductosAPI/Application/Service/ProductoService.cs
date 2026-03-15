using ProyectoProductosAPI.Application.Contract;
using ProyectoProductosAPI.DTOs;
using ProyectoProductosAPI.Domain.Entities;
using ProyectoProductosAPI.Infrastructure.Interfaces;

namespace ProyectoProductosAPI.Application.Service
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _repository;

        public ProductoService(IProductoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProductoDto>> GetAll()
        {
            var productos = await _repository.GetAll();

            return productos.Select(p => new ProductoDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Precio = p.Precio,
                Stock = p.Stock
            }).ToList();
        }

        public async Task<ProductoDto> GetById(int id)
        {
            var p = await _repository.GetById(id);

            if (p == null) return null;

            return new ProductoDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Precio = p.Precio,
                Stock = p.Stock
            };
        }

        public async Task<ProductoDto> Create(ProductoCreateDto dto)
        {
            var producto = new Producto
            {
                Nombre = dto.Nombre,
                Precio = dto.Precio,
                Stock = dto.Stock
            };

            await _repository.Add(producto);

            return new ProductoDto
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                Stock = producto.Stock
            };
        }

        public async Task<ProductoDto> Update(int id, ProductoUpdateDto dto)
        {
            var producto = await _repository.GetById(id);

            if (producto == null) return null;

            producto.Nombre = dto.Nombre;
            producto.Precio = dto.Precio;
            producto.Stock = dto.Stock;

            await _repository.Update(producto);

            return new ProductoDto
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                Stock = producto.Stock
            };
        }

        public async Task<bool> Delete(int id)
        {
            var producto = await _repository.GetById(id);

            if (producto == null) return false;

            await _repository.Delete(id);

            return true;
        }
    }
}
