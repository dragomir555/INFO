using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Autopraonica_Markus.Model.Entities;

namespace Autopraonica_Markus.services
{
    class UserService
    {
        private static Random random = new Random();

        private static string GetString()
        {
            const string characters = "abcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(characters, 8).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string GenerateSalt()
        {
            return GetString();
        }

        public static string GeneratePassword()
        {
            return GetString();
        }

        public static string GenerateUsername(string firstName, string lastName)
        {
            using (MarkusDb context = new MarkusDb()) {
                var employments = (from c in context.employments select c).ToList();
                var usernames = new List<string>();
                foreach(var e in employments)
                {
                    usernames.Add(e.UserName);
                }
                if(!usernames.Contains(firstName + "." + lastName))
                {
                    return firstName + "." + lastName;
                }
                else
                {
                    int i = 1;
                    while(true)
                    {
                        if (!usernames.Contains(firstName + "." + lastName))
                        {
                            return firstName + "." + lastName + i;
                        }
                        i++;
                    }
                }
            }
        }

        private static byte[] GetHash(string password)
        {
            HashAlgorithm algorithm = SHA256.Create();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        private static string GetEncodedHash(byte[] hash)
        {
            return System.Convert.ToBase64String(hash);
        }

        public static string GetPasswordHash(string salt, string password)
        {
            string s = salt + password;
            return GetEncodedHash(GetHash(s));
        }
    }
}
