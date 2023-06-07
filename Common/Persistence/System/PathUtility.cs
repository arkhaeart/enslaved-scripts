using System.IO;

namespace Persistence.Systems
{
    public partial class DataHandler
    {
        private class PathUtility
        {
            public static string GetPath<T>()
            {
                return Path.Combine(persistentPath, $"{info.dataPaths[typeof(T)]}");
            }

            public static string GetPath(System.Type type)
            {
                return Path.Combine(persistentPath, $"{info.dataPaths[type]}");
            }
            public static string GetPath<T>(string name)
            {
                return Path.Combine(persistentPath, $"{info.dataPaths[typeof(T)]}_{name}");
            }
        }
    }
}