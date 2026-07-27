using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;
using UnityEngine;
using Zenject;

namespace ThisProject.Waves
{
    [CreateAssetMenu(fileName = "WavesConfig", menuName = "ThisProject/WavesConfig")]
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

    /*
    wave settings:
    1) number of waves
    2) delay between waves

    3) number of enemyes
    4) enemy type
    5) delay...
    */
}