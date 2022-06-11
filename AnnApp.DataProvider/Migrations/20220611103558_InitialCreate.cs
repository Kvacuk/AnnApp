using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnnApp.DataProvider.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Annoucements",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Annoucements", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Annoucements",
                columns: new[] { "Id", "CreatedDate", "Description", "Title" },
                values: new object[] { "1e6db303-0065-439a-8f50-dc024f03271f", new DateTime(2021, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "An old man lived in the village. He was one of the most unfortunate people in the world. The whole village was tired of him; he was always gloomy, he constantly complained and was always in a bad mood.\r\n\r\n         longer he lived,\r\n                the more bile he was becoming and the more poisonous were his words.People avoided him,\r\n                because his misfortune became contagious.It was even unnatural and insulting to be happy next to him.\r\n\r\n        He created the feeling of unhappiness in others.\r\n\r\n        But one day,\r\n             when he turned eighty years old,\r\n                an incredible thing happened.Instantly everyone started hearing the rumour:\r\n        “An Old Man is happy today, he doesn’t complain about anything, smiles, and even his face is freshened up.”\r\n        The whole village gathered together.The old man was asked:\r\n        Villager: What happened to you?\r\n        “Nothing special. Eighty years I’ve been chasing happiness, and it was useless.And then I decided to live without happiness and just        enjoy life. That’s why I’m happy now.” – An Old Man\r\n        Moral of the story:\r\n        Don’t chase happiness.Enjoy your life.", "An Old Man Lived in the Village" });

            migrationBuilder.InsertData(
                table: "Annoucements",
                columns: new[] { "Id", "CreatedDate", "Description", "Title" },
                values: new object[] { "a992fc0a-351c-4941-a02e-ddaee3fb9798", new DateTime(2020, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "People have been coming to the wise man, complaining about the same problems every time. One day he told them a joke and everyone roared in laughter.\r\n        After a couple of minutes, he told them the same joke and only a few of them smiled.\r\n        When he told the same joke for the third time no one laughed anymore.\r\n        The wise man smiled and said:\r\n        “You can’t laugh at the same joke over and over. So why are you always crying about the same problem?”\r\n        Moral of the story:\r\n        Worrying won’t solve your problems, it’ll just waste your time and energy.", "The Wise Man" });

            migrationBuilder.InsertData(
                table: "Annoucements",
                columns: new[] { "Id", "CreatedDate", "Description", "Title" },
                values: new object[] { "be8641e2-0a4b-4428-bb26-6d624213520a", new DateTime(2021, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vijay and Raju were friends. On a holiday they went walking into a forest, enjoying the beauty of nature. Suddenly they saw a bear coming at them. They became frightened.\r\n        Raju, who knew all about climbing trees, ran up to a tree and climbed up quickly. He didn’t think of Vijay. Vijay had no idea how to climb the tree.\r\n        Vijay thought for a second. He’d heard animals don’t prefer dead bodies, so he fell to the ground and held his breath. The bear sniffed him and thought he was dead. So, it went on its way.\r\n        Raju asked Vijay;\r\n            “What did the bear whisper into your ears?”\r\n        Vijay replied, “The bear asked me to keep away from friends like you” …and went on his way.\r\n        Moral of the story:\r\n            A friend in need is a friend indeed.", "Two Friends & The Bear" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Annoucements");
        }
    }
}
