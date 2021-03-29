using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "PlayerSettings", menuName = "Installers/PlayerSettings")]
public class PlayerSettingsInstaller : ScriptableObjectInstaller<PlayerSettingsInstaller>
{
    public PlayerMoveData PlayerMoveSettings;
    public PlayerShootData PlayerShootSettings;
    public PlayerHealthData PlayerHealthSettings;
    public PlayerProgressData PlayerProgressSettings;
    
    public override void InstallBindings()
    {
        BindMoveSettings();
        BindShootSettings();
        BindHealthSettings();
        BindProgressSettings();
    }

    private void BindMoveSettings()
    {
        Container.BindInstance(PlayerMoveSettings).AsSingle().NonLazy();
    }

    private void BindShootSettings()
    {
        Container.BindInstance(PlayerShootSettings).AsSingle().NonLazy();
    }

    private void BindHealthSettings()
    {
        Container.BindInstance(PlayerHealthSettings).AsSingle().NonLazy();
    }

    private void BindProgressSettings()
    {
        Container.BindInstance(PlayerProgressSettings).AsSingle().NonLazy();
    }
}