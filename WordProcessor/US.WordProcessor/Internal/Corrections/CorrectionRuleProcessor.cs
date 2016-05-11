using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using US.WordProcessor.Internal.Corrections.CorrectionRules;

namespace US.WordProcessor.Internal.Corrections
{
   internal class CorrectionRuleProcessor
   {
      private readonly IEnumerable<ICorrectionRule> _correctionRules;

      internal CorrectionRuleProcessor(IEnumerable<ICorrectionRule> correctionRules)
      {
         _correctionRules = correctionRules;
      }

      internal IEnumerable<Correction> ProcessCorrectionRulesOnWord(SentenceReader sentenceReader)
      {
         var corrections = new List<Correction>();

         foreach (var correctionRule in _correctionRules)
         {
            var possibleCorrection = correctionRule.RunRuleOnWord(sentenceReader);

            if (possibleCorrection.HasValue)
            {
               corrections.Add(possibleCorrection.Value);
            }
         }

         return corrections;
      }
   }
}
