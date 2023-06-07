using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace Persistence.Systems
{
    [CreateAssetMenu(menuName = "Configs/DataClasses",fileName ="DataClassesConfig")]
    public class DataClassesConfig : ScriptableObject, IDropDownFiller
    {
        const string folderPath1 = "Assets/";
        const string folderPath2 = "Resources";
        public string assembly;
        public string namespaceName = "Persistence";
        public List<DataPair> dataPairs = new List<DataPair>();
        public string saveFilesExtension = ".sav";
        const string sampleFilesExtension = ".asset";
        public string sampleFilesFolder = "Samples";
        [Sirenix.OdinInspector.ValueDropdown("GetCiphers")]
        public string cipherStrategy;
        [Sirenix.OdinInspector.ValueDropdown("GetCiphers")]
        public string pathCipherStrategy;
#if(UNITY_EDITOR)
        public List<string> GetCiphers()
        {
            System.Type[] types = NamespaceClassesUtility.GetTypesByInterface<ICipherStrategy>();
            string[] entries = new string[types.Length];
            for (int i = 0; i < types.Length; i++)
            {
 
                entries[i] = types[i].AssemblyQualifiedName;
            }
            return entries.ToList();
        }
        
        public string[] GetEntries()
         {
             
             System.Type[] types = NamespaceClassesUtility.GetTypesWithAttribute<SaveableDataAttribute>();
             string[] entries = new string[types.Length];
             for (int i = 0; i < types.Length; i++)
             {
 
                 entries[i] = types[i].AssemblyQualifiedName;
             }
             return entries;
         }
        public void CreateSampleFiles()
        {
            if (UnityEditor.AssetDatabase.IsValidFolder(folderPath1 + folderPath2 + "/"+sampleFilesFolder))
            {
                UnityEditor.AssetDatabase.DeleteAsset(folderPath1 + folderPath2 + "/" + sampleFilesFolder);
            }
            UnityEditor.AssetDatabase.CreateFolder(folderPath1+folderPath2, sampleFilesFolder);
            foreach (var dataPair in dataPairs)
            {
                if(dataPair.createSampleFile)
                {
                    System.Type type = System.Type.GetType(dataPair.classType);
                    var emptyObject = System.Activator.CreateInstance(type);
                    string sampleString = JsonUtility.ToJson(emptyObject);
                    UnityEditor.AssetDatabase.CreateAsset(new TextAsset(sampleString),
                        folderPath1 + folderPath2 + "/" + sampleFilesFolder + "/" + dataPair.saveFileName +
                        sampleFilesExtension);
                }
            }
        }
#endif
        [System.Serializable]
        public class DataPair
        {
            [StringDropDown(path = "Configs/DataClassesConfig")]
            public string classType;
            public string saveFileName;
            public bool createSampleFile;
        }
    }
}