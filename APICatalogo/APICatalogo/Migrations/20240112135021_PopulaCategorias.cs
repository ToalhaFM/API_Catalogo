using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    /// <inheritdoc />
    public partial class PopulaCategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Categorias(CategoriaName, ImagemUrl)" +
                "Value('Bebidas', 'bebidas.jpg')");
            mb.Sql("Insert into Categorias(CategoriaName, ImagemUrl)" +
                "Value('Lanches', 'lanches.jpg')");
            mb.Sql("Insert into Categorias(CategoriaName, ImagemUrl)" +
                "Value('Sobremesas', 'sobremesa.jpg')");
            mb.Sql("Insert into Categorias(CategoriaName, ImagemUrl)" +
                "Value('Açaí', 'acai.jpg')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from categorias");
        }
    }
}
