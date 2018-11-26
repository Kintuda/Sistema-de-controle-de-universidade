namespace sistemaUniversidade.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teste : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cursoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                        inicioAula = c.DateTime(nullable: false),
                        Duracao = c.Int(nullable: false),
                        DepartamentoID = c.Int(nullable: false),
                        ProfessorID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Departamentoes", t => t.DepartamentoID, cascadeDelete: true)
                .ForeignKey("dbo.Professors", t => t.ProfessorID)
                .Index(t => t.DepartamentoID)
                .Index(t => t.ProfessorID);
            
            CreateTable(
                "dbo.Departamentoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Estudantes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Cidade = c.String(),
                        DataNascimento = c.DateTime(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        Sexo = c.Int(nullable: false),
                        Email = c.String(),
                        DepartamentoID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Departamentoes", t => t.DepartamentoID)
                .Index(t => t.DepartamentoID);
            
            CreateTable(
                "dbo.Professors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Formacao = c.Int(nullable: false),
                        Salario = c.Single(nullable: false),
                        Email = c.String(),
                        Telefone = c.String(),
                        DataContratacao = c.DateTime(nullable: false),
                        DepartamentoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Departamentoes", t => t.DepartamentoID, cascadeDelete: true)
                .Index(t => t.DepartamentoID);
            
            CreateTable(
                "dbo.EstudanteCursoes",
                c => new
                    {
                        Estudante_ID = c.Int(nullable: false),
                        Curso_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Estudante_ID, t.Curso_ID })
                .ForeignKey("dbo.Estudantes", t => t.Estudante_ID, cascadeDelete: true)
                .ForeignKey("dbo.Cursoes", t => t.Curso_ID, cascadeDelete: true)
                .Index(t => t.Estudante_ID)
                .Index(t => t.Curso_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Professors", "DepartamentoID", "dbo.Departamentoes");
            DropForeignKey("dbo.Cursoes", "ProfessorID", "dbo.Professors");
            DropForeignKey("dbo.Estudantes", "DepartamentoID", "dbo.Departamentoes");
            DropForeignKey("dbo.EstudanteCursoes", "Curso_ID", "dbo.Cursoes");
            DropForeignKey("dbo.EstudanteCursoes", "Estudante_ID", "dbo.Estudantes");
            DropForeignKey("dbo.Cursoes", "DepartamentoID", "dbo.Departamentoes");
            DropIndex("dbo.EstudanteCursoes", new[] { "Curso_ID" });
            DropIndex("dbo.EstudanteCursoes", new[] { "Estudante_ID" });
            DropIndex("dbo.Professors", new[] { "DepartamentoID" });
            DropIndex("dbo.Estudantes", new[] { "DepartamentoID" });
            DropIndex("dbo.Cursoes", new[] { "ProfessorID" });
            DropIndex("dbo.Cursoes", new[] { "DepartamentoID" });
            DropTable("dbo.EstudanteCursoes");
            DropTable("dbo.Professors");
            DropTable("dbo.Estudantes");
            DropTable("dbo.Departamentoes");
            DropTable("dbo.Cursoes");
        }
    }
}
