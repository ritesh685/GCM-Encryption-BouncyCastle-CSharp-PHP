<?php
$ciphertextWithTagHex = '616A615BC3494E96C906FFD95214A7274CF5E43C2418DB03B11AFC86A9C770'; // Ciphertext with appended tag (in hexadecimal)
$keyHex = '7EAFBE4775BD8355DF955F94CEF3E3DE9ABE00FF9DBF1C04473758844D09CE23'; // Key hexadecimal string
$nonceHex = '1ADAA49CB4A2E05D464E6AE8'; // Nonce hexadecimal string

$ciphertextWithTag = hex2bin($ciphertextWithTagHex);
$key = hex2bin($keyHex);
$nonce = hex2bin($nonceHex);

$ciphertext = substr($ciphertextWithTag, 0, -16); // Extract ciphertext portion (excluding the last 16 bytes for the tag)
$tag = substr($ciphertextWithTag, -16); // Extract the last 16 bytes for the tag

$decrypted = openssl_decrypt($ciphertext, 'aes-256-gcm', $key, OPENSSL_RAW_DATA, $nonce, $tag);

if ($decrypted !== false) {
    echo "Decrypted: $decrypted";
} else {
    echo "Decryption failed.";
}
?>