namespace StringUtilities.Library
{
    public class StringService : IStringService
    {
        public int GetOccurrences(string template, string text)
        {
            int occurrences = 0;
            int index = -1;
            while (true)
            {
                index = text.IndexOf(template, index + 1);
                if (index == -1)
                {
                    break;
                }

                occurrences += 1;

            }

            return occurrences;
        }
    }
}
