using UnityEngine;
using Zenject;

namespace ThisProject.Unsorted
{
    [CreateAssetMenu(fileName = "WavesConfig", menuName = "ThisProject/WavesConfig")]
    public class WavesConfig : ScriptableObjectInstaller<WavesConfig>
    {
        [SerializeField]
        //private List


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