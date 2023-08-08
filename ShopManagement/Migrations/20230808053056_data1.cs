using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopManagement.Migrations
{
    /// <inheritdoc />
    public partial class data1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetailPropertyDetail_ProductDetail_ProductDetailId",
                table: "ProductDetailPropertyDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetailPropertyDetail_Product_ProductId",
                table: "ProductDetailPropertyDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetailPropertyDetail_PropertyDetail_PropertyDetailId",
                table: "ProductDetailPropertyDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_Property_Product_ProductId",
                table: "Property");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyDetail_Property_PropertyId",
                table: "PropertyDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PropertyDetail",
                table: "PropertyDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Property",
                table: "Property");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductDetailPropertyDetail",
                table: "ProductDetailPropertyDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductDetail",
                table: "ProductDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.RenameTable(
                name: "PropertyDetail",
                newName: "PropertyDetails");

            migrationBuilder.RenameTable(
                name: "Property",
                newName: "Properties");

            migrationBuilder.RenameTable(
                name: "ProductDetailPropertyDetail",
                newName: "ProductDetailPropertyDetails");

            migrationBuilder.RenameTable(
                name: "ProductDetail",
                newName: "ProductDetails");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameIndex(
                name: "IX_PropertyDetail_PropertyId",
                table: "PropertyDetails",
                newName: "IX_PropertyDetails_PropertyId");

            migrationBuilder.RenameIndex(
                name: "IX_Property_ProductId",
                table: "Properties",
                newName: "IX_Properties_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductDetailPropertyDetail_PropertyDetailId",
                table: "ProductDetailPropertyDetails",
                newName: "IX_ProductDetailPropertyDetails_PropertyDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductDetailPropertyDetail_ProductId",
                table: "ProductDetailPropertyDetails",
                newName: "IX_ProductDetailPropertyDetails_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductDetailPropertyDetail_ProductDetailId",
                table: "ProductDetailPropertyDetails",
                newName: "IX_ProductDetailPropertyDetails_ProductDetailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PropertyDetails",
                table: "PropertyDetails",
                column: "PropertyDetailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Properties",
                table: "Properties",
                column: "PropertyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductDetailPropertyDetails",
                table: "ProductDetailPropertyDetails",
                column: "ProductDetailPropertyDetailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductDetails",
                table: "ProductDetails",
                column: "ProductDetailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetailPropertyDetails_ProductDetails_ProductDetailId",
                table: "ProductDetailPropertyDetails",
                column: "ProductDetailId",
                principalTable: "ProductDetails",
                principalColumn: "ProductDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetailPropertyDetails_Products_ProductId",
                table: "ProductDetailPropertyDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetailPropertyDetails_PropertyDetails_PropertyDetailId",
                table: "ProductDetailPropertyDetails",
                column: "PropertyDetailId",
                principalTable: "PropertyDetails",
                principalColumn: "PropertyDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Products_ProductId",
                table: "Properties",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyDetails_Properties_PropertyId",
                table: "PropertyDetails",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "PropertyId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetailPropertyDetails_ProductDetails_ProductDetailId",
                table: "ProductDetailPropertyDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetailPropertyDetails_Products_ProductId",
                table: "ProductDetailPropertyDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetailPropertyDetails_PropertyDetails_PropertyDetailId",
                table: "ProductDetailPropertyDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Products_ProductId",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyDetails_Properties_PropertyId",
                table: "PropertyDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PropertyDetails",
                table: "PropertyDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Properties",
                table: "Properties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductDetails",
                table: "ProductDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductDetailPropertyDetails",
                table: "ProductDetailPropertyDetails");

            migrationBuilder.RenameTable(
                name: "PropertyDetails",
                newName: "PropertyDetail");

            migrationBuilder.RenameTable(
                name: "Properties",
                newName: "Property");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "ProductDetails",
                newName: "ProductDetail");

            migrationBuilder.RenameTable(
                name: "ProductDetailPropertyDetails",
                newName: "ProductDetailPropertyDetail");

            migrationBuilder.RenameIndex(
                name: "IX_PropertyDetails_PropertyId",
                table: "PropertyDetail",
                newName: "IX_PropertyDetail_PropertyId");

            migrationBuilder.RenameIndex(
                name: "IX_Properties_ProductId",
                table: "Property",
                newName: "IX_Property_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductDetailPropertyDetails_PropertyDetailId",
                table: "ProductDetailPropertyDetail",
                newName: "IX_ProductDetailPropertyDetail_PropertyDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductDetailPropertyDetails_ProductId",
                table: "ProductDetailPropertyDetail",
                newName: "IX_ProductDetailPropertyDetail_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductDetailPropertyDetails_ProductDetailId",
                table: "ProductDetailPropertyDetail",
                newName: "IX_ProductDetailPropertyDetail_ProductDetailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PropertyDetail",
                table: "PropertyDetail",
                column: "PropertyDetailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Property",
                table: "Property",
                column: "PropertyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductDetail",
                table: "ProductDetail",
                column: "ProductDetailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductDetailPropertyDetail",
                table: "ProductDetailPropertyDetail",
                column: "ProductDetailPropertyDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetailPropertyDetail_ProductDetail_ProductDetailId",
                table: "ProductDetailPropertyDetail",
                column: "ProductDetailId",
                principalTable: "ProductDetail",
                principalColumn: "ProductDetailId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetailPropertyDetail_Product_ProductId",
                table: "ProductDetailPropertyDetail",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetailPropertyDetail_PropertyDetail_PropertyDetailId",
                table: "ProductDetailPropertyDetail",
                column: "PropertyDetailId",
                principalTable: "PropertyDetail",
                principalColumn: "PropertyDetailId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Property_Product_ProductId",
                table: "Property",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyDetail_Property_PropertyId",
                table: "PropertyDetail",
                column: "PropertyId",
                principalTable: "Property",
                principalColumn: "PropertyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
