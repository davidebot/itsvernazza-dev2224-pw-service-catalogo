using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Links.OpenLending.Services.Common.Exception;
using Links.OpenLending.Services.Common.Exception.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using ProjectWorkServiceCatalogo.BL.Interfaces;
using ProjectWorkServiceCatalogo.BL.Models;
using ProjectWorkServiceCatalogo.DL;
using ProjectWorkServiceCatalogo.DL.Models;

namespace ProjectWorkServiceCatalogo.BL.Implementations
{
    public class CategoriaService : ICategoriaService
    {
        private readonly CatalogoServiceDbContext _catalogoServiceDbContext;
        public CategoriaService(CatalogoServiceDbContext catalogoServiceDbContext)
        {
            _catalogoServiceDbContext = catalogoServiceDbContext;
        }

        public async Task<bool> Create(string nome)
        {
            bool exists = _catalogoServiceDbContext.TbCategoria.Any(cat => cat.Nome.ToLower() == nome.ToLower());

            if (exists)
            {
                throw new BusinessException(new BusinessErrorDTO("Categoria già presente", 400, "DUPLICATED"));
            }

            var categoria = new TbCategoria()
            {
                Nome = nome.Trim(),
            };

            await _catalogoServiceDbContext.TbCategoria.AddAsync(categoria);

            await _catalogoServiceDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Update(long id, string nome)
        {

            var categoria = await _catalogoServiceDbContext.TbCategoria.Where(c => c.IdCategoria == id).FirstOrDefaultAsync();
 
            if (categoria == null)
            {
                throw new BusinessException(new BusinessErrorDTO("Categoria assente, impossibile da modificare", 404, "NOT FOUND"));
            }

            categoria.Nome = nome;

            await _catalogoServiceDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(long id)
        {
            var categoriaDaRimuovere = await _catalogoServiceDbContext.TbCategoria.Where(c => c.IdCategoria == id).FirstOrDefaultAsync();

            if (categoriaDaRimuovere == null)
            {
                throw new BusinessException(new BusinessErrorDTO("Categoria assente, impossibile da visualizzare", 404, "NOT FOUND"));
            }

            _catalogoServiceDbContext.TbCategoria.Remove(categoriaDaRimuovere);

            await _catalogoServiceDbContext.SaveChangesAsync();

            return true;


        }

        public async Task<List<CategoriaDTO>> GetAll()
        {
            return await _catalogoServiceDbContext.TbCategoria.Select(c => new CategoriaDTO(c.IdCategoria, c.Nome)).ToListAsync();

        }

        public async Task<CategoriaDTO> GetById(long id)
        {
            var categoria = await _catalogoServiceDbContext.TbCategoria.Where(c => c.IdCategoria == id).FirstOrDefaultAsync();

            if (categoria == null)
            {
                throw new BusinessException(new BusinessErrorDTO("Categoria assente, impossibile da visualizzare", 404, "NOT FOUND"));
            }
            var categoriaVisualizzata = new CategoriaDTO(categoria.IdCategoria,categoria.Nome);
            
            return categoriaVisualizzata;




        }


    }
}

