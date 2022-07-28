using System;
using System.IO;
using System.Text.Json;
using EasyRestProjectNetTeam2.Models;

namespace EasyRestProjectNetTeam2.Helpers
{
    internal class DataReader
    {
        private readonly string _winPathToTestDataJsonFile = Directory.GetParent(@"../../../").FullName + "\\TestsData\\TestsData.json";
        private readonly string _macPathToTestDataJsonFile = Directory.GetParent(@"../../../").FullName+ "/TestsData/TestsData.json";
        private readonly string _winPathToQueryDataJsonFile = Directory.GetParent(@"../../../").FullName + "\\TestsData\\QueryData.json";
        private readonly string _macPathToQueryDataJsonFile = Directory.GetParent(@"../../../").FullName + "/TestsData/QueryData.json";

        public DataModel ReadDataFromTestData()
        {
            OperatingSystem os = Environment.OSVersion;
            string jsonFile;
            
            if (os.Platform.ToString().Equals("Win32NT"))
            {
                jsonFile = File.ReadAllText(_winPathToTestDataJsonFile);
            }
            else
            {
                jsonFile = File.ReadAllText(_macPathToTestDataJsonFile);
            }
            DataModel dataModelObject = JsonSerializer.Deserialize<DataModel>(jsonFile);
            return dataModelObject;
        }

        public QueryDataModel ReadDataFromQueryData()
        {
            OperatingSystem os = Environment.OSVersion;
            string jsonFile;

            if (os.Platform.ToString().Equals("Win32NT"))
            {
                jsonFile = File.ReadAllText(_winPathToQueryDataJsonFile);
            }
            else
            {
                jsonFile = File.ReadAllText(_macPathToQueryDataJsonFile);
            }
            QueryDataModel queryDataModelObject = JsonSerializer.Deserialize<QueryDataModel>(jsonFile);
            return queryDataModelObject;
        }
    }
}
