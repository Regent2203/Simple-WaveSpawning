using ThisProject.Enemies;
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
            Container.Bind<EnemyFactory>().AsSingle();

            Container.BindMemoryPool<EnemyView, EnemyViewPool>().WithInitialSize(50).
                FromComponentInNewPrefab(_enemyViewPrefab).UnderTransform(_enemyViewContainer);
        }
    }
}