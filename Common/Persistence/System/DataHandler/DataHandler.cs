using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using System.IO;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace Persistence.Systems
{
    public struct WriteData
    {
        public string path;
        public string json;

        public WriteData(string json, string path)
        {
            this.json = json;
            this.path = path;
        }
    }
     public static partial class DataHandler
    {
        private static string persistentPath;
        private static string namePrefix = "_";
        private static DataHandlerInfo info;
        private static string accountID;
        private static ICipherStrategy cipherStrategy;
        private static ICipherStrategy pathCipherStrategy;
        public static string AccountID
        {
            private get => accountID;
            set
            {
                accountID = cipherStrategy.Encode(value);
            }
        }

        public static async UniTask Init(DataClassesConfig config)
        {
            SetCipherStrategies(config);
            var filler = new DataHandlerFiller(config,cipherStrategy,pathCipherStrategy);
            info = filler.GetDataHandlerInfo();


            Debug.Log("Data Handler static initialization running");
            persistentPath = Path.Combine(Application.persistentDataPath, "49183427851348", "487491837413");


            await InitDirectoryAndFilesAsync();
            Debug.Log("Initialization finished");
            
        }

        private static void SetCipherStrategies(DataClassesConfig config)
        {
            System.Type cipherStrategyType = System.Type.GetType(config.cipherStrategy);
            if (cipherStrategyType == null)
            {
                Debug.LogError($"Could not get cipher strategy type from string {config.cipherStrategy}");
                cipherStrategy = new NoCipherStrategy();
            }
            else
            {
                cipherStrategy = (ICipherStrategy)System.Activator.CreateInstance(cipherStrategyType);
            }

            System.Type pathCipherStrategyType = System.Type.GetType(config.pathCipherStrategy);
            if (pathCipherStrategyType == null)
            {
                Debug.LogError($"Could not get cipher strategy type from string {config.pathCipherStrategy}");
                pathCipherStrategy = new NoCipherStrategy();
            }
            else
            {
                pathCipherStrategy = (ICipherStrategy)System.Activator.CreateInstance(pathCipherStrategyType);
            }
        }

        static async UniTask InitDirectoryAndFilesAsync()
        {
            if(!Directory.Exists(persistentPath))
            {
                Directory.CreateDirectory(persistentPath);
            }
            foreach(var pair in info.dataPaths)
            {
                string combined = Path.Combine(persistentPath, pair.Value);
                if (!File.Exists(combined))
                {
                    await AsyncWriter.CreateDefaultDataFile(pair.Key);
                }
            }
        }
        public static FileExistenceState GetFileExistence<T>(string name)
        {
            return AsyncReader.FileExists<T>(name);
        }

        public static void ClearAllData()
        {
            string[] files = Directory.GetFiles(persistentPath);
            foreach (var file in files)
            {
                File.Delete(file);
            }
        }
        public static FileExistenceState GetFileExistence<T>()
        {
            return AsyncReader.FileExists<T>();
        }
        // public static void SaveNewDataInFileSync<T>(T data)
        // {
        //     Debug.Log($"Saving {data} of type {typeof(T)} synchronously");
        //     SyncWriter.RewriteDataFile(info.dataPaths[typeof(T)], data);
        // }
        public static async UniTask<bool> SaveNewDataInFileAsync<T>(T data)
        {
            string json = JsonUtility.ToJson(data);
            string path = PathUtility.GetPath<T>();
            string tempPath = $"{path}_temp";
            Debug.Log($"Saving {data} of type {typeof(T)} asynchronously");
            var writeResult= await AsyncWriter.WriteAsync(new WriteData(json, tempPath));
            if (writeResult)
            {
                if(File.Exists(path))
                    File.Delete(path);
                File.Move(tempPath,path);
            }
            return writeResult;
        }

        public static async UniTask<bool> SaveNewDataInFileAsync<T>(T data, string subPath)
        {
            string json = JsonUtility.ToJson(data);
            string path = PathUtility.GetPath<T>(subPath);
            string tempPath = $"{path}_temp";
            Debug.Log($"Saving {data} of type {typeof(T)} asynchronously");
            bool writeResult= await AsyncWriter.WriteAsync(new WriteData(json, tempPath));
            if (writeResult)
            {
                if(File.Exists(path))
                    File.Delete(path);
                File.Move(tempPath,path);
            }

            return writeResult;
        }
        
        
        public static async UniTask<T> GetDataAsync<T>()
        {
            var fileExistence = GetFileExistence<T>();
            if (fileExistence == FileExistenceState.NotExists)
                return default;
            string path = PathUtility.GetPath<T>();
            return await AsyncReader.ReadAsync<T>(path,fileExistence== FileExistenceState.TempExists);
        }
        public static async UniTask<T> GetDataAsync<T>(string subPath)
        {
            var fileExistence = GetFileExistence<T>(subPath);
            if (fileExistence == FileExistenceState.NotExists)
                return default;
            string path = PathUtility.GetPath<T>(subPath);
            return await AsyncReader.ReadAsync<T>(path,fileExistence== FileExistenceState.TempExists);
        }
        public static T GetDataSync<T>(T type=default(T))
        {
            return SyncReader.Read<T>();
        }
    }
}