﻿using Company.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data.Context.Configurations
{
    class DepartmentConfigurations : IEntityTypeConfiguration<DepartmentViewModel>
    {
        public void Configure(EntityTypeBuilder<DepartmentViewModel> builder)
        {
            builder.Property(e => e.Id)
                   .UseIdentityColumn(10,10);
            builder.HasIndex(e => e.Name)
                   .IsUnique();
                   
        }
    }
}
