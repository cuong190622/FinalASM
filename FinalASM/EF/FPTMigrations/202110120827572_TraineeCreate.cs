namespace FinalASM.EF.FPTMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TraineeCreate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Trainee", "Name", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Trainee", "Education", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Trainee", "Education", c => c.String(maxLength: 20));
            AlterColumn("dbo.Trainee", "Name", c => c.String(maxLength: 25));
        }
    }
}
