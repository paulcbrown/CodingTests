using System.Collections.Specialized;

namespace US.WordProcessor.Internal.Corrections.CorrectionRules
{
   internal interface ICorrectionRule
   {
      Optional<Correction> RunRuleOnCurrentWord(SentenceReader sentenceReader);
   }
}
