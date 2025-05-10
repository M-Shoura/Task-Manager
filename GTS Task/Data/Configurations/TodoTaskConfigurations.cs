using GTS_Task.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GTS_Task.Data.Configurations
{
    public class TodoTaskConfigurations : IEntityTypeConfiguration<TodoTask>
    {
        public void Configure(EntityTypeBuilder<TodoTask> builder)
        {
            builder.Property(o => o.Status)
                .HasConversion(
                    x => x.ToString(),                                        
                    x => (Status)Enum.Parse(typeof(Status), x)                 
                );

            builder.Property(o => o.Priority)
                .HasConversion(
                    x => x.ToString(),                                        
                    x => (Priority)Enum.Parse(typeof(Priority), x)             
                );
        }
    }
}
