using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace US.WordProcessor.Internal.Corrections.CorrectionRules
{
   internal class ContractionsNeedApostropheRule : ICorrectionRule
   {
      public Optional<Correction> RunRuleOnCurrentWord(SentenceReader sentenceReader)
      {
         switch (sentenceReader.Current.ToLower())
         {
            case "isnt":
               return new Optional<Correction>(CreateCorrection(sentenceReader));
            case "wont":
               return  new Optional<Correction>(CreateCorrection(sentenceReader));
            case "doesnt":
               return  new Optional<Correction>(CreateCorrection(sentenceReader));
            default:
               return new Optional<Correction>();
         }
      }

      private Correction CreateCorrection(SentenceReader sentenceReader)
      {
         return new Correction(CorrectionType.MissingContractionApostrophe, sentenceReader.SourceSentence.ToString(), sentenceReader.Current);
      }
   }
}
