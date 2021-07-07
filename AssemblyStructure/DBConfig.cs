﻿using Newtonsoft.Json;
using System;
using System.IO;

namespace AssemblyStructure
{
    public class DBConfig
    {
        public string Name { get; set; } = "TravelDB";
        public string Source { get; set; } = "localhost";
        public string Catalog { get; set; } = "TravelDB";
        public string User { get; set; } = "sa";
        public string Password { get; set; } = "sa";

        public string GetStringConnection()
        {
            //string pathDBConfig = Path.Combine("DBConfig.json");
            //if (!File.Exists(pathDBConfig))
            //    throw new Exception($"La configuracion de base de datos no existe. | {pathDBConfig}");
            //DBConfig db = JsonConvert.DeserializeObject<DBConfig>(File.ReadAllText(pathDBConfig));
            return @$"Data Source={this.Source};Initial Catalog={this.Catalog};User ID={this.User};Password={this.Password};Application Name={this.Name}";
        }

    }
}
