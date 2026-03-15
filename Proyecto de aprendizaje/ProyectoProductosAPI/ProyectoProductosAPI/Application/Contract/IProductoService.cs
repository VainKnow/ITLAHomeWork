using ProyectoProductosAPI.DTOs;

namespace ProyectoProductosAPI.Application.Contract
{
    public interface IProductoService
    {
        Task<List<ProductoDto>> GetAll();
        Task<ProductoDto> GetById(int id);
        Task<ProductoDto> Create(ProductoCreateDto dto);
        Task<ProductoDto> Update(int id, ProductoUpdateDto dto);
        Task<bool> Delete(int id);
    }
}