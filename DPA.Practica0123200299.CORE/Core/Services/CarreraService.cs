using DPA.Practica0123200299.CORE.Core.Entities;
using DPA.Practica0123200299.CORE.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.Practica0123200299.CORE.Core.Services
{

    public class CarreraService : ICarreraService
    {


        private readonly ICarreraRepository _carreraRepository;

        public CarreraService(ICarreraRepository carreraRepository)
        {
            _carreraRepository = carreraRepository;
        }

        public async Task<IEnumerable<Carrera>> GetAllCarrerasAsync()
        {
            return await _carreraRepository.GetAllCarrerasAsync();
        }

        public async Task<Carrera?> GetCarreraByIdAsync(int id)
        {
            return await _carreraRepository.GetCarreraByIdAsync(id);
        }

        public async Task<int> AddCarreraAsync(Carrera carrera)
        {
            return await _carreraRepository.AddCarreraAsync(carrera);
        }

        public async Task<bool> UpdateCarreraAsync(Carrera carrera)
        {
            return await _carreraRepository.UpdateCarreraAsync(carrera);
        }

        public async Task<bool> DeleteCarreraAsync(int id)
        {
            return await _carreraRepository.DeleteCarreraAsync(id);
        }

    }
}
