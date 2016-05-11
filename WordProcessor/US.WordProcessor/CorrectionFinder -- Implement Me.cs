using System;
using System.Collections.Generic;
using US.WordProcessor.Internal;
using US.WordProcessor.Internal.Corrections;
using US.WordProcessor.Internal.Corrections.CorrectionRules;

namespace US.WordProcessor
{
   internal class CorrectionFinder
      : ICorrectionFinder
   {
      private static CorrectionRuleProcessor _correctionRuleProcessor;

      internal CorrectionFinder(Dictionary dictionary)
      {
         _correctionRuleProcessor = new CorrectionRuleProcessor(new List<ICorrectionRule>() {
            new ProperNounFollowedByNounApostropheCorrectionRule(dictionary)}
            );
      }

      public IEnumerable<Correction> Find(Paragraph paragraph)
      {
         var corrections = new List<Correction>();

         foreach (Sentence sentence in paragraph)
         {
            corrections.AddRange(this.FindCorrectionsInSentence(sentence));
         }

         return corrections;
      }

      private IEnumerable<Correction> FindCorrectionsInSentence(Sentence sentence)
      {
         var sentenceReader = new SentenceReader(sentence);

         var corrections = new List<Correction>();

         while (sentenceReader.MoveNext())
         {
            IEnumerable<Correction> correctionsForWord = _correctionRuleProcessor.ProcessCorrectionRulesOnWord(sentenceReader);

            corrections.AddRange(correctionsForWord);
         }

         return corrections;
      }
   }
}
