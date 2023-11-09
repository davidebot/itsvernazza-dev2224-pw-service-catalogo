using ProjectWorkServiceCatalogo.BL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectWorkServiceCatalogo.BL.Interfaces
{
    public interface ICategoriaService
    {
        public Task<bool> Create(string nome);
        public Task<bool> Update(long id, string nome);
        public Task<bool> Delete(long id);
        public Task<List<CategoriaDTO>> GetAll();
        public Task<CategoriaDTO> GetById(long id);
                
    }
}

