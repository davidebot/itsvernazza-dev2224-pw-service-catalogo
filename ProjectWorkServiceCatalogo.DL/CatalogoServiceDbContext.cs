using Microsoft.EntityFrameworkCore;
using ProjectWorkServiceCatalogo.DL.Models;

namespace ProjectWorkServiceCatalogo.DL
{
    public class CatalogoServiceDbContext : DbContext
    {
        public CatalogoServiceDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public virtual DbSet<TbCategoria> TbCategoria => Set<TbCategoria>();
    }
}