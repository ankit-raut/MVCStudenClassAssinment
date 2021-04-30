namespace MVCStudenClassAssinment.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntialDBMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ParentStudent",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Parent_Id = c.Int(),
                        Student_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.Parent_Id)
                .ForeignKey("dbo.User", t => t.Student_Id)
                .Index(t => t.Parent_Id)
                .Index(t => t.Student_Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        UserType = c.Int(nullable: false),
                        Email = c.String(),
                        Phone = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SchoolClass",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentClass",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Class_Id = c.Int(),
                        Student_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SchoolClass", t => t.Class_Id)
                .ForeignKey("dbo.User", t => t.Student_Id)
                .Index(t => t.Class_Id)
                .Index(t => t.Student_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentClass", "Student_Id", "dbo.User");
            DropForeignKey("dbo.StudentClass", "Class_Id", "dbo.SchoolClass");
            DropForeignKey("dbo.ParentStudent", "Student_Id", "dbo.User");
            DropForeignKey("dbo.ParentStudent", "Parent_Id", "dbo.User");
            DropIndex("dbo.StudentClass", new[] { "Student_Id" });
            DropIndex("dbo.StudentClass", new[] { "Class_Id" });
            DropIndex("dbo.ParentStudent", new[] { "Student_Id" });
            DropIndex("dbo.ParentStudent", new[] { "Parent_Id" });
            DropTable("dbo.StudentClass");
            DropTable("dbo.SchoolClass");
            DropTable("dbo.User");
            DropTable("dbo.ParentStudent");
        }
    }
}
