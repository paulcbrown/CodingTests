using US.WordProcessor.Internal;
using US.WordProcessor.Internal.Corrections;

namespace US.WordProcessor
{
   public static class CorrectionFactory
   {
      public static ICorrectionFinder CreateCorrectionFinder()
      {
         return new CorrectionFinder(CorrectionRuleProcessorFactory.CreateCorrectionRuleProcessor());
      }
   }
}
