using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BlueCaiCms.Data.EF;

namespace BlueCaiCms.Data.EF.Migrations
{
    [DbContext(typeof(BCDbContext))]
    partial class BCDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BlueCaiCms.Model.Class", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateTime");

                    b.Property<DateTime?>("EditTime");

                    b.Property<int>("Grade");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.Property<DateTime?>("RemoveTime");

                    b.HasKey("Id");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("BlueCaiCms.Model.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<Guid?>("ClassId");

                    b.Property<DateTime>("CreateTime");

                    b.Property<DateTime?>("EditTime");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.Property<string>("NickName");

                    b.Property<DateTime?>("RemoveTime");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("BlueCaiCms.Model.Student", b =>
                {
                    b.HasOne("BlueCaiCms.Model.Class", "Class")
                        .WithMany("Students")
                        .HasForeignKey("ClassId");
                });
        }
    }
}
