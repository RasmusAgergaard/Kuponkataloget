using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kuponkatalog.Models;

namespace Kuponkatalog.Data
{
    //public class FakeCatalogRepository : ICatalogRepository
    //{
        //public List<Catalog> Catalogs { get; set; }

        //public FakeCatalogRepository()
        //{
        //    if (Catalogs == null)
        //    {
        //        InitializeCatalogs();
        //    }
        //}

        //private void InitializeCatalogs()
        //{
        //    var pages = new List<Page>
        //    {
        //        new Page
        //        {
        //            Id = 0,
        //            ImgUrl = "https://online.adservicemedia.dk/banners/1565936894.jpeg",
        //            Title = "Illustreret videnskab + Quick Charge Powerbank",
        //            Type = Enums.pageTypes.Affiliate,
        //            DescriptionShort ="2 nr. of Illustreret Videnskab + Quick Charge Powerbank for 69 kr. + 39 kr. in taxes and shipping. In total 108 kr.",
        //            DescriptionLong = "Illustreret Videnskab - Bliv underholdt og udfordret, og forstå den verden, som omgiver dig. Tag med på opdagelsesrejse - fra Jordens dybeste kløft til universets yderste grænser. Glæd dig til seneste nyt fra forskernes frontlinje og spændende beretninger om nye teknologiske gennembrud. Altid forsynet med en videnskabelig forklaring undervejs.",
        //            ButtonText = "Bestil her",
        //            TargetUrl = "https://www.google.dk/"
        //        },
        //        new Page
        //        {
        //            Id = 1,
        //            ImgUrl = "https://online.adservicemedia.dk/banners/1565185442.jpeg",
        //            Title = "BO BEDRE + Menu Bottle Grinder",
        //            Type = Enums.pageTypes.Affiliate,
        //            DescriptionShort ="BO BEDRE - Danmarks største og bedste boligblad om indretning, design og shopping til boligen! Det er i BO BEDRE, du får overblik over det nyeste design både herhjemme og i udlandet, og det er også med BO BEDRE, du kommer indenfor i de mest spændende danske og udenlandske boliger. BO BEDRE er til alle, der drømmer om at skabe et godt og inspirerende hjem.",
        //            DescriptionLong = "Flotte og dekorative salt- og peberkværne fra danske MENU. Kværnene har et minimalistisk udseende og vil tage sig flot ud på et veldækket bord. Kværnene er yderst praktiske, da kværnen sidder i toppen, så du undgår krydderier på bordet Kan bruges til salt, peber og andre grove krydderier - Du får et sæt med 2 stk. og kan vælge mellem farverne grå/hvid (ash/carbon) og nudes",
        //            ButtonText = "Køb tilbud nu - Lige her!",
        //            TargetUrl = "https://www.google.dk/"
        //        },
        //        new Page
        //        {
        //            Id = 2,
        //            ImgUrl = "https://online.adservicemedia.dk/banners/1481192723.png",
        //            Title = "Find den bedste alarm løsning!",
        //            Type = Enums.pageTypes.Affiliate,
        //            DescriptionShort ="Få styr på sikkerheden i hjemmet og få installeret en tyverialarm/boligalarm. Alt afhængig af din bolig, så kan der være stor forskel på hvilken type alarm der passer bedst. Har du fx brug for videoovervågning, rumføler eller app til nem betjening ? Ved at indhente 3 tilbud her, så er du sikret både kvalificeret rådgivning, samt det bedste/billigste tilbud! Tjenestetorvet.dk har indhentet tilbud for snart 100.000 danskere og samarbejder udelukkende med anerkendte leverandører, som fx Falck, G4S og Verisure.",
        //            DescriptionLong = "1. Udfyld formularen/skemaet - 2. Vælg de 3 selskaber du ønsker at modtage tilbud fra - 3. Det står dig frit for om du vil takke ja eller nej til et af tilbuddene. Tjenestetorvet.dk hjælper dig ved nemt med at overskue markedet.Indhent tilbud fra flere forhandlere - så er du sikker på at du får den bedste aftale. Udfyld formularen og læn dig tilbage.Så bliver du kontaktet af flere forhandlere i dit lokalområde, som du kan sammenligne og derefter vælge den leverandør, der møder dine behov bedst! 100 % gratis og uforpligtende!",
        //            ButtonText = "Gå til tilbud!",
        //            TargetUrl = "https://www.google.dk/"
        //        },
        //        new Page
        //        {
        //            Id = 3,
        //            ImgUrl = "https://online.adservicemedia.dk/banners/1564640875.jpeg",
        //            Title = "Føler du dig heldig? Spin dig til vilde præmier!",
        //            Type = Enums.pageTypes.Affiliate,
        //            DescriptionShort ="Blue Energy har netop startet deres sommer lykkehjul og udlodder massere fede præmier. Når du tilmelder dig, vil du også modtage fede nyheder og tilbud fra Blue Energys samt 3 samarbejdspartnere som sponsorer konkurrencen. Vinderen trækkes allerede d.31/08, så tilmeld dig i en fart!",
        //            DescriptionLong = " ",
        //            ButtonText = "Tilmeld dig her, det koster 0 kr.:",
        //            TargetUrl = "https://www.google.dk/"
        //        },
        //        new Page
        //        {
        //            Id = 4,
        //            ImgUrl = "https://online.adservicemedia.dk/banners/1565680450.png",
        //            Title = "Samle dine lån og få overblikket tilbage",
        //            Type = Enums.pageTypes.Affiliate,
        //            DescriptionShort ="Forbrugslån er populære, når du står i en situation, hvor du mangler penge. Enten til flytning, skal stifte familie eller andet som kræver større pengebeløb. Hos Amy Finance har du mulighed for at låne optil 500 000 kr til lige præcis det du behøver.",
        //            DescriptionLong = "Vi stiller ingen spørgsmål – vi er her for at hjælpe.",
        //            ButtonText = "Hop til tjenesten her",
        //            TargetUrl = "https://www.google.dk/"
        //        },
        //    };

        //    Catalogs = new List<Catalog>
        //    {
        //        new Catalog{Id = 1, Title = "Katalog 1", Description="Dette er en beskrivelse for 1"},
        //        new Catalog{Id = 2, Title = "Katalog 2", Description="Dette er en beskrivelse for 2"}
        //    };

        //    //Catalogs[0].Pages = new List<Page>();
        //    //Catalogs[0].Pages.Add(pages[0]);
        //    //Catalogs[0].Pages.Add(pages[1]);
        //    //Catalogs[0].Pages.Add(pages[2]);
        //    //Catalogs[0].Pages.Add(pages[3]);
        //    //Catalogs[0].Pages.Add(pages[4]);


        //    //Catalogs[1].Pages = new List<Page>();
        //    //Catalogs[1].Pages.Add(pages[4]);
        //    //Catalogs[1].Pages.Add(pages[3]);
        //    //Catalogs[1].Pages.Add(pages[2]);
        //    //Catalogs[1].Pages.Add(pages[1]);
        //    //Catalogs[1].Pages.Add(pages[0]);
        //}

        //public void AddCatalog(Catalog catalog)
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<Catalog> GetAllCatalogs()
        //{
        //    return Catalogs;
        //}

        //public Catalog GetCatalogById(int id)
        //{
        //    return Catalogs.FirstOrDefault(c => c.Id == id);
        //}
    //}
}
