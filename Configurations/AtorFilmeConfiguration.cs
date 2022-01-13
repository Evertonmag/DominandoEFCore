using DominandoEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominandoEFCore.Configurations
{
    public class AtorFilmeConfiguration : IEntityTypeConfiguration<Ator>
    {
        public void Configure(EntityTypeBuilder<Ator> builder)
        {
            /*
            builder
                .HasMany(p => p.Filmes)
                .WithMany(p => p.Atores)
                .UsingEntity(p=>p.ToTable("AtoresFilmes"));
            */
            builder
                .HasMany(p => p.Filmes)
                .WithMany(p => p.Atores)
                .UsingEntity<Dictionary<string, object>>(
                    "FilmesAtores",
                    p=>p.HasOne<Filme>().WithMany().HasForeignKey("FilmeID"),
                    p=>p.HasOne<Ator>().WithMany().HasForeignKey("AtorID"),
                    p =>
                    {
                        p.Property<DateTime>("CadastradoEm").HasDefaultValueSql("GETDATE()");
                    }
                );
        }
    }
}
