using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ThisProject.Enemies
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "ThisProject/EnemyConfig")]
    public class EnemyConfig : ScriptableObjectInstaller<EnemyConfig>
    {
        [SerializeField]
        private List<EnemyType> _enemyTypes;
    }
}