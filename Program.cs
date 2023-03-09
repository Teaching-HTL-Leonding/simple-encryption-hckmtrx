char[] alphabet = Enumerable.Range('a', 'z' - 'a' + 1).Select(i => (Char)i).ToArray();

string encryptedLink = "rddzc://mvkccbyyw.qsdrel.myw/k/njQi4uvX";
string decryptedLink = "";

for (int i = 0; i < encryptedLink.Length; i++)
{
    char decryptedChar;

    if (!alphabet.Contains(Char.ToLower(encryptedLink[i]))) { decryptedChar = encryptedLink[i]; }
    else
    {
        int index = Array.IndexOf(alphabet, Char.ToLower(encryptedLink[i]));
        decryptedChar = alphabet[(26 + index - 10) % 26];
    }
    
    decryptedLink += Char.IsUpper(encryptedLink[i]) ? Char.ToUpper(decryptedChar) : decryptedChar;
}

Console.WriteLine(decryptedLink);