using AnnApp.DataProvider.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnApp.DataProvider.Context
{
    public class AnnContext : DbContext
    {
        public DbSet<Announcement> Annoucements { get; set; }
        public AnnContext(DbContextOptions<AnnContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Announcement>().HasData(
                new Announcement
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "An Old Man Lived in the Village",
                    Description = @"An old man lived in the village. He was one of the most unfortunate people in the world. The whole village was tired of him; he was always gloomy, he constantly complained and was always in a bad mood.

         longer he lived,
                the more bile he was becoming and the more poisonous were his words.People avoided him,
                because his misfortune became contagious.It was even unnatural and insulting to be happy next to him.

        He created the feeling of unhappiness in others.

        But one day,
             when he turned eighty years old,
                an incredible thing happened.Instantly everyone started hearing the rumour:
        “An Old Man is happy today, he doesn’t complain about anything, smiles, and even his face is freshened up.”
        The whole village gathered together.The old man was asked:
        Villager: What happened to you?
        “Nothing special. Eighty years I’ve been chasing happiness, and it was useless.And then I decided to live without happiness and just        enjoy life. That’s why I’m happy now.” – An Old Man
        Moral of the story:
        Don’t chase happiness.Enjoy your life.",
                    CreatedDate = DateTime.Parse("9.02.2021")
                },
                new Announcement
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "The Wise Man",
                    Description = @"People have been coming to the wise man, complaining about the same problems every time. One day he told them a joke and everyone roared in laughter.
        After a couple of minutes, he told them the same joke and only a few of them smiled.
        When he told the same joke for the third time no one laughed anymore.
        The wise man smiled and said:
        “You can’t laugh at the same joke over and over. So why are you always crying about the same problem?”
        Moral of the story:
        Worrying won’t solve your problems, it’ll just waste your time and energy.",
                    CreatedDate = DateTime.Parse("24.03.2020")
                },
                new Announcement
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Two Friends & The Bear",
                    Description = @"Vijay and Raju were friends. On a holiday they went walking into a forest, enjoying the beauty of nature. Suddenly they saw a bear coming at them. They became frightened.
        Raju, who knew all about climbing trees, ran up to a tree and climbed up quickly. He didn’t think of Vijay. Vijay had no idea how to climb the tree.
        Vijay thought for a second. He’d heard animals don’t prefer dead bodies, so he fell to the ground and held his breath. The bear sniffed him and thought he was dead. So, it went on its way.
        Raju asked Vijay;
            “What did the bear whisper into your ears?”
        Vijay replied, “The bear asked me to keep away from friends like you” …and went on his way.
        Moral of the story:
            A friend in need is a friend indeed.",
                    CreatedDate = DateTime.Parse("30.04.2021")
                }
                );
        }
    }
}
