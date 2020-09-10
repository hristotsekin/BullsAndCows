﻿namespace BullsAndCowsASPnet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inituserstable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        DateOfRegisration = c.DateTime(nullable: false),
                        Password = c.String(),
                        isEmailVerified = c.Boolean(nullable: false),
                        ActivationCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
