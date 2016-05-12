using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using US.WordProcessor.Internal.Corrections.CorrectionRules;

namespace US.WordProcessor.Internal.Corrections
{
   internal static class CorrectionRuleProcessorFactory
   {
      internal static CorrectionRuleProcessor CreateCorrectionRuleProcessor()
      {
         var dictionary = new Dictionary();

         return new CorrectionRuleProcessor(new List<ICorrectionRule>() {
            new ProperNounApostropheCorrectionRule(dictionary),
            new RegularNounsDoNotNeedApostrophesRule(dictionary),
            new ContractionsNeedApostropheRule()
         }
         );
      }
   }
}
