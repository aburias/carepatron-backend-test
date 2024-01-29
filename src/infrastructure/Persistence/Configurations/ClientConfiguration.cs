using domain.Clients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructure.Persistence.Configurations
{
    internal class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).HasConversion(
                clientId => clientId.Value,
                value => new ClientId(value)).IsRequired();

            builder.Property(c => c.Email).HasConversion(
                clientEmail => clientEmail.Value,
                value => new Email(value)).IsRequired();

            builder.Property(c => c.PhoneNumber).HasConversion(
                phoneNumber => phoneNumber.Value,
                value => new PhoneNumber(value)).IsRequired();

            builder.OwnsOne(c => c.Name,
                nameBuilder =>
                {
                    nameBuilder.Property(n => n.FirstName).IsRequired();
                    nameBuilder.Property(n => n.LastName).IsRequired();
                });
        }
    }
}
