namespace FluentAPI_Prj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DId = c.Int(nullable: false, identity: true),
                        DName = c.String(),
                    })
                .PrimaryKey(t => t.DId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Salary = c.Double(nullable: false),
                        Departments_DId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.Departments_DId)
                .Index(t => t.Departments_DId);
            
            CreateStoredProcedure(
                "dbo.InsertEmployeeProc",
                p => new
                    {
                        Name = p.String(),
                        Salary = p.Double(),
                        Departments_DId = p.Int(),
                    },
                body:
                    @"INSERT [dbo].[Employees]([Name], [Salary], [Departments_DId])
                      VALUES (@Name, @Salary, @Departments_DId)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[Employees]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[Employees] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.UpdateemployeeProc",
                p => new
                    {
                        Id = p.Int(),
                        Name = p.String(),
                        Salary = p.Double(),
                        Departments_DId = p.Int(),
                    },
                body:
                    @"UPDATE [dbo].[Employees]
                      SET [Name] = @Name, [Salary] = @Salary, [Departments_DId] = @Departments_DId
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.DeleteEmployeeProc",
                p => new
                    {
                        Id = p.Int(),
                        Departments_DId = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Employees]
                      WHERE (([Id] = @Id) AND (([Departments_DId] = @Departments_DId) OR ([Departments_DId] IS NULL AND @Departments_DId IS NULL)))"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.DeleteEmployeeProc");
            DropStoredProcedure("dbo.UpdateemployeeProc");
            DropStoredProcedure("dbo.InsertEmployeeProc");
            DropForeignKey("dbo.Employees", "Departments_DId", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "Departments_DId" });
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
        }
    }
}
