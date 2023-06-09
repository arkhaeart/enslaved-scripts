﻿using System.IO;
using UnityEngine;

namespace Persistence.Systems
{
    public partial class DataHandler
    {
        private class SyncReader
        {
            public static string ReadFromSample(string path)
            {
                TextAsset ass = (TextAsset)Resources.Load(path, typeof(TextAsset));
                if (ass == null)
                    return "{}";
                return ass.text;
            }
            public static T Read<T>(T type=default(T))
            {
                
                if (info.dataPaths.ContainsKey(typeof(T)))
                {
                    using StreamReader sr = new StreamReader(Path.Combine(persistentPath, info.dataPaths[typeof(T)]));
                    string json = sr.ReadToEnd();
                    Debug.Log(json);
                    return JsonUtility.FromJson<T>(json);
                }
                else return default;
            }
        }
        static class SyncWriter
        {
            [System.Obsolete("sync write is no longer supported and developed, please use async write")]

            public static void CreateDefaultDataFile(System.Type type)
            {
                string sample = SyncReader.ReadFromSample(info.jsonResourcesPaths[type]);
                string path = info.dataPaths[type];
                using (FileStream fs = File.Create(Path.Combine(persistentPath, path)))
                {

                }
                using (StreamWriter sw = new StreamWriter(Path.Combine(persistentPath, path)))
                {
                    sw.Write(sample);
                }
            }
            [System.Obsolete("sync write is no longer supported and developed, please use async write")]
            public static void RewriteDataFile<T>(string path, T data)
            {
                string dataInJson = JsonUtility.ToJson(data);

                using StreamWriter sw = new StreamWriter(Path.Combine(persistentPath, path), false);
                sw.Write(dataInJson);
            }
        }

    }
}
