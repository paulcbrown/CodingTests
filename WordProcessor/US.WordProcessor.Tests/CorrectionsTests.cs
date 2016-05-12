using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace US.WordProcessor.Tests
{
   [TestClass]
   public class CorrectionsTests
   {
      [TestMethod]
      public void ProperNounsSuffixedWithSNeedAnAposBeforeTheSCorrect()
      {
         var p = new Paragraph("Susan owns a hat. It is Susan’s hat.");
         var c = CorrectionFactory.CreateCorrectionFinder()
            .Find(p)
            .ToList();
         
         Assert.AreEqual(0, c.Count);
      }

      [TestMethod]
      public void ProperNounsSuffixedWithSNeedAnAposBeforeTheSIncorrect()
      {
         var p = new Paragraph("Susan owns a hat. It is Susans hat.");
         var c = CorrectionFactory.CreateCorrectionFinder()
            .Find(p)
            .Single();

         Assert.AreEqual(CorrectionType.OwnershipByAProperNoun, c.Type);
         Assert.AreEqual("It is Susans hat", c.Sentence);
         Assert.AreEqual("Susans", c.Word);
      }

      [TestMethod]
      public void ProperNounsPrecededByIsNeedAnAposBeforeTheSCorrect()
      {
         var p = new Paragraph("Barry owns a car. The car is Barry’s.");
         var c = CorrectionFactory.CreateCorrectionFinder()
            .Find(p)
            .ToList();

         Assert.AreEqual(0, c.Count);
      }

      [TestMethod]
      public void ProperNounsPrecededByIsNeedAnAposBeforeTheSIncorrect()
      {
         var p = new Paragraph("Barry owns a car. The car is Barrys.");
         var c = CorrectionFactory.CreateCorrectionFinder()
            .Find(p)
            .Single();

         Assert.AreEqual(CorrectionType.OwnershipByAProperNoun, c.Type);
         Assert.AreEqual("The car is Barrys", c.Sentence);
         Assert.AreEqual("Barrys", c.Word);
      }

      [TestMethod]
      public void RegularNounsDoNotNeedAnApostropheCorrect()
      {
         var p = new Paragraph("Look at those airplanes over there.");
         var c = CorrectionFactory.CreateCorrectionFinder()
            .Find(p)
            .ToList();

         Assert.AreEqual(0, c.Count);
      }

      [TestMethod]
      public void RegularNounsDoNotNeedAnApostropheIncorrect()
      {
         var p = new Paragraph("Look at those airplane's over there.");
         var c = CorrectionFactory.CreateCorrectionFinder()
            .Find(p)
            .Single();

         Assert.AreEqual(CorrectionType.IncorrectNounApostrophe, c.Type);
         Assert.AreEqual("Look at those airplane's over there", c.Sentence);
         Assert.AreEqual("airplane's", c.Word);
      }

      [TestMethod]
      public void IsntNeedsAnApostropheIncorrect()
      {
         var p = new Paragraph("Isnt coding Fun?");
         var c = CorrectionFactory.CreateCorrectionFinder().Find(p).Single();

         Assert.AreEqual(CorrectionType.MissingContractionApostrophe, c.Type);
         Assert.AreEqual("Isnt coding Fun?", c.Sentence);
         Assert.AreEqual("Isnt", c.Word);
      }

      [TestMethod]
      public void IsntNeedsAnApostropheCorrect()
      {
         var p = new Paragraph("Isn't coding Fun?");
         var c = CorrectionFactory.CreateCorrectionFinder().Find(p).ToList();

         Assert.AreEqual(0, c.Count);
      }

      [TestMethod]
      public void WontNeedsAnApostropheIncorrect()
      {
         var p = new Paragraph("Why wont this build?");
         var c = CorrectionFactory.CreateCorrectionFinder().Find(p).Single();

         Assert.AreEqual(CorrectionType.MissingContractionApostrophe, c.Type);
         Assert.AreEqual("Why wont this build?", c.Sentence);
         Assert.AreEqual("wont", c.Word);
      }

      [TestMethod]
      public void WontNeedsAnApostropheCorrect()
      {
         var p = new Paragraph("Why won't this build?");
         var c = CorrectionFactory.CreateCorrectionFinder().Find(p).ToList();

         Assert.AreEqual(0, c.Count);
      }

      [TestMethod]
      public void DoesntNeedsAnApostropheIncorrect()
      {
         var p = new Paragraph("Something doesnt have an apostrophe.");
         var c = CorrectionFactory.CreateCorrectionFinder().Find(p).Single();

         Assert.AreEqual(CorrectionType.MissingContractionApostrophe, c.Type);
         Assert.AreEqual("Something doesnt have an apostrophe", c.Sentence);
         Assert.AreEqual("doesnt", c.Word);
      }

      [TestMethod]
      public void DoesntNeedsAnApostropheCorrect()
      {
         var p = new Paragraph("Something doesn't have an apostrophe.");
         var c = CorrectionFactory.CreateCorrectionFinder().Find(p).ToList();

         Assert.AreEqual(0, c.Count);
      }

      [TestMethod]
      public void MultipleIncorrectContractionsMultipleCorrections()
      {
         var p = new Paragraph("This isnt right, it wont work.");
         var c = CorrectionFactory.CreateCorrectionFinder().Find(p).ToList();

         Assert.AreEqual(2,c.Count);
      }
   }
}
