using System;
using System.IO;
using System.Text.Json;
using EasyRestProjectNetTeam2.Models;

namespace EasyRestProjectNetTeam2.Helpers
{
    internal class DataReader
    {
        private string _winPathToJsonFile = Directory.GetParent(@"../../../").FullName + "\\TestsData\\TestsData.json";
        private string _macPathToJsonFile = Directory.GetParent(@"../../../").FullName+ "/TestsData/TestsData.json";

        public DataModel ReadData()
        {
            OperatingSystem os = Environment.OSVersion;
            string jsonFile;
            
            if (os.Platform.ToString().Equals("Win32NT"))
            {
                jsonFile = File.ReadAllText(_winPathToJsonFile);
            }
            else
            {
                jsonFile = File.ReadAllText(_macPathToJsonFile);
            }
            DataModel dataModelObject = JsonSerializer.Deserialize<DataModel>(jsonFile);
            return dataModelObject;
        }
    }
}
