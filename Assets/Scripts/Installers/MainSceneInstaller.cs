using ThisProject.Enemies;
using ThisProject.Waves;
using UnityEngine;
using Zenject;

namespace ThisProject.Installers
{
    public class MainSceneInstaller : MonoInstaller
    {
        [SerializeField]
        private EnemyView _enemyViewPrefab;
        [SerializeField]
        private Transform _enemyViewContainer;


        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<WaveSpawner>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<EnemyFactory>().AsSingle();

            Container.BindMemoryPool<EnemyView, EnemyViewPool>().WithInitialSize(10).
                FromComponentInNewPrefab(_enemyViewPrefab).UnderTransform(_enemyViewContainer);
        }
    }
}