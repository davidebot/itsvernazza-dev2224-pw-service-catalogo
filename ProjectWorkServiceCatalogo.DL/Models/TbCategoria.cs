using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectWorkServiceCatalogo.DL.Models
{
    [Table("CATEGORIA")]
    public class TbCategoria
    {
        public TbCategoria() { }

        [Key]
        [Column("ID")]
        public long IdCategoria { get; set; }

        [Required]
        [Column("NOME")]
        [MaxLength(100)]
        public string Nome { get; set; } = string.Empty;
    }
}

