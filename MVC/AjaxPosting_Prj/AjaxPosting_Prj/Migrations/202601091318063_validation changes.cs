namespace AjaxPosting_Prj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validationchanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "StudentName", c => c.String());
            AlterColumn("dbo.Students", "StudentAddress", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "StudentAddress", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "StudentName", c => c.String(nullable: false));
        }
    }
}
