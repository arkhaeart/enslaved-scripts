using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.IO;
using System;
using System.Threading;
using Cysharp.Threading.Tasks;

//using CodeStage.AntiCheat.ObscuredTypes;

namespace Persistence.Systems
{
    public enum FileExistenceState
    {
        NotExists,
        Exists,
        TempExists
    }
    public partial class DataHandler
    {
        class AsyncReader
        {
            // public static async UniTask<T> ReadAsync<T>(bool useTemp=false)
            // {
            //     try
            //     {
            //         if (info.dataPaths.ContainsKey(typeof(T)))
            //         {
            //             using (StreamReader sr = new StreamReader(PathUtility.GetPath<T>()))
            //             {
            //                 string json = await sr.ReadToEndAsync();
            //                 return JsonUtility.FromJson<T>(cipherStrategy.Decode(json));
            //             }
            //         }
            //         else return default;
            //     }
            //     catch (System.Exception e)
            //     {
            //         Debug.LogError(e);
            //         return default;
            //     }
            // }

            public static FileExistenceState FileExists<T>(string name)
            {
                string path = PathUtility.GetPath<T>(name);
                return GetFileExistenceState<T>(path);
            }

            private static FileExistenceState GetFileExistenceState<T>(string path)
            {
                if (File.Exists($"{path}_temp"))
                    return FileExistenceState.TempExists;
                return File.Exists(path) ? FileExistenceState.Exists : FileExistenceState.NotExists;
            }

            public static FileExistenceState FileExists<T>()
            {
                string path = PathUtility.GetPath<T>();
                return GetFileExistenceState<T>(path);
            }
            public static async UniTask<T> ReadAsync<T>(string path,bool useTemp=false)
            {
                try
                {
                    if (info.dataPaths.ContainsKey(typeof(T)))
                    {
                        using (StreamReader sr=new StreamReader(path))
                        {
                            string json = await sr.ReadToEndAsync();
                            return JsonUtility.FromJson<T>(cipherStrategy.Decode(json));
                        
                        }
                    
                    }
                    else
                    {
                        return default;
                    }
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                    return default;
                }
            }
            //public static IEnumerator ReadFromSampleAsync(string path,System.Action<string> callback)
            //{
            //    var req = UnityWebRequest.Get(Path.Combine(constPath, path));
            //    Debug.Log("Request send");
            //    yield return req.SendWebRequest();


            //    callback?.Invoke( req.downloadHandler.text);
            //}
        }
        static class AsyncWriter
        {
            public static async UniTask CreateDefaultDataFile(System.Type type)
            {
                string sample = SyncReader.ReadFromSample(info.jsonResourcesPaths[type]);
                string path = PathUtility.GetPath(type);
                using (FileStream fs = File.Create(path))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        await sw.WriteAsync(cipherStrategy.Encode(sample));
                    }
                }
            }
            // public static async UniTask<bool> WriteAsync<T>(T data)
            // {
            //     try
            //     {
            //         string json = JsonUtility.ToJson(data);
            //         string path = PathUtility.GetPath<T>();
            //         using (StreamWriter sw = new StreamWriter(path))
            //         {
            //             await sw.WriteAsync(_cipherStrategy.Encode(json));
            //         }
            //
            //         return true;
            //     }
            //     catch (Exception e)
            //     {
            //         Debug.LogError(e);
            //         return false;
            //     }
            //
            // }
            public static async UniTask<bool> WriteAsync(WriteData writeData)
            {
                try
                {
                    using (var fs = File.Create(writeData.path))
                    {
                        using (var sw = new StreamWriter(fs))
                        {
                            await sw.WriteAsync(cipherStrategy.Encode(writeData.json));
                        }
                    }
                    return true;
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                    return false;
                }
            }

            // public static async UniTask<bool> WriteInNewFileAsync(WriteData writeData)
            // {
            //     try
            //     {
            //         using (var fs = File.Create(writeData.path))
            //         {
            //             using (var sw = new StreamWriter(fs))
            //             {
            //                 await sw.WriteAsync(cipherStrategy.Encode(writeData.json));
            //             }
            //         }
            //         return true;
            //     }
            //     catch (Exception e)
            //     {
            //         Debug.LogError(e);
            //         return false;
            //     }
            // }
        }
    }
}
