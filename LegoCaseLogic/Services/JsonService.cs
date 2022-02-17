using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace LegoCaseLogic.Services
{
    public class JsonService
    {
        public T JSONToObjList<T>(string jsonPath)
        {
            string jsonString = ReadJsonData(jsonPath);

            if (string.IsNullOrEmpty(jsonString))
                return default(T);
            return JsonSerializer.Deserialize<T>(jsonString);
        }

        private string ReadJsonData(string jsonPath)
        {
            return File.ReadAllText(jsonPath);
        }
    }
}
