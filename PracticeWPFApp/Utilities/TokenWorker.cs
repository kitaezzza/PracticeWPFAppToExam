using PracticeWPFApp.DB;
using PracticeWPFApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeWPFApp.Utilities
{
    public class TokenWorker
    {
        //Добавить токен
        public static void AddToken(string addtoken)
        {
            using TokenContext db = new();

            Tokens token = new()
            {
                Value = addtoken
            };
            db.Tokens.Add(token);
            db.SaveChanges();
        }
        //Проверить токен
        public static string ValidToken(string validtoken)
        {
            using TokenContext db = new();

            var token = db.Tokens.FirstOrDefault(t => t.Value == validtoken);
            if (token == null)
                return null!;
            return token.Value;
        }
    }
}
