using Editoria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Editoria.Infrastructure.Persistence.Configurations;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.Property(a=>a.Name)
            .HasMaxLength(50)
            .IsRequired();
        
        builder.Property(a=>a.Surname)
            .HasMaxLength(50)
            .IsRequired();
    }
}