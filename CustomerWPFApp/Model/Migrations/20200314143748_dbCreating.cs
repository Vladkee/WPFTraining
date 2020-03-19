using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class dbCreating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "production");

            migrationBuilder.EnsureSchema(
                name: "sales");

            migrationBuilder.CreateTable(
                name: "brands",
                schema: "production",
                columns: table => new
                {
                    brand_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    brand_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_brands", x => x.brand_id);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                schema: "production",
                columns: table => new
                {
                    category_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.category_id);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                schema: "sales",
                columns: table => new
                {
                    customer_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(nullable: true),
                    last_name = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    street = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    zip_code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.customer_id);
                });

            migrationBuilder.CreateTable(
                name: "stores",
                schema: "sales",
                columns: table => new
                {
                    store_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    store_name = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    street = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    zip_code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stores", x => x.store_id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                schema: "production",
                columns: table => new
                {
                    product_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_name = table.Column<string>(nullable: true),
                    brand_id = table.Column<int>(nullable: false),
                    category_id = table.Column<int>(nullable: false),
                    model_year = table.Column<int>(nullable: false),
                    list_price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.product_id);
                    table.ForeignKey(
                        name: "FK_products_brands_brand_id",
                        column: x => x.brand_id,
                        principalSchema: "production",
                        principalTable: "brands",
                        principalColumn: "brand_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_products_categories_category_id",
                        column: x => x.category_id,
                        principalSchema: "production",
                        principalTable: "categories",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "staffs",
                schema: "sales",
                columns: table => new
                {
                    staff_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(nullable: true),
                    last_name = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    active = table.Column<bool>(nullable: false),
                    manager_id = table.Column<int>(nullable: true),
                    store_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_staffs", x => x.staff_id);
                    table.ForeignKey(
                        name: "FK_staffs_stores_store_id",
                        column: x => x.store_id,
                        principalSchema: "sales",
                        principalTable: "stores",
                        principalColumn: "store_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "stocks",
                schema: "production",
                columns: table => new
                {
                    store_id = table.Column<int>(nullable: false),
                    product_id = table.Column<int>(nullable: false),
                    quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stocks", x => new { x.store_id, x.product_id });
                    table.ForeignKey(
                        name: "FK_stocks_products_product_id",
                        column: x => x.product_id,
                        principalSchema: "production",
                        principalTable: "products",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_stocks_stores_store_id",
                        column: x => x.store_id,
                        principalSchema: "sales",
                        principalTable: "stores",
                        principalColumn: "store_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                schema: "sales",
                columns: table => new
                {
                    order_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_id = table.Column<int>(nullable: false),
                    order_status = table.Column<string>(nullable: true),
                    order_date = table.Column<DateTime>(nullable: false),
                    required_date = table.Column<DateTime>(nullable: false),
                    shipped_date = table.Column<DateTime>(nullable: false),
                    store_id = table.Column<int>(nullable: false),
                    staff_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.order_id);
                    table.ForeignKey(
                        name: "FK_orders_customers_customer_id",
                        column: x => x.customer_id,
                        principalSchema: "sales",
                        principalTable: "customers",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orders_staffs_staff_id",
                        column: x => x.staff_id,
                        principalSchema: "sales",
                        principalTable: "staffs",
                        principalColumn: "staff_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orders_stores_store_id",
                        column: x => x.store_id,
                        principalSchema: "sales",
                        principalTable: "stores",
                        principalColumn: "store_id");
                });

            migrationBuilder.CreateTable(
                name: "orders_items",
                schema: "sales",
                columns: table => new
                {
                    order_id = table.Column<int>(nullable: false),
                    product_id = table.Column<int>(nullable: false),
                    quantity = table.Column<int>(nullable: false),
                    list_price = table.Column<decimal>(nullable: false),
                    discount = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders_items", x => new { x.order_id, x.product_id });
                    table.ForeignKey(
                        name: "FK_orders_items_orders_order_id",
                        column: x => x.order_id,
                        principalSchema: "sales",
                        principalTable: "orders",
                        principalColumn: "order_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orders_items_products_product_id",
                        column: x => x.product_id,
                        principalSchema: "production",
                        principalTable: "products",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "production",
                table: "brands",
                columns: new[] { "brand_id", "brand_name" },
                values: new object[,]
                {
                    { 1, "Apple" },
                    { 2, "ASUS" },
                    { 3, "Acer" }
                });

            migrationBuilder.InsertData(
                schema: "production",
                table: "categories",
                columns: new[] { "category_id", "category_name" },
                values: new object[,]
                {
                    { 1, "Phone" },
                    { 2, "Notebook" }
                });

            migrationBuilder.InsertData(
                schema: "sales",
                table: "customers",
                columns: new[] { "customer_id", "city", "email", "first_name", "last_name", "phone", "state", "street", "zip_code" },
                values: new object[,]
                {
                    { 1, "Odesa", "fedko@gmail.com", "Nikolay", "Fedko", "+380665338211", "Default", "Nekimora, 101", "51095" },
                    { 2, "Lviv", "pepela@gmail.com", "Dmitriy", "Pelepa", "+380661125312", "Default", "Svetlaya, 101", "41111" },
                    { 3, "Kharkiv", "boy777@gmail.com", "Oleg", "Reshetilo", "+380501460586", "Default", "Zernovaya, 85", "61194" },
                    { 4, "Kharkiv", "kasat@gmail.com", "Alexey", "Kasatkin", "+380663110984", "Default", "Akademika, 1", "61095" }
                });

            migrationBuilder.InsertData(
                schema: "sales",
                table: "stores",
                columns: new[] { "store_id", "city", "email", "phone", "state", "store_name", "street", "zip_code" },
                values: new object[,]
                {
                    { 1, "Kyiv", "n.shop@gmail.com", "+380578445793", "Default", "North Shop", "Shevchenko, 14", "55483" },
                    { 2, "Kharkiv", "s.shop@gmail.com", "+380578445790", "Default", "South Shop", "Naukova, 20", "61111" }
                });

            migrationBuilder.InsertData(
                schema: "production",
                table: "products",
                columns: new[] { "product_id", "brand_id", "category_id", "list_price", "model_year", "product_name" },
                values: new object[,]
                {
                    { 1, 1, 1, 20000.00m, 2018, "IPhone X" },
                    { 2, 1, 1, 15000.00m, 2018, "IPhone 8" },
                    { 3, 1, 1, 10000.00m, 2017, "IPhone 7" },
                    { 4, 2, 2, 21000.00m, 2018, "Notebook 15" },
                    { 5, 3, 2, 17000.00m, 2015, "Butterfly 19" }
                });

            migrationBuilder.InsertData(
                schema: "sales",
                table: "staffs",
                columns: new[] { "staff_id", "email", "first_name", "active", "last_name", "manager_id", "phone", "store_id" },
                values: new object[,]
                {
                    { 1, "vlad@gmail.com", "Vlad", true, "Radchenko", null, "+380990527544", 1 },
                    { 2, "roman@gmail.com", "Roman", true, "Sokolenko", 1, "+380506447544", 1 },
                    { 3, "andrey@gmail.com", "Andrey", true, "Fedorchenko", 1, "+380993349763", 2 },
                    { 4, "tanya@gmail.com", "Tanya", true, "Ryzyk", 1, "+380991144267", 2 }
                });

            migrationBuilder.InsertData(
                schema: "production",
                table: "stocks",
                columns: new[] { "store_id", "product_id", "quantity" },
                values: new object[,]
                {
                    { 1, 1, 50 },
                    { 1, 2, 25 },
                    { 2, 3, 100 }
                });

            migrationBuilder.InsertData(
                schema: "sales",
                table: "orders",
                columns: new[] { "order_id", "customer_id", "order_date", "order_status", "required_date", "shipped_date", "staff_id", "store_id" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 3, 14, 16, 37, 47, 223, DateTimeKind.Local).AddTicks(4913), "Delivered", new DateTime(2020, 3, 14, 16, 37, 47, 227, DateTimeKind.Local).AddTicks(523), new DateTime(2020, 3, 14, 16, 37, 47, 227, DateTimeKind.Local).AddTicks(1409), 1, 1 },
                    { 2, 1, new DateTime(2020, 3, 14, 16, 37, 47, 227, DateTimeKind.Local).AddTicks(3427), "Delivered", new DateTime(2020, 3, 14, 16, 37, 47, 227, DateTimeKind.Local).AddTicks(3468), new DateTime(2020, 3, 14, 16, 37, 47, 227, DateTimeKind.Local).AddTicks(3485), 2, 1 },
                    { 3, 2, new DateTime(2020, 3, 14, 16, 37, 47, 227, DateTimeKind.Local).AddTicks(3523), "On Holding", new DateTime(2020, 3, 14, 16, 37, 47, 227, DateTimeKind.Local).AddTicks(3527), new DateTime(2020, 3, 14, 16, 37, 47, 227, DateTimeKind.Local).AddTicks(3532), 3, 2 },
                    { 4, 2, new DateTime(2020, 3, 14, 16, 37, 47, 227, DateTimeKind.Local).AddTicks(3538), "On Holding", new DateTime(2020, 3, 14, 16, 37, 47, 227, DateTimeKind.Local).AddTicks(3543), new DateTime(2020, 3, 14, 16, 37, 47, 227, DateTimeKind.Local).AddTicks(3547), 4, 2 }
                });

            migrationBuilder.InsertData(
                schema: "sales",
                table: "orders_items",
                columns: new[] { "order_id", "product_id", "discount", "list_price", "quantity" },
                values: new object[,]
                {
                    { 1, 1, null, 500.00m, 20 },
                    { 2, 2, 10, 100.00m, 30 },
                    { 3, 3, 5, 1000.00m, 100 },
                    { 4, 4, null, 350.00m, 66 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_products_brand_id",
                schema: "production",
                table: "products",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "IX_products_category_id",
                schema: "production",
                table: "products",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_stocks_product_id",
                schema: "production",
                table: "stocks",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_customer_id",
                schema: "sales",
                table: "orders",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_staff_id",
                schema: "sales",
                table: "orders",
                column: "staff_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_store_id",
                schema: "sales",
                table: "orders",
                column: "store_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_items_product_id",
                schema: "sales",
                table: "orders_items",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_staffs_store_id",
                schema: "sales",
                table: "staffs",
                column: "store_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "stocks",
                schema: "production");

            migrationBuilder.DropTable(
                name: "orders_items",
                schema: "sales");

            migrationBuilder.DropTable(
                name: "orders",
                schema: "sales");

            migrationBuilder.DropTable(
                name: "products",
                schema: "production");

            migrationBuilder.DropTable(
                name: "customers",
                schema: "sales");

            migrationBuilder.DropTable(
                name: "staffs",
                schema: "sales");

            migrationBuilder.DropTable(
                name: "brands",
                schema: "production");

            migrationBuilder.DropTable(
                name: "categories",
                schema: "production");

            migrationBuilder.DropTable(
                name: "stores",
                schema: "sales");
        }
    }
}
