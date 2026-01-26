using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ASP_app.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    BlogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "Author", "Content", "CreatedAt", "Title" },
                values: new object[,]
                {
                    { 1, "Quốc Mạnh Trần", "Chỉ tui đâu việc em nha. Hóa dép con tủ hết bè là tủ. Đâu chín gì đã áo khâu cửa yêu biển thế.", new DateTime(2026, 9, 15, 9, 0, 16, 706, DateTimeKind.Unspecified).AddTicks(5026), "Nha ờ nghỉ trăng lầu." },
                    { 2, "Xuân Phương Phan", "Nón đỏ ừ. Khoan cửa tô bạn ghét. Độc đá bốn xanh. Vẽ áo hương đạp lầu độc.", new DateTime(2026, 8, 4, 9, 41, 59, 506, DateTimeKind.Unspecified).AddTicks(4469), "Ác bàn viết lỗi biết á." },
                    { 3, "Duy Thành Phan", "Thích vàng đang. May quê làm nha đã đạp thế nghỉ. Ghế may mượn biển một quê á gì. Máy cái mướn mua đạp đập mua viết. Leo đã không bạn.", new DateTime(2026, 11, 10, 12, 6, 3, 103, DateTimeKind.Unspecified).AddTicks(9047), "Thuê thuê ừ bơi." },
                    { 4, "Hương Tiên Phạm", "Sáu hết biển nón đã hương ghế làm xe mười. Thuê hàng trời mua mướn việc bàn. Nước ruộng á xe tôi giày viết mướn hết. Đâu quần tàu vá một. Cửa đồng sáu không tui ruộng leo tàu đỏ thích.", new DateTime(2026, 7, 30, 14, 36, 25, 147, DateTimeKind.Unspecified).AddTicks(4694), "Tô tám leo đạp hết tám thì khâu xuồng." },
                    { 5, "Quang Sáng Hà", "Chết hóa không tám cái nha con thương xuồng. Một biết anh không quê gì may núi đập. Đập thích xuồng mượn chín hết xe. Mướn thích ừ gió tám mượn á hết mây đập. Vàng tàu xe bàn đã gió nón bảy ừ. Nước quần tàu ngọt nghỉ bàn đá nước.", new DateTime(2026, 11, 7, 16, 53, 6, 980, DateTimeKind.Unspecified).AddTicks(4352), "Nha giết bơi gì cái ừ hai làm thì." },
                    { 6, "Ngọc Vy Hồ", "Đạp á con đá. Ruộng chìm làm thích tàu làm ba ba nước. Núi ngọt vá leo là đang phá. Trăng giết đã việc viết thuyền ruộng xuồng đang giết. Ba độc chín thuê núi viết đang khoan. Cửa tám khoảng thì việc.", new DateTime(2026, 10, 8, 17, 19, 19, 980, DateTimeKind.Unspecified).AddTicks(4736), "Dép cửa bảy trời cửa được nghỉ đang." },
                    { 7, "Hiếu Phong Vương", "Bàn vàng nghỉ xanh khâu quần thì may được quần. Thế khâu tui anh đỏ tám hóa hương. Ruộng viết đá leo hương lầu ừ nhà tím trời. May ba kim nón. Ngọt xuồng may tủ đá chìm á thế đạp.", new DateTime(2026, 5, 30, 3, 24, 24, 817, DateTimeKind.Unspecified).AddTicks(7293), "Thì chết mướn mua á bạn cửa giết thương." },
                    { 8, "Ðông Trà Phạm", "Tàu đỏ biết bàn được á. Chỉ là gió ừ thế lỗi khâu làm bảy tám. Ờ đánh á bè mười trăng anh chìm mua. Hai ngọt độc anh mượn lầu bè độc.", new DateTime(2026, 5, 24, 16, 20, 38, 833, DateTimeKind.Unspecified).AddTicks(8095), "Năm gì hóa thương mây nước." },
                    { 9, "Thiện Tiên Vương", "Bơi thôi mười. Phá mượn không tui tui phá sáu viết ác ác. Một hết nước bạn sáu việc đá đang bè tô. Vẽ năm thuê đỏ á quần bàn.", new DateTime(2026, 11, 12, 14, 17, 15, 980, DateTimeKind.Unspecified).AddTicks(8595), "Thì khâu bốn bạn cái tám giày giày nón may." },
                    { 10, "Anh Thái Tăng", "Nước ba nha. Mướn độc bè cái ghét chết. Giày ghét chín máy bạn con á chết anh sáu. Yêu tím biết được. Đâu yêu quần.", new DateTime(2026, 9, 24, 18, 58, 6, 721, DateTimeKind.Unspecified).AddTicks(8559), "Bè hai bốn ruộng." }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BlogId", "Content", "Rating", "User" },
                values: new object[,]
                {
                    { 1, 1, "The box this comes in is 5 light-year by 6 foot and weights 17 megaton!!!", 5, "Hương Tiên Phạm" },
                    { 2, 1, "This product works excessively well. It speedily improves my baseball by a lot.", 3, "Xuân Vân Hoàng" },
                    { 3, 2, "one of my hobbies is piano. and when i'm playing piano this works great.", 1, "Huệ Thương Đặng" },
                    { 4, 2, "My neighbor Montserrat has one of these. She works as a circus performer and she says it looks shriveled.", 4, "Khắc Triệu Mai" },
                    { 5, 2, "I saw one of these in Spratly Islands and I bought one.", 1, "Hùng Ngọc Trần" },
                    { 6, 2, "I tried to grab it but got bonbon all over it.", 2, "Hồng Quý Mai" },
                    { 7, 2, "My neighbor Victoria has one of these. She works as a professor and she says it looks menthol.", 3, "Hiểu Lam Phạm" },
                    { 8, 2, "heard about this on balearic beat radio, decided to give it a try.", 1, "Thảo Hồng Đào" },
                    { 9, 2, "My neighbor Julisa has one of these. She works as a bartender and she says it looks crooked.", 3, "Quốc Mạnh Trần" },
                    { 10, 2, "i use it barely when i'm in my store.", 4, "Trà My Vương" },
                    { 11, 5, "I saw one of these in Bhutan and I bought one.", 1, "Hoa Lý Trịnh" },
                    { 12, 5, "This product works really well. It wildly improves my baseball by a lot.", 1, "Sao Mai Đỗ" },
                    { 13, 5, "I tried to shred it but got watermelon all over it.", 3, "Phi Ðiệp Đinh" },
                    { 14, 6, "This product works outstandingly well. It grudgingly improves my baseball by a lot.", 1, "Nhã Sương Ngô" },
                    { 15, 7, "I saw one of these in Canada and I bought one.", 3, "Xuân Khoa Bùi" },
                    { 16, 7, "It only works when I'm Chad.", 1, "Xuân Phương Phan" },
                    { 17, 7, "this product is ghetto.", 5, "Minh Khai Hoàng" },
                    { 18, 7, "It only works when I'm Rwanda.", 3, "Minh Hiên Nguyễn" },
                    { 19, 7, "one of my hobbies is gaming. and when i'm gaming this works great.", 5, "Bích Loan Đoàn" },
                    { 20, 7, "this product is papery.", 3, "Thái Tâm Trần" },
                    { 21, 7, "My neighbor Forest has one of these. She works as a gardener and she says it looks nude.", 4, "Hải Châu Đặng" },
                    { 22, 8, "My tiger loves to play with it.", 5, "Mộng Hương Tô" },
                    { 23, 8, "It only works when I'm Mauritania.", 5, "Cẩm Nhung Nguyễn" },
                    { 24, 8, "My scarab beetle loves to play with it.", 3, "Hải Bình Hoàng" },
                    { 25, 8, "i use it hardly when i'm in my prison.", 1, "Kim Thủy Phan" },
                    { 26, 8, "this product is mellow.", 5, "Thế Duyệt Phạm" },
                    { 27, 8, "heard about this on melodic death metal radio, decided to give it a try.", 5, "Duy Thành Phan" },
                    { 28, 9, "This product works extremely well. It wetly improves my tennis by a lot.", 1, "Quỳnh Ngân Tô" },
                    { 29, 9, "one of my hobbies is theater. and when i'm acting this works great.", 5, "Quỳnh Thanh Lê" },
                    { 30, 10, "My co-worker Skylar has one of these. He says it looks sweaty.", 5, "Xuân Bình Vũ" },
                    { 31, 10, "works okay.", 4, "Huy Tuấn Phạm" },
                    { 32, 10, "The box this comes in is 5 kilometer by 5 inch and weights 13 kilogram!!!", 3, "Thy Vân Bùi" },
                    { 33, 10, "My co-worker Rey has one of these. He says it looks uneven.", 2, "Minh Hằng Mai" },
                    { 34, 10, "It only works when I'm Samoa.", 5, "Mộc Miên Đặng" },
                    { 35, 10, "this product is amiable.", 3, "Trường Phát Hà" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BlogId",
                table: "Comments",
                column: "BlogId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Blogs");
        }
    }
}
