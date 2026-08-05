using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerSales.Data.Persistence.Migrations
{
    public partial class InitWithoutIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Drop FKs from Sales
            migrationBuilder.DropForeignKey("FK_Sales_Customers_CustomerId", "Sales");
            migrationBuilder.DropForeignKey("FK_Sales_Products_ProductId", "Sales");
            migrationBuilder.DropForeignKey("FK_Sales_Stores_StoreId", "Sales");
            migrationBuilder.DropForeignKey("FK_Sales_PaymentMethods_PaymentId", "Sales");

            // Customers
            migrationBuilder.DropPrimaryKey("PK_Customers", "Customers");
            migrationBuilder.DropColumn("CustomerId", "Customers");
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Customers",
                type: "int",
                nullable: false);
            migrationBuilder.AddPrimaryKey("PK_Customers", "Customers", "CustomerId");

            // Products
            migrationBuilder.DropPrimaryKey("PK_Products", "Products");
            migrationBuilder.DropColumn("ProductId", "Products");
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Products",
                type: "int",
                nullable: false);
            migrationBuilder.AddPrimaryKey("PK_Products", "Products", "ProductId");

            // Stores
            migrationBuilder.DropPrimaryKey("PK_Stores", "Stores");
            migrationBuilder.DropColumn("StoreId", "Stores");
            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "Stores",
                type: "int",
                nullable: false);
            migrationBuilder.AddPrimaryKey("PK_Stores", "Stores", "StoreId");

            // PaymentMethods
            migrationBuilder.DropPrimaryKey("PK_PaymentMethods", "PaymentMethods");
            migrationBuilder.DropColumn("PaymentId", "PaymentMethods");
            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "PaymentMethods",
                type: "int",
                nullable: false);
            migrationBuilder.AddPrimaryKey("PK_PaymentMethods", "PaymentMethods", "PaymentId");

            // Recreate FKs in Sales
            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Customers_CustomerId",
                table: "Sales",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Products_ProductId",
                table: "Sales",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Stores_StoreId",
                table: "Sales",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_PaymentMethods_PaymentId",
                table: "Sales",
                column: "PaymentId",
                principalTable: "PaymentMethods",
                principalColumn: "PaymentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drop FKs from Sales
            migrationBuilder.DropForeignKey("FK_Sales_Customers_CustomerId", "Sales");
            migrationBuilder.DropForeignKey("FK_Sales_Products_ProductId", "Sales");
            migrationBuilder.DropForeignKey("FK_Sales_Stores_StoreId", "Sales");
            migrationBuilder.DropForeignKey("FK_Sales_PaymentMethods_PaymentId", "Sales");

            // Customers back to Identity
            migrationBuilder.DropPrimaryKey("PK_Customers", "Customers");
            migrationBuilder.DropColumn("CustomerId", "Customers");
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Customers",
                type: "int",
                nullable: false)
                .Annotation("SqlServer:Identity", "1, 1");
            migrationBuilder.AddPrimaryKey("PK_Customers", "Customers", "CustomerId");

            // Products back to Identity
            migrationBuilder.DropPrimaryKey("PK_Products", "Products");
            migrationBuilder.DropColumn("ProductId", "Products");
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Products",
                type: "int",
                nullable: false)
                .Annotation("SqlServer:Identity", "1, 1");
            migrationBuilder.AddPrimaryKey("PK_Products", "Products", "ProductId");

            // Stores back to Identity
            migrationBuilder.DropPrimaryKey("PK_Stores", "Stores");
            migrationBuilder.DropColumn("StoreId", "Stores");
            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "Stores",
                type: "int",
                nullable: false)
                .Annotation("SqlServer:Identity", "1, 1");
            migrationBuilder.AddPrimaryKey("PK_Stores", "Stores", "StoreId");

            // PaymentMethods back to Identity
            migrationBuilder.DropPrimaryKey("PK_PaymentMethods", "PaymentMethods");
            migrationBuilder.DropColumn("PaymentId", "PaymentMethods");
            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "PaymentMethods",
                type: "int",
                nullable: false)
                .Annotation("SqlServer:Identity", "1, 1");
            migrationBuilder.AddPrimaryKey("PK_PaymentMethods", "PaymentMethods", "PaymentId");

            // Recreate FKs in Sales
            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Customers_CustomerId",
                table: "Sales",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Products_ProductId",
                table: "Sales",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Stores_StoreId",
                table: "Sales",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_PaymentMethods_PaymentId",
                table: "Sales",
                column: "PaymentId",
                principalTable: "PaymentMethods",
                principalColumn: "PaymentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
