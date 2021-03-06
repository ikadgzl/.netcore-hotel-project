// <auto-generated />
using HotelProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HotelProject.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210630112028_DatabaseSeeded")]
    partial class DatabaseSeeded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("HotelProject.Data.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("ShortName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Turkey",
                            ShortName = "TR"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Germany",
                            ShortName = "GER"
                        },
                        new
                        {
                            Id = 3,
                            Name = "France",
                            ShortName = "FR"
                        });
                });

            modelBuilder.Entity("HotelProject.Data.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<int>("CountryId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<double>("Rating")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Hotel in Turkey, some address, 21, 12",
                            CountryId = 1,
                            Name = "Hotel in Turkey",
                            Rating = 7.2999999999999998
                        },
                        new
                        {
                            Id = 2,
                            Address = "Hotel in Germany, some address, 21, 12",
                            CountryId = 2,
                            Name = "Hotel in Germany",
                            Rating = 9.0
                        },
                        new
                        {
                            Id = 3,
                            Address = "Hotel in France, some address, 21, 12",
                            CountryId = 3,
                            Name = "Hotel in France",
                            Rating = 4.2999999999999998
                        });
                });

            modelBuilder.Entity("HotelProject.Data.Hotel", b =>
                {
                    b.HasOne("HotelProject.Data.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });
#pragma warning restore 612, 618
        }
    }
}
