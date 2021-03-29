using UnityEngine;
using Zenject;

namespace DI_Contexts.Scene_Context
{
    public class LocationInstaller : MonoInstaller
    {
        public Transform PlayerSpawnPoint;
        public GameObject PlayerPrefab;
        
        public override void InstallBindings()
        {
            BindPlayer();
        }

        private void BindPlayer()
        {
            var playerBehavior = Container
                .InstantiatePrefabForComponent<PlayerMoveBehaviour>(PlayerPrefab, PlayerSpawnPoint.position,
                    Quaternion.identity, null);
            
            Container.Bind<PlayerMoveBehaviour>()
                .FromInstance(playerBehavior)
                .AsSingle();
        }
    }
}