using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UmutYapi.Migrations
{
    /// <inheritdoc />
    public partial class init99 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sepetler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sepetler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UrunKategoriler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriAdi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrunKategoriler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sehir = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ulke = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fotograf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SepetId = table.Column<int>(type: "int", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Sepetler_SepetId",
                        column: x => x.SepetId,
                        principalTable: "Sepetler",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SepetItemler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunId = table.Column<int>(type: "int", nullable: false),
                    SatınAlınacakAdet = table.Column<int>(type: "int", nullable: false),
                    SepetId = table.Column<int>(type: "int", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SepetItemler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SepetItemler_Sepetler_SepetId",
                        column: x => x.SepetId,
                        principalTable: "Sepetler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Urunler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunKodu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrunAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrunFiyati = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StokAdeti = table.Column<int>(type: "int", nullable: false),
                    StokAdetiBirimi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrunFoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KategoriId = table.Column<int>(type: "int", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urunler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Urunler_UrunKategoriler_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "UrunKategoriler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                name: "Siparisler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SiparisTutarı = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SatınAlmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siparisler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Siparisler_AspNetUsers_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SiparisItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunId = table.Column<int>(type: "int", nullable: false),
                    Adet = table.Column<int>(type: "int", nullable: false),
                    SiparisId = table.Column<int>(type: "int", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiparisItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SiparisItems_Siparisler_SiparisId",
                        column: x => x.SiparisId,
                        principalTable: "Siparisler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "UrunKategoriler",
                columns: new[] { "Id", "GuncellemeTarihi", "KategoriAdi", "OlusturmaTarihi" },
                values: new object[,]
                {
                    { 1, null, "Beton", new DateTime(2024, 6, 1, 22, 19, 54, 438, DateTimeKind.Local).AddTicks(8890) },
                    { 2, null, "Yalıtım", new DateTime(2024, 6, 1, 22, 19, 54, 438, DateTimeKind.Local).AddTicks(8901) },
                    { 3, null, "DuvarDöseme", new DateTime(2024, 6, 1, 22, 19, 54, 438, DateTimeKind.Local).AddTicks(8903) },
                    { 4, null, "KapıPencere", new DateTime(2024, 6, 1, 22, 19, 54, 438, DateTimeKind.Local).AddTicks(8905) },
                    { 5, null, "BoyaKaplama", new DateTime(2024, 6, 1, 22, 19, 54, 438, DateTimeKind.Local).AddTicks(8906) },
                    { 6, null, "AhşapMarangoz", new DateTime(2024, 6, 1, 22, 19, 54, 438, DateTimeKind.Local).AddTicks(8907) },
                    { 7, null, "Elektrik", new DateTime(2024, 6, 1, 22, 19, 54, 438, DateTimeKind.Local).AddTicks(8908) },
                    { 8, null, "SıhhiTesisat", new DateTime(2024, 6, 1, 22, 19, 54, 438, DateTimeKind.Local).AddTicks(8909) },
                    { 9, null, "Metal", new DateTime(2024, 6, 1, 22, 19, 54, 438, DateTimeKind.Local).AddTicks(8910) },
                    { 10, null, "ELveMakina", new DateTime(2024, 6, 1, 22, 19, 54, 438, DateTimeKind.Local).AddTicks(8911) }
                });

            migrationBuilder.InsertData(
                table: "Urunler",
                columns: new[] { "Id", "Aciklama", "GuncellemeTarihi", "KategoriId", "OlusturmaTarihi", "StokAdeti", "StokAdetiBirimi", "UrunAdi", "UrunFiyati", "UrunFoto", "UrunKodu" },
                values: new object[,]
                {
                    { 1, "50KG", null, 1, new DateTime(2024, 6, 1, 22, 19, 54, 438, DateTimeKind.Local).AddTicks(9475), 1900, "Kg", "Çimento", 200m, "çimento.jpg", "B-0001" },
                    { 2, "İnce Kum", null, 1, new DateTime(2024, 6, 1, 22, 19, 54, 438, DateTimeKind.Local).AddTicks(9479), 10000, "Ton", "Kum", 60m, "kum.jpg", "B-0002" },
                    { 3, "Kırma Çakıl", null, 1, new DateTime(2024, 6, 1, 22, 19, 54, 438, DateTimeKind.Local).AddTicks(9483), 8000, "Ton", "Çakıl", 240m, "çakıl.jpg", "B-0003" },
                    { 4, "5cm", null, 2, new DateTime(2024, 6, 1, 22, 19, 54, 438, DateTimeKind.Local).AddTicks(9485), 700, "m3", "Strafor", 250m, "strafor.jpg", "Y-0001" },
                    { 5, "10cm", null, 2, new DateTime(2024, 6, 1, 22, 19, 54, 438, DateTimeKind.Local).AddTicks(9488), 650, "m3", "Cam Yünü", 300m, "cam yünü.jpg", "Y-0002" },
                    { 6, "5cm", null, 2, new DateTime(2024, 6, 1, 22, 19, 54, 438, DateTimeKind.Local).AddTicks(9490), 500, "m3", "Taş yünü", 400m, "taş yünü.jpg", "Y-0003" },
                    { 7, "3mm", null, 2, new DateTime(2024, 6, 1, 22, 19, 54, 438, DateTimeKind.Local).AddTicks(9492), 1000, "m3", "Su Yalıtım Membranı", 50m, "su membranı.jpg", "Y-0004" },
                    { 8, "40mm", null, 2, new DateTime(2024, 6, 1, 22, 19, 54, 438, DateTimeKind.Local).AddTicks(9495), 150, "Adet", "Akustik Panel", 50m, "akustik panel.jpg", "Y-0005" },
                    { 9, "Yığma", null, 3, new DateTime(2024, 6, 1, 22, 19, 54, 438, DateTimeKind.Local).AddTicks(9497), 5000, "Adet", "Tuğla", 7m, "tuğla1.jpg", "D-0001" },
                    { 10, "5'lik", null, 3, new DateTime(2024, 6, 1, 22, 19, 54, 438, DateTimeKind.Local).AddTicks(9499), 3000, "Adet", "Ytong", 190m, "ytong tuğla.jpg", "D-0002" },
                    { 11, "G4", null, 3, new DateTime(2024, 6, 1, 22, 19, 54, 438, DateTimeKind.Local).AddTicks(9501), 2800, "Adet", "Gaz Beton", 180m, "gaz beton.jpg", "D-0003" },
                    { 12, "Duvar Karosu", null, 3, new DateTime(2024, 6, 1, 22, 19, 54, 438, DateTimeKind.Local).AddTicks(9508), 3000, "m3", "Seramik", 340m, "seramik.jpg", "D-0004" },
                    { 13, "Seramik", null, 3, new DateTime(2024, 6, 1, 22, 19, 54, 438, DateTimeKind.Local).AddTicks(9510), 3300, "m3", "Fayans", 280m, "fayans.png", "D-0005" },
                    { 14, "Ahşap", null, 3, new DateTime(2024, 6, 1, 22, 19, 54, 438, DateTimeKind.Local).AddTicks(9511), 4000, "m3", "Laminant Parke", 450m, "laminant.jpg", "D-0006" },
                    { 15, "Kahverengi Renk", null, 4, new DateTime(2024, 6, 1, 22, 19, 54, 438, DateTimeKind.Local).AddTicks(9513), 100, "Adet", "Ahşap Kapı", 2000m, "ahşap kapı.jpg", "K-0001" },
                    { 16, "Gri Renk", null, 4, new DateTime(2024, 6, 1, 22, 19, 54, 438, DateTimeKind.Local).AddTicks(9515), 100, "Adet", "Çelik Kapı", 2500m, "çelik kapı.jpg", "K-0002" },
                    { 17, "Çift Açılım", null, 4, new DateTime(2024, 6, 1, 22, 19, 54, 438, DateTimeKind.Local).AddTicks(9517), 200, "Adet", "PVC Pencere", 1900m, "pvc pencere.jpg", "K-0003" },
                    { 18, "Giyotin", null, 4, new DateTime(2024, 6, 1, 22, 19, 54, 438, DateTimeKind.Local).AddTicks(9518), 230, "Adet", "Ahşap Pencere", 2500m, "ahşap pencere.jpg", "K-0004" },
                    { 19, "Fonksiyonel", null, 4, new DateTime(2024, 6, 1, 22, 19, 54, 438, DateTimeKind.Local).AddTicks(9520), 4003, "Adet", "Menteşe", 6m, "menteşe.jpg", "K-0005" },
                    { 20, "Asma", null, 1, new DateTime(2024, 6, 1, 22, 19, 54, 438, DateTimeKind.Local).AddTicks(9522), 400, "Adet", "Kilit", 70m, "kilit.jpg", "K-0006" },
                    { 21, "Krom Kaplama", null, 4, new DateTime(2024, 6, 1, 22, 19, 54, 438, DateTimeKind.Local).AddTicks(9524), 280, "Adet", "Kulp", 30m, "kapı kulp.jpg", "K-0007" },
                    { 22, "Plastik Boya", null, 5, new DateTime(2024, 6, 1, 22, 19, 54, 438, DateTimeKind.Local).AddTicks(9526), 200, "Adet", "Plastik Boya", 50m, "plastik boya.jpg", "BK-0001" },
                    { 23, "Silikonlu Boya", null, 5, new DateTime(2024, 6, 1, 22, 19, 54, 438, DateTimeKind.Local).AddTicks(9527), 250, "Adet", "Silikonlu Boya", 80m, "silikonlu boya.jpg", "BK-0002" },
                    { 24, "Saten Boya", null, 5, new DateTime(2024, 6, 1, 22, 19, 54, 438, DateTimeKind.Local).AddTicks(9530), 4000, "Adet", "Dekoratif Kaplama", 140m, "dekoratif kaplama.jpg", "BK-0003" },
                    { 25, "Meşe", null, 6, new DateTime(2024, 6, 1, 22, 19, 54, 438, DateTimeKind.Local).AddTicks(9533), 5000, "m3", "Kereste", 160m, "kereste.jpg", "A-0001" },
                    { 26, "Filmli", null, 6, new DateTime(2024, 6, 1, 22, 19, 54, 438, DateTimeKind.Local).AddTicks(9536), 4000, "m3", "Plywood", 280m, "plywood.jpg", "A-0002" },
                    { 27, "MDF Lam", null, 6, new DateTime(2024, 6, 1, 22, 19, 54, 438, DateTimeKind.Local).AddTicks(9537), 3900, "m3", "MDF", 200m, "mdf.jpg", "A-0003" },
                    { 28, "Turuncu Renk", null, 6, new DateTime(2024, 6, 1, 22, 19, 54, 438, DateTimeKind.Local).AddTicks(9539), 2800, "m3", "Sunta", 80m, "sunta.jpg", "A-0004" },
                    { 29, "Çok Telli", null, 7, new DateTime(2024, 6, 1, 22, 19, 54, 438, DateTimeKind.Local).AddTicks(9542), 1500, "Metre", "NYA Kablo", 40m, "nya kablo.jpg", "E-00001" },
                    { 30, "G4", null, 7, new DateTime(2024, 6, 1, 22, 19, 54, 438, DateTimeKind.Local).AddTicks(9545), 900, "Adet", "Duy Priz", 25m, "duy priz.jpg", "E-0002" },
                    { 31, "Komülatör", null, 7, new DateTime(2024, 6, 1, 22, 19, 54, 438, DateTimeKind.Local).AddTicks(9547), 800, "Adet", "Anahtar", 15m, "anahtar.jpg", "E-0003" },
                    { 32, "Beyaz Renk", null, 7, new DateTime(2024, 6, 1, 22, 19, 54, 438, DateTimeKind.Local).AddTicks(9550), 1000, "Adet", "Led Ampul", 80m, "led ampul.jpg", "E-0004" },
                    { 33, "PLC 2 Pinli", null, 7, new DateTime(2024, 6, 1, 22, 19, 54, 438, DateTimeKind.Local).AddTicks(9552), 600, "Adet", "Florasan Lamba", 40m, "florasan.jpg", "E-0005" },
                    { 34, "250mm", null, 8, new DateTime(2024, 6, 1, 22, 19, 54, 438, DateTimeKind.Local).AddTicks(9556), 700, "Metre", "PVC Boru", 20m, "pcv boru.jpg", "S-0001" },
                    { 35, "Uzun Musluk", null, 8, new DateTime(2024, 6, 1, 22, 19, 54, 438, DateTimeKind.Local).AddTicks(9559), 1000, "Adet", "Musluk", 190m, "musluk.jpg", "S-0002" },
                    { 36, "Krom Menfez", null, 8, new DateTime(2024, 6, 1, 22, 19, 54, 438, DateTimeKind.Local).AddTicks(9561), 400, "Adet", "Menfez", 50m, "menfez.jpg", "S-0003" },
                    { 37, "Plastik Köşebent", null, 9, new DateTime(2024, 6, 1, 22, 19, 54, 438, DateTimeKind.Local).AddTicks(9563), 1900, "Adet", "Köşebent", 4m, "köşebent.jpg", "M-0001" },
                    { 38, "Germe Civatası", null, 9, new DateTime(2024, 6, 1, 22, 19, 54, 438, DateTimeKind.Local).AddTicks(9565), 1450, "Adet", "Civata", 1m, "civata.jpg", "M-0002" },
                    { 39, "Düz Rondela", null, 9, new DateTime(2024, 6, 1, 22, 19, 54, 438, DateTimeKind.Local).AddTicks(9566), 1400, "Adet", "Rondela", 2m, "rondela.jpg", "M-0003" },
                    { 40, "Demir Çekiç", null, 10, new DateTime(2024, 6, 1, 22, 19, 54, 438, DateTimeKind.Local).AddTicks(9569), 60, "Adet", "Çekiç", 100m, "çekiç.jpg", "EM-0001" },
                    { 41, "Yıldız Tornavida", null, 10, new DateTime(2024, 6, 1, 22, 19, 54, 438, DateTimeKind.Local).AddTicks(9571), 100, "Adet", "Tornavida", 30m, "tornavida.jpg", "EM-0002" },
                    { 42, "KargaBurun Pense", null, 10, new DateTime(2024, 6, 1, 22, 19, 54, 438, DateTimeKind.Local).AddTicks(9572), 40, "Adet", "Pense", 50m, "pense.jpg", "EM-0003" },
                    { 43, "Darbeli Matkap", null, 10, new DateTime(2024, 6, 1, 22, 19, 54, 438, DateTimeKind.Local).AddTicks(9574), 20, "Adet", "Matkap", 200m, "matkap.jpg", "EM-0004" },
                    { 44, "Demir Testere", null, 10, new DateTime(2024, 6, 1, 22, 19, 54, 438, DateTimeKind.Local).AddTicks(9576), 50, "Adet", "Testere", 100m, "testere.jpg", "EM-0005" },
                    { 45, "Sabit", null, 10, new DateTime(2024, 6, 1, 22, 19, 54, 438, DateTimeKind.Local).AddTicks(9578), 5, "Adet", "Beton Mikseri", 13000m, "beton mikseri.jpg", "EM-0006" },
                    { 46, "Endistriyel", null, 10, new DateTime(2024, 6, 1, 22, 19, 54, 438, DateTimeKind.Local).AddTicks(9580), 5, "Adet", "Taş Kesme Makinası", 5000m, "taş kesme makinası.jpg", "EM-0007" }
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
                name: "IX_AspNetUsers_SepetId",
                table: "AspNetUsers",
                column: "SepetId",
                unique: true,
                filter: "[SepetId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SepetItemler_SepetId",
                table: "SepetItemler",
                column: "SepetId");

            migrationBuilder.CreateIndex(
                name: "IX_SiparisItems_SiparisId",
                table: "SiparisItems",
                column: "SiparisId");

            migrationBuilder.CreateIndex(
                name: "IX_Siparisler_KullaniciId",
                table: "Siparisler",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_Urunler_KategoriId",
                table: "Urunler",
                column: "KategoriId");
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
                name: "SepetItemler");

            migrationBuilder.DropTable(
                name: "SiparisItems");

            migrationBuilder.DropTable(
                name: "Urunler");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Siparisler");

            migrationBuilder.DropTable(
                name: "UrunKategoriler");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Sepetler");
        }
    }
}
