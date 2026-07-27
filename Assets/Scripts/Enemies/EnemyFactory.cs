using UnityEngine;

namespace ThisProject.Enemies
{
    public class EnemyFactory
    {
        private int _newId = 0;

        private EnemyViewPool _enemyPool;


        public EnemyFactory(EnemyViewPool enemyPool)
        {
            _enemyPool = enemyPool;
        }

        public EnemyView CreateEnemy(EnemyType enemyType, Vector2 startPos, Vector2 endPos, int steps)
        {
            var id = _newId++;

            var enemyView = _enemyPool.Spawn(id, enemyType, startPos, endPos, steps);

            return enemyView;
        }
    }
}
