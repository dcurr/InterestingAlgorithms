using System.Text;

namespace InterestingAlgorithms
{
    public class CaesarCipher
    {
        const string baseAlphabet = "abcdefghijklmnopqrstuvwxyz";

        /// <summary>
        /// Encrypt a string using the caesar cypher
        /// </summary>
        /// <param name="shift">minus values indicate a left shift, positive a right shift</param>
        /// <param name="plaintextMsg">message to be encrypted</param>
        /// <returns></returns>
        public string Encrypt(int shift, string plaintextMsg)
        {
            string encryptedMsg = "";
            foreach (char c in plaintextMsg.ToLower())
            {
                int indexOfCharInAlphabet = baseAlphabet.IndexOf(c);
                if (indexOfCharInAlphabet < 0)
                {
                    encryptedMsg += c;
                }
                else
                {
                    encryptedMsg += GetShiftedValue(shift, c);
                }
            }

            return encryptedMsg;
        }

        public string Decrypt(int shift, string encryptedMsg)
        {
            return Encrypt(-shift, encryptedMsg);
        }

        private char GetShiftedValue(int shift, char inputValue)
        {
            StringBuilder alphabet = new StringBuilder();
            alphabet.Append(baseAlphabet);

            int indexOfCharInAlphabet = baseAlphabet.IndexOf(inputValue);
            int offset = indexOfCharInAlphabet + shift;
            var absoluteOffset = Math.Abs(offset);

            if (absoluteOffset > alphabet.Length)
            {
                var x = absoluteOffset / alphabet.Length;
                for (int i = 0; i < x; i++)
                {
                    alphabet.Append(baseAlphabet);
                }
            }

            if (offset >= 0)
            {
                return alphabet[offset];
            }
            else
            {
                var reversedAlphabet = new string(alphabet.ToString().Reverse().ToArray());
                return reversedAlphabet[absoluteOffset - 1];
            }
        }
    }
}
