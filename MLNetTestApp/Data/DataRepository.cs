using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.ML;
using Microsoft.ML.Data;

namespace MLNetTestApp.Data
{
    public static class DataRepository
    {
        public static readonly string IrisDataFilePath = Path.Combine(Directory.GetCurrentDirectory(), @"Data\iris-data.csv");
        public static readonly string SumsDataFilePath = Path.Combine(Directory.GetCurrentDirectory(), @"Data\sums-data.csv");
        
        public static string GetIrisDataRaw() => File.ReadAllText(IrisDataFilePath);
        public static IDataView GetIrisDataView(TextLoader textLoader) => textLoader.Load(IrisDataFilePath);
        
        public static string GetSumsDataRaw() => File.ReadAllText(SumsDataFilePath);
        public static IDataView GetSumsDataView(TextLoader textLoader) => textLoader.Load(SumsDataFilePath);
    }
}