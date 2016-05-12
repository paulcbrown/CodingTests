namespace US.WordProcessor.Internal.Extensions
{
   public static class StringExtensions
   {
      public static bool HasSingularApostrophe(this string word)
      {
         if (word.Length >= 2 && word[word.Length - 2] == '\'')
         {
            return true;
         }

         return false;
      }
   }
}
