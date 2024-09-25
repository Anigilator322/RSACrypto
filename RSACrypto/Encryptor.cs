using System;
using System.Numerics;

namespace RSACrypto
{
	public class Encryptor
	{
		private int _p, _q;
		public Encryptor(int p, int q)
		{
			_p = p;
			_q = q;
		}
        private static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
        private static BigInteger ModInverse(int e, int phi)
        {
            for (BigInteger d = 1; d < phi; d++)
            {
                if ((e * d) % phi == 1)
                {
                    return d;
                }
            }
            return -1;
        }
        public static (Tuple<int, int>, Tuple<int, int>) GenerateKeys(int p, int q)
        {
            int n = p * q;
            int phi = (p - 1) * (q - 1);

            int e = p - 1;
            while (GCD(e, phi) != 1 && e > 1)
            {
                e--;
            }
            BigInteger d = ModInverse(e, phi);
            return (Tuple.Create(e, n), Tuple.Create((int)d, n));  
        }
        public (Tuple<int, int>, Tuple<int, int>) GenerateKeys()
        {
            int n = _p * _q;
            int phi = (_p - 1) * (_q - 1);

            int e = _p - 1;
            while (GCD(e, phi) != 1 && e > 1)
            {
                e--;
            }
            BigInteger d = ModInverse(e, phi);
            return (Tuple.Create(e, n), Tuple.Create((int)d, n));
        }
        public static List<int> Encrypt(string message, Tuple<int, int> publicKey)
        {
            int e = publicKey.Item1;
            int n = publicKey.Item2;

            BigInteger messageInt = 0;
            List<int> crypt = new List<int>();
            foreach (char c in message)
            {
                messageInt += (byte)c;
                BigInteger.ModPow(messageInt, e, n);
                crypt.Add((int)messageInt);
                messageInt = 0;
            }
            return crypt;
        }
        
    }
}
