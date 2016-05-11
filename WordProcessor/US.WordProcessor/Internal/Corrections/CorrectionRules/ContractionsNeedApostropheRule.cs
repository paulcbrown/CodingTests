using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace US.WordProcessor.Internal.Corrections.CorrectionRules
{
   internal class ContractionsNeedApostropheRule : ICorrectionRule
   {
      public Optional<Correction> RunRuleOnWord(SentenceReader sentenceReader)
      {
         throw new NotImplementedException();
      }
   }
}
