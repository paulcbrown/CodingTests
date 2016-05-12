using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using US.WordProcessor.Internal.Extensions;

namespace US.WordProcessor.Internal.Corrections.CorrectionRules
{
   internal class RegularNounsDoNotNeedApostrophesRule : ICorrectionRule
   {
      private readonly Dictionary _dictionary;

      internal RegularNounsDoNotNeedApostrophesRule(Dictionary dictionary)
      {
         _dictionary = dictionary;
      }

      public Optional<Correction> RunRuleOnCurrentWord(SentenceReader sentenceReader)
      {
         var definitionReader = new DefinitionReader(_dictionary, sentenceReader);

         if (definitionReader.CurrentDefinition.Type == WordType.Noun && definitionReader.CurrentDefinition.Suffix == "s")
         {
            if (sentenceReader.Current.HasSingularApostrophe())
            {
               return new Optional<Correction>(new Correction(CorrectionType.IncorrectNounApostrophe, sentenceReader.SourceSentence.ToString(), sentenceReader.Current));
            }
         }

         return new Optional<Correction>();
      }
   }
}
