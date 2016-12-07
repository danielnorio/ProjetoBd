using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProjetoDeBancoDeDados.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dependente",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CPF = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    RG = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependente", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CPF = table.Column<string>(nullable: true),
                    Cargo = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    RG = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PlanoOdontologico",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Numero = table.Column<int>(nullable: false),
                    Tipo = table.Column<string>(nullable: true),
                    Titular = table.Column<string>(nullable: true),
                    Validade = table.Column<DateTime>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanoOdontologico", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PlanoSaude",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Numero = table.Column<int>(nullable: false),
                    Tipo = table.Column<string>(nullable: true),
                    Titular = table.Column<string>(nullable: true),
                    Validade = table.Column<DateTime>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanoSaude", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Seguradora",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CNPJ = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Endereco = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seguradora", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SeguroAcidente",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Numero = table.Column<int>(nullable: false),
                    Tipo = table.Column<string>(nullable: true),
                    Titular = table.Column<string>(nullable: true),
                    Validade = table.Column<DateTime>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeguroAcidente", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Unidade",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Departamento = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Endereco = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unidade", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dependente");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "PlanoOdontologico");

            migrationBuilder.DropTable(
                name: "PlanoSaude");

            migrationBuilder.DropTable(
                name: "Seguradora");

            migrationBuilder.DropTable(
                name: "SeguroAcidente");

            migrationBuilder.DropTable(
                name: "Unidade");
        }
    }
}
