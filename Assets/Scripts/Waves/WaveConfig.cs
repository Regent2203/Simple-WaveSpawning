using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ThisProject.Waves
{
    [CreateAssetMenu(fileName = "WaveConfig", menuName = "ThisProject/WaveConfig")]
    public class WaveConfig : ScriptableObjectInstaller<WaveConfig>
    {
        [SerializeField]
        private List<Wave> _waves;

        public IReadOnlyList<Wave> Waves => _waves;


        public override void InstallBindings()
        {
            Container.BindInstance(this).AsSingle();
        }
    }
}