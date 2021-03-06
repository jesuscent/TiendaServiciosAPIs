// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TiendaServicios.api.CarritoCompra.Persistencia;

namespace TiendaServicios.api.CarritoCompra.Migrations
{
    [DbContext(typeof(ContextoCarrito))]
    partial class ContextoCarritoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TiendaServicios.api.CarritoCompra.Modelo.CarritoSession", b =>
                {
                    b.Property<int>("CarritoSessionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.HasKey("CarritoSessionId");

                    b.ToTable("CarritoSession");
                });

            modelBuilder.Entity("TiendaServicios.api.CarritoCompra.Modelo.CarritoSessionDetalle", b =>
                {
                    b.Property<int>("CarritoSessionDetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CarritoSesionId")
                        .HasColumnType("int");

                    b.Property<int?>("CarritoSessionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<string>("ProductoSeleccionado")
                        .HasColumnType("text");

                    b.HasKey("CarritoSessionDetalleId");

                    b.HasIndex("CarritoSessionId");

                    b.ToTable("CarritoSessionDetalle");
                });

            modelBuilder.Entity("TiendaServicios.api.CarritoCompra.Modelo.CarritoSessionDetalle", b =>
                {
                    b.HasOne("TiendaServicios.api.CarritoCompra.Modelo.CarritoSession", "CarritoSession")
                        .WithMany("ListaDetalle")
                        .HasForeignKey("CarritoSessionId");
                });
#pragma warning restore 612, 618
        }
    }
}
