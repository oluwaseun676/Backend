using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class RestaurantTestData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RestaurantCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestaurantCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RestaurantCategory_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Italienisch");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Französisch");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 3, "Mexikanisch" },
                    { 4, "Japanisch" },
                    { 5, "Chinesisch" },
                    { 6, "Indisch" },
                    { 7, "Griechisch" },
                    { 8, "Thailändisch" },
                    { 9, "Spanisch" },
                    { 10, "Deutsch" },
                    { 11, "Amerikanisch" },
                    { 12, "Brasilianisch" },
                    { 13, "Türkisch" },
                    { 14, "Koreanisch" },
                    { 15, "Vietnamesisch" },
                    { 16, "Libanesisch" },
                    { 17, "Argentinisch" },
                    { 18, "Vegetarisch/Vegan" },
                    { 19, "Meeresfrüchte" },
                    { 20, "Steakhouse" },
                    { 21, "Pizzeria" },
                    { 22, "Fast Food" },
                    { 23, "Café" },
                    { 24, "Bäckerei" },
                    { 25, "Pub/Gastropub" },
                    { 26, "Barbecue/Grill" },
                    { 27, "Sushi" },
                    { 28, "Tapas" },
                    { 29, "Fine Dining" },
                    { 30, "Street Food" }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "Address", "Description", "Name", "StreetNr", "ZipCodeId" },
                values: new object[,]
                {
                    { 1, "Hauptstraße", "Genießen Sie authentische italienische Küche in einer gemütlichen Atmosphäre. Von hausgemachten Pastagerichten bis hin zu frisch zubereiteten Pizzen bieten wir eine Vielzahl von Optionen für jeden Geschmack.", "La Trattoria", "123", 1 },
                    { 2, "Bahnhofstraße", "Tauchen Sie ein in die Welt des Sushis und erleben Sie eine Fusion aus traditionellen und modernen japanischen Geschmacksrichtungen. Unsere Sushi-Rollen und frischen Meeresfrüchte werden Sie begeistern.", "Sushi Corner", "456", 1 },
                    { 3, "Kirchplatz", "Lassen Sie sich von der französischen Küche verführen. Unsere raffinierten Gerichte, inspiriert von den Aromen Frankreichs, werden Ihren Gaumen verwöhnen. Genießen Sie ein Glas Wein aus unserer umfangreichen Weinkarte.", "Le Bistro Français", "789", 1 },
                    { 4, "Gartenweg", "Erleben Sie die exotischen Aromen der indischen Küche in unserem Restaurant. Von würzigen Currygerichten bis hin zu köstlichen andoori-Spezialitäten bieten wir eine Vielzahl von Gerichten, die Ihre Sinne begeistern werden.", "Spice Paradise", "234", 1 },
                    { 5, "Marktstraße", "Freuen Sie sich auf saftige Steaks, perfekt gegrillt nach Ihren Wünschen. Unser Steakhaus bietet eine rustikale Atmosphäre und eine Auswahl an hochwertigen Fleischsorten. Begleitet von Beilagen und Saucen wird Ihr Besuch zu einem kulinarischen Erlebnis.", "Steakhouse Deluxe", "567", 1 },
                    { 6, "Rue de la Paix", "Chez Pierre ist ein elegantes französisches Restaurant, das sich auf klassische französische Küche spezialisiert hat. Mit einer raffinierten Atmosphäre und einer umfangreichen Weinkarte bietet Chez Pierre ein unvergessliches kulinarisches Erlebnis.", "Chez Pierre", "10", 1 },
                    { 7, "Main Street", "The Spice Garden entführt Sie auf eine kulinarische Reise durch die Aromen Indiens. Von würzigen Currygerichten bis hin zu delikaten Vorspeisen bieten wir eine vielfältige Auswahl an indischen Spezialitäten, die Ihre Geschmacksknospen verzaubern werden.", "The Spice Garden", "10", 1 },
                    { 8, "Shibuya-ku, Shibuya", "Erleben Sie den Geschmack von Mexiko bei El Rancho. Unser lebhaftes Restaurant serviert authentische mexikanische Gerichte wie Tacos, Enchiladas und frittierte Nachos, begleitet von erfrischenden Margaritas und traditionellen lateinamerikanischen Getränken.", "Sushi Zen", "3-1-1", 1 },
                    { 9, "Calle Principal", "Erleben Sie die exotischen Aromen der indischen Küche in unserem Restaurant. Von würzigen Currygerichten bis hin zu köstlichen andoori-Spezialitäten bieten wir eine Vielzahl von Gerichten, die Ihre Sinne begeistern werden.", "El Rancho", "20", 1 },
                    { 10, "Via Roma", "Bella Italia ist ein charmantes italienisches Restaurant, das köstliche Pasta, Pizza und Antipasti anbietet. Mit frischen Zutaten und traditionellen Rezepten möchten wir Ihnen ein Stück Italien inmitten der Stadt präsentieren.", "Bella Italia", "5a", 1 }
                });

            migrationBuilder.UpdateData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Location", "ZipCodeNr" },
                values: new object[] { "Leonding", "4020" });

            migrationBuilder.InsertData(
                table: "Zipcodes",
                columns: new[] { "Id", "District", "Location", "ZipCodeNr" },
                values: new object[] { 3, "Linz", "Linz", "4030" });

            migrationBuilder.InsertData(
                table: "Zipcodes",
                columns: new[] { "Id", "District", "Location", "ZipCodeNr" },
                values: new object[,]
                {
                    { 4, "Urfahr-Umgebung", "Altenberg bei Linz", "4040" },
                    { 5, "Urfahr-Umgebung", "Gramastetten", "4040" },
                    { 6, "Urfahr-Umgebung", "Kirchschlag bei Linz", "4040" },
                    { 7, "Urfahr-Umgebung", "Lichtenberg", "4040" },
                    { 8, "Linz", "Linz", "4040" },
                    { 9, "Urfahr-Umgebung", "Steyregg", "4040" },
                    { 10, "Urfahr-Umgebung", "Puchenau", "4048" },
                    { 11, "Linz-Land", "Traun", "4050" },
                    { 12, "Linz-Land", "Ansfelden", "4052" },
                    { 13, "Linz", "Linz", "4052" },
                    { 14, "Linz-Land", "Ansfelden", "4053" },
                    { 15, "Linz-Land", "Neuhofen an der Krems", "4053" },
                    { 16, "Linz-Land", "Pucking", "4055" },
                    { 17, "Linz-Land", "Leonding", "4060" },
                    { 18, "Linz-Land", "Leonding", "4061" },
                    { 19, "Linz-Land", "Pasching", "4061" },
                    { 20, "Linz-Land", "Wilhering", "4061" },
                    { 21, "Linz-Land", "Kirchberg-Thening", "4062" },
                    { 22, "Linz-Land", "Hörsching", "4063" },
                    { 23, "Linz-Land", "Traun", "4063" },
                    { 24, "Linz-Land", "Oftering", "4064" },
                    { 25, "Eferding", "Eferding", "4070" },
                    { 26, "Eferding", "Fraham", "4070" },
                    { 27, "Eferding", "Hartkirchen", "4070" },
                    { 28, "Eferding", "Hinzenbach", "4070" },
                    { 29, "Eferding", "Prambachkirchen", "4070" },
                    { 30, "Eferding", "Pupping", "4070" },
                    { 31, "Eferding", "Stroheim", "4070" },
                    { 32, "Eferding", "Alkoven", "4072" },
                    { 33, "Linz-Land", "Wilhering", "4073" },
                    { 34, "Eferding", "Hartkirchen", "4074" },
                    { 35, "Eferding", "Prambachkirchen", "4074" },
                    { 36, "Eferding", "Stroheim", "4074" },
                    { 37, "Eferding", "Fraham", "4075" },
                    { 38, "Eferding", "St. Marienkirchen an der Polsenz", "4076" },
                    { 39, "Eferding", "Hartkirchen", "4081" },
                    { 40, "Eferding", "Pupping", "4081" },
                    { 41, "Eferding", "Stroheim", "4081" },
                    { 42, "Eferding", "Aschach an der Donau", "4082" },
                    { 43, "Eferding", "Haibach ob der Donau", "4083" },
                    { 44, "Grieskirchen", "St. Agatha", "4083" },
                    { 45, "Grieskirchen", "Eschenau im Hausruckkreis", "4084" }
                });

            migrationBuilder.InsertData(
                table: "Zipcodes",
                columns: new[] { "Id", "District", "Location", "ZipCodeNr" },
                values: new object[,]
                {
                    { 46, "Grieskirchen", "St. Agatha", "4084" },
                    { 47, "Grieskirchen", "Eschenau im Hausruckkreis", "4085" },
                    { 48, "Rohrbach", "Hofkirchen im Mühlkreis", "4085" },
                    { 49, "Rohrbach", "Neustift im Mühlkreis", "4085" },
                    { 50, "Rohrbach", "Pfarrkirchen im Mühlkreis", "4085" },
                    { 51, "Schärding", "Waldkirchen am Wesen", "4085" },
                    { 52, "Schärding", "Engelhartszell", "4090" },
                    { 53, "Schärding", "St. Roman", "4091" },
                    { 54, "Schärding", "Vichtenstein", "4091" },
                    { 55, "Schärding", "Esternberg", "4092" },
                    { 56, "Urfahr-Umgebung", "Gramastetten", "4100" },
                    { 57, "Urfahr-Umgebung", "Ottensheim", "4100" },
                    { 58, "Urfahr-Umgebung", "Feldkirchen an der Donau", "4101" },
                    { 59, "Urfahr-Umgebung", "Herzogsdorf", "4101" },
                    { 60, "Urfahr-Umgebung", "Goldwörth", "4102" },
                    { 61, "Urfahr-Umgebung", "Gramastetten", "4111" },
                    { 62, "Urfahr-Umgebung", "Walding", "4111" },
                    { 63, "Urfahr-Umgebung", "Gramastetten", "4112" },
                    { 64, "Urfahr-Umgebung", "St. Gotthard im Mühlkreis", "4112" },
                    { 65, "Urfahr-Umgebung", "Feldkirchen an der Donau", "4113" },
                    { 66, "Rohrbach", "Niederwaldkirchen", "4113" },
                    { 67, "Rohrbach", "St. Martin im Mühlkreis", "4113" },
                    { 68, "Rohrbach", "Kirchberg ob der Donau", "4114" },
                    { 69, "Rohrbach", "Kleinzell im Mühlkreis", "4114" },
                    { 70, "Rohrbach", "St. Martin im Mühlkreis", "4114" },
                    { 71, "Rohrbach", "Kirchberg ob der Donau", "4115" },
                    { 72, "Rohrbach", "Kleinzell im Mühlkreis", "4115" },
                    { 73, "Rohrbach", "St. Ulrich im Mühlkreis", "4116" },
                    { 74, "Rohrbach", "Altenfelden", "4120" },
                    { 75, "Rohrbach", "Kleinzell im Mühlkreis", "4120" },
                    { 76, "Rohrbach", "Neufelden", "4120" },
                    { 77, "Rohrbach", "Altenfelden", "4121" },
                    { 78, "Rohrbach", "Arnreit", "4121" },
                    { 79, "Rohrbach", "Hörbich", "4121" },
                    { 80, "Rohrbach", "Neufelden", "4121" },
                    { 81, "Rohrbach", "Arnreit", "4122" },
                    { 82, "Rohrbach", "Kirchberg ob der Donau", "4131" },
                    { 83, "Rohrbach", "Lembach im Mühlkreis", "4131" },
                    { 84, "Rohrbach", "Niederkappel", "4131" },
                    { 85, "Rohrbach", "Hörbich", "4132" },
                    { 86, "Rohrbach", "Lembach im Mühlkreis", "4132" },
                    { 87, "Rohrbach", "Niederkappel", "4132" }
                });

            migrationBuilder.InsertData(
                table: "Zipcodes",
                columns: new[] { "Id", "District", "Location", "ZipCodeNr" },
                values: new object[,]
                {
                    { 88, "Rohrbach", "Putzleinsdorf", "4132" },
                    { 89, "Rohrbach", "Hofkirchen im Mühlkreis", "4133" },
                    { 90, "Rohrbach", "Niederkappel", "4133" },
                    { 91, "Rohrbach", "Putzleinsdorf", "4133" },
                    { 92, "Rohrbach", "Atzesberg", "4134" },
                    { 93, "Rohrbach", "Hörbich", "4134" },
                    { 94, "Rohrbach", "Putzleinsdorf", "4134" },
                    { 95, "Rohrbach", "Pfarrkirchen im Mühlkreis", "4141" },
                    { 96, "Rohrbach", "Putzleinsdorf", "4141" },
                    { 97, "Rohrbach", "Hofkirchen im Mühlkreis", "4142" },
                    { 98, "Rohrbach", "Pfarrkirchen im Mühlkreis", "4142" },
                    { 99, "Rohrbach", "Neustift im Mühlkreis", "4143" },
                    { 100, "Rohrbach", "Neustift im Mühlkreis", "4144" },
                    { 101, "Rohrbach", "Oberkappel", "4144" },
                    { 102, "Rohrbach", "Pfarrkirchen im Mühlkreis", "4144" },
                    { 103, "Rohrbach", "Rohrbach-Berg", "4150" },
                    { 104, "Rohrbach", "Sarleinsbach", "4150" },
                    { 105, "Rohrbach", "Oepping", "4151" },
                    { 106, "Rohrbach", "Atzesberg", "4152" },
                    { 107, "Rohrbach", "Hörbich", "4152" },
                    { 108, "Rohrbach", "Kollerschlag", "4152" },
                    { 109, "Rohrbach", "Oberkappel", "4152" },
                    { 110, "Rohrbach", "Sarleinsbach", "4152" },
                    { 111, "Rohrbach", "Julbach", "4153" },
                    { 112, "Rohrbach", "Peilstein im Mühlviertel", "4153" },
                    { 113, "Rohrbach", "Kollerschlag", "4154" },
                    { 114, "Rohrbach", "Oberkappel", "4154" },
                    { 115, "Rohrbach", "Julbach", "4155" },
                    { 116, "Rohrbach", "Nebelberg", "4155" },
                    { 117, "Rohrbach", "Aigen-Schlägl", "4160" },
                    { 118, "Rohrbach", "Ulrichsberg", "4160" },
                    { 119, "Rohrbach", "Aigen-Schlägl", "4161" },
                    { 120, "Rohrbach", "Schwarzenberg am Böhmerwald", "4161" },
                    { 121, "Rohrbach", "Ulrichsberg", "4161" },
                    { 122, "Rohrbach", "Julbach", "4162" },
                    { 123, "Rohrbach", "Peilstein im Mühlviertel", "4162" },
                    { 124, "Rohrbach", "Ulrichsberg", "4162" },
                    { 125, "Rohrbach", "Klaffer am Hochficht", "4163" },
                    { 126, "Rohrbach", "Ulrichsberg", "4163" },
                    { 127, "Rohrbach", "Schwarzenberg am Böhmerwald", "4164" },
                    { 128, "Rohrbach", "Auberg", "4170" },
                    { 129, "Rohrbach", "Haslach an der Mühl", "4170" }
                });

            migrationBuilder.InsertData(
                table: "Zipcodes",
                columns: new[] { "Id", "District", "Location", "ZipCodeNr" },
                values: new object[,]
                {
                    { 130, "Rohrbach", "Lichtenau im Mühlkreis", "4170" },
                    { 131, "Rohrbach", "Rohrbach-Berg", "4170" },
                    { 132, "Rohrbach", "St. Oswald bei Haslach", "4170" },
                    { 133, "Rohrbach", "St. Peter am Wimberg", "4170" },
                    { 134, "Rohrbach", "St. Stefan-Afiesl", "4170" },
                    { 135, "Rohrbach", "Auberg", "4171" },
                    { 136, "Rohrbach", "St. Peter am Wimberg", "4171" },
                    { 137, "Rohrbach", "St. Stefan-Afiesl", "4171" },
                    { 138, "Rohrbach", "St. Johann am Wimberg", "4172" },
                    { 139, "Rohrbach", "St. Veit im Mühlkreis", "4173" },
                    { 140, "Rohrbach", "Niederwaldkirchen", "4174" },
                    { 141, "Rohrbach", "St. Veit im Mühlkreis", "4174" },
                    { 142, "Urfahr-Umgebung", "Herzogsdorf", "4175" },
                    { 143, "Rohrbach", "St. Veit im Mühlkreis", "4175" },
                    { 144, "Urfahr-Umgebung", "Reichenau im Mühlkreis", "4180" },
                    { 145, "Urfahr-Umgebung", "Sonnberg im Mühlkreis", "4180" },
                    { 146, "Urfahr-Umgebung", "Zwettl an der Rodl", "4180" },
                    { 147, "Urfahr-Umgebung", "Herzogsdorf", "4181" },
                    { 148, "Urfahr-Umgebung", "Oberneukirchen", "4181" },
                    { 149, "Urfahr-Umgebung", "Zwettl an der Rodl", "4181" },
                    { 150, "Rohrbach", "Helfenberg", "4182" },
                    { 151, "Urfahr-Umgebung", "Oberneukirchen", "4182" },
                    { 152, "Rohrbach", "Helfenberg", "4183" },
                    { 153, "Urfahr-Umgebung", "Oberneukirchen", "4183" },
                    { 154, "Urfahr-Umgebung", "Vorderweißenbach", "4183" },
                    { 155, "Rohrbach", "Helfenberg", "4184" },
                    { 156, "Rohrbach", "St. Johann am Wimberg", "4184" },
                    { 157, "Rohrbach", "St. Peter am Wimberg", "4184" },
                    { 158, "Rohrbach", "St. Stefan-Afiesl", "4184" },
                    { 159, "Urfahr-Umgebung", "Vorderweißenbach", "4184" },
                    { 160, "Urfahr-Umgebung", "Bad Leonfelden", "4190" },
                    { 161, "Urfahr-Umgebung", "Vorderweißenbach", "4190" },
                    { 162, "Urfahr-Umgebung", "Vorderweißenbach", "4191" },
                    { 163, "Freistadt", "Hirschbach im Mühlkreis", "4192" },
                    { 164, "Urfahr-Umgebung", "Schenkenfelden", "4192" },
                    { 165, "Freistadt", "Hirschbach im Mühlkreis", "4193" },
                    { 166, "Freistadt", "Rainbach im Mühlkreis", "4193" },
                    { 167, "Urfahr-Umgebung", "Reichenthal", "4193" },
                    { 168, "Freistadt", "Waldburg", "4193" },
                    { 169, "Urfahr-Umgebung", "Eidenberg", "4201" },
                    { 170, "Urfahr-Umgebung", "Gramastetten", "4201" },
                    { 171, "Urfahr-Umgebung", "Kirchschlag bei Linz", "4201" }
                });

            migrationBuilder.InsertData(
                table: "Zipcodes",
                columns: new[] { "Id", "District", "Location", "ZipCodeNr" },
                values: new object[,]
                {
                    { 172, "Urfahr-Umgebung", "Lichtenberg", "4201" },
                    { 173, "Urfahr-Umgebung", "Zwettl an der Rodl", "4201" },
                    { 174, "Urfahr-Umgebung", "Alberndorf in der Riedmark", "4202" },
                    { 175, "Urfahr-Umgebung", "Altenberg bei Linz", "4202" },
                    { 176, "Urfahr-Umgebung", "Eidenberg", "4202" },
                    { 177, "Urfahr-Umgebung", "Hellmonsödt", "4202" },
                    { 178, "Urfahr-Umgebung", "Kirchschlag bei Linz", "4202" },
                    { 179, "Urfahr-Umgebung", "Sonnberg im Mühlkreis", "4202" },
                    { 180, "Urfahr-Umgebung", "Altenberg bei Linz", "4203" },
                    { 181, "Urfahr-Umgebung", "Haibach im Mühlkreis", "4204" },
                    { 182, "Urfahr-Umgebung", "Ottenschlag im Mühlkreis", "4204" },
                    { 183, "Urfahr-Umgebung", "Reichenau im Mühlkreis", "4204" },
                    { 184, "Urfahr-Umgebung", "Altenberg bei Linz", "4209" },
                    { 185, "Urfahr-Umgebung", "Engerwitzdorf", "4209" },
                    { 186, "Urfahr-Umgebung", "Altenberg bei Linz", "4210" },
                    { 187, "Urfahr-Umgebung", "Gallneukirchen", "4210" },
                    { 188, "Urfahr-Umgebung", "Alberndorf in der Riedmark", "4211" },
                    { 189, "Urfahr-Umgebung", "Altenberg bei Linz", "4211" },
                    { 190, "Freistadt", "Neumarkt im Mühlkreis", "4211" },
                    { 191, "Freistadt", "Kefermarkt", "4212" },
                    { 192, "Freistadt", "Neumarkt im Mühlkreis", "4212" },
                    { 193, "Freistadt", "Unterweitersdorf", "4213" },
                    { 194, "Urfahr-Umgebung", "Steyregg", "4221" },
                    { 195, "Urfahr-Umgebung", "Engerwitzdorf", "4222" },
                    { 196, "Perg", "Langenstein", "4222" },
                    { 197, "Perg", "St. Georgen an der Gusen", "4222" },
                    { 198, "Perg", "Katsdorf", "4223" },
                    { 199, "Perg", "St. Georgen an der Gusen", "4223" },
                    { 200, "Perg", "Katsdorf", "4224" },
                    { 201, "Freistadt", "Wartberg ob der Aist", "4224" },
                    { 202, "Perg", "Luftenberg an der Donau", "4225" },
                    { 203, "Freistadt", "Gutau", "4230" },
                    { 204, "Freistadt", "Hagenberg im Mühlkreis", "4230" },
                    { 205, "Freistadt", "Pregarten", "4230" },
                    { 206, "Freistadt", "Tragwein", "4230" },
                    { 207, "Freistadt", "Hagenberg im Mühlkreis", "4232" },
                    { 208, "Freistadt", "Freistadt", "4240" },
                    { 209, "Freistadt", "Kefermarkt", "4240" },
                    { 210, "Freistadt", "Lasberg", "4240" },
                    { 211, "Urfahr-Umgebung", "Reichenthal", "4240" },
                    { 212, "Freistadt", "Waldburg", "4240" },
                    { 213, "Freistadt", "Hirschbach im Mühlkreis", "4242" }
                });

            migrationBuilder.InsertData(
                table: "Zipcodes",
                columns: new[] { "Id", "District", "Location", "ZipCodeNr" },
                values: new object[,]
                {
                    { 214, "Freistadt", "Sandl", "4251" },
                    { 215, "Freistadt", "Liebenau", "4252" },
                    { 216, "Freistadt", "Grünbach", "4261" },
                    { 217, "Freistadt", "Rainbach im Mühlkreis", "4261" },
                    { 218, "Freistadt", "Leopoldschlag", "4262" },
                    { 219, "Freistadt", "Sandl", "4263" },
                    { 220, "Freistadt", "Windhaag bei Freistadt", "4263" },
                    { 221, "Freistadt", "Grünbach", "4264" },
                    { 222, "Freistadt", "Lasberg", "4264" },
                    { 223, "Freistadt", "Lasberg", "4271" },
                    { 224, "Freistadt", "St. Oswald bei Freistadt", "4271" },
                    { 225, "Freistadt", "St. Leonhard bei Freistadt", "4272" },
                    { 226, "Freistadt", "Weitersfelden", "4272" },
                    { 227, "Freistadt", "Kaltenberg", "4273" },
                    { 228, "Freistadt", "Unterweißenbach", "4273" },
                    { 229, "Freistadt", "Bad Zell", "4274" },
                    { 230, "Freistadt", "Pierbach", "4274" },
                    { 231, "Freistadt", "Schönau im Mühlkreis", "4274" },
                    { 232, "Freistadt", "Königswiesen", "4280" },
                    { 233, "Freistadt", "Königswiesen", "4281" },
                    { 234, "Perg", "Pabneukirchen", "4281" },
                    { 235, "Freistadt", "Pierbach", "4281" },
                    { 236, "Freistadt", "Königswiesen", "4282" },
                    { 237, "Freistadt", "Pierbach", "4282" },
                    { 238, "Freistadt", "Schönau im Mühlkreis", "4282" },
                    { 239, "Perg", "St. Thomas am Blasenstein", "4282" },
                    { 240, "Freistadt", "Bad Zell", "4283" },
                    { 241, "Perg", "Allerheiligen im Mühlkreis", "4284" },
                    { 242, "Freistadt", "Tragwein", "4284" },
                    { 243, "Freistadt", "Kefermarkt", "4291" },
                    { 244, "Freistadt", "Lasberg", "4291" },
                    { 245, "Freistadt", "Gutau", "4292" },
                    { 246, "Freistadt", "Kefermarkt", "4292" },
                    { 247, "Freistadt", "Lasberg", "4292" },
                    { 248, "Freistadt", "Pregarten", "4292" },
                    { 249, "Freistadt", "Bad Zell", "4293" },
                    { 250, "Freistadt", "Gutau", "4293" },
                    { 251, "Freistadt", "Schönau im Mühlkreis", "4293" },
                    { 252, "Freistadt", "St. Leonhard bei Freistadt", "4293" },
                    { 253, "Freistadt", "Tragwein", "4293" },
                    { 254, "Freistadt", "Gutau", "4294" },
                    { 255, "Freistadt", "Schönau im Mühlkreis", "4294" }
                });

            migrationBuilder.InsertData(
                table: "Zipcodes",
                columns: new[] { "Id", "District", "Location", "ZipCodeNr" },
                values: new object[,]
                {
                    { 256, "Freistadt", "St. Leonhard bei Freistadt", "4294" },
                    { 257, "Freistadt", "St. Oswald bei Freistadt", "4294" },
                    { 258, "Amstetten", "Ernsthofen", "4300" },
                    { 259, "Amstetten", "St. Valentin", "4300" },
                    { 260, "Amstetten", "St. Pantaleon-Erla", "4303" },
                    { 261, "Perg", "Langenstein", "4310" },
                    { 262, "Perg", "Mauthausen", "4310" },
                    { 263, "Perg", "Naarn im Machlande", "4311" },
                    { 264, "Perg", "Ried in der Riedmark", "4311" },
                    { 265, "Perg", "Schwertberg", "4311" },
                    { 266, "Freistadt", "Tragwein", "4311" },
                    { 267, "Perg", "Langenstein", "4312" },
                    { 268, "Perg", "Mauthausen", "4312" },
                    { 269, "Perg", "Ried in der Riedmark", "4312" },
                    { 270, "Perg", "Schwertberg", "4312" },
                    { 271, "Perg", "Allerheiligen im Mühlkreis", "4320" },
                    { 272, "Perg", "Naarn im Machlande", "4320" },
                    { 273, "Perg", "Perg", "4320" },
                    { 274, "Perg", "Windhaag bei Perg", "4320" },
                    { 275, "Perg", "St. Thomas am Blasenstein", "4322" },
                    { 276, "Perg", "Windhaag bei Perg", "4322" },
                    { 277, "Perg", "Arbing", "4323" },
                    { 278, "Perg", "Bad Kreuzen", "4323" },
                    { 279, "Perg", "Münzbach", "4323" },
                    { 280, "Perg", "Rechberg", "4323" },
                    { 281, "Perg", "Windhaag bei Perg", "4323" },
                    { 282, "Perg", "Rechberg", "4324" },
                    { 283, "Perg", "Naarn im Machlande", "4331" },
                    { 284, "Perg", "Naarn im Machlande", "4332" },
                    { 285, "Perg", "Arbing", "4341" },
                    { 286, "Perg", "Baumgartenberg", "4341" },
                    { 287, "Perg", "Arbing", "4342" },
                    { 288, "Perg", "Baumgartenberg", "4342" },
                    { 289, "Perg", "Münzbach", "4342" },
                    { 290, "Perg", "Mitterkirchen im Machland", "4343" },
                    { 291, "Perg", "Baumgartenberg", "4351" },
                    { 292, "Perg", "Saxen", "4351" },
                    { 293, "Perg", "Bad Kreuzen", "4352" },
                    { 294, "Perg", "Klam", "4352" },
                    { 295, "Perg", "Münzbach", "4352" },
                    { 296, "Perg", "Saxen", "4352" },
                    { 297, "Perg", "Bad Kreuzen", "4360" }
                });

            migrationBuilder.InsertData(
                table: "Zipcodes",
                columns: new[] { "Id", "District", "Location", "ZipCodeNr" },
                values: new object[,]
                {
                    { 298, "Perg", "Grein", "4360" },
                    { 299, "Perg", "Waldhausen im Strudengau", "4360" },
                    { 300, "Perg", "Bad Kreuzen", "4362" },
                    { 301, "Perg", "Pabneukirchen", "4362" },
                    { 302, "Perg", "St. Thomas am Blasenstein", "4362" },
                    { 303, "Perg", "Pabneukirchen", "4363" },
                    { 304, "Perg", "St. Thomas am Blasenstein", "4363" },
                    { 305, "Perg", "St. Thomas am Blasenstein", "4364" },
                    { 306, "Perg", "Dimbach", "4371" },
                    { 307, "Perg", "Pabneukirchen", "4371" },
                    { 308, "Perg", "St. Georgen am Walde", "4371" },
                    { 309, "Zwettl", "Altmelon", "4372" },
                    { 310, "Perg", "Pabneukirchen", "4372" },
                    { 311, "Perg", "St. Georgen am Walde", "4372" },
                    { 312, "Perg", "St. Nikola an der Donau", "4381" },
                    { 313, "Perg", "St. Nikola an der Donau", "4382" },
                    { 314, "Perg", "Waldhausen im Strudengau", "4382" },
                    { 315, "Perg", "Waldhausen im Strudengau", "4391" },
                    { 316, "Melk", "Dorfstetten", "4392" },
                    { 317, "Perg", "Waldhausen im Strudengau", "4392" },
                    { 318, "Steyr-Land", "Garsten", "4400" },
                    { 319, "Steyr-Land", "St. Ulrich bei Steyr", "4400" },
                    { 320, "Steyr", "Steyr", "4400" },
                    { 321, "Steyr-Land", "Dietach", "4407" },
                    { 322, "Steyr", "Steyr", "4407" },
                    { 323, "Steyr-Land", "Aschach an der Steyr", "4421" },
                    { 324, "Kirchdorf", "Steinbach an der Steyr", "4421" },
                    { 325, "Amstetten", "Haidershofen", "4431" },
                    { 326, "Amstetten", "Ernsthofen", "4432" },
                    { 327, "Amstetten", "Behamberg", "4441" },
                    { 328, "Steyr-Land", "Maria Neustift", "4442" },
                    { 329, "Amstetten", "St. Peter in der Au", "4442" },
                    { 330, "Steyr-Land", "St. Ulrich bei Steyr", "4442" },
                    { 331, "Steyr-Land", "Großraming", "4443" },
                    { 332, "Steyr-Land", "Maria Neustift", "4443" },
                    { 333, "Amstetten", "St. Peter in der Au", "4443" },
                    { 334, "Steyr-Land", "St. Ulrich bei Steyr", "4443" },
                    { 335, "Steyr-Land", "Garsten", "4451" },
                    { 336, "Steyr-Land", "St. Ulrich bei Steyr", "4451" },
                    { 337, "Steyr", "Steyr", "4451" },
                    { 338, "Steyr-Land", "Ternberg", "4451" },
                    { 339, "Steyr-Land", "Ternberg", "4452" }
                });

            migrationBuilder.InsertData(
                table: "Zipcodes",
                columns: new[] { "Id", "District", "Location", "ZipCodeNr" },
                values: new object[,]
                {
                    { 340, "Steyr-Land", "Ternberg", "4453" },
                    { 341, "Steyr-Land", "Laussa", "4460" },
                    { 342, "Steyr-Land", "Losenstein", "4460" },
                    { 343, "Steyr-Land", "Garsten", "4461" },
                    { 344, "Steyr-Land", "Laussa", "4461" },
                    { 345, "Steyr-Land", "Reichraming", "4462" },
                    { 346, "Steyr-Land", "Großraming", "4463" },
                    { 347, "Steyr-Land", "Laussa", "4463" },
                    { 348, "Steyr-Land", "Weyer", "4464" },
                    { 349, "Linz-Land", "Enns", "4470" },
                    { 350, "Linz-Land", "Kronstorf", "4470" },
                    { 351, "Linz-Land", "Asten", "4481" },
                    { 352, "Linz-Land", "Enns", "4481" },
                    { 353, "Perg", "Luftenberg an der Donau", "4481" },
                    { 354, "Amstetten", "Ennsdorf", "4482" },
                    { 355, "Amstetten", "St. Valentin", "4482" },
                    { 356, "Linz-Land", "Hargelsberg", "4483" },
                    { 357, "Linz-Land", "Kronstorf", "4483" },
                    { 358, "Steyr-Land", "Dietach", "4484" },
                    { 359, "Linz-Land", "Hargelsberg", "4484" },
                    { 360, "Linz-Land", "Kronstorf", "4484" },
                    { 361, "Linz-Land", "St. Florian", "4490" },
                    { 362, "Linz-Land", "Hofkirchen im Traunkreis", "4491" },
                    { 363, "Linz-Land", "Niederneukirchen", "4491" },
                    { 364, "Linz-Land", "St. Marien", "4491" },
                    { 365, "Linz-Land", "Hofkirchen im Traunkreis", "4492" },
                    { 366, "Steyr-Land", "Schiedlberg", "4493" },
                    { 367, "Steyr-Land", "Wolfern", "4493" },
                    { 368, "Linz-Land", "Neuhofen an der Krems", "4501" },
                    { 369, "Linz-Land", "St. Marien", "4502" },
                    { 370, "Linz-Land", "Allhaming", "4511" },
                    { 371, "Linz-Land", "Neuhofen an der Krems", "4511" },
                    { 372, "Steyr-Land", "Schiedlberg", "4521" },
                    { 373, "Linz-Land", "St. Marien", "4521" },
                    { 374, "Steyr-Land", "Schiedlberg", "4522" },
                    { 375, "Steyr-Land", "Sierning", "4522" },
                    { 376, "Steyr-Land", "Aschach an der Steyr", "4523" },
                    { 377, "Steyr-Land", "Garsten", "4523" },
                    { 378, "Steyr-Land", "Sierning", "4523" },
                    { 379, "Linz-Land", "Kematen an der Krems", "4531" },
                    { 380, "Linz-Land", "Neuhofen an der Krems", "4531" },
                    { 381, "Steyr-Land", "Sierning", "4531" }
                });

            migrationBuilder.InsertData(
                table: "Zipcodes",
                columns: new[] { "Id", "District", "Location", "ZipCodeNr" },
                values: new object[,]
                {
                    { 382, "Linz-Land", "Kematen an der Krems", "4532" },
                    { 383, "Kirchdorf", "Kremsmünster", "4532" },
                    { 384, "Steyr-Land", "Rohr im Kremstal", "4532" },
                    { 385, "Linz-Land", "Piberbach", "4533" },
                    { 386, "Steyr-Land", "Adlwang", "4540" },
                    { 387, "Steyr-Land", "Bad Hall", "4540" },
                    { 388, "Kirchdorf", "Kremsmünster", "4540" },
                    { 389, "Steyr-Land", "Pfarrkirchen bei Bad Hall", "4540" },
                    { 390, "Steyr-Land", "Adlwang", "4541" },
                    { 391, "Kirchdorf", "Nußbach", "4542" },
                    { 392, "Linz-Land", "Kematen an der Krems", "4550" },
                    { 393, "Kirchdorf", "Kremsmünster", "4550" },
                    { 394, "Steyr-Land", "Rohr im Kremstal", "4550" },
                    { 395, "Kirchdorf", "Ried im Traunkreis", "4551" },
                    { 396, "Steyr-Land", "Pfarrkirchen bei Bad Hall", "4552" },
                    { 397, "Kirchdorf", "Wartberg an der Krems", "4552" },
                    { 398, "Kirchdorf", "Schlierbach", "4553" },
                    { 399, "Kirchdorf", "Oberschlierbach", "4554" },
                    { 400, "Kirchdorf", "Kirchdorf an der Krems", "4560" },
                    { 401, "Kirchdorf", "Steinbach am Ziehberg", "4562" },
                    { 402, "Kirchdorf", "Kirchdorf an der Krems", "4563" },
                    { 403, "Kirchdorf", "Micheldorf in Oberösterreich", "4563" },
                    { 404, "Kirchdorf", "Klaus an der Pyhrnbahn", "4564" },
                    { 405, "Kirchdorf", "Inzersdorf im Kremstal", "4565" },
                    { 406, "Kirchdorf", "Klaus an der Pyhrnbahn", "4571" },
                    { 407, "Kirchdorf", "Hinterstoder", "4572" },
                    { 408, "Kirchdorf", "Klaus an der Pyhrnbahn", "4572" },
                    { 409, "Kirchdorf", "St. Pankraz", "4572" },
                    { 410, "Kirchdorf", "Hinterstoder", "4573" },
                    { 411, "Kirchdorf", "Hinterstoder", "4574" },
                    { 412, "Kirchdorf", "Vorderstoder", "4574" },
                    { 413, "Kirchdorf", "Roßleithen", "4575" },
                    { 414, "Kirchdorf", "Edlbach", "4580" },
                    { 415, "Kirchdorf", "Windischgarsten", "4580" },
                    { 416, "Kirchdorf", "Edlbach", "4581" },
                    { 417, "Kirchdorf", "Rosenau am Hengstpaß", "4581" },
                    { 418, "Kirchdorf", "Edlbach", "4582" },
                    { 419, "Kirchdorf", "Spital am Pyhrn", "4582" },
                    { 420, "Kirchdorf", "Molln", "4591" },
                    { 421, "Kirchdorf", "Rosenau am Hengstpaß", "4591" },
                    { 422, "Kirchdorf", "Grünburg", "4592" },
                    { 423, "Kirchdorf", "Grünburg", "4593" }
                });

            migrationBuilder.InsertData(
                table: "Zipcodes",
                columns: new[] { "Id", "District", "Location", "ZipCodeNr" },
                values: new object[,]
                {
                    { 424, "Steyr-Land", "Aschach an der Steyr", "4594" },
                    { 425, "Kirchdorf", "Grünburg", "4594" },
                    { 426, "Kirchdorf", "Steinbach an der Steyr", "4594" },
                    { 427, "Steyr-Land", "Waldneukirchen", "4595" },
                    { 428, "Kirchdorf", "Steinbach an der Steyr", "4596" },
                    { 429, "Steyr-Land", "Ternberg", "4596" },
                    { 430, "Wels-Land", "Schleißheim", "4600" },
                    { 431, "Wels-Land", "Thalheim bei Wels", "4600" },
                    { 432, "Wels", "Wels", "4600" },
                    { 433, "Wels-Land", "Buchkirchen", "4611" },
                    { 434, "Grieskirchen", "Wallern an der Trattnach", "4611" },
                    { 435, "Wels-Land", "Buchkirchen", "4612" },
                    { 436, "Eferding", "Scharten", "4612" },
                    { 437, "Wels-Land", "Buchkirchen", "4613" },
                    { 438, "Wels-Land", "Marchtrenk", "4614" },
                    { 439, "Wels-Land", "Holzhausen", "4615" },
                    { 440, "Linz-Land", "Eggendorf im Traunkreis", "4616" },
                    { 441, "Wels-Land", "Weißkirchen an der Traun", "4616" },
                    { 442, "Kirchdorf", "Kremsmünster", "4621" },
                    { 443, "Wels-Land", "Sipbachzell", "4621" },
                    { 444, "Linz-Land", "Eggendorf im Traunkreis", "4622" },
                    { 445, "Wels-Land", "Gunskirchen", "4623" },
                    { 446, "Wels-Land", "Offenhausen", "4624" },
                    { 447, "Wels-Land", "Pennewang", "4624" },
                    { 448, "Grieskirchen", "Meggenhofen", "4625" },
                    { 449, "Wels-Land", "Offenhausen", "4625" },
                    { 450, "Wels-Land", "Pennewang", "4625" },
                    { 451, "Wels-Land", "Buchkirchen", "4631" },
                    { 452, "Wels-Land", "Krenglbach", "4631" },
                    { 453, "Wels-Land", "Pichl bei Wels", "4631" },
                    { 454, "Grieskirchen", "Wallern an der Trattnach", "4631" },
                    { 455, "Grieskirchen", "Kematen am Innbach", "4632" },
                    { 456, "Wels-Land", "Pichl bei Wels", "4632" },
                    { 457, "Grieskirchen", "Schlüßlberg", "4632" },
                    { 458, "Grieskirchen", "Kematen am Innbach", "4633" },
                    { 459, "Wels-Land", "Pichl bei Wels", "4633" },
                    { 460, "Wels-Land", "Fischlham", "4641" },
                    { 461, "Wels-Land", "Steinhaus", "4641" },
                    { 462, "Wels-Land", "Sattledt", "4642" },
                    { 463, "Wels-Land", "Eberstalzell", "4643" },
                    { 464, "Kirchdorf", "Pettenbach", "4643" },
                    { 465, "Kirchdorf", "Ried im Traunkreis", "4643" }
                });

            migrationBuilder.InsertData(
                table: "Zipcodes",
                columns: new[] { "Id", "District", "Location", "ZipCodeNr" },
                values: new object[,]
                {
                    { 466, "Kirchdorf", "Steinbach am Ziehberg", "4643" },
                    { 467, "Gmunden", "Grünau im Almtal", "4644" },
                    { 468, "Gmunden", "Scharnstein", "4644" },
                    { 469, "Gmunden", "St. Konrad", "4644" },
                    { 470, "Gmunden", "Grünau im Almtal", "4645" },
                    { 471, "Gmunden", "Scharnstein", "4645" },
                    { 472, "Wels-Land", "Edt bei Lambach", "4650" },
                    { 473, "Wels-Land", "Gunskirchen", "4650" },
                    { 474, "Wels-Land", "Lambach", "4650" },
                    { 475, "Wels-Land", "Stadl-Paura", "4651" },
                    { 476, "Wels-Land", "Fischlham", "4652" },
                    { 477, "Wels-Land", "Steinerkirchen an der Traun", "4652" },
                    { 478, "Wels-Land", "Eberstalzell", "4653" },
                    { 479, "Gmunden", "Vorchdorf", "4653" },
                    { 480, "Wels-Land", "Bad Wimsbach-Neydharting", "4654" },
                    { 481, "Gmunden", "Roitham am Traunfall", "4655" },
                    { 482, "Wels-Land", "Steinerkirchen an der Traun", "4655" },
                    { 483, "Gmunden", "Vorchdorf", "4655" },
                    { 484, "Gmunden", "Kirchham", "4656" },
                    { 485, "Gmunden", "Laakirchen", "4656" },
                    { 486, "Gmunden", "Roitham am Traunfall", "4661" },
                    { 487, "Gmunden", "Laakirchen", "4662" },
                    { 488, "Gmunden", "Laakirchen", "4663" },
                    { 489, "Gmunden", "Gschwandt", "4664" },
                    { 490, "Gmunden", "Laakirchen", "4664" },
                    { 491, "Wels-Land", "Aichkirchen", "4671" },
                    { 492, "Wels-Land", "Neukirchen bei Lambach", "4671" },
                    { 493, "Wels-Land", "Bachmanning", "4672" },
                    { 494, "Grieskirchen", "Meggenhofen", "4672" },
                    { 495, "Wels-Land", "Pennewang", "4672" },
                    { 496, "Grieskirchen", "Gaspoltshofen", "4673" },
                    { 497, "Grieskirchen", "Gaspoltshofen", "4674" },
                    { 498, "Grieskirchen", "Weibern", "4675" },
                    { 499, "Grieskirchen", "Aistersheim", "4676" },
                    { 500, "Grieskirchen", "Gaspoltshofen", "4676" },
                    { 501, "Ried", "Geiersberg", "4680" },
                    { 502, "Grieskirchen", "Haag am Hausruck", "4680" },
                    { 503, "Grieskirchen", "Weibern", "4680" },
                    { 504, "Grieskirchen", "Rottenbach", "4681" },
                    { 505, "Grieskirchen", "Gaspoltshofen", "4682" },
                    { 506, "Grieskirchen", "Geboltskirchen", "4682" },
                    { 507, "Vöcklabruck", "Oberndorf bei Schwanenstadt", "4690" }
                });

            migrationBuilder.InsertData(
                table: "Zipcodes",
                columns: new[] { "Id", "District", "Location", "ZipCodeNr" },
                values: new object[,]
                {
                    { 508, "Vöcklabruck", "Pitzenberg", "4690" },
                    { 509, "Vöcklabruck", "Pühret", "4690" },
                    { 510, "Vöcklabruck", "Rüstorf", "4690" },
                    { 511, "Vöcklabruck", "Rutzenham", "4690" },
                    { 512, "Vöcklabruck", "Schlatt", "4690" },
                    { 513, "Vöcklabruck", "Schwanenstadt", "4690" },
                    { 514, "Wels-Land", "Stadl-Paura", "4690" },
                    { 515, "Vöcklabruck", "Niederthalheim", "4691" },
                    { 516, "Vöcklabruck", "Schlatt", "4691" },
                    { 517, "Grieskirchen", "Gaspoltshofen", "4692" },
                    { 518, "Vöcklabruck", "Niederthalheim", "4692" },
                    { 519, "Vöcklabruck", "Desselbrunn", "4693" },
                    { 520, "Vöcklabruck", "Rüstorf", "4693" },
                    { 521, "Gmunden", "Ohlsdorf", "4694" },
                    { 522, "Grieskirchen", "Bad Schallerbach", "4701" },
                    { 523, "Wels-Land", "Pichl bei Wels", "4701" },
                    { 524, "Grieskirchen", "Wallern an der Trattnach", "4701" },
                    { 525, "Grieskirchen", "Bad Schallerbach", "4702" },
                    { 526, "Wels-Land", "Krenglbach", "4702" },
                    { 527, "Wels-Land", "Pichl bei Wels", "4702" },
                    { 528, "Grieskirchen", "Wallern an der Trattnach", "4702" },
                    { 529, "Grieskirchen", "Grieskirchen", "4707" },
                    { 530, "Grieskirchen", "Schlüßlberg", "4707" },
                    { 531, "Grieskirchen", "Grieskirchen", "4710" },
                    { 532, "Grieskirchen", "Pollham", "4710" },
                    { 533, "Grieskirchen", "St. Georgen bei Grieskirchen", "4710" },
                    { 534, "Grieskirchen", "Tollet", "4710" },
                    { 535, "Grieskirchen", "Michaelnbach", "4712" },
                    { 536, "Grieskirchen", "Tollet", "4712" },
                    { 537, "Grieskirchen", "Waizenkirchen", "4712" },
                    { 538, "Grieskirchen", "Gallspach", "4713" },
                    { 539, "Grieskirchen", "Grieskirchen", "4713" },
                    { 540, "Grieskirchen", "Kematen am Innbach", "4713" },
                    { 541, "Grieskirchen", "Schlüßlberg", "4713" },
                    { 542, "Grieskirchen", "St. Georgen bei Grieskirchen", "4713" },
                    { 543, "Grieskirchen", "Gaspoltshofen", "4714" },
                    { 544, "Grieskirchen", "Meggenhofen", "4714" },
                    { 545, "Wels-Land", "Offenhausen", "4714" },
                    { 546, "Grieskirchen", "St. Georgen bei Grieskirchen", "4715" },
                    { 547, "Grieskirchen", "Taufkirchen an der Trattnach", "4715" },
                    { 548, "Grieskirchen", "Tollet", "4715" },
                    { 549, "Grieskirchen", "Hofkirchen an der Trattnach", "4716" }
                });

            migrationBuilder.InsertData(
                table: "Zipcodes",
                columns: new[] { "Id", "District", "Location", "ZipCodeNr" },
                values: new object[,]
                {
                    { 550, "Grieskirchen", "Kallham", "4720" },
                    { 551, "Grieskirchen", "Michaelnbach", "4720" },
                    { 552, "Grieskirchen", "Neumarkt im Hausruckkreis", "4720" },
                    { 553, "Grieskirchen", "Pötting", "4720" },
                    { 554, "Grieskirchen", "Wendling", "4720" },
                    { 555, "Schärding", "Altschwendt", "4721" },
                    { 556, "Grieskirchen", "Neukirchen am Walde", "4722" },
                    { 557, "Grieskirchen", "Peuerbach", "4722" },
                    { 558, "Grieskirchen", "Steegen", "4722" },
                    { 559, "Schärding", "Kopfing im Innkreis", "4723" },
                    { 560, "Grieskirchen", "Natternbach", "4723" },
                    { 561, "Grieskirchen", "Eschenau im Hausruckkreis", "4724" },
                    { 562, "Grieskirchen", "Neukirchen am Walde", "4724" },
                    { 563, "Schärding", "Waldkirchen am Wesen", "4724" },
                    { 564, "Schärding", "Engelhartszell", "4725" },
                    { 565, "Schärding", "Kopfing im Innkreis", "4725" },
                    { 566, "Schärding", "St. Aegidi", "4725" },
                    { 567, "Schärding", "St. Roman", "4725" },
                    { 568, "Eferding", "Prambachkirchen", "4730" },
                    { 569, "Grieskirchen", "St. Agatha", "4730" },
                    { 570, "Eferding", "Stroheim", "4730" },
                    { 571, "Grieskirchen", "Waizenkirchen", "4730" },
                    { 572, "Eferding", "Prambachkirchen", "4731" },
                    { 573, "Eferding", "Stroheim", "4731" },
                    { 574, "Grieskirchen", "Waizenkirchen", "4731" },
                    { 575, "Grieskirchen", "Pollham", "4732" },
                    { 576, "Eferding", "Prambachkirchen", "4732" },
                    { 577, "Eferding", "St. Marienkirchen an der Polsenz", "4732" },
                    { 578, "Grieskirchen", "St. Thomas", "4732" },
                    { 579, "Grieskirchen", "Heiligenberg", "4733" },
                    { 580, "Grieskirchen", "Hofkirchen an der Trattnach", "4741" },
                    { 581, "Grieskirchen", "Rottenbach", "4741" },
                    { 582, "Grieskirchen", "Wendling", "4741" },
                    { 583, "Grieskirchen", "Pram", "4742" },
                    { 584, "Ried", "Peterskirchen", "4743" },
                    { 585, "Schärding", "Dorf an der Pram", "4751" },
                    { 586, "Ried", "Taiskirchen im Innkreis", "4751" },
                    { 587, "Ried", "Lambrechten", "4752" },
                    { 588, "Schärding", "Riedau", "4752" },
                    { 589, "Ried", "Lambrechten", "4753" },
                    { 590, "Ried", "Taiskirchen im Innkreis", "4753" },
                    { 591, "Ried", "Andrichsfurt", "4754" }
                });

            migrationBuilder.InsertData(
                table: "Zipcodes",
                columns: new[] { "Id", "District", "Location", "ZipCodeNr" },
                values: new object[,]
                {
                    { 592, "Ried", "Peterskirchen", "4754" },
                    { 593, "Ried", "Utzenaich", "4754" },
                    { 594, "Schärding", "Altschwendt", "4755" },
                    { 595, "Schärding", "Zell an der Pram", "4755" },
                    { 596, "Schärding", "Raab", "4760" },
                    { 597, "Schärding", "St. Willibald", "4760" },
                    { 598, "Schärding", "Enzenkirchen", "4761" },
                    { 599, "Schärding", "Enzenkirchen", "4762" },
                    { 600, "Grieskirchen", "Natternbach", "4762" },
                    { 601, "Schärding", "St. Willibald", "4762" },
                    { 602, "Schärding", "Andorf", "4770" },
                    { 603, "Schärding", "Enzenkirchen", "4771" },
                    { 604, "Schärding", "Sigharting", "4771" },
                    { 605, "Schärding", "Andorf", "4772" },
                    { 606, "Ried", "Lambrechten", "4772" },
                    { 607, "Ried", "Utzenaich", "4772" },
                    { 608, "Schärding", "Eggerding", "4773" },
                    { 609, "Schärding", "St. Marienkirchen bei Schärding", "4773" },
                    { 610, "Schärding", "St. Marienkirchen bei Schärding", "4774" },
                    { 611, "Schärding", "Taufkirchen an der Pram", "4774" },
                    { 612, "Schärding", "Eggerding", "4775" },
                    { 613, "Schärding", "Taufkirchen an der Pram", "4775" },
                    { 614, "Schärding", "Diersbach", "4776" },
                    { 615, "Schärding", "Rainbach im Innkreis", "4776" },
                    { 616, "Schärding", "Mayrhof", "4777" },
                    { 617, "Schärding", "Schärding", "4780" },
                    { 618, "Schärding", "St. Florian am Inn", "4782" },
                    { 619, "Schärding", "Schardenberg", "4783" },
                    { 620, "Schärding", "Wernstein am Inn", "4783" },
                    { 621, "Schärding", "Schardenberg", "4784" },
                    { 622, "Schärding", "Wernstein am Inn", "4784" },
                    { 623, "Schärding", "Freinberg", "4785" },
                    { 624, "Schärding", "Schardenberg", "4785" },
                    { 625, "Schärding", "Brunnenthal", "4786" },
                    { 626, "Schärding", "Rainbach im Innkreis", "4791" },
                    { 627, "Schärding", "Schardenberg", "4791" },
                    { 628, "Schärding", "Taufkirchen an der Pram", "4791" },
                    { 629, "Schärding", "Münzkirchen", "4792" },
                    { 630, "Schärding", "Schardenberg", "4792" },
                    { 631, "Schärding", "St. Roman", "4792" },
                    { 632, "Schärding", "Kopfing im Innkreis", "4793" },
                    { 633, "Schärding", "St. Roman", "4793" }
                });

            migrationBuilder.InsertData(
                table: "Zipcodes",
                columns: new[] { "Id", "District", "Location", "ZipCodeNr" },
                values: new object[,]
                {
                    { 634, "Schärding", "Enzenkirchen", "4794" },
                    { 635, "Schärding", "Kopfing im Innkreis", "4794" },
                    { 636, "Schärding", "St. Aegidi", "4794" },
                    { 637, "Vöcklabruck", "Attnang-Puchheim", "4800" },
                    { 638, "Vöcklabruck", "Desselbrunn", "4800" },
                    { 639, "Vöcklabruck", "Pilsbach", "4800" },
                    { 640, "Vöcklabruck", "Pühret", "4800" },
                    { 641, "Vöcklabruck", "Regau", "4800" },
                    { 642, "Gmunden", "Altmünster", "4801" },
                    { 643, "Gmunden", "Traunkirchen", "4801" },
                    { 644, "Gmunden", "Ebensee am Traunsee", "4802" },
                    { 645, "Gmunden", "Altmünster", "4810" },
                    { 646, "Gmunden", "Gmunden", "4810" },
                    { 647, "Gmunden", "Gschwandt", "4810" },
                    { 648, "Gmunden", "Pinsdorf", "4810" },
                    { 649, "Gmunden", "Altmünster", "4812" },
                    { 650, "Gmunden", "Pinsdorf", "4812" },
                    { 651, "Vöcklabruck", "Regau", "4812" },
                    { 652, "Gmunden", "Altmünster", "4813" },
                    { 653, "Gmunden", "Altmünster", "4814" },
                    { 654, "Vöcklabruck", "Aurach am Hongar", "4814" },
                    { 655, "Gmunden", "Gschwandt", "4816" },
                    { 656, "Gmunden", "Laakirchen", "4816" },
                    { 657, "Gmunden", "Gschwandt", "4817" },
                    { 658, "Gmunden", "Kirchham", "4817" },
                    { 659, "Gmunden", "Scharnstein", "4817" },
                    { 660, "Gmunden", "St. Konrad", "4817" },
                    { 661, "Gmunden", "Bad Ischl", "4820" },
                    { 662, "Gmunden", "Bad Ischl", "4821" },
                    { 663, "Gmunden", "Bad Goisern am Hallstättersee", "4822" },
                    { 664, "Gmunden", "Hallstatt", "4823" },
                    { 665, "Gmunden", "Gosau", "4824" },
                    { 666, "Gmunden", "Gosau", "4825" },
                    { 667, "Gmunden", "Hallstatt", "4830" },
                    { 668, "Gmunden", "Obertraun", "4831" },
                    { 669, "Vöcklabruck", "Pilsbach", "4840" },
                    { 670, "Vöcklabruck", "Vöcklabruck", "4840" },
                    { 671, "Vöcklabruck", "Pilsbach", "4841" },
                    { 672, "Vöcklabruck", "Timelkam", "4841" },
                    { 673, "Vöcklabruck", "Ungenach", "4841" },
                    { 674, "Vöcklabruck", "Vöcklabruck", "4841" },
                    { 675, "Vöcklabruck", "Zell am Pettenfirst", "4842" }
                });

            migrationBuilder.InsertData(
                table: "Zipcodes",
                columns: new[] { "Id", "District", "Location", "ZipCodeNr" },
                values: new object[,]
                {
                    { 676, "Vöcklabruck", "Ampflwang im Hausruckwald", "4843" },
                    { 677, "Vöcklabruck", "Aurach am Hongar", "4844" },
                    { 678, "Vöcklabruck", "Regau", "4844" },
                    { 679, "Gmunden", "Pinsdorf", "4845" },
                    { 680, "Vöcklabruck", "Regau", "4845" },
                    { 681, "Vöcklabruck", "Redlham", "4846" },
                    { 682, "Vöcklabruck", "Puchkirchen am Trattberg", "4849" },
                    { 683, "Vöcklabruck", "Neukirchen an der Vöckla", "4850" },
                    { 684, "Vöcklabruck", "Timelkam", "4850" },
                    { 685, "Vöcklabruck", "Ungenach", "4850" },
                    { 686, "Vöcklabruck", "Vöcklabruck", "4850" },
                    { 687, "Vöcklabruck", "Gampern", "4851" },
                    { 688, "Vöcklabruck", "Seewalchen am Attersee", "4851" },
                    { 689, "Vöcklabruck", "Weyregg am Attersee", "4852" },
                    { 690, "Vöcklabruck", "Steinbach am Attersee", "4853" },
                    { 691, "Salzburg-Umgebung", "Sankt Gilgen", "4854" },
                    { 692, "Vöcklabruck", "Steinbach am Attersee", "4854" },
                    { 693, "Vöcklabruck", "Lenzing", "4860" },
                    { 694, "Vöcklabruck", "Regau", "4860" },
                    { 695, "Vöcklabruck", "Timelkam", "4860" },
                    { 696, "Vöcklabruck", "Aurach am Hongar", "4861" },
                    { 697, "Vöcklabruck", "Schörfling am Attersee", "4861" },
                    { 698, "Vöcklabruck", "Weyregg am Attersee", "4861" },
                    { 699, "Vöcklabruck", "Berg im Attergau", "4863" },
                    { 700, "Vöcklabruck", "Seewalchen am Attersee", "4863" },
                    { 701, "Vöcklabruck", "Attersee am Attersee", "4864" },
                    { 702, "Vöcklabruck", "Nußdorf am Attersee", "4865" },
                    { 703, "Vöcklabruck", "Innerschwand am Mondsee", "4866" },
                    { 704, "Salzburg-Umgebung", "Sankt Gilgen", "4866" },
                    { 705, "Vöcklabruck", "Unterach am Attersee", "4866" },
                    { 706, "Vöcklabruck", "Pfaffing", "4870" },
                    { 707, "Vöcklabruck", "Vöcklamarkt", "4870" },
                    { 708, "Vöcklabruck", "Frankenburg am Hausruck", "4871" },
                    { 709, "Vöcklabruck", "Gampern", "4871" },
                    { 710, "Vöcklabruck", "Neukirchen an der Vöckla", "4871" },
                    { 711, "Vöcklabruck", "Pfaffing", "4871" },
                    { 712, "Vöcklabruck", "Vöcklamarkt", "4871" },
                    { 713, "Vöcklabruck", "Neukirchen an der Vöckla", "4872" },
                    { 714, "Vöcklabruck", "Frankenburg am Hausruck", "4873" },
                    { 715, "Vöcklabruck", "Neukirchen an der Vöckla", "4873" },
                    { 716, "Vöcklabruck", "Redleiten", "4873" },
                    { 717, "Vöcklabruck", "Berg im Attergau", "4880" }
                });

            migrationBuilder.InsertData(
                table: "Zipcodes",
                columns: new[] { "Id", "District", "Location", "ZipCodeNr" },
                values: new object[,]
                {
                    { 718, "Vöcklabruck", "Seewalchen am Attersee", "4880" },
                    { 719, "Vöcklabruck", "St. Georgen im Attergau", "4880" },
                    { 720, "Vöcklabruck", "Straß im Attergau", "4881" },
                    { 721, "Vöcklabruck", "Oberwang", "4882" },
                    { 722, "Vöcklabruck", "Fornach", "4890" },
                    { 723, "Vöcklabruck", "Frankenmarkt", "4890" },
                    { 724, "Vöcklabruck", "Vöcklamarkt", "4890" },
                    { 725, "Vöcklabruck", "Weißenkirchen im Attergau", "4890" },
                    { 726, "Vöcklabruck", "Frankenmarkt", "4891" },
                    { 727, "Vöcklabruck", "Pöndorf", "4891" },
                    { 728, "Vöcklabruck", "Weißenkirchen im Attergau", "4891" },
                    { 729, "Vöcklabruck", "Fornach", "4892" },
                    { 730, "Vöcklabruck", "Pfaffing", "4892" },
                    { 731, "Vöcklabruck", "Oberhofen am Irrsee", "4893" },
                    { 732, "Vöcklabruck", "Tiefgraben", "4893" },
                    { 733, "Vöcklabruck", "Zell am Moos", "4893" },
                    { 734, "Vöcklabruck", "Oberhofen am Irrsee", "4894" },
                    { 735, "Vöcklabruck", "Ottnang am Hausruck", "4901" },
                    { 736, "Grieskirchen", "Gaspoltshofen", "4902" },
                    { 737, "Vöcklabruck", "Niederthalheim", "4902" },
                    { 738, "Vöcklabruck", "Wolfsegg am Hausruck", "4902" },
                    { 739, "Vöcklabruck", "Manning", "4903" },
                    { 740, "Vöcklabruck", "Atzbach", "4904" },
                    { 741, "Ried", "Eberschwang", "4906" },
                    { 742, "Ried", "Aurolzmünster", "4910" },
                    { 743, "Ried", "Mehrnbach", "4910" },
                    { 744, "Ried", "Pattigham", "4910" },
                    { 745, "Ried", "Ried im Innkreis", "4910" },
                    { 746, "Ried", "Tumeltsham", "4911" },
                    { 747, "Ried", "Neuhofen im Innkreis", "4912" },
                    { 748, "Ried", "Schildorn", "4920" },
                    { 749, "Ried", "Hohenzell", "4921" },
                    { 750, "Ried", "Geiersberg", "4922" },
                    { 751, "Ried", "Lohnsburg am Kobernaußerwald", "4923" },
                    { 752, "Ried", "Waldzell", "4924" },
                    { 753, "Ried", "Pattigham", "4925" },
                    { 754, "Ried", "Pramet", "4925" },
                    { 755, "Ried", "St. Marienkirchen am Hausruck", "4926" },
                    { 756, "Braunau", "Aspach", "4931" },
                    { 757, "Ried", "Mettmach", "4931" },
                    { 758, "Braunau", "Aspach", "4932" },
                    { 759, "Ried", "Kirchheim im Innkreis", "4932" }
                });

            migrationBuilder.InsertData(
                table: "Zipcodes",
                columns: new[] { "Id", "District", "Location", "ZipCodeNr" },
                values: new object[,]
                {
                    { 760, "Braunau", "Aspach", "4933" },
                    { 761, "Ried", "Mehrnbach", "4941" },
                    { 762, "Ried", "Ried im Innkreis", "4941" },
                    { 763, "Ried", "Gurten", "4942" },
                    { 764, "Ried", "Wippenham", "4942" },
                    { 765, "Ried", "Geinberg", "4943" },
                    { 766, "Ried", "Gurten", "4943" },
                    { 767, "Ried", "Kirchdorf am Inn", "4943" },
                    { 768, "Braunau", "Polling im Innkreis", "4943" },
                    { 769, "Braunau", "Altheim", "4950" },
                    { 770, "Braunau", "Weng im Innkreis", "4950" },
                    { 771, "Ried", "Geinberg", "4951" },
                    { 772, "Braunau", "Polling im Innkreis", "4951" },
                    { 773, "Braunau", "Altheim", "4952" },
                    { 774, "Braunau", "Moosbach", "4952" },
                    { 775, "Braunau", "Weng im Innkreis", "4952" },
                    { 776, "Ried", "Mühlheim am Inn", "4961" },
                    { 777, "Braunau", "Weng im Innkreis", "4961" },
                    { 778, "Braunau", "Mining", "4962" },
                    { 779, "Braunau", "St. Peter am Hart", "4962" },
                    { 780, "Braunau", "Burgkirchen", "4963" },
                    { 781, "Braunau", "St. Peter am Hart", "4963" },
                    { 782, "Ried", "Eitzing", "4970" },
                    { 783, "Ried", "Andrichsfurt", "4971" },
                    { 784, "Ried", "Aurolzmünster", "4971" },
                    { 785, "Ried", "Mehrnbach", "4971" },
                    { 786, "Ried", "Utzenaich", "4971" },
                    { 787, "Ried", "Andrichsfurt", "4972" },
                    { 788, "Ried", "Aurolzmünster", "4972" },
                    { 789, "Ried", "Utzenaich", "4972" },
                    { 790, "Ried", "Aurolzmünster", "4973" },
                    { 791, "Ried", "Mörschwang", "4973" },
                    { 792, "Ried", "Reichersberg", "4973" },
                    { 793, "Ried", "Senftenbach", "4973" },
                    { 794, "Ried", "St. Martin im Innkreis", "4973" },
                    { 795, "Ried", "Utzenaich", "4973" },
                    { 796, "Ried", "Lambrechten", "4974" },
                    { 797, "Ried", "Ort im Innkreis", "4974" },
                    { 798, "Ried", "Reichersberg", "4974" },
                    { 799, "Schärding", "Suben", "4975" },
                    { 800, "Ried", "Antiesenhofen", "4980" },
                    { 801, "Schärding", "Eggerding", "4980" }
                });

            migrationBuilder.InsertData(
                table: "Zipcodes",
                columns: new[] { "Id", "District", "Location", "ZipCodeNr" },
                values: new object[,]
                {
                    { 802, "Ried", "Reichersberg", "4980" },
                    { 803, "Ried", "Reichersberg", "4981" },
                    { 804, "Ried", "Kirchdorf am Inn", "4982" },
                    { 805, "Ried", "Mörschwang", "4982" },
                    { 806, "Ried", "Obernberg am Inn", "4982" },
                    { 807, "Ried", "St. Georgen bei Obernberg am Inn", "4983" },
                    { 808, "Ried", "Mörschwang", "4984" },
                    { 809, "Ried", "Weilbach", "4984" }
                });

            migrationBuilder.InsertData(
                table: "RestaurantCategory",
                columns: new[] { "Id", "CategoryId", "RestaurantId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 27, 2 },
                    { 3, 2, 3 },
                    { 4, 6, 4 },
                    { 5, 20, 5 },
                    { 6, 2, 6 },
                    { 7, 6, 7 },
                    { 8, 3, 8 },
                    { 9, 6, 9 },
                    { 10, 1, 10 }
                });

            migrationBuilder.InsertData(
                table: "RestaurantOpeningTimes",
                columns: new[] { "Id", "ClosingTime", "Day", "OpeningTime", "RestaurantId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 26, 18, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2023, 5, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, new DateTime(2023, 5, 26, 18, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2023, 5, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, new DateTime(2023, 5, 26, 18, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2023, 5, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, new DateTime(2023, 5, 26, 18, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2023, 5, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 5, new DateTime(2023, 5, 26, 18, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2023, 5, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 6, new DateTime(2023, 5, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), 6, new DateTime(2023, 5, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 7, new DateTime(2023, 5, 28, 16, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2023, 5, 28, 10, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                table: "RestaurantTables",
                columns: new[] { "Id", "RestaurantId", "SeatPlaces" },
                values: new object[,]
                {
                    { 1, 1, 6 },
                    { 2, 2, 8 },
                    { 3, 3, 5 },
                    { 4, 4, 6 },
                    { 5, 5, 7 },
                    { 6, 6, 6 },
                    { 7, 7, 9 },
                    { 8, 8, 5 },
                    { 9, 9, 6 },
                    { 10, 10, 7 },
                    { 11, 1, 6 },
                    { 12, 2, 8 },
                    { 13, 3, 5 },
                    { 14, 4, 6 },
                    { 15, 5, 7 },
                    { 16, 6, 6 },
                    { 17, 7, 9 },
                    { 18, 8, 5 },
                    { 19, 9, 6 },
                    { 20, 10, 7 },
                    { 21, 1, 6 },
                    { 22, 2, 7 },
                    { 23, 3, 5 },
                    { 24, 4, 6 },
                    { 25, 5, 8 }
                });

            migrationBuilder.InsertData(
                table: "RestaurantTables",
                columns: new[] { "Id", "RestaurantId", "SeatPlaces" },
                values: new object[,]
                {
                    { 26, 6, 6 },
                    { 27, 7, 9 },
                    { 28, 8, 5 },
                    { 29, 9, 6 },
                    { 30, 10, 7 },
                    { 31, 1, 6 },
                    { 32, 2, 7 },
                    { 33, 3, 5 },
                    { 34, 4, 6 },
                    { 35, 5, 8 },
                    { 36, 6, 6 },
                    { 37, 7, 9 },
                    { 38, 8, 5 },
                    { 39, 9, 6 },
                    { 40, 10, 7 },
                    { 41, 1, 7 },
                    { 42, 2, 9 },
                    { 43, 3, 6 },
                    { 44, 4, 8 },
                    { 45, 5, 5 },
                    { 46, 6, 7 },
                    { 47, 7, 6 },
                    { 48, 8, 8 },
                    { 49, 9, 9 },
                    { 50, 10, 5 },
                    { 51, 1, 6 },
                    { 52, 2, 7 },
                    { 53, 3, 5 },
                    { 54, 4, 6 },
                    { 55, 5, 8 },
                    { 56, 6, 6 },
                    { 57, 7, 9 },
                    { 58, 8, 5 },
                    { 59, 9, 6 },
                    { 60, 10, 7 },
                    { 61, 1, 6 },
                    { 62, 2, 7 },
                    { 63, 3, 5 },
                    { 64, 4, 6 },
                    { 65, 5, 8 },
                    { 66, 6, 6 },
                    { 67, 7, 9 }
                });

            migrationBuilder.InsertData(
                table: "RestaurantTables",
                columns: new[] { "Id", "RestaurantId", "SeatPlaces" },
                values: new object[] { 68, 8, 5 });

            migrationBuilder.InsertData(
                table: "RestaurantTables",
                columns: new[] { "Id", "RestaurantId", "SeatPlaces" },
                values: new object[] { 69, 9, 6 });

            migrationBuilder.InsertData(
                table: "RestaurantTables",
                columns: new[] { "Id", "RestaurantId", "SeatPlaces" },
                values: new object[] { 70, 10, 7 });

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantCategory_CategoryId",
                table: "RestaurantCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantCategory_RestaurantId",
                table: "RestaurantCategory",
                column: "RestaurantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RestaurantCategory");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "RestaurantOpeningTimes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RestaurantOpeningTimes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RestaurantOpeningTimes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RestaurantOpeningTimes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RestaurantOpeningTimes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RestaurantOpeningTimes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "RestaurantOpeningTimes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "RestaurantTables",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 209);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 211);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 213);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 214);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 215);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 216);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 217);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 218);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 219);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 220);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 221);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 222);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 223);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 224);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 225);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 226);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 227);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 228);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 229);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 230);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 231);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 232);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 233);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 234);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 235);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 236);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 237);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 238);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 239);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 240);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 241);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 242);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 243);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 244);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 245);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 246);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 247);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 248);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 249);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 250);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 251);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 252);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 253);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 254);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 255);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 256);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 257);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 258);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 259);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 260);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 261);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 262);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 263);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 264);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 265);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 266);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 267);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 268);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 269);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 270);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 271);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 272);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 273);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 274);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 275);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 276);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 277);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 278);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 279);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 280);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 281);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 282);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 283);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 284);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 285);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 286);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 287);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 288);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 289);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 290);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 291);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 292);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 293);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 294);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 295);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 296);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 297);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 298);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 299);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 300);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 301);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 302);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 303);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 304);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 305);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 306);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 307);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 308);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 309);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 310);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 311);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 312);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 313);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 314);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 315);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 316);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 317);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 318);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 319);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 320);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 321);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 322);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 323);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 324);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 325);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 326);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 327);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 328);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 329);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 330);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 331);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 332);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 333);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 334);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 335);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 336);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 337);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 338);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 339);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 340);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 341);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 342);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 343);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 344);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 345);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 346);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 347);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 348);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 349);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 350);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 351);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 352);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 353);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 354);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 355);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 356);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 357);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 358);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 359);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 360);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 361);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 362);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 363);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 364);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 365);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 366);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 367);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 368);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 369);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 370);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 371);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 372);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 373);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 374);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 375);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 376);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 377);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 378);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 379);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 380);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 381);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 382);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 383);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 384);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 385);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 386);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 387);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 388);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 389);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 390);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 391);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 392);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 393);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 394);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 395);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 396);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 397);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 398);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 399);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 400);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 401);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 402);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 403);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 404);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 405);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 406);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 407);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 408);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 409);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 410);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 411);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 412);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 413);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 414);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 415);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 416);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 417);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 418);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 419);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 420);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 421);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 422);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 423);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 424);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 425);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 426);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 427);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 428);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 429);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 430);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 431);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 432);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 433);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 434);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 435);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 436);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 437);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 438);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 439);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 440);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 441);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 442);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 443);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 444);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 445);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 446);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 447);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 448);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 449);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 450);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 451);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 452);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 453);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 454);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 455);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 456);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 457);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 458);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 459);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 460);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 461);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 462);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 463);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 464);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 465);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 466);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 467);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 468);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 469);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 470);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 471);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 472);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 473);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 474);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 475);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 476);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 477);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 478);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 479);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 480);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 481);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 482);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 483);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 484);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 485);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 486);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 487);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 488);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 489);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 490);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 491);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 492);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 493);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 494);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 495);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 496);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 497);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 498);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 499);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 500);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 501);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 502);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 503);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 504);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 505);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 506);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 507);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 508);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 509);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 510);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 511);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 512);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 513);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 514);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 515);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 516);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 517);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 518);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 519);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 520);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 521);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 522);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 523);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 524);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 525);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 526);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 527);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 528);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 529);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 530);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 531);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 532);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 533);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 534);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 535);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 536);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 537);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 538);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 539);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 540);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 541);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 542);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 543);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 544);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 545);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 546);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 547);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 548);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 549);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 550);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 551);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 552);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 553);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 554);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 555);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 556);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 557);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 558);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 559);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 560);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 561);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 562);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 563);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 564);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 565);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 566);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 567);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 568);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 569);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 570);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 571);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 572);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 573);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 574);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 575);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 576);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 577);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 578);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 579);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 580);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 581);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 582);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 583);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 584);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 585);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 586);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 587);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 588);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 589);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 590);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 591);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 592);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 593);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 594);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 595);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 596);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 597);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 598);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 599);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 600);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 601);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 602);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 603);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 604);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 605);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 606);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 607);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 608);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 609);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 610);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 611);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 612);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 613);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 614);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 615);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 616);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 617);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 618);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 619);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 620);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 621);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 622);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 623);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 624);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 625);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 626);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 627);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 628);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 629);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 630);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 631);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 632);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 633);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 634);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 635);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 636);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 637);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 638);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 639);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 640);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 641);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 642);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 643);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 644);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 645);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 646);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 647);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 648);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 649);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 650);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 651);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 652);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 653);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 654);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 655);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 656);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 657);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 658);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 659);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 660);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 661);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 662);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 663);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 664);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 665);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 666);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 667);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 668);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 669);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 670);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 671);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 672);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 673);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 674);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 675);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 676);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 677);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 678);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 679);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 680);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 681);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 682);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 683);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 684);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 685);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 686);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 687);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 688);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 689);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 690);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 691);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 692);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 693);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 694);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 695);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 696);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 697);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 698);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 699);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 700);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 701);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 702);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 703);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 704);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 705);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 706);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 707);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 708);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 709);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 710);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 711);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 712);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 713);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 714);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 715);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 716);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 717);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 718);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 719);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 720);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 721);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 722);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 723);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 724);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 725);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 726);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 727);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 728);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 729);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 730);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 731);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 732);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 733);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 734);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 735);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 736);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 737);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 738);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 739);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 740);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 741);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 742);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 743);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 744);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 745);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 746);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 747);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 748);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 749);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 750);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 751);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 752);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 753);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 754);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 755);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 756);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 757);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 758);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 759);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 760);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 761);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 762);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 763);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 764);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 765);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 766);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 767);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 768);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 769);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 770);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 771);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 772);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 773);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 774);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 775);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 776);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 777);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 778);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 779);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 780);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 781);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 782);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 783);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 784);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 785);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 786);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 787);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 788);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 789);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 790);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 791);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 792);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 793);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 794);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 795);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 796);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 797);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 798);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 799);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 800);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 801);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 802);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 803);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 804);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 805);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 806);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 807);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 808);

            migrationBuilder.DeleteData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 809);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Amerikanisch");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Arabisch");

            migrationBuilder.UpdateData(
                table: "Zipcodes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Location", "ZipCodeNr" },
                values: new object[] { "Enns", "4470" });
        }
    }
}
