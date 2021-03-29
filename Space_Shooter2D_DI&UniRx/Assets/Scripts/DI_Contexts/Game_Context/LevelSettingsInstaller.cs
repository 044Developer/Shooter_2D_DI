using System.Collections.Generic;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "LevelSettingsInstaller", menuName = "Installers/LevelSettingsInstaller")]
public class LevelSettingsInstaller : ScriptableObjectInstaller<LevelSettingsInstaller>
{
    public List<LevelSettingsData> LevelSettings;
    public override void InstallBindings()
    {
        BindLevelSettings();
    }

    private void BindLevelSettings()
    {
        Container.BindInstance(LevelSettings).AsSingle().NonLazy();
    }
}