using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RPGGame.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame.IEntityTypeConfigurations
{
    internal class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.Property(p => p.Name).IsRequired();
            builder.HasKey(p => p.Name);

            builder.HasOne(p => p.CardType).
                WithOne(p=>p.Card).
                HasForeignKey<Card>(p => p.CardTypeID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Inventory)
                .WithOne(p => p.Card)
                .HasForeignKey<Inventory>(p => p.CardName)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
