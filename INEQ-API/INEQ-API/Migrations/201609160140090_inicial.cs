namespace INEQ_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brand",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Component",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Active = c.Boolean(nullable: false),
                        ComponentTypeId = c.Int(nullable: false),
                        EquipmentId = c.Int(nullable: false),
                        EquipmentTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ComponentType", t => t.ComponentTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Equipament", t => t.EquipmentId, cascadeDelete: true)
                .ForeignKey("dbo.EquipamentType", t => t.EquipmentTypeId, cascadeDelete: true)
                .Index(t => t.ComponentTypeId)
                .Index(t => t.EquipmentId)
                .Index(t => t.EquipmentTypeId);
            
            CreateTable(
                "dbo.ComponentType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Equipament",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EquipmentTypeId = c.Int(nullable: false),
                        ModelId = c.Int(nullable: false),
                        BrandId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        WarehouseId = c.Int(nullable: false),
                        EntryDate = c.DateTime(nullable: false),
                        Serie = c.String(),
                        SofttekId = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brand", t => t.BrandId, cascadeDelete: true)
                .ForeignKey("dbo.EquipamentType", t => t.EquipmentTypeId, cascadeDelete: false)
                .ForeignKey("dbo.Model", t => t.ModelId, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .ForeignKey("dbo.Warehouse", t => t.WarehouseId, cascadeDelete: true)
                .Index(t => t.EquipmentTypeId)
                .Index(t => t.ModelId)
                .Index(t => t.BrandId)
                .Index(t => t.StatusId)
                .Index(t => t.WarehouseId);
            
            CreateTable(
                "dbo.EquipamentType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        UsefulLife = c.Single(nullable: false),
                        GuaranteeDuration = c.Single(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Model",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Active = c.Boolean(nullable: false),
                        BrandId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brand", t => t.BrandId, cascadeDelete: false)
                .Index(t => t.BrandId);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Warehouse",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        IS = c.String(),
                        Responsable = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Component", "EquipmentTypeId", "dbo.EquipamentType");
            DropForeignKey("dbo.Component", "EquipmentId", "dbo.Equipament");
            DropForeignKey("dbo.Equipament", "WarehouseId", "dbo.Warehouse");
            DropForeignKey("dbo.Equipament", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Equipament", "ModelId", "dbo.Model");
            DropForeignKey("dbo.Model", "BrandId", "dbo.Brand");
            DropForeignKey("dbo.Equipament", "EquipmentTypeId", "dbo.EquipamentType");
            DropForeignKey("dbo.Equipament", "BrandId", "dbo.Brand");
            DropForeignKey("dbo.Component", "ComponentTypeId", "dbo.ComponentType");
            DropIndex("dbo.Model", new[] { "BrandId" });
            DropIndex("dbo.Equipament", new[] { "WarehouseId" });
            DropIndex("dbo.Equipament", new[] { "StatusId" });
            DropIndex("dbo.Equipament", new[] { "BrandId" });
            DropIndex("dbo.Equipament", new[] { "ModelId" });
            DropIndex("dbo.Equipament", new[] { "EquipmentTypeId" });
            DropIndex("dbo.Component", new[] { "EquipmentTypeId" });
            DropIndex("dbo.Component", new[] { "EquipmentId" });
            DropIndex("dbo.Component", new[] { "ComponentTypeId" });
            DropTable("dbo.User");
            DropTable("dbo.Warehouse");
            DropTable("dbo.Status");
            DropTable("dbo.Model");
            DropTable("dbo.EquipamentType");
            DropTable("dbo.Equipament");
            DropTable("dbo.ComponentType");
            DropTable("dbo.Component");
            DropTable("dbo.Brand");
        }
    }
}
