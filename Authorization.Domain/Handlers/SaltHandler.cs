﻿using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace Authentication.Domain.Handlers;

public static class SaltHandler
{
    public static AuthenticationCredentials CreateUserCredentials(string password)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);
        string base64Salt = Convert.ToBase64String(salt);

        var key = KeyDerivation.Pbkdf2(password,
                                       salt,
                                       KeyDerivationPrf.HMACSHA256,
                                       100000,
                                       256 / 8);

        var encryptedPassword = Convert.ToBase64String(key);

        return new AuthenticationCredentials(encryptedPassword, base64Salt);
    }
    public static string EncrypPassword(string password, string salt)
    {
        var key = KeyDerivation.Pbkdf2(password,
                           Convert.FromBase64String(salt),
                           KeyDerivationPrf.HMACSHA256,
                           100000,
                           256 / 8);

        return Convert.ToBase64String(key);
    }
}
