namespace PasswordGenerator;

class Program
{
    static void Main(string[] args)
    {
        // Generate a 12-character random string with uppercase, lowercase, and numbers.
        if (args.Any(s => s == "--help"))
        {
            Console.WriteLine(
                @"Generates a randon password:
                    passwordGenerator <length> <startsWith> <options>
                    <length>
                        password length

                    <startsWith>
                        uppercase
                        lowercase
                        number
                        special

                    <options>
                        --useUppercase
                        --useLowercase
                        --useNumbers
                        --useSpecialCharacters
                "
            );
            return;
        }

        int length = 12;
        if (int.TryParse(args[0], out int consoleLength))
            length = consoleLength;

        string startsWith = args[1].StartsWith("--") ? "" : args[1];

        bool useUppercase = args.Any(s => s == "--useUppercase");
        bool useLowercase = args.Any(s => s == "--useLowercase");
        bool useNumbers = args.Any(s => s == "--useNumbers");
        bool useSpecialCharacters = args.Any(s => s == "--useSpecialCharacters");

        string randomString = RandomStringGenerator.GenerateRandomString(
            length,
            startsWith,
            useUppercase: useUppercase,
            useLowercase: useLowercase,
            useNumbers: useNumbers,
            useSpecialCharacters: useSpecialCharacters
        );
        Console.WriteLine(randomString);
    }
}