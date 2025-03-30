using Company.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data.Context.Configurations
{
    class EmployeeConfigurations : IEntityTypeConfiguration<EmployeeViewModel>
    {
        public void Configure(EntityTypeBuilder<EmployeeViewModel> builder)
        {
            builder.Property(e => e.Name)
                   .IsRequired()
                   .HasMaxLength(50);
        }
    }
}
