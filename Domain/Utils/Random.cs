using System.Text;

namespace Domain.Utils;

public static class Random {
    private readonly static char[] Chars =
        "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();

    public static string RandomStringCode(int length) {
        if (length < 1) throw new ArgumentException("Length must be greater than 0", nameof(length));

        StringBuilder stringBuilder = new StringBuilder(length);
        System.Random random        = new System.Random();

        for (int i = 0; i < length; i++)
        {
            char randomChar = Chars[random.Next(Chars.Length)];
            stringBuilder.Append(randomChar);
        }

        return stringBuilder.ToString();
    }
}