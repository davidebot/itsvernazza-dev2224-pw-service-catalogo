using System;
using System.Threading.Tasks;

namespace ProjectWorkServiceCatalogo.BL.Interfaces
{
    public interface ICategoriaService
    {
        public Task<bool> Create(string nome);
    }
}

