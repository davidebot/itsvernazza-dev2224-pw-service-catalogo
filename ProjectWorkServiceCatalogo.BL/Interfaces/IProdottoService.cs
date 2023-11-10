using ProjectWorkServiceCatalogo.BL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectWorkServiceCatalogo.BL.Interfaces
{
    public interface IProdottoService
    {
        public Task<List<ProdottoDTO>> FindAll(long idCategoria);
        public Task<ProdottoDTO> FindById(long id);
        public Task<bool> Create(ProdottoUpsertDTO prdottoDTO);
        public Task<bool> Update(long id, ProdottoUpsertDTO prdottoDTO);
        public Task<bool> Delete(long id);
    }
}
