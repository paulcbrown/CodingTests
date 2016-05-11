using US.WordProcessor.Internal;

namespace US.WordProcessor
{
   public static class CorrectionFactory
   {
      public static ICorrectionFinder CreateCorrectionFinder()
      {
         return new CorrectionFinder(new Dictionary());
      }
   }
}
