using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Zenject;

namespace Persistence.Systems
{
    public class RuntimePlayerDataHandler
    {
        
        private DataClassesConfig dataClassesConfig;
        
        [Inject]
        public RuntimePlayerDataHandler(DataClassesConfig dataClassesConfig)
        {
            this.dataClassesConfig = dataClassesConfig;
            
        }
        public async UniTask Start() 
        {
            await DataHandler.Init(dataClassesConfig);
        }

        public void ClearAllData()
        {
            DataHandler.ClearAllData();
        }
        public void SetAccountID(string accountID)
        {
            DataHandler.AccountID = accountID;
        }


        
        public async UniTask<T> GetDataObject<T>(string name) 
        {
            var dataObject= await DataHandler.GetDataAsync<T>(name);
            return dataObject;

        }
        
        public async UniTask<T> GetDataObject<T>() 
        {
            var dataObject= await DataHandler.GetDataAsync<T>();
            return dataObject;

        }

        public async UniTask<bool> SaveDataObject<T>(T data, string subPath)
        {
            return await DataHandler.SaveNewDataInFileAsync(data, subPath);
        }
        public async UniTask<bool> SaveDataObject<T>(T data) 
        {
            return await DataHandler.SaveNewDataInFileAsync(data);
        }
    }
}

