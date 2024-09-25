using RSACrypto;
namespace Example
{
    class Program
    {

        static void Main()
        {
            Encryptor _encryptor;
            int p = 29;  // Первое простое число
            int q = 73;  // Второе простое число
            string message = "OKB18P";
            _encryptor = new Encryptor(p, q);
            (Tuple<int, int> publicKey, Tuple<int, int> privateKey) = _encryptor.GenerateKeys();
            List<int> crypt = Encryptor.Encrypt(message, publicKey);
            foreach (var c in crypt)
                Console.WriteLine(c);
            string answer = Decryptor.Decrypt(crypt, privateKey);
            Console.WriteLine(answer);
        }

    }
}
