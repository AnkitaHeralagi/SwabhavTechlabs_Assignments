using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace AccountApp_Serialization_Deserialization
{
    internal class FileHandler
    {
        private string path = "account.json";

        public void Save(Account acc)
        {
            string json = JsonSerializer.Serialize(acc, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, json);
        }

        public Account Load()
        {
            if (!File.Exists(path))
                return null;

            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<Account>(json);
        }
    }
}
