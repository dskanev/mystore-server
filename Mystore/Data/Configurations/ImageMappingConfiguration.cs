using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mystore.Api.Data.Models.Nomenclature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mystore.Api.Data.Configurations
{
    public class ImageMappingConfiguration : IEntityTypeConfiguration<ImageMapping>
    {
        public void Configure(EntityTypeBuilder<ImageMapping> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .HasOne(x => x.Project);
        }
    }
}
