using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWorkServiceCatalogo.BL.Models
{
    public class ProdottoDTO
    {
        public ProdottoDTO() { }
        public long Id { get; set; }
        public string Nome { get; set; }
        public long? Categoria { get; set; }
        public decimal? Prezzo { get; set; }
        public decimal? Peso { get; set; } 
        public int? Disponibilita { get; set; }
        public string? Descrizione { get; set; }
        public string? Immagine { get; set; }        
        public string? Materiale { get; set; } 
        

    }
}
