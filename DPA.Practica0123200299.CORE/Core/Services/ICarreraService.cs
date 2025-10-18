using DPA.Practica0123200299.CORE.Core.Entities;

namespace DPA.Practica0123200299.CORE.Core.Services
{
    public interface ICarreraService
    {
        Task<int> AddCarreraAsync(Carrera carrera);
        Task<bool> DeleteCarreraAsync(int id);
        Task<IEnumerable<Carrera>> GetAllCarrerasAsync();
        Task<Carrera?> GetCarreraByIdAsync(int id);
        Task<bool> UpdateCarreraAsync(Carrera carrera);
    }
}