using AppTask.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppTask.Data.Map
{
    public class TaskMap : IEntityTypeConfiguration<TaskModels>
    {
        public void Configure(EntityTypeBuilder<TaskModels> builder)
        {
            builder.HasKey(task => task.Id);
            builder.Property(task => task.Name).IsRequired().HasMaxLength(255);
            builder.Property(task => task.Status).IsRequired();
        }
    }
}
