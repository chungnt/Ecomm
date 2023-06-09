using FluentMigrator;

namespace Ecomm.Data
{
	[Migration(20230507232552)]
	public class InitialMigration : Migration
	{
		public override void Up()
		{
			Create.Table("product")
				.WithColumn("id").AsInt32().NotNullable().PrimaryKey().Identity()
				.WithColumn("sku").AsString(50).NotNullable()
                .WithColumn("name").AsString().NotNullable()
                .WithColumn("description").AsString()
                .WithColumn("created_date").AsDateTime().NotNullable().WithDefaultValue(DateTime.Now)
                .WithColumn("created_by").AsString().NotNullable()
                .WithColumn("updated_date").AsDateTime()
                .WithColumn("updated_by").AsString();
		}

		public override void Down()
		{
            Delete.Table("product");
        }
	}
}  