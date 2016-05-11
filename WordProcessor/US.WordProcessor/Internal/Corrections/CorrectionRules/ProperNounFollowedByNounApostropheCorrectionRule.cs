using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace US.WordProcessor.Internal.Corrections.CorrectionRules
{
   internal class ProperNounFollowedByNounApostropheCorrectionRule : ICorrectionRule
   {
      private readonly Dictionary _dictionary;

      internal ProperNounFollowedByNounApostropheCorrectionRule(Dictionary dictionary)
      {
         _dictionary = dictionary;
      }

      public Optional<Correction> RunRuleOnWord(SentenceReader sentenceReader)
      {
         var definitionReader = new DefinitionReader(_dictionary, sentenceReader);

         if (definitionReader.CurrentDefinition.Type==WordType.ProperNoun && definitionReader.CurrentDefinition.Suffix=="s")
         {
            if (sentenceReader.HasNext)
            {
               if (definitionReader.NextDefinition.Type == WordType.Noun)
               {
                  if (sentenceReader.Current[sentenceReader.Current.Length - 2] != '\'')
                  {
                     return new Optional<Correction>(new Correction(CorrectionType.OwnershipByAProperNoun, sentenceReader.SourceSentence.ToString(), sentenceReader.Current));
                  }
               }
            }
         }

         return new Optional<Correction>();
      }
   }
}
