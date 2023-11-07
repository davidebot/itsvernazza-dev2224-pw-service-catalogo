using System.Linq;
using System.Threading.Tasks;
using Links.OpenLending.Services.Common.Exception;
using Links.OpenLending.Services.Common.Exception.Models;
using ProjectWorkServiceCatalogo.BL.Interfaces;
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
    }
}

