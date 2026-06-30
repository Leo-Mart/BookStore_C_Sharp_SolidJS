using System.Text.Json;
using BookStore.Models.Addresses;
using BookStore.Models.Authors;
using BookStore.Models.Books;
using BookStore.Models.Genres;
using BookStore.Models.Inventories;
using BookStore.Models.OrderItems;
using BookStore.Models.Orders;
using BookStore.Models.PaymentMethods;
using BookStore.Models.Payments;
using BookStore.Models.Reviews;
using BookStore.Models.ShippingMethods;
using BookStore.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BookStore.DbContexts
{
    public class ApplicationDbContext(DbContextOptions dbContextOptions) : IdentityDbContext<AppUser>(dbContextOptions)
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<ShippingMethod> ShippingMethods { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book()
                {
                    Id = 1,
                    Isbn = "9713196ajdhadhjakhd",
                    Title = "Gardens of the Moon",
                    Publisher = "Tor Books",
                    PublishedDate = new DateTime(1999, 1, 1),
                    Description = "Bled dry by interminable warfare, infighting and bloody confrontations with Lord Anomander Rake and his Tiste Andii, the vast, sprawling Malazan empire simmers with discontent. Even its imperial legions yearn for some respite. For Sergeant Whiskeyjack and his Bridgeburners, and for Tattersail - sole surviving sorceress of the Second Legion - the aftermath of the siege of Pale should have been a time to mourn the dead. But Darujhistan, the last of the Free Cities of Genabackis, still holds out against the empire - and Empress Lasseen's ambition knows no bounds. However, it seems the empire is not alone in this great game. Sinister forces gather as the gods themselves prepare to play their hand . . . Conceived and written on an epic scale, Gardens of the Moon is a breathtaking achievement - a novel in which grand design, a dark and complex mythology, wild and wayward magic and a host of enduring characters combine with thrilling, powerful storytelling to resounding effect",
                    Price = 150,
                    UpdatedAt = new DateTime(2026, 6, 5),
                    CreatedAt = new DateTime(2026, 6, 5)
                },
                new Book()
                {
                    Id = 2,
                    Isbn = "9713196ajdhadhjakhd",
                    Title = "Pride and Prejudice",
                    Publisher = "T. Egerton, Whitehall",
                    PublishedDate = new DateTime(1813, 1, 1),
                    Description = "MR DARCY!",
                    Price = 1337,
                    UpdatedAt = new DateTime(2026, 6, 5),
                    CreatedAt = new DateTime(2026, 6, 5)
                },
                new Book()
                {
                    Id = 3,
                    Isbn = "9713196ajdhadhjakhd",
                    Title = "House of Leaves",
                    Publisher = "A publisher",
                    PublishedDate = new DateTime(2020, 5, 11),
                    Description = "a house of leaves",
                    Price = 150,
                    UpdatedAt = new DateTime(2026, 6, 5),
                    CreatedAt = new DateTime(2026, 6, 5)
                },
                new Book()
                {
                    Id = 4,
                    Isbn = "9780765348791",
                    Title = "Deadhouse Gates",
                    Publisher = "Tor Books",
                    PublishedDate = new DateTime(2000, 1, 1),
                    Description = "In the Holy Desert Raraku, the seer Sha'ik and her followers prepare for the long-prophesied uprising named the Whirlwind. Enslaved in the Otataral mines, Felisin - youngest scion of the disgraced House of Paran - dreams of freedom and vows revenge. The outlawed Bridgeburners Fiddler and Kalam conspire to rid the world of the Empress Laseen - although it seems the gods would, as always, have it otherwise. And as two ancient warriors - bearers of a devastating secret - enter this blighted land, so an untried commander of the Malaz 7th Army leads his war-weary troops in a last, valiant running battle to save the lives of thirty thousand refugees.",
                    Price = 200,
                    UpdatedAt = new DateTime(2026, 6, 5),
                    CreatedAt = new DateTime(2026, 6, 5)
                },
                new Book()
                {
                    Id = 5,
                    Isbn = "9780765348807",
                    Title = "Memories of Ice",
                    Publisher = "Tor Books",
                    PublishedDate = new DateTime(2001, 1, 1),
                    Description = "The ravaged continent of Genabackis has given birth to a terrifying new empire: the Pannion Domin. Like a fanatical tide of corrupted blood, it seethes across the land, devouring all who fail to heed the Word of its elusive prophet, the Pannion Seer. In its path stands an uneasy alliance: Dujek Onearm's Host and the Bridgeburners - each now outlawed by the Empress ­- alongside some enemies of old that include the grim forces of Warlord Caladan Brood, Anomander Rake, Son of Darkness, and his Tiste Andii, and the Rhivi people of the Plains. But more ancient clans are also gathering. As if in answer to some primal summons, the massed ranks of the undead T'lan Imass have risen. It would seem that something altogether darker and more malign threatens the very substance of this world. The Warrens are poisoned, and rumours abound that the Crippled God is now unchained and intent on a terrible revenge . . .",
                    Price = 239,
                    UpdatedAt = new DateTime(2026, 6, 5),
                    CreatedAt = new DateTime(2026, 6, 5)
                },
                new Book()
                {
                    Id = 6,
                    Isbn = "9780765348814",
                    Title = "House of Chains",
                    Publisher = "Tor Books",
                    PublishedDate = new DateTime(2002, 1, 1),
                    Description = "Years after a tribal attack on the southern flatlands, Tavore, an Adjunct to the Empress, struggles to train a band of some twelve thousand inexperienced recruits to meet an attack by the forces of her sister, Sha'ik",
                    Price = 239,
                    UpdatedAt = new DateTime(2026, 6, 5),
                    CreatedAt = new DateTime(2026, 6, 5)
                },
                new Book()
                {
                    Id = 7,
                    Isbn = "9780765348821",
                    Title = "Midnight Tides",
                    Publisher = "Tor Books",
                    PublishedDate = new DateTime(2004, 1, 1),
                    Description = "After decades of warfare, the five tribes of the Tiste Edur have finally been united under the implacable rule of the Warlock King of Hiroth, but their peace has been exacted at the cost of a pact made with a hidden power, and ancient forces are awakening that could unleash a vengeful bloodbath on all concerned",
                    Price = 239,
                    UpdatedAt = new DateTime(2026, 6, 5),
                    CreatedAt = new DateTime(2026, 6, 5)
                },
                new Book()
                {
                    Id = 8,
                    Isbn = "9780765348838",
                    Title = "The Bonehunters",
                    Publisher = "Tor Books",
                    PublishedDate = new DateTime(2006, 1, 1),
                    Description = "The Seven Cities Rebellion has been crushed. Sha'ik is dead. One last rebel force remains, holed up in the city of Y'Ghatan and under the fanatical command of Leoman of the Flails. The prospect of laying siege to this ancient fortress makes the battle-weary Malaz 14th Army uneasy. For it was here that the Empire's greatest champion Dassem Ultor was slain and a tide of Malazan blood spilled. A place of foreboding, its smell is of death. But elsewhere, agents of a far greater conflict have made their opening moves. The Crippled God has been granted a place in the pantheon, a schism threatens and sides must be chosen. Whatever each god decides, the ground-rules have changed, irrevocably, terrifyingly and the first blood spilled will be in the mortal world. A world in which a host of characters, familiar and new, including Heboric Ghost Hands, the possessed Apsalar, Cutter, once a thief now a killer, the warrior Karsa Orlong and the two ancient wanderers Icarium and Mappo--each searching for such a fate as they might fashion with their own hands, guided by their own will. If only the gods would leave them alone. But now that knives have been unsheathed, the gods are disinclined to be kind. There shall be war, war in the heavens. And, the prize? Nothing less than existence itself... Here is the stunning new chapter in Steven Erikson magnificent Malazan Book of the Fallen--hailed as an epic of the imagination and acknowledged as a fantasy classic in the making.",
                    Price = 219,
                    UpdatedAt = new DateTime(2026, 6, 5),
                    CreatedAt = new DateTime(2026, 6, 5)
                },
                new Book()
                {
                    Id = 9,
                    Isbn = "9780765348845",
                    Title = "Reaper's Gale",
                    Publisher = "Tor Books",
                    PublishedDate = new DateTime(2007, 1, 1),
                    Description = "All is not well in the Letherii Empire. Rhulad Sengar, the Emperor of a Thousand Deaths, spirals into madness, surrounded by sycophants and agents of his Machiavellian chancellor. Meanwhile, the Letherii secret police conduct a campaign of terror against their own people. The Errant, once a farseeing god, is suddenly blind to the future. Conspiracies seethe throughout the palace, as the empire - driven by the corrupt and self-interested - edges ever-closer to all-out war with the neighboring kingdoms. The great Edur fleet--its warriors selected from countless numbers of people--draws closer. Amongst the warriors are Karsa Orlong and Icarium Lifestealer--each destined to cross blades with the emperor himself. That yet more blood is to be spilled is inevitable... Against this backdrop, a band of fugitives seek a way out of the empire, but one of them, Fear Sengar, must find the soul of Scabandari Bloodeye. It is his hope that the soul might help halt the Tiste Edur, and so save his brother, the emperor. Yet, traveling with them is Scabandari's most ancient foe: Silchas Ruin, brother of Anomander Rake. And his motives are anything but certain - for the wounds he carries on his back, made by the blades of Scabandari, are still fresh. Fate decrees that there is to be a reckoning, for such bloodshed cannot go unanswered--and it will be a reckoning on an unimaginable scale. This is a brutal, harrowing novel of war, intrigue and dark, uncontrollable magic; this is epic fantasy at its most imaginative, storytelling at its most thrilling.",
                    Price = 239,
                    UpdatedAt = new DateTime(2026, 6, 5),
                    CreatedAt = new DateTime(2026, 6, 5)
                },
                new Book()
                {
                    Id = 10,
                    Isbn = "9780765348852",
                    Title = "Toll the Hounds",
                    Publisher = "Tor Books",
                    PublishedDate = new DateTime(2008, 1, 1),
                    Description = "It is said that Hood waits at the end of every plot, every scheme, each grandiose ambition. But this time it is different: this time the Lord of Death is there at the beginning... Darujhistan swelters in the summer heat and seethes with portents, rumours and whispers. Strangers have arrived, a murderer is abroad, past-tyrannies are stirring and assassins seem to be targeting the owners of K'rul's Bar. For the rotund, waistcoat-clad man knows such events will be dwarfed by what is about to happen: for in the distance can be heard the baying of hounds. Far away, in Black Coral, the ruling Tiste Andii appear oblivious to the threat posed by the fast-growing cult of the Redeemer - an honourable, one-mortal man who seems powerless against the twisted vision of his followers. So Hood waits at the beginning of a conspiracy that will shake the cosmos, but at its end there is another: Anomander Rake, Son of Darkness, has come to right an ancient and terrible wrong...",
                    Price = 239,
                    UpdatedAt = new DateTime(2026, 6, 5),
                    CreatedAt = new DateTime(2026, 6, 5)
                },
                new Book()
                {
                    Id = 11,
                    Isbn = "9780765348869",
                    Title = "Dust of Dreams",
                    Publisher = "Tor Books",
                    PublishedDate = new DateTime(2009, 1, 1),
                    Description = "The penultimate book in the acclaimed Malazan Book of the Fallen fantasy seriesOn the Letherii continent the exiled Malazan army commanded by Adjunct Tavore begins its march into the eastern Wastelands, to fight for an unknown cause against an enemy it has never seen.",
                    Price = 239,
                    UpdatedAt = new DateTime(2026, 6, 5),
                    CreatedAt = new DateTime(2026, 6, 5)
                },
                new Book()
                {
                    Id = 12,
                    Isbn = "9780765348876",
                    Title = "The Crippled God",
                    Publisher = "Tor Books",
                    PublishedDate = new DateTime(2011, 1, 1),
                    Description = "The final, apocalyptic chapter in one of the most original, exciting and acclaimed fantasy series of our time . Their desire is to cleanse the world - to eradicate every civilization, to annihilate every human - in order to begin anew. And outside the abandoned city of Kharkanas, thousands have gathered upon the First Shore.",
                    Price = 239,
                    UpdatedAt = new DateTime(2026, 6, 5),
                    CreatedAt = new DateTime(2026, 6, 5)
                }
            );

            modelBuilder.Entity<AppUser>().HasData(
                new AppUser
                {
                    Id = "26a17d98-2564-4a5c-a21d-8b806ca91db9",
                    UserName = "Mrs.Test",
                    FirstName = "Mrs.",
                    LastName = "Test",
                    NormalizedUserName = "MRS.TEST",
                    Email = "mrstest@test.com",
                    NormalizedEmail = "MRSTEST@TEST.COM",
                    EmailConfirmed = false,
                    SecurityStamp = "A_SECURITY_STAMP",
                    ConcurrencyStamp = "1",
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                    PasswordHash = "AQAAAAIAAYagAAAAEDo5bk0UyyMvrhmqvw+gCLnDkvWWjE2xbXj6qX93YoEOYLR9pY5LGwBNm0qDScF23g=="
                },
                new AppUser
                {
                    Id = "ab2c49be-9e83-41af-82b5-9165ddeb125f",
                    FirstName = "Mr.",
                    LastName = "Test",
                    UserName = "Mr.Test",
                    NormalizedUserName = "MR.TEST",
                    Email = "mrtest@test.com",
                    NormalizedEmail = "MRTEST@TEST.COM",
                    EmailConfirmed = false,
                    SecurityStamp = "A_SECURITY_STAMP",
                    ConcurrencyStamp = "1",
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                    PasswordHash = "AQAAAAIAAYagAAAAEDo5bk0UyyMvrhmqvw+gCLnDkvWWjE2xbXj6qX93YoEOYLR9pY5LGwBNm0qDScF23g=="
                }
            );

            modelBuilder.Entity<Review>().HasData(
                new Review()
                {
                    Id = 1,
                    BookId = 1,
                    AppUserId = "26a17d98-2564-4a5c-a21d-8b806ca91db9",
                    Title = "Such a good series",
                    Text = "Wow. So good.",
                    Score = 5,
                    UpdatedAt = new DateTime(2026, 6, 5),
                    CreatedAt = new DateTime(2026, 6, 5)
                },
                new Review()
                {
                    Id = 2,
                    BookId = 1,
                    AppUserId = "ab2c49be-9e83-41af-82b5-9165ddeb125f",
                    Title = "Such a bad series",
                    Text = "Wow. So bad.",
                    Score = 1,
                    UpdatedAt = new DateTime(2026, 6, 5),
                    CreatedAt = new DateTime(2026, 6, 5)
                },
                new Review()
                {
                    Id = 3,
                    BookId = 2,
                    AppUserId = "26a17d98-2564-4a5c-a21d-8b806ca91db9",
                    Title = "He is so dreamy",
                    Text = "Wow. So dreamy.",
                    Score = 5,
                    UpdatedAt = new DateTime(2026, 6, 5),
                    CreatedAt = new DateTime(2026, 6, 5)
                },
                new Review()
                {
                    Id = 4,
                    BookId = 2,
                    AppUserId = "ab2c49be-9e83-41af-82b5-9165ddeb125f",
                    Title = "She is so dreamy",
                    Text = "Wow. So dreamy.",
                    Score = 5,
                    UpdatedAt = new DateTime(2026, 6, 5),
                    CreatedAt = new DateTime(2026, 6, 5)
                }
            );

            modelBuilder.Entity<Author>().HasData(
                new Author()
                {
                    Id = 1,
                    FirstName = "Steven",
                    LastName = "Eriksson",
                    Bio = "Canadian?",
                    UpdatedAt = new DateTime(2026, 6, 5),
                    CreatedAt = new DateTime(2026, 6, 5)
                },
                new Author()
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Austen",
                    Bio = "English?",
                    UpdatedAt = new DateTime(2026, 6, 5),
                    CreatedAt = new DateTime(2026, 6, 5)
                },
                new Author()
                {
                    Id = 3,
                    FirstName = "Mark",
                    LastName = "Z. Danielewski",
                    Bio = "no clue where this dude is from, could google it, but...",
                    UpdatedAt = new DateTime(2026, 6, 5),
                    CreatedAt = new DateTime(2026, 6, 5)
                }
            );

            modelBuilder.Entity<Genre>().HasData(
                new Genre()
                {
                    Id = 1,
                    Name = "Fantasy",
                    Description = "Here be dragons",
                    UpdatedAt = new DateTime(2026, 6, 5),
                    CreatedAt = new DateTime(2026, 6, 5)
                },
                new Genre()
                {
                    Id = 2,
                    Name = "Romance",
                    Description = "Smooches",
                    UpdatedAt = new DateTime(2026, 6, 5),
                    CreatedAt = new DateTime(2026, 6, 5)
                },
                new Genre()
                {
                    Id = 3,
                    Name = "Horror",
                    Description = "Spooky-scary skeletons",
                    UpdatedAt = new DateTime(2026, 6, 5),
                    CreatedAt = new DateTime(2026, 6, 5)
                },
                new Genre()
                {
                    Id = 4,
                    Name = "Satire",
                    Description = "Fools are my theme, let satire be my song.",
                    UpdatedAt = new DateTime(2026, 6, 5),
                    CreatedAt = new DateTime(2026, 6, 5)
                },
                new Genre()
                {
                    Id = 5,
                    Name = "Science Fiction",
                    Description = "Speculative fiction exploring futuristic science, technology, space exploration, and their impact on society.",
                    CreatedAt = new(2026, 1, 1),
                    UpdatedAt = new(2026, 1, 1)
                },
                new Genre()
                {
                    Id = 6,
                    Name = "Classic",
                    Description = "Foundational works of literary fiction widely considered to be of superior quality and enduring significance.",
                    CreatedAt = new(2026, 1, 1),
                    UpdatedAt = new(2026, 1, 1)
                }
            );

            modelBuilder.Entity<Order>()
                .HasOne(o => o.ShippingMethod)
                .WithMany(sm => sm.Orders)
                .HasForeignKey(o => o.ShippingMethodId)
                .OnDelete(DeleteBehavior.NoAction);
                
            modelBuilder.Entity<ShippingMethod>()
                .HasData(
                    new ShippingMethod
                    {
                        Id = 1,
                        Company = "Postnord",
                        Type = "pick-up",
                        Price = 49,
                        Description = "Pick up your parcel at a nearby pick-up point"
                    },
                    new ShippingMethod
                    {
                        Id = 2,
                        Company = "Postnord",
                        Type = "home",
                        Price = 100,
                        Description = "The parcel is delivered to your door."
                    },
                    new ShippingMethod
                    {
                        Id = 3,
                        Company = "Dhl",
                        Type = "pick-up",
                        Price = 49,
                        Description = "The parcel can be picked up from a DHL service point."
                    },
                    new ShippingMethod
                    {
                        Id = 4,
                        Company = "instabox",
                        Type = "box",
                        Price = 49,
                        Description = "The parcel can be picked up from a Instabox parcel-box."
                    },
                    new ShippingMethod
                    {
                        Id = 5,
                        Company = "budbee",
                        Type = "box",
                        Price = 49,
                        Description = "The parcel can be picked up from a Budbee parcel-box."
                    }
                );

            modelBuilder.Entity<Book>()
                .HasMany(a => a.Authors)
                .WithMany(b => b.Books)
                .UsingEntity(j => j.HasData(
                    new { BooksId = 1, AuthorsId = 1 },
                    new { BooksId = 2, AuthorsId = 2 },
                    new { BooksId = 3, AuthorsId = 3 },
                    new { BooksId = 4, AuthorsId = 1 },
                    new { BooksId = 5, AuthorsId = 1 },
                    new { BooksId = 6, AuthorsId = 1 },
                    new { BooksId = 7, AuthorsId = 1 },
                    new { BooksId = 8, AuthorsId = 1 },
                    new { BooksId = 9, AuthorsId = 1 },
                    new { BooksId = 10, AuthorsId = 1 },
                    new { BooksId = 11, AuthorsId = 1 },
                    new { BooksId = 12, AuthorsId = 1 }
                ));

            modelBuilder.Entity<Book>()
                .HasMany(g => g.Genres)
                .WithMany(b => b.Books)
                .UsingEntity(j => j.HasData(
                    new { BooksId = 1, GenresId = 1 },
                    new { BooksId = 2, GenresId = 4 },
                    new { BooksId = 2, GenresId = 2 },
                    new { BooksId = 3, GenresId = 3 },
                    new { BooksId = 4, GenresId = 1 },
                    new { BooksId = 5, GenresId = 1 },
                    new { BooksId = 6, GenresId = 1 },
                    new { BooksId = 7, GenresId = 1 },
                    new { BooksId = 8, GenresId = 1 },
                    new { BooksId = 9, GenresId = 1 },
                    new { BooksId = 10, GenresId = 1 },
                    new { BooksId = 11, GenresId = 1 },
                    new { BooksId = 12, GenresId = 1 }
                ));

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = "Admin",
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = "1"

                },
                new IdentityRole
                {
                    Id = "User",
                    Name = "User",
                    NormalizedName = "USER",
                    ConcurrencyStamp = "1"
                }
            };
            modelBuilder.Entity<IdentityRole>().HasData(roles);

            modelBuilder.Entity<Inventory>()
                .HasOne(i => i.Book)
                .WithOne(b => b.Inventory)
                .HasForeignKey<Inventory>(i => i.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Inventory>().HasData(
                new Inventory()
                {
                    Id = 1,
                    BookId = 1,
                    AmountInStock = 20,
                    ReorderThreshold = 5,
                    UpdatedAt = new DateTime(2026, 6, 12),
                    CreatedAt = new DateTime(2026, 6, 12)
                }
            );

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.AppUserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Address)
                .WithMany(a => a.Orders)
                .HasForeignKey(o => o.AddressId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.PaymentMethod)
                .WithMany(p => p.Orders)
                .HasForeignKey(o => o.PaymentMethodId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PaymentMethod>()
                .HasOne(pm => pm.AppUser)
                .WithMany(u => u.PaymentMethods)
                .HasForeignKey(pm => pm.AppUserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Order)
                .WithMany()
                .HasForeignKey(p => p.OrderId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.PaymentMethod)
                .WithMany(pm => pm.Payments)
                .HasForeignKey(p => p.PaymentMethodId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.Items)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Book)
                .WithMany(b => b.OrderItems)
                .HasForeignKey(oi => oi.BookId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Book>().HasData(SeedBooksFromJSON(@"./SeedData/books.json"));
            modelBuilder.Entity<Author>().HasData(SeedAuthorFromJSON(@"./SeedData/authors.json"));

            var rawBookAuthors = System.Text.Json.JsonSerializer.Deserialize<List<JsonElement>>(File.ReadAllText(@"./SeedData/book_authors.json"));
            var bookAuthorSeedData = rawBookAuthors.Select(e => new
            {
                BooksId = e.GetProperty("booksId").GetInt32(),
                AuthorsId = e.GetProperty("authorsId").GetInt32()
            }).ToArray();

            var rawBooksGenres = System.Text.Json.JsonSerializer.Deserialize<List<JsonElement>>(File.ReadAllText(@"./SeedData/book_genres.json"));
            var bookGenresSeedData = rawBooksGenres.Select(e => new
            {
                BooksId = e.GetProperty("booksId").GetInt32(),
                GenresId = e.GetProperty("genresId").GetInt32()
            }).ToArray();

            modelBuilder.Entity<Book>()
                .HasMany(a => a.Authors)
                .WithMany(b => b.Books)
                .UsingEntity(j => j.HasData(bookAuthorSeedData));

            modelBuilder.Entity<Book>()
                .HasMany(g => g.Genres)
                .WithMany(b => b.Books)
                .UsingEntity(j => j.HasData(bookGenresSeedData));

            base.OnModelCreating(modelBuilder);
        }

        public List<Book> SeedBooksFromJSON(string path)
        {
            var data = new List<Book>();
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();

                data = JsonConvert.DeserializeObject<List<Book>>(json);
            }
            return data;
        }

        public List<Author> SeedAuthorFromJSON(string path)
        {
            var data = new List<Author>();
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();

                data = JsonConvert.DeserializeObject<List<Author>>(json);
            }
            return data;
        }
    }
}