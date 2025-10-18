using DPA.Practica0123200299.CORE.Core.Entities;
using DPA.Practica0123200299.CORE.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.Practica0123200299.CORE.Infrastructure.Repositories
{
    public class CarreraRepository : ICarreraRepository
    {
        private readonly UniversidadBdContext _context;

        public CarreraRepository(UniversidadBdContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Carrera>> GetAllCarrerasAsync()
        {
            return await _context.Carrera.ToListAsync();
        }

        public async Task<Carrera?> GetCarreraByIdAsync(int id)
        {
            return await _context.Carrera.FindAsync(id);
        }

        public async Task<int> AddCarreraAsync(Carrera carrera)
        {
            await _context.Carrera.AddAsync(carrera);
            await _context.SaveChangesAsync();

            return carrera.IdCarrera;
        }

        public async Task<bool> UpdateCarreraAsync(Carrera carrera)
        {
            var existingCarrera = await _context.Carrera.FindAsync(carrera.IdCarrera);
            if (existingCarrera == null)
            {
                return false;
            }
            _context.Entry(existingCarrera).CurrentValues.SetValues(carrera);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCarreraAsync(int id)
        {
            var carrera = await _context.Carrera.FindAsync(id);
            if (carrera == null)
            {
                return false;
            }
            _context.Carrera.Remove(carrera);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
