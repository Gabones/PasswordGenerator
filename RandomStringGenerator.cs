using System.Text;

namespace PasswordGenerator;

public class RandomStringGenerator
{
    private static readonly Random Random = new Random();
    private static readonly string _uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private static readonly string _lowercase = "abcdefghijklmnopqrstuvwxyz";
    private static readonly string _numbers = "0123456789";
    private static readonly string _special = "!@#$%^&*()-_=+[]{}|;:'\",.<>?/";

    public static string GenerateRandomString(int length, string startsWith, bool useUppercase = true, bool useLowercase = true, bool useNumbers = true, bool useSpecialCharacters = true)
    {
        var characterSet = new StringBuilder();
        var result = new StringBuilder(length);

        if (!string.IsNullOrEmpty(startsWith))
        {
            switch (startsWith)
            {
                case "lowercase":
                    result.Append(PickLetter(_lowercase));
                    break;
                case "uppercase":
                    result.Append(PickLetter(_uppercase));
                    break;
                case "number":
                    result.Append(PickLetter(_numbers));
                    break;
                case "special":
                    result.Append(PickLetter(_special));
                    break;
            }
        }

        if (useUppercase)
            characterSet.Append(_uppercase);
        if (useLowercase)
            characterSet.Append(_lowercase);
        if (useNumbers)
            characterSet.Append(_numbers);
        if (useSpecialCharacters)
            characterSet.Append(_special);

        if (characterSet.Length == 0)
            throw new ArgumentException("At least one character type must be selected");

        for (int i = result.Length; i < length; i++)
        {
            result.Append(PickLetter(characterSet));
        }

        return result.ToString();
    }

    private static char PickLetter(string characterSet)
    {
        int index = Random.Next(characterSet.Length);
        return characterSet[index];
    }

    private static char PickLetter(StringBuilder characterSet)
    {
        int index = Random.Next(characterSet.Length);
        return characterSet[index];
    }
}
