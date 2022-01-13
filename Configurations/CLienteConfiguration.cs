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
    public class CLienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            // Owned Types
            builder.OwnsOne(x => x.Endereco, end =>
                {
                    end.Property(p => p.Bairro).HasColumnName("Bairro");
                    end.Property(p => p.Cidade).HasColumnName("Cidade");
                    end.Property(p => p.Estado).HasColumnName("Estado");

                    end.ToTable("Endereco");
                });
        }
    }
}
