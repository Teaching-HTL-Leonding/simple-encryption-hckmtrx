#region Constants
const int OFFSET = 9;
const string ENCRYPT = "e";
const string DECRYPT = "d";
#endregion

#region Main Program
{
    string option;
    bool inputIsValid;
    do
    {
        Console.Write("Decrypt or Encrypt? (d/e): ");
        option = Console.ReadLine()!.ToLower();

        inputIsValid = option is DECRYPT or ENCRYPT;
        if (!inputIsValid) { Console.WriteLine("Invalid input. Try again..."); }
    } while (!inputIsValid);

    bool encrypt = option == ENCRYPT;

    Console.Write("\nEnter an input: ");
    string output = Cryptography(Console.ReadLine()!, encrypt ? OFFSET : -OFFSET);

    Console.Write(encrypt ? "Encrypted" : "Decrypted");
    Console.WriteLine($" output: {output}");
}
#endregion

#region Methods
string Cryptography(string input, int offSet)
{
    const string ALPHABET = "abcdefghijklmnopqrstuvwxyz";
    string output = "";

    for (int i = 0; i < input.Length; i++)
    {
        char outputChar;

        if (!ALPHABET.Contains(Char.ToLower(input[i]))) { outputChar = input[i]; }
        else
        {
            int index = ALPHABET.IndexOf(Char.ToLower(input[i]));
            outputChar = ALPHABET[(ALPHABET.Count() + index + offSet) % ALPHABET.Count()];
        }

        output += Char.IsUpper(input[i]) ? Char.ToUpper(outputChar) : outputChar;
    }

    return output;
}
#endregion
