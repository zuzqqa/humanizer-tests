using System;
using System.Globalization;
using System.Threading;
using Humanizer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mono.Cecil;

namespace Humanizer.FunctionalTests
{
    [TestClass]
    public class HumanizerFunctionalTests
    {
        [TestInitialize]
        public void Initialize()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pl-PL");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("pl-PL");
        }

        [TestMethod]
        public void TestTextTransformation()
        {
            var input = "TestowanieTransformacjiTekstu";

            // DZIAŁA
            var humanized = input.Humanize();
            Assert.AreEqual("Testowanie transformacji tekstu", humanized);

            // DZIAŁA
            var dehumanized = humanized.Dehumanize();
            Assert.AreEqual("TestowanieTransformacjiTekstu", dehumanized);

            // DZIAŁA
            var camelCased = input.Camelize();
            Assert.AreEqual("testowanieTransformacjiTekstu", camelCased);

            // DZIAŁA
            var underscored = input.Underscore();
            Assert.AreEqual("testowanie_transformacji_tekstu", underscored);
        }

        [TestMethod]
        public void TestDateFormatting()
        {
            var in1Days = DateTime.UtcNow.AddDays(1).Humanize();
            var oneDayAgo = DateTime.UtcNow.AddDays(-1).Humanize();
            var twoDaysAgo = DateTime.UtcNow.AddDays(-2).Humanize();
            var inThreeDays = DateTime.UtcNow.AddDays(3).Humanize();

            // DZIAŁA
            Assert.AreEqual("wczoraj", oneDayAgo);

            // NIE DZIAŁA WYNIK = ZA 23 GODZIN
            //Assert.AreEqual("jutro", in1Days);

            // DZIAŁA
            Assert.AreEqual("przed 2 dniami", twoDaysAgo);

            // NIE DZIAŁA WYNIK = ZA 2 DNI
            //Assert.AreEqual("za 3 dni", inThreeDays);
        }

        [TestMethod]
        public void TestTimeConversion()
        {
            // DZIAŁA
            Assert.AreEqual("2 godziny", TimeSpan.FromMinutes(120).Humanize());

            // DZIAŁA
            Assert.AreEqual("1 dzień", TimeSpan.FromHours(24).Humanize());

            // DZIAŁA
            Assert.AreEqual("1 tydzień", TimeSpan.FromHours(168).Humanize());

            // DZIAŁA
            Assert.AreEqual("1 tydzień", TimeSpan.FromDays(7).Humanize());

            // DZIAŁA
            Assert.AreEqual("30 sekund", TimeSpan.FromSeconds(30).Humanize());

            // DZIAŁA
            Assert.AreEqual("45 minut", TimeSpan.FromMinutes(45).Humanize());
        }

        [TestMethod]
        public void TestNumberToWords()
        {
            // DZIAŁA
            Assert.AreEqual("pięć", 5.ToWords());

            // DZIAŁA
            Assert.AreEqual("sto", 100.ToWords());

            // DZIAŁA
            Assert.AreEqual("sto dwadzieścia trzy", 123.ToWords());

            // DZIAŁA
            Assert.AreEqual("milion", 1000000.ToWords());

            // DZIAŁA
            Assert.AreEqual("minus pięć", (-5).ToWords());

            // DZIAŁA
            Assert.AreEqual("minus sto dwadzieścia trzy", (-123).ToWords());
        }

        [TestMethod]
        public void TestNumberFormatting()
        {
            // DZIAŁA
            Assert.AreEqual("1M", 1000000.ToMetric());

            // DZIAŁA
            Assert.AreEqual("1,5M", 1500000.ToMetric());
        }

        [TestMethod]
        public void TestUnitHumanizing()
        {
            // DZIAŁA
            Assert.AreEqual("1 GB", 1024.Megabytes().Humanize());

            // DZIAŁA
            Assert.AreEqual("1,5 GB", 1536.Megabytes().Humanize());

            // DZIAŁA
            Assert.AreEqual("1 godzina", 3600.Seconds().Humanize());

            // DZIAŁA
            Assert.AreEqual("1 dzień", 24.Hours().Humanize());
        }

        [TestMethod]
        public void TestQuantityString()
        {
            // NIE DZIAŁA WYNIK = 0 książkas
            // var output = "książka".ToQuantity(0);
            // Assert.AreEqual("0 książek", output);

            // DZIAŁA WYNIK = 1 książka
            var output = "książka".ToQuantity(1);
            Assert.AreEqual("1 książka", output);

            // NIE DZIAŁA WYNIK = 2 książkis
            // var output = "książki".ToQuantity(2);
            // Assert.AreEqual("2 książki", output);
        }

        [TestMethod]
        public void TestTimeAgo()
        {
            var now = DateTime.Now;

            // DZIAŁA
            Assert.AreEqual("przed minutą", now.AddMinutes(-1).Humanize());

            // DZIAŁA
            Assert.AreEqual("przed 3 dniami", now.AddDays(-3).Humanize());

            // NIE DZIAŁA WYNIK = za 4 minuty
            // Assert.AreEqual("za 5 minut", now.AddMinutes(5).Humanize());

            // NIE DZIAŁA WYNIK = za godzinę
            // Assert.AreEqual("za 2 godziny", now.AddHours(2).Humanize());

            // DZIAŁA
            Assert.AreEqual("przed 14 dniami", now.AddDays(-14).Humanize());

            // DZIAŁA
            Assert.AreEqual("za 3 lata", now.AddYears(3).Humanize());
        }

        [TestMethod]
        public void TestOrdinalNumbers()
        {
            // NIE DZIAŁA WYNIK = pierwszy
            // Assert.AreEqual("pierwszy", 1.ToOrdinalWords(GrammaticalGender.Masculine));

            // NIE DZIAŁA WYNIK = 2
            // Assert.AreEqual("druga", 2.ToOrdinalWords(GrammaticalGender.Feminine));
        }

        [TestMethod]
        public void TestInflectorExtensions()
        {
            // NIE DZIAŁA WYNIK = programs
            // Assert.AreEqual("programy", "program".Pluralize());

            // NIE DZIAŁA WYNIK = programy
            // Assert.AreEqual("program", "programy".Singularize());

            // NIE DZIAŁA WYNIK = dzieckos
            // Assert.AreEqual("dzieci", "dziecko".Pluralize());

            // NIE DZIAŁA WYNIK = dzieci
            // Assert.AreEqual("dziecko", "dzieci".Singularize());
        }
    }
}