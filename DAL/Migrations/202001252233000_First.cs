namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(
                "dbo.SpSelect",
                p => new
                {

                },
                body:
                    @"Select * from Products"
            );
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.SpSelect");
        }
    }
}
