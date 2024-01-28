using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    /// <inheritdoc />
    public partial class PopulaProdutos2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Produtos(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId)" +
               "Value('Coca-Cola', 'Refrigerante de Cola 350ml', 5.45, 'cocacola.jpg', 50, now(), 4)");
            mb.Sql("Insert into Produtos(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId)" +
                "Value('Coca-Cola', 'Refrigerante de Cola 2l', 9.50, 'cocacola2l.jpg', 70, now(), 4)");
            mb.Sql("Insert into Produtos(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId)" +
                "Value('Guaraná Antática', 'Refrigerante de Guaraná 2l', 10.00, 'GuaranaAntatica2l.jpg', 50, now(), 4)");
            mb.Sql("Insert into Produtos(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId)" +
                "Value('Guaraná Antática', 'Refrigerante de Guaraná 350ml', 5.45, 'GuaranaAntatica.jpg', 60, now(), 4)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Produtos");
        }
    }
}
