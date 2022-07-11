using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using EasyRestProjectNetTeam2.Models;

namespace EasyRestProjectNetTeam2.Helpers
{
    internal class DataReader
    {
        private string _pathToJsonFile = Directory.GetParent(@"../../../").FullName + "\\TestsData\\TestsData.json";

        public void ReadData(out DataModel dataModelObject)
        {
            string jsonFile = File.ReadAllText(_pathToJsonFile);
            dataModelObject = JsonSerializer.Deserialize<DataModel>(jsonFile);
        }

    }
}
