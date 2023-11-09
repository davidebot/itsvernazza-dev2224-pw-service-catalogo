using ProjectWorkServiceCatalogo.BL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectWorkServiceCatalogo.BL.Interfaces
{
    public interface IProdottoService
    {
        public Task<List<ProdottoDTO>> FindAll();
        public Task<ProdottoDTO> FindById(long id);
        public Task<bool> Create(ProdottoDTO prdottoDTO);

        public Task<bool> Update(long id, ProdottoDTO prdottoDTO);
        Task<bool?> Delete(long id);
    }
}
