using InterestingAlgorithms;

CaesarCipher cEncrypter = new CaesarCipher();
int shift = 500;

var userInput = "";
while (userInput != "exit")
{
    userInput = Console.ReadLine();
    var encryptedText = cEncrypter.Encrypt(shift, userInput);
    Console.WriteLine("Encrypted: " + encryptedText);
    Console.WriteLine("Decrypted: " + cEncrypter.Decrypt(shift, encryptedText));
}
