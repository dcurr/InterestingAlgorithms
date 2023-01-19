using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestingAlgorithms
{
    public class CaesarCipher
    {
        const string baseAlphabet = "abcdefghijklmnopqrstuvwxyz";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shift">minus values indicate a left shift, positive a right shift</param>
        /// <param name="plaintextMsg">message to be encoded</param>
        /// <returns></returns>
        public string Encrypt(int shift, string plaintextMsg)
        {
            string encryptedMsg = "";
            foreach(char c in plaintextMsg.ToLower())
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
            var alphabet = baseAlphabet;
            int indexOfCharInAlphabet = baseAlphabet.IndexOf(inputValue);
            int offset = indexOfCharInAlphabet + shift;

            if (Math.Abs(offset) > alphabet.Length)
            {
                var x = Math.Abs(offset) / alphabet.Length;
                for(int i = 0; i < x; i++)
                {
                    alphabet += alphabet;
                }
            }

            if (offset >= 0)
            {
                return alphabet[offset];
            }
            else
            {
                var reversedAlphabet = new string(alphabet.Reverse().ToArray());
                return reversedAlphabet[Math.Abs(offset) - 1];
            }
        }
    }
}
