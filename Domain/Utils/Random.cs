using System.Text;

namespace Domain.Utils;

public static class RandomGenerator {
    private readonly static char[] Chars =
        "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();

    public static String RandomStringCode(int length) {
        if (length < 1) throw new ArgumentException("Length must be greater than 0", nameof(length));

        StringBuilder stringBuilder = new StringBuilder(length);
        Random random        = new Random();

        for (int i = 0; i < length; i++)
        {
            char randomChar = Chars[random.Next(Chars.Length)];
            stringBuilder.Append(randomChar);
        }

        return stringBuilder.ToString();
    }
}