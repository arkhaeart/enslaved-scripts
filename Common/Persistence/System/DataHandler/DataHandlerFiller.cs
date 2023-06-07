using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Persistence.Systems
{
    public class DataHandlerFiller
    {
        
        private DataHandlerInfo info;
        private ICipherStrategy cipherStrategy;
        private ICipherStrategy pathCipherStrategy;
        public DataHandlerFiller(DataClassesConfig config,ICipherStrategy cipherStrategy,ICipherStrategy pathCipherStrategy)
        {
            this.cipherStrategy = cipherStrategy;
            info = new DataHandlerInfo();
            FillDataPathsDict(config);
            FillResourcesPathsDict(config);
        }
        public DataHandlerInfo GetDataHandlerInfo()
        {
            return info;
        }
        void FillDataPathsDict(DataClassesConfig config)
        {
            info.dataPaths = new Dictionary<System.Type, string>();
            foreach(var pair in config.dataPairs)
            {
                info.dataPaths.TryAdd(System.Type.GetType(pair.classType), 
                    $"{cipherStrategy.Encode(pair.saveFileName)}{config.saveFilesExtension}");
            }
        }
        void FillResourcesPathsDict(DataClassesConfig config)
        {
            info.jsonResourcesPaths = new Dictionary<System.Type, string>();
            foreach (var pair in config.dataPairs)
            {
                info.jsonResourcesPaths.TryAdd(System.Type.GetType(pair.classType),
                    $"{config.sampleFilesFolder}/{pair.saveFileName}");
            }
        }
    }
    public class DataHandlerInfo
    {
        public Dictionary<System.Type, string> dataPaths;
        public Dictionary<System.Type, string> jsonResourcesPaths;
    }
}