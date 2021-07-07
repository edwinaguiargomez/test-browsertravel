using Newtonsoft.Json;
using System;
using System.IO;

namespace Entities.Infrastructure
{
    public class DBConfig
    {
        public string Name { get; set; }
        public string Source { get; set; }
        public string Catalog { get; set; }
        public string User { get; set; }
        public string Password { get; set; }

        public string GetStringConnection()
        {
            string pathDBConfig = Path.Combine("DBConfig.json");
            if (!File.Exists(pathDBConfig))
                throw new Exception("La configuracion de base de datos no existe.");
            DBConfig db = JsonConvert.DeserializeObject<DBConfig>(File.ReadAllText(pathDBConfig));
            return @$"Data Source={db.Source};Initial Catalog={db.Catalog};User ID={db.User};Password={db.Password};Application Name={db.Name}";
        }

    }
}
