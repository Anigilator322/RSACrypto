using System.Numerics;


namespace RSACrypto
{
    public class Decryptor
    {
        public static string Decrypt(List<int> ciphertext, Tuple<int, int> privateKey)
        {
            int d = privateKey.Item1;
            int n = privateKey.Item2;
            ciphertext.Reverse();
            string message = "";
            foreach (var c in ciphertext)
            {
                BigInteger.ModPow(c, d, n);
                message = (char)(c) + message;
            }
            return message;
        }
    }
}
