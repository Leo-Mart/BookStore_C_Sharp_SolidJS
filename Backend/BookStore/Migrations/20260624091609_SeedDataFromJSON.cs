using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStore.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataFromJSON : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Bio", "CreatedAt", "FirstName", "LastName", "UpdatedAt" },
                values: new object[,]
                {
                    { 4, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "J.R.R.", "Tolkien", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patrick", "Rothfuss", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brandon", "Sanderson", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "George R.R.", "Martin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Joe", "Abercrombie", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Scott", "Lynch", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert", "Jordan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Neil", "Gaiman", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Terry", "Pratchett", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ursula K.", "Le Guin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "C.S.", "Lewis", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robin", "Hobb", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Erin", "Morgenstern", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Susanna", "Clarke", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guy Gavriel", "Kay", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Samantha", "Shannon", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "N.K.", "Jemisin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Frank", "Herbert", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "George", "Orwell", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aldous", "Huxley", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Douglas", "Adams", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Isaac", "Asimov", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "William", "Gibson", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Orson Scott", "Card", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Scalzi", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andy", "Weir", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Liu", "Cixin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kazuo", "Ishiguro", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 32, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Neal", "Stephenson", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adrian", "Tchaikovsky", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 34, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Peter", "Watts", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 35, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Martha", "Wells", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 36, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Blake", "Crouch", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 37, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arkady", "Martine", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 38, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Becky", "Chambers", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 39, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane", "Austen", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 40, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Charlotte", "Brontë", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 41, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emily", "Brontë", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 42, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Charles", "Dickens", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 43, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Leo", "Tolstoy", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 44, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fyodor", "Dostoevsky", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 45, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Miguel de", "Cervantes", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 46, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "William", "Shakespeare", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 47, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Herman", "Melville", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 48, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nathaniel", "Hawthorne", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 49, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mark", "Twain", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 50, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oscar", "Wilde", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 51, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mary", "Shelley", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 52, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bram", "Stoker", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 53, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alexandre", "Dumas", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 54, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Victor", "Hugo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 55, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gustave", "Flaubert", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 56, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "George", "Eliot", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 57, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "James", "Joyce", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 58, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Virginia", "Woolf", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 59, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "F. Scott", "Fitzgerald", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 60, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Steinbeck", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 61, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ernest", "Hemingway", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 62, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harper", "Lee", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 63, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "J.D.", "Salinger", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 64, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "William", "Golding", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 65, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mark", "Lawrence", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 66, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brent", "Weeks", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 67, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Garth", "Nix", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 68, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ralph", "Ellison", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 69, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Toni", "Morrison", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 70, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriel García", "Márquez", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 71, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Albert", "Camus", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "CoverImageUrl", "CreatedAt", "Description", "Isbn", "Price", "PublishedDate", "Publisher", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 13, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The first part of Tolkien's epic fantasy trilogy, following hobbit Frodo Baggins as he sets out on a quest to destroy the One Ring.", "978-0-261-10221-7", 14.99m, new DateTime(1954, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Allen & Unwin", "The Fellowship of the Ring", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The second volume of The Lord of the Rings, continuing the War of the Ring as the Fellowship is broken.", "978-0-261-10236-1", 14.99m, new DateTime(1954, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Allen & Unwin", "The Two Towers", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The final volume of The Lord of the Rings, culminating in the destruction of the One Ring and the defeat of Sauron.", "978-0-261-10237-8", 14.99m, new DateTime(1955, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Allen & Unwin", "The Return of the King", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The tale of Kvothe, a legendary wizard and musician, told in his own words as he recounts his extraordinary life.", "978-0-7432-7356-5", 16.99m, new DateTime(2007, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "DAW Books", "The Name of the Wind", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Epic fantasy set in the world of Roshar, where a war is fought on the Shattered Plains and ancient powers begin to return.", "978-0-7564-0407-6", 19.99m, new DateTime(2010, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tor Books", "The Way of Kings", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The second book in The Stormlight Archive, continuing the story of the Knights Radiant and the Desolation threatening Roshar.", "978-0-7564-0473-1", 19.99m, new DateTime(2014, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tor Books", "Words of Radiance", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "In a world where ash falls from the sky and mists dominate the night, a group of rebels plans to overthrow a seemingly immortal ruler.", "978-0-7653-2637-9", 15.99m, new DateTime(2006, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tor Books", "The Final Empire", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The first novel in the A Song of Ice and Fire series, set in the Seven Kingdoms of Westeros where noble houses vie for the Iron Throne.", "978-0-380-97593-3", 17.99m, new DateTime(1996, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bantam Books", "A Game of Thrones", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The second book in A Song of Ice and Fire, in which five kings claim the Iron Throne as the War of the Five Kings begins.", "978-0-553-10354-0", 17.99m, new DateTime(1998, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bantam Books", "A Clash of Kings", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The first book of The First Law trilogy, a gritty fantasy following a barbarian, a torturer, and a crippled war hero.", "978-0-00-711835-0", 13.99m, new DateTime(2006, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gollancz", "The Blade Itself", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A master thief and his gang of con artists pull off an elaborate heist in a city built on the ruins of an alien civilization.", "978-0-06-112009-3", 15.99m, new DateTime(2006, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bantam Spectra", "The Lies of Locke Lamora", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The first book in The Wheel of Time series, following a young farmhand who discovers he may be the Dragon Reborn.", "978-0-345-45430-5", 16.99m, new DateTime(1990, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tor Books", "The Eye of the World", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A recently released ex-convict is drawn into a conflict between old gods brought to America by immigrants and new gods of technology and media.", "978-0-441-00897-8", 15.99m, new DateTime(2001, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "William Morrow", "American Gods", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "After helping a mysterious injured girl, a London businessman finds himself in London Below, a magical underworld beneath the city streets.", "978-0-06-093546-9", 13.99m, new DateTime(1996, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avon Books", "Neverwhere", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The first Discworld novel, following the hapless wizard Rincewind and the world's first tourist across a flat world balanced on four elephants.", "978-0-575-07979-0", 12.99m, new DateTime(1983, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Colin Smythe", "The Colour of Magic", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A young girl and her cat travel through a mystical land in search of her missing uncle, guided by fantastic beings.", "978-0-06-073218-2", 11.99m, new DateTime(1968, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ace Books", "The Name of the Wind", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A young boy with unusual magical ability is sent to a school for wizards on an island, where he unleashes a terrible shadow.", "978-0-7432-7356-5", 11.99m, new DateTime(1968, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Parnassus Press", "A Wizard of Earthsea", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Four children step through a wardrobe into the magical land of Narnia, where they must help the great lion Aslan defeat the White Witch.", "978-0-06-447187-3", 10.99m, new DateTime(1950, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Geoffrey Bles", "The Lion, The Witch and the Wardrobe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The illegitimate son of a prince is trained as a royal assassin while uncovering dangerous secrets about the kingdom.", "978-0-7432-7357-2", 13.99m, new DateTime(1995, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bantam Books", "Assassin's Apprentice", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 32, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A mysterious black-and-white circus appears without warning and two young magicians compete within it, unaware of the stakes of their contest.", "978-0-316-76948-0", 14.99m, new DateTime(2011, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doubleday", "The Night Circus", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Two very different magicians attempt to restore magic to England during the Napoleonic Wars, with unpredictable consequences.", "978-0-06-112008-6", 17.99m, new DateTime(2004, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bloomsbury", "Jonathan Strange & Mr Norrell", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 34, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "In a conquered land whose very name has been magically erased, a band of rebels struggles to reclaim their history and freedom.", "978-0-380-78868-0", 14.99m, new DateTime(1990, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Penguin Books", "Tigana", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 35, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A sweeping standalone fantasy of dragons, queens, and ancient prophecy, set in a richly imagined world on the brink of cataclysm.", "978-0-06-055397-7", 18.99m, new DateTime(2019, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bloomsbury Publishing", "The Priory of the Orange Tree", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 36, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "An angel and a demon who have grown fond of Earth team up to avert the coming Apocalypse, complicated by a missing Antichrist.", "978-0-385-33348-1", 14.99m, new DateTime(1990, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gollancz", "Good Omens", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 37, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "In a world that experiences catastrophic climate events, a woman searches for her daughter amid the end of civilization.", "978-0-7564-1571-3", 15.99m, new DateTime(2015, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Orbit Books", "The Fifth Season", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 38, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A young nobleman takes control of the desert planet Arrakis, the only source of the universe's most valuable substance, melange.", "978-0-441-78935-8", 17.99m, new DateTime(1965, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chilton Books", "Dune", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 39, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The sequel to Dune, following Paul Atreides twelve years after his rise to power as religious and political forces conspire against him.", "978-0-441-17271-9", 15.99m, new DateTime(1969, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Putnam", "Dune Messiah", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 40, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "In a totalitarian future society, Winston Smith works for the government rewriting historical records and begins a doomed resistance.", "978-0-451-52493-5", 12.99m, new DateTime(1949, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Secker & Warburg", "1984", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 41, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A dystopian vision of a future where humans are genetically engineered and conditioned to be happy consumers in a rigid caste system.", "978-0-06-085052-4", 12.99m, new DateTime(1932, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chatto & Windus", "Brave New World", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 42, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "An ordinary man is swept into an absurd adventure across the universe after Earth is demolished to make way for a hyperspace bypass.", "978-0-7432-7358-9", 12.99m, new DateTime(1979, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pan Books", "The Hitchhiker's Guide to the Galaxy", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 43, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A mathematician foresees the fall of a galactic empire and establishes a foundation to preserve knowledge and shorten the coming dark age.", "978-0-553-29335-3", 14.99m, new DateTime(1951, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gnome Press", "Foundation", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 44, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Foundation faces a dual threat: the remnants of the old Galactic Empire and a mysterious mutant known as the Mule.", "978-0-553-29337-7", 14.99m, new DateTime(1952, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gnome Press", "Foundation and Empire", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 45, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A collection of interconnected stories exploring the relationship between humans and robots governed by the Three Laws of Robotics.", "978-0-553-29338-4", 13.99m, new DateTime(1950, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gnome Press", "I, Robot", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 46, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A washed-up hacker is hired by a mysterious employer for one last job: hacking the most powerful artificial intelligence in the world.", "978-0-7432-7359-6", 14.99m, new DateTime(1984, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ace Books", "Neuromancer", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 47, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A human emissary travels to a planet where the inhabitants have no fixed gender, challenging his own assumptions about identity and society.", "978-0-316-76948-1", 13.99m, new DateTime(1969, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ace Books", "The Left Hand of Darkness", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 48, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A gifted child is trained at a military school in space to become the commander of Earth's forces against an alien species.", "978-0-553-38016-3", 13.99m, new DateTime(1985, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tor Books", "Ender's Game", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 49, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A 75-year-old man joins the army to fight humanity's interstellar wars, given a young enhanced body in exchange for military service.", "978-1-59606-399-7", 13.99m, new DateTime(2005, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tor Books", "Old Man's War", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 50, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "An astronaut is accidentally left behind on Mars and must use his ingenuity to survive and signal his crew to return.", "978-0-7653-7230-0", 15.99m, new DateTime(2011, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Crown Publishing", "The Martian", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 51, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A lone astronaut wakes with no memory in a spacecraft far from Earth and must piece together his mission to save humanity.", "978-0-7653-7654-4", 16.99m, new DateTime(2021, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ballantine Books", "Project Hail Mary", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 52, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "During China's Cultural Revolution, a secret military project sends signals into space, leading to first contact with a civilization facing cosmic doom.", "978-0-8041-7734-8", 16.99m, new DateTime(2008, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tor Books", "The Three-Body Problem", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 53, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "As alien invasion looms, one man is given the mission to devise a secret strategy to save Earth using only his own mind.", "978-0-8041-7735-5", 16.99m, new DateTime(2008, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tor Books", "The Dark Forest", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 54, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "An Artificial Friend observes the human world from a shop window, waiting to be chosen, and contemplating what it truly means to love.", "978-0-316-38957-1", 15.99m, new DateTime(2021, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Faber & Faber", "Klara and the Sun", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 55, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A haunting tale of three friends who grew up together at a seemingly idyllic English boarding school and discover their terrifying purpose.", "978-0-385-49081-6", 14.99m, new DateTime(2005, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Faber & Faber", "Never Let Me Go", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 56, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "In a near-future America, a hacker and pizza deliveryman investigates a new drug that is crashing the Metaverse and its users' minds.", "978-0-7432-7360-2", 15.99m, new DateTime(1992, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bantam Books", "Snow Crash", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 57, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Uplifted spiders evolve civilization on a terraformed planet while the last remnants of humanity desperately search for a new home.", "978-0-525-55360-5", 15.99m, new DateTime(2015, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tor Books", "Children of Time", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 58, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "First contact with an alien species forces humanity to question the nature of consciousness and what it means to be sentient.", "978-0-7653-2635-5", 14.99m, new DateTime(2006, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tor Books", "Blindsight", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 59, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A self-described 'murderbot' with hacked governor protocols just wants to watch TV serials while reluctantly protecting its human clients.", "978-0-385-54734-9", 11.99m, new DateTime(2017, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tor.com", "All Systems Red", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 60, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A scientist's memory technology is weaponized to rewrite reality, forcing a detective and the inventor herself to fight through altered timelines.", "978-0-316-23877-5", 16.99m, new DateTime(2019, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Crown Publishing", "Recursion", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 61, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "An ambassador from a small space station arrives in the capital of a vast interstellar empire and discovers a plot threatening all humanity.", "978-0-7653-9358-0", 16.99m, new DateTime(2019, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tor Books", "A Memory Called Empire", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 62, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A crew of misfits aboard a tunneling ship takes on a job that sends them on a long journey to the galactic core.", "978-1-250-31357-3", 14.99m, new DateTime(2014, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hodder & Stoughton", "The Long Way to a Small, Angry Planet", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 63, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The story of Elizabeth Bennet and her complex relationship with the proud and wealthy Mr. Darcy, set in rural England.", "978-0-14-043723-0", 9.99m, new DateTime(1813, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "T. Egerton", "Pride and Prejudice", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 64, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Two sisters navigate the pitfalls of love and society in 19th century England, contrasting rational judgment with romantic feeling.", "978-0-14-143951-8", 9.99m, new DateTime(1811, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thomas Egerton", "Sense and Sensibility", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 65, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "An orphaned girl grows up to become a governess and falls in love with her brooding employer, concealing a terrible secret.", "978-0-14-143952-5", 10.99m, new DateTime(1847, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smith, Elder & Co.", "Jane Eyre", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 66, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The brooding Heathcliff and his passionate love for Catherine Earnshaw unfold across two generations of turbulent Yorkshire families.", "978-0-14-143955-6", 10.99m, new DateTime(1847, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thomas Newby", "Wuthering Heights", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 67, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A young orphan boy named Pip aspires to become a gentleman after a mysterious benefactor provides him with unexpected wealth.", "978-0-14-143954-9", 10.99m, new DateTime(1861, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chapman & Hall", "Great Expectations", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 68, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Set during the French Revolution, a story of love, sacrifice, and redemption connecting London and Paris.", "978-0-14-143960-0", 10.99m, new DateTime(1859, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chapman & Hall", "A Tale of Two Cities", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 69, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A married aristocrat risks everything for love, while a landowner seeks meaning in a changing Russian society.", "978-0-14-143957-0", 13.99m, new DateTime(1878, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Russian Messenger", "Anna Karenina", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 70, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A sweeping epic of Russian society during the Napoleonic Wars, following five intertwined aristocratic families.", "978-0-14-030474-4", 19.99m, new DateTime(1869, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Russian Messenger", "War and Peace", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 71, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A destitute student murders a pawnbroker and then grapples with the psychological consequences of his act in St. Petersburg.", "978-0-14-044913-4", 11.99m, new DateTime(1866, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Russian Messenger", "Crime and Punishment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 72, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Three brothers, representing different facets of humanity, are bound together by the murder of their despicable father.", "978-0-14-044919-6", 14.99m, new DateTime(1880, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Russian Messenger", "The Brothers Karamazov", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 73, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "An aging nobleman so obsessed with chivalric tales that he sets out as a knight-errant, accompanied by his practical squire Sancho Panza.", "978-0-14-028329-7", 14.99m, new DateTime(1605, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Francisco de Robles", "Don Quixote", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 74, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prince Hamlet seeks revenge for his father's murder by his uncle, who has seized the throne of Denmark and married Hamlet's mother.", "978-0-14-028381-5", 9.99m, new DateTime(1603, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nicholas Ling", "Hamlet", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 75, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Captain Ahab's obsessive quest to hunt the great white whale that took his leg leads his crew to disaster.", "978-0-14-071455-7", 12.99m, new DateTime(1851, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harper & Brothers", "Moby-Dick", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 76, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A woman in Puritan New England is forced to wear a scarlet A as punishment for adultery, exploring themes of sin and guilt.", "978-0-7432-7361-9", 9.99m, new DateTime(1850, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ticknor, Reed and Fields", "The Scarlet Letter", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 77, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A young boy and an escaped slave travel down the Mississippi River on a raft, confronting the hypocrisy of society.", "978-0-14-028381-6", 9.99m, new DateTime(1884, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chatto & Windus", "The Adventures of Huckleberry Finn", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 78, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A young man's portrait ages and becomes corrupt in his place while he himself remains young and beautiful, living a life of moral decay.", "978-0-14-317752-0", 10.99m, new DateTime(1890, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ward, Lock and Company", "The Picture of Dorian Gray", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 79, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A scientist creates a living being from dead matter, only to be horrified by his creation and abandon it to a tragic existence.", "978-0-14-028381-7", 9.99m, new DateTime(1818, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lackington, Hughes, Harding, Mavor & Jones", "Frankenstein", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 80, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Solicitor Jonathan Harker visits a Transylvanian castle, and a vampiric Count follows him to England to prey on the living.", "978-0-14-028381-8", 9.99m, new DateTime(1897, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Archibald Constable and Company", "Dracula", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 81, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A man wrongly imprisoned escapes after years of captivity and returns as the mysterious Count of Monte Cristo to exact his revenge.", "978-0-14-028381-9", 14.99m, new DateTime(1844, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pétion", "The Count of Monte Cristo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 82, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "An ex-convict pursued by a relentless policeman strives to become an honest man in post-Revolutionary France.", "978-0-14-028382-0", 16.99m, new DateTime(1862, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "A. Lacroix, Verboeckhoven & Cie", "Les Misérables", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 83, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A doctor's wife, dissatisfied with rural provincial life, pursues romantic affairs and material pleasures with ruinous consequences.", "978-0-14-028382-1", 10.99m, new DateTime(1857, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michel Lévy Frères", "Madame Bovary", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 84, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The interlocking stories of residents of a fictional English Midlands town in the period of 1829-32, exploring idealism and marriage.", "978-0-14-028382-2", 13.99m, new DateTime(1871, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "William Blackwood and Sons", "Middlemarch", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 85, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Detailing one day in the life of Leopold Bloom in Dublin, this modernist novel mirrors the structure of Homer's Odyssey.", "978-0-14-028382-3", 14.99m, new DateTime(1922, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sylvia Beach", "Ulysses", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 86, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A family's visit to a Scottish island over two days separated by ten years explores memory, loss, and the nature of time.", "978-0-14-028382-4", 10.99m, new DateTime(1927, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hogarth Press", "To the Lighthouse", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 87, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A mysterious millionaire's obsession with a lost love plays out against the backdrop of the decadent Jazz Age in 1920s America.", "978-0-14-028382-5", 10.99m, new DateTime(1925, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Charles Scribner's Sons", "The Great Gatsby", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 88, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Two displaced ranch workers dream of owning their own farm during the Great Depression, but their dream is tragically fragile.", "978-0-14-028382-6", 9.99m, new DateTime(1937, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Covici Friede", "Of Mice and Men", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 89, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "An aging Cuban fisherman struggles to land a giant marlin far out in the Gulf Stream, a battle of will and endurance.", "978-0-14-028382-7", 9.99m, new DateTime(1952, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Charles Scribner's Sons", "The Old Man and the Sea", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 90, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lawyer Atticus Finch defends a Black man falsely accused of rape in the Deep South, seen through the eyes of his young daughter Scout.", "978-0-06-112008-7", 10.99m, new DateTime(1960, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "J. B. Lippincott & Co.", "To Kill a Mockingbird", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 91, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A disenchanted teenager narrates his aimless days in New York City after being expelled from prep school, exploring alienation and identity.", "978-0-316-76948-2", 10.99m, new DateTime(1951, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Little, Brown and Company", "The Catcher in the Rye", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 92, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "British boys stranded on a deserted island descend into savagery as they try to govern themselves without adult supervision.", "978-0-14-028382-9", 10.99m, new DateTime(1954, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Faber and Faber", "Lord of the Flies", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 93, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Following the defeat of the Lord Ruler, Vin and her companions struggle to maintain order as new threats and ancient prophecies emerge.", "978-0-7432-7362-6", 17.99m, new DateTime(2007, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tor Books", "Mistborn: The Well of Ascension", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 94, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The conclusion of the Mistborn trilogy, in which Vin and Elend battle against the ancient force of Ruin threatening all life.", "978-0-7432-7363-3", 17.99m, new DateTime(2008, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tor Books", "The Hero of Ages", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 95, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The second book of The First Law trilogy, in which three storylines converge: a doomed expedition, a city under siege, and a torturer on trial.", "978-0-575-09390-1", 13.99m, new DateTime(2007, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gollancz", "Before They Are Hanged", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 96, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The First Law trilogy concludes as war comes to the Union, political machinations reach their peak, and dark truths are finally revealed.", "978-0-575-07979-1", 13.99m, new DateTime(2008, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gollancz", "Last Argument of Kings", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 97, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A young girl with a gift for violence is recruited to a convent of killers on a dying world illuminated by a narrowing band of sunlight.", "978-0-06-112009-4", 15.99m, new DateTime(2017, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ace Books", "Red Sister", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 98, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A young prince leads a band of brothers through a dark medieval world, seeking revenge for his mother's murder.", "978-0-06-112009-5", 14.99m, new DateTime(2011, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "HarperVoyager", "Prince of Thorns", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 99, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The world's most powerful man discovers he has a son and must face the consequences of a secret kept for sixteen years.", "978-1-59020-842-2", 16.99m, new DateTime(2010, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Orbit Books", "The Black Prism", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 100, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A man lives alone in a labyrinthine house with infinite halls filled with statues and tides, slowly uncovering his forgotten past.", "978-0-316-38957-2", 13.99m, new DateTime(2020, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bloomsbury Publishing", "Piranesi", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 101, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A graduate student discovers a mysterious book that leads him to an underground world devoted to storytelling and books.", "978-0-316-38957-3", 14.99m, new DateTime(2019, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doubleday", "The Starless Sea", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 102, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A young woman crosses the Wall into the Old Kingdom to rescue her necromancer father, wielding bells to bind the dead.", "978-0-316-38957-4", 13.99m, new DateTime(1995, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "HarperCollins", "Sabriel", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 103, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The sequel to Children of Time, in which human and spider-kind encounter a new alien intelligence across a distant solar system.", "978-0-525-55360-6", 15.99m, new DateTime(2019, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tor Books", "Children of Ruin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 104, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "An AI inhabiting a body for the first time must learn to navigate human society alongside a young woman escaping her own past.", "978-1-250-31357-4", 14.99m, new DateTime(2016, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hodder & Stoughton", "A Closed and Common Orbit", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 105, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Murderbot continues its investigations while pretending to be a bot, teaming up with another rogue AI along the way.", "978-0-385-54734-0", 11.99m, new DateTime(2018, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tor.com", "Rogue Protocol", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 106, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The sequel to A Memory Called Empire, in which a fleet commander investigates a mysterious alien entity beyond the empire's borders.", "978-0-7653-9358-1", 16.99m, new DateTime(2021, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tor Books", "A Desolation Called Peace", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 107, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Three thousand years after the Xenocide, Ender Wiggin travels to a distant world to speak for the dead and encounters a new alien species.", "978-0-7653-2637-0", 13.99m, new DateTime(1986, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tor Books", "Speaker for the Dead", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 108, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A physicist is abducted and wakes up in an alternate version of his life, desperate to find his way back to his family.", "978-0-316-76948-3", 15.99m, new DateTime(2016, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Crown Publishing", "Dark Matter", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 109, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "An unnamed Black man narrates his life from childhood in the South to adulthood in New York, exploring racial injustice and identity.", "978-0-14-028383-0", 11.99m, new DateTime(1952, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Random House", "Invisible Man", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 110, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A formerly enslaved woman is haunted by the ghost of her dead daughter in post-Civil War Ohio, confronting the trauma of slavery.", "978-0-14-028383-1", 12.99m, new DateTime(1987, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alfred A. Knopf", "Beloved", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 111, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Buendía family's multi-generational saga in the fictional town of Macondo, blending reality and magic in a chronicle of love and solitude.", "978-0-14-028383-2", 13.99m, new DateTime(1967, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Editorial Sudamericana", "One Hundred Years of Solitude", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 112, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A detached Algerian man commits a murder and faces trial, exploring themes of absurdism, indifference, and the meaning of existence.", "978-0-14-028383-3", 9.99m, new DateTime(1942, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gallimard", "The Stranger", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 5, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Speculative fiction exploring futuristic science, technology, space exploration, and their impact on society.", "Science Fiction", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Foundational works of literary fiction widely considered to be of superior quality and enduring significance.", "Classic", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "AuthorBook",
                columns: new[] { "AuthorsId", "BooksId" },
                values: new object[,]
                {
                    { 4, 13 },
                    { 4, 14 },
                    { 4, 15 },
                    { 5, 16 },
                    { 6, 17 },
                    { 6, 18 },
                    { 6, 19 },
                    { 6, 93 },
                    { 6, 94 },
                    { 7, 20 },
                    { 7, 21 },
                    { 8, 22 },
                    { 8, 95 },
                    { 8, 96 },
                    { 9, 23 },
                    { 10, 24 },
                    { 11, 25 },
                    { 11, 26 },
                    { 11, 36 },
                    { 12, 27 },
                    { 12, 36 },
                    { 13, 28 },
                    { 13, 29 },
                    { 13, 47 },
                    { 14, 30 },
                    { 15, 31 },
                    { 16, 32 },
                    { 16, 101 },
                    { 17, 33 },
                    { 17, 100 },
                    { 18, 34 },
                    { 19, 35 },
                    { 20, 37 },
                    { 21, 38 },
                    { 21, 39 },
                    { 22, 40 },
                    { 23, 41 },
                    { 24, 42 },
                    { 25, 43 },
                    { 25, 44 },
                    { 25, 45 },
                    { 26, 46 },
                    { 27, 48 },
                    { 27, 107 },
                    { 28, 49 },
                    { 29, 50 },
                    { 29, 51 },
                    { 30, 52 },
                    { 30, 53 },
                    { 31, 54 },
                    { 31, 55 },
                    { 32, 56 },
                    { 33, 57 },
                    { 33, 103 },
                    { 34, 58 },
                    { 35, 59 },
                    { 35, 105 },
                    { 36, 60 },
                    { 36, 108 },
                    { 37, 61 },
                    { 37, 106 },
                    { 38, 62 },
                    { 38, 104 },
                    { 39, 63 },
                    { 39, 64 },
                    { 40, 65 },
                    { 41, 66 },
                    { 42, 67 },
                    { 42, 68 },
                    { 43, 69 },
                    { 43, 70 },
                    { 44, 71 },
                    { 44, 72 },
                    { 45, 73 },
                    { 46, 74 },
                    { 47, 75 },
                    { 48, 76 },
                    { 49, 77 },
                    { 50, 78 },
                    { 51, 79 },
                    { 52, 80 },
                    { 53, 81 },
                    { 54, 82 },
                    { 55, 83 },
                    { 56, 84 },
                    { 57, 85 },
                    { 58, 86 },
                    { 59, 87 },
                    { 60, 88 },
                    { 61, 89 },
                    { 62, 90 },
                    { 63, 91 },
                    { 64, 92 },
                    { 65, 97 },
                    { 65, 98 },
                    { 66, 99 },
                    { 67, 102 },
                    { 68, 109 },
                    { 69, 110 },
                    { 70, 111 },
                    { 71, 112 }
                });

            migrationBuilder.InsertData(
                table: "BookGenre",
                columns: new[] { "BooksId", "GenresId" },
                values: new object[,]
                {
                    { 13, 1 },
                    { 14, 1 },
                    { 15, 1 },
                    { 16, 1 },
                    { 17, 1 },
                    { 18, 1 },
                    { 19, 1 },
                    { 20, 1 },
                    { 21, 1 },
                    { 22, 1 },
                    { 23, 1 },
                    { 24, 1 },
                    { 25, 1 },
                    { 26, 1 },
                    { 27, 1 },
                    { 28, 1 },
                    { 29, 1 },
                    { 30, 1 },
                    { 31, 1 },
                    { 32, 1 },
                    { 33, 1 },
                    { 34, 1 },
                    { 35, 1 },
                    { 36, 1 },
                    { 37, 1 },
                    { 38, 5 },
                    { 39, 5 },
                    { 40, 5 },
                    { 41, 5 },
                    { 42, 5 },
                    { 43, 5 },
                    { 44, 5 },
                    { 45, 5 },
                    { 46, 5 },
                    { 47, 5 },
                    { 48, 5 },
                    { 49, 5 },
                    { 50, 5 },
                    { 51, 5 },
                    { 52, 5 },
                    { 53, 5 },
                    { 54, 5 },
                    { 55, 5 },
                    { 56, 5 },
                    { 57, 5 },
                    { 58, 5 },
                    { 59, 5 },
                    { 60, 5 },
                    { 61, 5 },
                    { 62, 5 },
                    { 63, 6 },
                    { 64, 6 },
                    { 65, 6 },
                    { 66, 6 },
                    { 67, 6 },
                    { 68, 6 },
                    { 69, 6 },
                    { 70, 6 },
                    { 71, 6 },
                    { 72, 6 },
                    { 73, 6 },
                    { 74, 6 },
                    { 75, 6 },
                    { 76, 6 },
                    { 77, 6 },
                    { 78, 6 },
                    { 79, 6 },
                    { 80, 6 },
                    { 81, 6 },
                    { 82, 6 },
                    { 83, 6 },
                    { 84, 6 },
                    { 85, 6 },
                    { 86, 6 },
                    { 87, 6 },
                    { 88, 6 },
                    { 89, 6 },
                    { 90, 6 },
                    { 91, 6 },
                    { 92, 6 },
                    { 93, 1 },
                    { 94, 1 },
                    { 95, 1 },
                    { 96, 1 },
                    { 97, 1 },
                    { 98, 1 },
                    { 99, 1 },
                    { 100, 1 },
                    { 101, 1 },
                    { 102, 1 },
                    { 103, 5 },
                    { 104, 5 },
                    { 105, 5 },
                    { 106, 5 },
                    { 107, 5 },
                    { 108, 5 },
                    { 109, 6 },
                    { 110, 6 },
                    { 111, 6 },
                    { 112, 6 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 4, 13 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 4, 14 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 4, 15 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 5, 16 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 6, 17 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 6, 18 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 6, 19 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 6, 93 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 6, 94 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 7, 20 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 7, 21 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 8, 22 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 8, 95 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 8, 96 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 9, 23 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 10, 24 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 11, 25 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 11, 26 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 11, 36 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 12, 27 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 12, 36 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 13, 28 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 13, 29 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 13, 47 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 14, 30 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 15, 31 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 16, 32 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 16, 101 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 17, 33 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 17, 100 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 18, 34 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 19, 35 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 20, 37 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 21, 38 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 21, 39 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 22, 40 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 23, 41 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 24, 42 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 25, 43 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 25, 44 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 25, 45 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 26, 46 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 27, 48 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 27, 107 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 28, 49 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 29, 50 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 29, 51 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 30, 52 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 30, 53 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 31, 54 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 31, 55 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 32, 56 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 33, 57 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 33, 103 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 34, 58 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 35, 59 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 35, 105 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 36, 60 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 36, 108 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 37, 61 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 37, 106 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 38, 62 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 38, 104 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 39, 63 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 39, 64 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 40, 65 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 41, 66 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 42, 67 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 42, 68 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 43, 69 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 43, 70 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 44, 71 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 44, 72 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 45, 73 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 46, 74 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 47, 75 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 48, 76 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 49, 77 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 50, 78 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 51, 79 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 52, 80 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 53, 81 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 54, 82 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 55, 83 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 56, 84 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 57, 85 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 58, 86 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 59, 87 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 60, 88 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 61, 89 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 62, 90 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 63, 91 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 64, 92 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 65, 97 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 65, 98 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 66, 99 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 67, 102 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 68, 109 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 69, 110 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 70, 111 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 71, 112 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 13, 1 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 14, 1 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 15, 1 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 16, 1 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 17, 1 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 18, 1 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 19, 1 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 20, 1 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 21, 1 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 22, 1 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 23, 1 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 24, 1 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 25, 1 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 26, 1 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 27, 1 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 28, 1 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 29, 1 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 30, 1 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 31, 1 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 32, 1 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 33, 1 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 34, 1 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 35, 1 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 36, 1 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 37, 1 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 38, 5 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 39, 5 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 40, 5 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 41, 5 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 42, 5 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 43, 5 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 44, 5 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 45, 5 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 46, 5 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 47, 5 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 48, 5 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 49, 5 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 50, 5 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 51, 5 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 52, 5 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 53, 5 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 54, 5 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 55, 5 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 56, 5 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 57, 5 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 58, 5 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 59, 5 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 60, 5 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 61, 5 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 62, 5 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 63, 6 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 64, 6 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 65, 6 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 66, 6 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 67, 6 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 68, 6 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 69, 6 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 70, 6 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 71, 6 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 72, 6 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 73, 6 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 74, 6 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 75, 6 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 76, 6 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 77, 6 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 78, 6 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 79, 6 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 80, 6 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 81, 6 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 82, 6 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 83, 6 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 84, 6 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 85, 6 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 86, 6 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 87, 6 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 88, 6 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 89, 6 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 90, 6 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 91, 6 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 92, 6 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 93, 1 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 94, 1 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 95, 1 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 96, 1 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 97, 1 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 98, 1 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 99, 1 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 100, 1 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 101, 1 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 102, 1 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 103, 5 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 104, 5 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 105, 5 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 106, 5 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 107, 5 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 108, 5 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 109, 6 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 110, 6 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 111, 6 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 112, 6 });

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
