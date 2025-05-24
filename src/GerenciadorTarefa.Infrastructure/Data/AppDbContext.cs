using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GerenciadorTarefa.Domain.Entities;

namespace GerenciadorTarefa.Infrastructure.Data
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarefa>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Titulo)
                  .IsRequired()
                  .HasMaxLength(100);

                entity.Property(t => t.DataCriacao)
                      .HasDefaultValueSql("GETDATE()");

            });
        }


    }

}
