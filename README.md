# GCM_Encryption
This repository contains a solution for encryption in GCM (Galois/Counter Mode) using Bouncy Castle library in C#, along with a corresponding decryption solution in PHP. The GCM mode provides authenticated encryption with associated data, ensuring both confidentiality and integrity of the encrypted data.

# Features:

C# Encryption Solution: The C# code demonstrates how to perform encryption using Bouncy Castle library in GCM mode. It includes example code for generating cryptographic keys, encrypting data, and generating the authentication tag.

PHP Decryption Solution: The PHP code showcases the decryption process for data encrypted with the C# solution. It demonstrates how to validate the integrity of the encrypted data and retrieve the original plaintext.

Cross-Language Compatibility: The solutions provided in this repository enable interoperability between C# and PHP, allowing encrypted data to be securely transmitted and decrypted in a different programming language.
Secure Communication: With the implementation of GCM mode, the solutions provide strong encryption and authentication capabilities, ensuring the confidentiality and integrity of sensitive data during transmission and storage.

# Usage:
The C# encryption solution can be integrated into C# projects by importing the necessary Bouncy Castle libraries and following the provided code examples.
The PHP decryption solution can be used in PHP applications by including the decryption code and adapting it to the specific requirements of the project.
Please note that this repository serves as a reference implementation and should be tailored to suit your specific needs. Feel free to explore, modify, and adapt the code as required.
