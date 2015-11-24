namespace StringUtilities.ConsoleClient
{
    using System;

    using StringServiceReference;

    public class Startup
    {
        public static void Main()
        {
            using (var client = new StringServiceClient())
            {
                int result = client.GetOccurrences("lorem", "lorem lorem lorem lorem");
                Console.WriteLine(result);
            }
        }
    }
}
