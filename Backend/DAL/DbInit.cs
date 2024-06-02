using System.Text.RegularExpressions;
using lars_notedatabase.Models;

namespace lars_notedatabase.DAL;

public static class DbInit
{
    public static async void Seed(IApplicationBuilder app)
    {
        using IServiceScope serviceScope = app.ApplicationServices.CreateScope();
        NoteDbContext context = serviceScope.ServiceProvider.GetRequiredService<NoteDbContext>();
        
        //await context.Database.EnsureDeletedAsync(); // Deletes database if it exists 
        await context.Database.EnsureCreatedAsync(); // Creates database if it doesn't exist


        List<Country> countriesList =
        [
            new() { Id = 1, Name = "Skandinavia" },
            new() { Id = 2, Name = "Amerika" },
            new() { Id = 3, Name = "England" },
            new() { Id = 4, Name = "Skottland" },
            new() { Id = 5, Name = "Sverige" },
            new() { Id = 6, Name = "Norge" },
            new() { Id = 7, Name = "Danmark" },
            new() { Id = 8, Name = "Finnland" },
            new() { Id = 9, Name = "Island" },
            new() { Id = 10, Name = "Tyskland" },
            new() { Id = 11, Name = "Serbia" },
            new() { Id = 12, Name = "Frankrike" },
            new() { Id = 13, Name = "Jugoslavia" },
            new() { Id = 14, Name = "Tsjekkoslovakia" },
            new() { Id = 15, Name = "Nederland" },
            new() { Id = 16, Name = "Østerike" },
            new() { Id = 17, Name = "Polen" },
            new() { Id = 18, Name = "Italia" },
            new() { Id = 19, Name = "Hellas" },
            new() { Id = 20, Name = "Belgia" },
            new() { Id = 21, Name = "Luxemburg" },
            new() { Id = 22, Name = "Spania" },
            new() { Id = 23, Name = "Argentina" },
            new() { Id = 24, Name = "Brazil" },
            new() { Id = 25, Name = "Mexico" },
            new() { Id = 26, Name = "diverse" },
            new() { Id = 27, Name = "Irland" },
            new() { Id = 28, Name = "Japan" },
            new() { Id = 29, Name = "Kina" },
            new() { Id = 30, Name = "Ostindien" },
            new() { Id = 31, Name = "Iran" },
            new() { Id = 32, Name = "Portugal" },
            new() { Id = 33, Name = "Romania" },
            new() { Id = 34, Name = "Russland" },
            new() { Id = 35, Name = "Siam" },
            new() { Id = 36, Name = "Ungarn" },
            new() { Id = 37, Name = "Israel" },
            new() { Id = 38, Name = "Cuba" },
            new() { Id = 39, Name = "Puerto Rico" },
            new() { Id = 40, Name = "Marokko" },
            new() { Id = 41, Name = "Hawaii" },
            new() { Id = 42, Name = "Canada" },
            new() { Id = 43, Name = "Sveits" },
            new() { Id = 44, Name = "Native American" },
            new() { Id = 45, Name = "Fransk-engelsk" },
            new() { Id = 46, Name = "Ukraina" },
            new() { Id = 47, Name = "Schlesien (en del av Polen)" },
            new() { Id = 48, Name = "Tysk-engelsk" },
            new() { Id = 49, Name = "Ukjent" },
            new() { Id = 50, Name = "Baskisk" },
            new() { Id = 51, Name = "Tysk-jødisk" },
            new() { Id = 52, Name = "Tysk-østerisk" },
            new() { Id = 53, Name = "Walisisk" },
            new() { Id = 54, Name = "Tsjekkia" },
            new() { Id = 55, Name = "Tysk-sveitsisk" },
            new() { Id = 56, Name = "Malta" }
        ];

        if (!context.Countries.Any())
        {
            await context.Countries.AddRangeAsync(countriesList);
            await context.SaveChangesAsync();
            Console.WriteLine("Countries added");
        }

        if (!context.Instruments.Any())
        {
            List<Instrument> instrumentList =
            [
                new() { Name = "Alt-saksofon i Eb 1" },
                new() { Name = "Alt-saksofon i Eb 2" },
                new() { Name = "Alt-saksofon i Eb 3" },
                new() { Name = "Banjo" },
                new() { Name = "Bariton-Saxofon i Eb" },
                new() { Name = "Bassklarinett (og eller klarinett i Eb)" },
                new() { Name = "Bass-trombone" },
                new() { Name = "Bratsj" },
                new() { Name = "Castagnetter" },
                new() { Name = "Celesta" },
                new() { Name = "Cello 1" },
                new() { Name = "Cello 2" },
                new() { Name = "Cello obligato" },
                new() { Name = "Chimes/tubular bells" },
                new() { Name = "Cymbaler" },
                new() { Name = "Dombjeller" },
                new() { Name = "Engelsk horn" },
                new() { Name = "Eufonium" },
                new() { Name = "Fagott 1" },
                new() { Name = "Fagott 2" },
                new() { Name = "Fiolin 1" },
                new() { Name = "Fiolin 2" },
                new() { Name = "Fiolin 3" },
                new() { Name = "Fiolin obligat" },
                new() { Name = "Fløyte 1" },
                new() { Name = "Fløyte 2" },
                new() { Name = "Fløyte 3" },
                new() { Name = "Gitar" },
                new() { Name = "Harmonika" },
                new() { Name = "Harmonium" },
                new() { Name = "Harpe" },
                new() { Name = "Horn i C 1" },
                new() { Name = "Horn i C 2" },
                new() { Name = "Horn i D 1" },
                new() { Name = "Horn i D 2" },
                new() { Name = "Horn i Eb 1" },
                new() { Name = "Horn i Eb 2" },
                new() { Name = "Horn i F 1" },
                new() { Name = "Horn i F 2" },
                new() { Name = "Horn i F 3" },
                new() { Name = "Horn i F 4" },
                new() { Name = "Klarinett 1 i A" },
                new() { Name = "Klarinett 1 i Bb" },
                new() { Name = "Klarinett 1 i C" },
                new() { Name = "Klarinett 2 i A" },
                new() { Name = "Klarinett 2 i Bb" },
                new() { Name = "Klarinett 2 i C" },
                new() { Name = "Klarinett 3 i A" },
                new() { Name = "Klarinett 3 i Bb" },
                new() { Name = "Klaver" },
                new() { Name = "Klokkespill" },
                new() { Name = "Kontrabass" },
                new() { Name = "Kontrafagott" },
                new() { Name = "Kornett i A 1" },
                new() { Name = "Kornett i A 2" },
                new() { Name = "Kornett i Bb 1" },
                new() { Name = "Kornett i Bb 2" },
                new() { Name = "Kubjelle" },
                new() { Name = "Mandolin 1" },
                new() { Name = "Obo 1" },
                new() { Name = "Obo 2" },
                new() { Name = "Obo Obligat" },
                new() { Name = "Pauker 1-2 stk" },
                new() { Name = "Pauker 3 eller fler" },
                new() { Name = "Piccolo (muligens som en av fløytestemmene)" },
                new() { Name = "Skarptromme" },
                new() { Name = "Slagverk" },
                new() { Name = "Solist" },
                new() { Name = "Sopran-saksofon" },
                new() { Name = "Stortromme" },
                new() { Name = "Tamburtromme" },
                new() { Name = "Tenorbanjo" },
                new() { Name = "Tenor-saksofon i Bb 1" },
                new() { Name = "Tenor-saksofon i Bb 2" },
                new() { Name = "Tenor-saksofon i Bb 3" },
                new() { Name = "Tenor-saksofon i Bb 4" },
                new() { Name = "Tenor-saksofon i C (melodi)" },
                new() { Name = "Timbaler" },
                new() { Name = "Tom tom" },
                new() { Name = "Trekkspill/Bandoneon" },
                new() { Name = "Triangel" },
                new() { Name = "Trombone 1" },
                new() { Name = "Trombone 2" },
                new() { Name = "Trombone 3" },
                new() { Name = "Trompet i A 1" },
                new() { Name = "Trompet i A 2" },
                new() { Name = "Trompet i A obligat" },
                new() { Name = "Trompet i Bb 1" },
                new() { Name = "Trompet i Bb 2" },
                new() { Name = "Trompet i Bb 3" },
                new() { Name = "Trompet i Bb 4" },
                new() { Name = "Trompet i Bb obligat" },
                new() { Name = "Trompet i C 1" },
                new() { Name = "Trompet i C 2" },
                new() { Name = "Trompet i F 1" },
                new() { Name = "Trompet i F 2" },
                new() { Name = "Tuba-Ophicléide" },
                new() { Name = "Tuba" },
                new() { Name = "Vibrafon" },
                new() { Name = "Xylofon" }
            ];


            await context.Instruments.AddRangeAsync(instrumentList);
            await context.SaveChangesAsync();
        }


        if (!context.Contributors.Any())
        {
            string filePath = "DbImports/contributors.txt";
            string[] lines = await File.ReadAllLinesAsync(filePath);

            List<string> contributorList = lines.ToList();


            List<Contributor> filteredContributors = FilterContributors(contributorList);
            /*foreach (var contributor in filteredContributors)
            {
                Console.WriteLine(
                    $"{contributor.FirstName} {contributor.LastName},  {contributor.BirthDate}-{contributor.DeathDate}");
            }*/


            static List<Contributor> FilterContributors(List<string> contributors)
            {
                List<Contributor> contributorList = [];

                foreach (string contributorString in contributors)
                {
                    // Use a regular expression to extract names
                    Match match = Regex.Match(contributorString, @"^([\w\s.-]+)(?:\s\((\d{4})-(\d{4})\))?$");

                    if (match.Success)
                    {
                        string firstName = match.Groups[1].Value.Trim();
                        string lastName = string.Empty;

                        // Split the name into first and last name
                        string[] names = firstName.Split(' ');
                        if (names.Length > 1)
                        {
                            firstName = names[0];
                            lastName = names[1];
                        }

                        int? birthYear = match.Groups[2].Success ? int.Parse(match.Groups[2].Value) : null;
                        int? deathYear = match.Groups[3].Success ? int.Parse(match.Groups[3].Value) : null;

                        Contributor contributor = new Contributor
                        {
                            FirstName = firstName,
                            LastName = lastName,
                            BirthDate = birthYear != null ? new DateTime(birthYear.Value, 1, 1) : null,
                            DeathDate = deathYear != null ? new DateTime(deathYear.Value, 1, 1) : null,
                        };

                        contributorList.Add(contributor);
                    }
                }

                return contributorList;
            }

            await context.Contributors.AddRangeAsync(filteredContributors);
            await context.SaveChangesAsync();
        }
    }
}