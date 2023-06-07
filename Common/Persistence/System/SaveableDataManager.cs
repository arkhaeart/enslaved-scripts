// using System.Collections;
// using System.Collections.Generic;
// using _Car_Parking.Scripts.Persistence.Migration;
// using CPM.Common;
// using Cysharp.Threading.Tasks;
// using Zenject;
//
// namespace Persistence.Systems
// {
//     public class SaveableDataManager
//     {
//         private readonly RuntimePlayerDataHandler runtimePlayerDataHandler;
//         private readonly EasySaveRuntimeDataHandler es3DataHandler;
//         private readonly VersionedDataClassesConfig dataClassesConfig;
//         
//         private MigrationManager migrationManager;
//         [Inject]
//         public SaveableDataManager(RuntimePlayerDataHandler runtimePlayerDataHandler,
//             EasySaveRuntimeDataHandler es3DataHandler,
//             VersionedDataClassesConfig dataClassesConfig,
//             MigrationManager migrationManager)
//         {
//             this.es3DataHandler = es3DataHandler;
//             this.dataClassesConfig = dataClassesConfig;
//             this.runtimePlayerDataHandler=runtimePlayerDataHandler;
//             this.migrationManager = migrationManager;
//         }
//         public async UniTask ProcessLocalSaves()
//         {
//             var versionsStorage=await runtimePlayerDataHandler.GetDataObject<DataClassesVersionStorage>();
//                      versionsStorage.Initialize();
//             var entriesForMigration = await ProcessDataClassesVersions(versionsStorage);
//             foreach (var pair in entriesForMigration)
//             {
//                 System.Type from = System.Type.GetType(pair.Key.saveableType);
//                 System.Type to = System.Type.GetType(pair.Value.saveableType);
//                 var newData=migrationManager.MigrateData(from,to);
//             }
//         }
//         public async UniTask ProcessRemoteSaves()
//         {
//             var versionsStorage = await dataVersionService.GetDataVersions();
//             var entriesForMigration=await ProcessDataClassesVersions(versionsStorage);
//         }
//         
//     }
// }