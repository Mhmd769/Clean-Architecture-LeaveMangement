﻿using HR.LeaveMangement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveMangment.Persistence.Configuration
{
    public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
    {
        public void Configure(EntityTypeBuilder<LeaveType> builder)
        {
            builder.HasData(
                new LeaveType
                {
                    Id = 1,
                    Name = "Vacation",
                    DefaultDays = 10,
                    DateModified = DateTime.Now,
                    DateCreated = DateTime.Now,
                }
            );

            builder.Property(q => q.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
