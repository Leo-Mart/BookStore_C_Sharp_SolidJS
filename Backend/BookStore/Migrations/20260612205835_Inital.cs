using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStore.Migrations
{
    /// <inheritdoc />
    public partial class Inital : Migration
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
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isbn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CoverImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
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
                name: "AuthorBook",
                columns: table => new
                {
                    AuthorsId = table.Column<int>(type: "int", nullable: false),
                    BooksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBook", x => new { x.AuthorsId, x.BooksId });
                    table.ForeignKey(
                        name: "FK_AuthorBook_Authors_AuthorsId",
                        column: x => x.AuthorsId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorBook_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookGenre",
                columns: table => new
                {
                    BooksId = table.Column<int>(type: "int", nullable: false),
                    GenresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookGenre", x => new { x.BooksId, x.GenresId });
                    table.ForeignKey(
                        name: "FK_BookGenre_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookGenre_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "Admin", "1", "Admin", "ADMIN" },
                    { "User", "1", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "26a17d98-2564-4a5c-a21d-8b806ca91db9", 0, "1", "mrstest@test.com", false, "", "", true, null, "MRSTEST@TEST.COM", "MRS.TEST", "AQAAAAIAAYagAAAAEDo5bk0UyyMvrhmqvw+gCLnDkvWWjE2xbXj6qX93YoEOYLR9pY5LGwBNm0qDScF23g==", null, false, "A_SECURITY_STAMP", false, "Mrs.Test" },
                    { "ab2c49be-9e83-41af-82b5-9165ddeb125f", 0, "1", "mrtest@test.com", false, "", "", true, null, "MRTEST@TEST.COM", "MR.TEST", "AQAAAAIAAYagAAAAEDo5bk0UyyMvrhmqvw+gCLnDkvWWjE2xbXj6qX93YoEOYLR9pY5LGwBNm0qDScF23g==", null, false, "A_SECURITY_STAMP", false, "Mr.Test" }
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Bio", "CreatedAt", "FirstName", "LastName", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Canadian?", new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Steven", "Eriksson", new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "English?", new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane", "Austen", new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "no clue where this dude is from, could google it, but...", new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mark", "Z. Danielewski", new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "CoverImageUrl", "CreatedAt", "Description", "Isbn", "Price", "PublishedDate", "Publisher", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bled dry by interminable warfare, infighting and bloody confrontations with Lord Anomander Rake and his Tiste Andii, the vast, sprawling Malazan empire simmers with discontent. Even its imperial legions yearn for some respite. For Sergeant Whiskeyjack and his Bridgeburners, and for Tattersail - sole surviving sorceress of the Second Legion - the aftermath of the siege of Pale should have been a time to mourn the dead. But Darujhistan, the last of the Free Cities of Genabackis, still holds out against the empire - and Empress Lasseen's ambition knows no bounds. However, it seems the empire is not alone in this great game. Sinister forces gather as the gods themselves prepare to play their hand . . . Conceived and written on an epic scale, Gardens of the Moon is a breathtaking achievement - a novel in which grand design, a dark and complex mythology, wild and wayward magic and a host of enduring characters combine with thrilling, powerful storytelling to resounding effect", "9713196ajdhadhjakhd", 150m, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tor Books", "Gardens of the Moon", new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, null, new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "MR DARCY!", "9713196ajdhadhjakhd", 1337m, new DateTime(1813, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "T. Egerton, Whitehall", "Pride and Prejudice", new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, null, new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "a house of leaves", "9713196ajdhadhjakhd", 150m, new DateTime(2020, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "A publisher", "House of Leaves", new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, null, new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "In the Holy Desert Raraku, the seer Sha'ik and her followers prepare for the long-prophesied uprising named the Whirlwind. Enslaved in the Otataral mines, Felisin - youngest scion of the disgraced House of Paran - dreams of freedom and vows revenge. The outlawed Bridgeburners Fiddler and Kalam conspire to rid the world of the Empress Laseen - although it seems the gods would, as always, have it otherwise. And as two ancient warriors - bearers of a devastating secret - enter this blighted land, so an untried commander of the Malaz 7th Army leads his war-weary troops in a last, valiant running battle to save the lives of thirty thousand refugees.", "9780765348791", 200m, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tor Books", "Deadhouse Gates", new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, null, new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "The ravaged continent of Genabackis has given birth to a terrifying new empire: the Pannion Domin. Like a fanatical tide of corrupted blood, it seethes across the land, devouring all who fail to heed the Word of its elusive prophet, the Pannion Seer. In its path stands an uneasy alliance: Dujek Onearm's Host and the Bridgeburners - each now outlawed by the Empress ­- alongside some enemies of old that include the grim forces of Warlord Caladan Brood, Anomander Rake, Son of Darkness, and his Tiste Andii, and the Rhivi people of the Plains. But more ancient clans are also gathering. As if in answer to some primal summons, the massed ranks of the undead T'lan Imass have risen. It would seem that something altogether darker and more malign threatens the very substance of this world. The Warrens are poisoned, and rumours abound that the Crippled God is now unchained and intent on a terrible revenge . . .", "9780765348807", 239m, new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tor Books", "Memories of Ice", new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, null, new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Years after a tribal attack on the southern flatlands, Tavore, an Adjunct to the Empress, struggles to train a band of some twelve thousand inexperienced recruits to meet an attack by the forces of her sister, Sha'ik", "9780765348814", 239m, new DateTime(2002, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tor Books", "House of Chains", new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, null, new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "After decades of warfare, the five tribes of the Tiste Edur have finally been united under the implacable rule of the Warlock King of Hiroth, but their peace has been exacted at the cost of a pact made with a hidden power, and ancient forces are awakening that could unleash a vengeful bloodbath on all concerned", "9780765348821", 239m, new DateTime(2004, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tor Books", "Midnight Tides", new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, null, new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Seven Cities Rebellion has been crushed. Sha'ik is dead. One last rebel force remains, holed up in the city of Y'Ghatan and under the fanatical command of Leoman of the Flails. The prospect of laying siege to this ancient fortress makes the battle-weary Malaz 14th Army uneasy. For it was here that the Empire's greatest champion Dassem Ultor was slain and a tide of Malazan blood spilled. A place of foreboding, its smell is of death. But elsewhere, agents of a far greater conflict have made their opening moves. The Crippled God has been granted a place in the pantheon, a schism threatens and sides must be chosen. Whatever each god decides, the ground-rules have changed, irrevocably, terrifyingly and the first blood spilled will be in the mortal world. A world in which a host of characters, familiar and new, including Heboric Ghost Hands, the possessed Apsalar, Cutter, once a thief now a killer, the warrior Karsa Orlong and the two ancient wanderers Icarium and Mappo--each searching for such a fate as they might fashion with their own hands, guided by their own will. If only the gods would leave them alone. But now that knives have been unsheathed, the gods are disinclined to be kind. There shall be war, war in the heavens. And, the prize? Nothing less than existence itself... Here is the stunning new chapter in Steven Erikson magnificent Malazan Book of the Fallen--hailed as an epic of the imagination and acknowledged as a fantasy classic in the making.", "9780765348838", 219m, new DateTime(2006, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tor Books", "The Bonehunters", new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, null, new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "All is not well in the Letherii Empire. Rhulad Sengar, the Emperor of a Thousand Deaths, spirals into madness, surrounded by sycophants and agents of his Machiavellian chancellor. Meanwhile, the Letherii secret police conduct a campaign of terror against their own people. The Errant, once a farseeing god, is suddenly blind to the future. Conspiracies seethe throughout the palace, as the empire - driven by the corrupt and self-interested - edges ever-closer to all-out war with the neighboring kingdoms. The great Edur fleet--its warriors selected from countless numbers of people--draws closer. Amongst the warriors are Karsa Orlong and Icarium Lifestealer--each destined to cross blades with the emperor himself. That yet more blood is to be spilled is inevitable... Against this backdrop, a band of fugitives seek a way out of the empire, but one of them, Fear Sengar, must find the soul of Scabandari Bloodeye. It is his hope that the soul might help halt the Tiste Edur, and so save his brother, the emperor. Yet, traveling with them is Scabandari's most ancient foe: Silchas Ruin, brother of Anomander Rake. And his motives are anything but certain - for the wounds he carries on his back, made by the blades of Scabandari, are still fresh. Fate decrees that there is to be a reckoning, for such bloodshed cannot go unanswered--and it will be a reckoning on an unimaginable scale. This is a brutal, harrowing novel of war, intrigue and dark, uncontrollable magic; this is epic fantasy at its most imaginative, storytelling at its most thrilling.", "9780765348845", 239m, new DateTime(2007, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tor Books", "Reaper's Gale", new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, null, new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "It is said that Hood waits at the end of every plot, every scheme, each grandiose ambition. But this time it is different: this time the Lord of Death is there at the beginning... Darujhistan swelters in the summer heat and seethes with portents, rumours and whispers. Strangers have arrived, a murderer is abroad, past-tyrannies are stirring and assassins seem to be targeting the owners of K'rul's Bar. For the rotund, waistcoat-clad man knows such events will be dwarfed by what is about to happen: for in the distance can be heard the baying of hounds. Far away, in Black Coral, the ruling Tiste Andii appear oblivious to the threat posed by the fast-growing cult of the Redeemer - an honourable, one-mortal man who seems powerless against the twisted vision of his followers. So Hood waits at the beginning of a conspiracy that will shake the cosmos, but at its end there is another: Anomander Rake, Son of Darkness, has come to right an ancient and terrible wrong...", "9780765348852", 239m, new DateTime(2008, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tor Books", "Toll the Hounds", new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, null, new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "The penultimate book in the acclaimed Malazan Book of the Fallen fantasy seriesOn the Letherii continent the exiled Malazan army commanded by Adjunct Tavore begins its march into the eastern Wastelands, to fight for an unknown cause against an enemy it has never seen.", "9780765348869", 239m, new DateTime(2009, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tor Books", "Dust of Dreams", new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, null, new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "The final, apocalyptic chapter in one of the most original, exciting and acclaimed fantasy series of our time . Their desire is to cleanse the world - to eradicate every civilization, to annihilate every human - in order to begin anew. And outside the abandoned city of Kharkanas, thousands have gathered upon the First Shore.", "9780765348876", 239m, new DateTime(2011, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tor Books", "The Crippled God", new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Here be dragons", "Fantasy", new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smooches", "Romance", new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spooky-scary skeletons", "Horror", new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fools are my theme, let satire be my song.", "Satire", new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "AuthorBook",
                columns: new[] { "AuthorsId", "BooksId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 4 },
                    { 1, 5 },
                    { 1, 6 },
                    { 1, 7 },
                    { 1, 8 },
                    { 1, 9 },
                    { 1, 10 },
                    { 1, 11 },
                    { 1, 12 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "BookGenre",
                columns: new[] { "BooksId", "GenresId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 2, 4 },
                    { 3, 3 },
                    { 4, 1 },
                    { 5, 1 },
                    { 6, 1 },
                    { 7, 1 },
                    { 8, 1 },
                    { 9, 1 },
                    { 10, 1 },
                    { 11, 1 },
                    { 12, 1 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "AppUserId", "BookId", "CreatedAt", "Score", "Text", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "26a17d98-2564-4a5c-a21d-8b806ca91db9", 1, new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Wow. So good.", "Such a good series", new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "ab2c49be-9e83-41af-82b5-9165ddeb125f", 1, new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Wow. So bad.", "Such a bad series", new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "26a17d98-2564-4a5c-a21d-8b806ca91db9", 2, new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Wow. So dreamy.", "He is so dreamy", new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "ab2c49be-9e83-41af-82b5-9165ddeb125f", 2, new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Wow. So dreamy.", "She is so dreamy", new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) }
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
                name: "IX_AuthorBook_BooksId",
                table: "AuthorBook",
                column: "BooksId");

            migrationBuilder.CreateIndex(
                name: "IX_BookGenre_GenresId",
                table: "BookGenre",
                column: "GenresId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_AppUserId",
                table: "Reviews",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_BookId",
                table: "Reviews",
                column: "BookId");
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
                name: "AuthorBook");

            migrationBuilder.DropTable(
                name: "BookGenre");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
