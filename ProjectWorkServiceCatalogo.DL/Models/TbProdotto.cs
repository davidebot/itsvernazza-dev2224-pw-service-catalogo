using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWorkServiceCatalogo.DL.Models
{
    [Table("PRODOTTO")]
    public class TbProdotto
    {
        public TbProdotto() { }

        [Key]
        [Column("ID")]
        public long IdProdotto { get; set; }

        [Required]
        [Column("NOME")]
        [MaxLength(100)]
        public string? Nome { get; set; } = string.Empty;

        
        [Required]
        [Column("IDCATEGORIA")]
        [MaxLength(50)]
        public long? IdCategoria { get; set; }

        [ForeignKey(nameof(IdCategoria))]
        public virtual TbCategoria IdCatNavigation { get; set; } = null!;

        [Required]
        [Column("PREZZO")]
        public decimal? Prezzo { get; set; } = decimal.Zero;

        
        [Column("PESO")]
        public decimal? Peso { get; set; } = decimal.Zero;

        [Required]
        [Column("DISPONIBILITA")]
        public int? Disponibilita { get; set; }

        
        [Column("DESCRIZIONE")]
        public string? Descrizione { get; set; } = string.Empty;
        
        
        [Column("IMMAGINE")]
        public string? Immagine { get; set; } = string.Empty;
        
        
        [Column("MATERIALE")]
        public string? Materiale { get; set; } = string.Empty;






    }
}
