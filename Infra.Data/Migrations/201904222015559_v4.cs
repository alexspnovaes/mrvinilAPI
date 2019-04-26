namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Client", "UserName", c => c.String(maxLength: 8000, unicode: false));
            AddColumn("dbo.Client", "Email", c => c.String(maxLength: 8000, unicode: false));
            AddColumn("dbo.Client", "Password", c => c.String(maxLength: 8000, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Client", "Password");
            DropColumn("dbo.Client", "Email");
            DropColumn("dbo.Client", "UserName");
        }
    }
}
