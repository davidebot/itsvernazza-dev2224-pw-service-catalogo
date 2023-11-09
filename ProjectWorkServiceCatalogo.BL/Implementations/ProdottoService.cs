using Links.OpenLending.Services.Common.Exception.Models;
using Links.OpenLending.Services.Common.Exception;
using ProjectWorkServiceCatalogo.BL.Interfaces;
using ProjectWorkServiceCatalogo.BL.Models;
using ProjectWorkServiceCatalogo.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectWorkServiceCatalogo.DL.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjectWorkServiceCatalogo.BL.Implementations
{
    public class ProdottoService : IProdottoService
    {
        private readonly CatalogoServiceDbContext _catalogoServiceDbContext;
        public ProdottoService (CatalogoServiceDbContext catalogoServiceDbContext)
        {
            _catalogoServiceDbContext = catalogoServiceDbContext;
        }

        public async Task<bool> Create(ProdottoDTO prodottoDTO)
        {
            bool exist = _catalogoServiceDbContext.TbProdotto.Any(p => p.Nome.ToLower() == prodottoDTO.Nome.ToLower());
            if (exist)
            {
                throw new BusinessException(new BusinessErrorDTO("Prodotto già presente", 400, "DUPLICATED"));
            }

            var prodotto = new TbProdotto()
            {
                Nome = prodottoDTO.Nome,
                Prezzo = prodottoDTO.Prezzo,
                IdCategoria = prodottoDTO.Categoria,
                Immagine = prodottoDTO.Immagine,
                Descrizione = prodottoDTO.Descrizione,
                Materiale = prodottoDTO.Materiale,
                Peso = prodottoDTO.Peso,
                Disponibilita = prodottoDTO.Disponibilita

            };

            await _catalogoServiceDbContext.TbProdotto.AddAsync(prodotto);
            await _catalogoServiceDbContext.SaveChangesAsync();
            return true;

        }

        public async Task<List<ProdottoDTO>> FindAll()
        {
            //bool isEmpty = _catalogoServiceDbContext.TbProdotto.Any();
            //if (isEmpty)
            //{
            //    throw new Exception("Nessun prodotto da visualizzare");
            //}

            var listaProdotti = await _catalogoServiceDbContext.TbProdotto.Select(prodotto => new ProdottoDTO()
            {
                Nome = prodotto.Nome,
                Prezzo = prodotto.Prezzo,
                Categoria = prodotto.IdCategoria,
                Immagine = prodotto.Immagine,
                Descrizione = prodotto.Descrizione,
                Materiale = prodotto.Materiale,
                Peso = prodotto.Peso,
                Disponibilita = prodotto.Disponibilita
            }).ToListAsync();
           
            
            return listaProdotti;
        }
        
        public async Task<ProdottoDTO> FindById(long id)
        {
            ProdottoDTO? prodotto = await _catalogoServiceDbContext.TbProdotto
                .Where(p => p.IdProdotto == id)
                .Select(prodotto => new ProdottoDTO()
                    {
                        Nome = prodotto.Nome,
                        Prezzo = prodotto.Prezzo,
                        Categoria = prodotto.IdCategoria,
                        Immagine = prodotto.Immagine,
                        Descrizione = prodotto.Descrizione,
                        Materiale = prodotto.Materiale,
                        Peso = prodotto.Peso,
                        Disponibilita = prodotto.Disponibilita
                })
                .FirstOrDefaultAsync();

            if (prodotto == null)
            {
                throw new BusinessException(new BusinessErrorDTO($"Prodotto con Id: {id} non trovato", 404, "NOT_FOUND"));
            }
            
            return prodotto;
        }

        public async Task<bool> Update(long id, ProdottoDTO prodottoDTO)
        {
            TbProdotto? prodotto = await _catalogoServiceDbContext.TbProdotto
                .Where(p => p.IdProdotto == id)
                .FirstOrDefaultAsync();

            if (prodotto == null)
            {
                throw new BusinessException(new BusinessErrorDTO($"Prodotto con Id: {id} non trovato", 404, "NOT_FOUND"));
            }

            prodotto.Nome = prodottoDTO.Nome ?? prodotto.Nome;
            prodotto.Descrizione = prodottoDTO.Descrizione ?? prodotto.Descrizione;
            prodotto.Disponibilita = prodottoDTO.Disponibilita ?? prodotto.Disponibilita;
            prodotto.Peso = prodottoDTO.Peso ?? prodotto.Peso;
            prodotto.Prezzo = prodottoDTO.Prezzo ?? prodotto.Prezzo;
            prodotto.Materiale = prodottoDTO.Materiale ?? prodotto.Materiale;
            prodotto.Immagine = prodottoDTO.Immagine ?? prodotto.Immagine;
            prodotto.IdCategoria = prodottoDTO.Categoria ?? prodotto.IdCategoria;


            _catalogoServiceDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool?> Delete(long id)
        {
            bool pr = _catalogoServiceDbContext.TbProdotto.Any(p => p.IdProdotto == id);
            if (!pr)
            {
                throw new BusinessException(new BusinessErrorDTO($"Prodotto con Id: {id} non trovato", 404, "NOT_FOUND"));
            }
            var prodotto = _catalogoServiceDbContext.TbProdotto.Where(p => p.IdProdotto.Equals(id)).FirstOrDefault();
            _catalogoServiceDbContext.Remove(prodotto);


            _catalogoServiceDbContext.SaveChangesAsync();

            return true;
        }

    }
}
