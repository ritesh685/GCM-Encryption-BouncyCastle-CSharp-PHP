static void Main()
{
    // Input plaintext
    string plaintext = "Hello";

    // Generate a 256-bit secret key
    byte[] key = new byte[32];
    using (var rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
    {
        rng.GetBytes(key);
    }

    // Generate a 96-bit nonce (IV)
    byte[] nonce = new byte[12];
    using (var rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
    {
        rng.GetBytes(nonce);
    }

    // Encrypt the plaintext
    byte[] encrypted = Encrypt(Encoding.UTF8.GetBytes(plaintext), key, nonce);

    // Share the data in hexadecimal format
    string cipher = BitConverter.ToString(encrypted).Replace("-", "");
    string key_hex = BitConverter.ToString(key).Replace("-", "");
    string nonce_hex = BitConverter.ToString(nonce).Replace("-", "");

    // Decrypt the ciphertext
    byte[] decrypted = Decrypt(encrypted, key, nonce);
    string decryptedText = Encoding.UTF8.GetString(decrypted);

    MessageBox.Show(decryptedText);
}

public static byte[] Encrypt(byte[] plaintext, byte[] key, byte[] nonce)
{
    // Create a GCM block cipher with AES as the underlying encryption algorithm
    GcmBlockCipher cipher = new GcmBlockCipher(new AesEngine());

    // Set up the parameters for encryption (key and nonce)
    AeadParameters parameters = new AeadParameters(new KeyParameter(key), 128, nonce);

    cipher.Init(true, parameters);

    // Encrypt the plaintext
    byte[] ciphertext = new byte[cipher.GetOutputSize(plaintext.Length)];
    int len = cipher.ProcessBytes(plaintext, 0, plaintext.Length, ciphertext, 0);
    cipher.DoFinal(ciphertext, len);

    // Retrieve the authentication tag
    byte[] tag = cipher.GetMac();

    // Convert the tag to a Base64 string
    string tagBase64 = Convert.ToBase64String(tag);

    return ciphertext;
}

public static byte[] Decrypt(byte[] ciphertext, byte[] key, byte[] nonce)
{
    // Create a GCM block cipher with AES as the underlying encryption algorithm
    GcmBlockCipher cipher = new GcmBlockCipher(new AesEngine());

    // Set up the parameters for decryption (key and nonce)
    AeadParameters parameters = new AeadParameters(new KeyParameter(key), 128, nonce);

    cipher.Init(false, parameters);

    // Decrypt the ciphertext
    byte[] plaintext = new byte[cipher.GetOutputSize(ciphertext.Length)];
    int len = cipher.ProcessBytes(ciphertext, 0, ciphertext.Length, plaintext, 0);
    cipher.DoFinal(plaintext, len);

    return plaintext;
}
