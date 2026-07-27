using ThisProject.Unsorted;
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
            Container.BindMemoryPool<EnemyView, EnemyViewPool>().WithInitialSize(100).
                FromComponentInNewPrefab(_enemyViewPrefab).UnderTransform(_enemyViewContainer);
        }
    }
}