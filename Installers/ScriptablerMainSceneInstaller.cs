using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "ScriptablerMainSceneInstaller", menuName = "Installers/ScriptablerMainSceneInstaller")]
public class ScriptablerMainSceneInstaller : ScriptableObjectInstaller<ScriptablerMainSceneInstaller>
{
    public GameSettings gameSettings;
    public override void InstallBindings()
    {
        Container.BindInstance(gameSettings);
    }
}