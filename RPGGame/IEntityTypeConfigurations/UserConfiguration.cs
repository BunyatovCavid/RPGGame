using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RPGGame.Domain.Entities;

namespace RPGGame.IEntityTypeConfigurations
{
    internal class UserConfiguration:IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(p => p.Name).IsRequired();

            builder.HasOne(p => p.Class)
                .WithOne(p => p.User)
                .HasForeignKey<User>(p => p.ClassID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p=> p.Race)
                .WithOne(p=>p.User)
                .HasForeignKey<User>(p=>p.RaceID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
