using ThisProject.Enemies;
using UnityEngine;

namespace ThisProject.Waves
{
    public class WaveSpawner : MonoBehaviour
    {
        private WaveConfig _waveConfig;
        private EnemyFactory _enemyFactory;


        public WaveSpawner(WaveConfig waveConfig, EnemyFactory enemyFactory)
        {
            _waveConfig = waveConfig;
            _enemyFactory = enemyFactory;
        }

        public void Work() //todo rename
        {
            foreach (var wave in _waveConfig.Waves)
            {
                ProcessWave(wave);
            }
        }

        private void ProcessWave(Wave wave) //todo rename
        {
            //1. wait wave.DelayBefore

            //2.
            Vector2 spawnPos = wave.Position + new Vector2(wave.EnemySpacing * (wave.EnemyCount - 1) / 2, 0);
            for (int i = 0; i < wave.EnemyCount; i++)
            {
                _enemyFactory.CreateEnemy(wave.Enemy, spawnPos, wave.Target, wave.ReachSteps);
                spawnPos += new Vector2(wave.EnemySpacing, 0);
            }

            //3. wait wave.DelayAfter

            //4. repeat wave.RepeatCount
        }
    }    
}