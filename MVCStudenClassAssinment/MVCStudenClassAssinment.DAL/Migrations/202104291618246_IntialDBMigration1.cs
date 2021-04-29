namespace MVCStudenClassAssinment.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntialDBMigration1 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.SchoolClassViewModel");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SchoolClassViewModel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
