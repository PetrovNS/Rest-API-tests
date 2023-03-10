using System.Text;

namespace REST_API.Utils
{
    public static class RandomGenerator
    {
        private static string pool = "abcdefghijklmnopqrstuvwxyz";
        private static Random random = new Random((int)DateTime.Now.Ticks);
        public static string RandomString(int length)
        {
            var builder = new StringBuilder();

            for (var i = 0; i < length; i++)
            {
                var c = pool[random.Next(pool.Length)];
                builder.Append(c);
            }
            return builder.ToString();
        }
    }
}
