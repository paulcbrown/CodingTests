using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using US.WordProcessor.Internal.Extensions;

namespace US.WordProcessor.Internal.Corrections.CorrectionRules
{
   internal class ProperNounApostropheCorrectionRule : ICorrectionRule
   {
      private readonly Dictionary _dictionary;

      internal ProperNounApostropheCorrectionRule(Dictionary dictionary)
      {
         _dictionary = dictionary;
      }

      public Optional<Correction> RunRuleOnCurrentWord(SentenceReader sentenceReader)
      {
         var definitionReader = new DefinitionReader(_dictionary, sentenceReader);

         if (definitionReader.CurrentDefinition.Type == WordType.ProperNoun && definitionReader.CurrentDefinition.Suffix == "s")
         {
            if (!sentenceReader.Current.HasSingularApostrophe())
            {
               if (sentenceReader.HasNext && definitionReader.NextDefinition.Type == WordType.Noun)
               {
                  return
                     new Optional<Correction>(this.CreateCorrection(sentenceReader));
               }


               if (sentenceReader.HasPrevious && sentenceReader.Previous.Value == "is")
               {
                  return
                     new Optional<Correction>(this.CreateCorrection(sentenceReader));
               }
            }
         }

         return new Optional<Correction>();
      }

      private Correction CreateCorrection(SentenceReader sentenceReader)
      {
         return new Correction(CorrectionType.OwnershipByAProperNoun,
            sentenceReader.SourceSentence.ToString(), sentenceReader.Current);
      }

   }
}
