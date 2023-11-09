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
        public string Nome { get; set; } = string.Empty;


        [Required]
        [Column("FK_CATEGORIA")]
        [MaxLength(50)]
        public long FkCategoria { get; set; }

        [ForeignKey(nameof(FkCategoria))]
        public virtual TbCategoria FkCategoriaNavigation { get; set; } = null!;

        [Required]
        [Column("PREZZO")]
        public decimal Prezzo { get; set; } = 0;

        [Column("PESO")]
        public decimal? Peso { get; set; } = null;

        [Required]
        [Column("DISPONIBILITA")]
        public int Disponibilita { get; set; } = 0;

        [Column("DESCRIZIONE")]
        public string? Descrizione { get; set; } = null;

        [Column("IMMAGINE")]
        public string? Immagine { get; set; } = null;

        [Column("MATERIALE")]
        public string? Materiale { get; set; } = null;

    }
}
