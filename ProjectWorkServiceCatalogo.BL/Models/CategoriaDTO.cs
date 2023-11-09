namespace ProjectWorkServiceCatalogo.BL.Models
{
    public class CategoriaDTO
    {
        public CategoriaDTO()
        {
        }
        public CategoriaDTO(long id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public long Id { get; set; } = 0;

        public string Nome { get; set; } = string.Empty;
    }
}

