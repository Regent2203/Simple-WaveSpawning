using ThisProject.Enemies;
using UnityEngine;

namespace ThisProject.Waves
{
    public struct Wave
    {
        public float DelayBefore;
        public EnemyType Enemy;
        public int EnemyCount;
        public float EnemySpacing;
        public Vector2 Position;
        public Vector2 Target;
        public int ReachSteps;
        public float DelayAfter;
        public int RepeatCount;
    }
}
