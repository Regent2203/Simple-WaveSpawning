using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using ThisProject.Enemies;
using ThisProject.Installers;
using UnityEngine;
using Zenject;

namespace ThisProject.Waves
{
    public class WaveSpawner : IInitializable, IDisposable
    {
        private WaveConfig _waveConfig;
        private EnemyFactory _enemyFactory;
        private readonly SignalBus _signalBus;

        private readonly CancellationTokenSource _cts = new();


        public WaveSpawner(WaveConfig waveConfig, EnemyFactory enemyFactory, SignalBus signalBus)
        {
            _waveConfig = waveConfig;
            _enemyFactory = enemyFactory;
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            WorkAsync(_cts.Token).Forget();
        }

        public void Dispose()
        {
            _cts.Cancel();
            _cts.Dispose();
        }

        private async UniTaskVoid WorkAsync(CancellationToken token)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(1));

            try
            {
                int currentWaveNumber = 1;
                foreach (var wave in _waveConfig.Waves)
                {
                    _signalBus.Fire(new WaveChangedSignal { WaveNumber = currentWaveNumber });

                    await ProcessWaveAsync(wave, token);

                    currentWaveNumber++;
                }
                Debug.Log("Waves spawn has been finished successfully.");
            }
            catch (OperationCanceledException)
            {
                Debug.Log("Waves spawn has been cancelled.");
            }
        }

        private async UniTask ProcessWaveAsync(Wave wave, CancellationToken token)
        {
            //1. wait wave.DelayBefore
            if (wave.DelayBefore > 0)
            {
                await UniTask.Delay(TimeSpan.FromSeconds(wave.DelayBefore), cancellationToken: token);
            }

            int repeats = 1 + wave.RepeatCount;

            for (int r = 0; r < repeats; r++)
            {
                //2. spawn enemies in horizontal line (for simplicity)
                Vector2 spawnPos = wave.Position - new Vector2(wave.EnemySpacing * (wave.EnemyCount - 1) / 2f, 0);
                for (int i = 0; i < wave.EnemyCount; i++)
                {
                    _enemyFactory.CreateEnemy(wave.Enemy, spawnPos, wave.Target, wave.ReachSteps);
                    _signalBus.Fire(new EnemyCountChangedSignal { Delta = 1 });
                    spawnPos += new Vector2(wave.EnemySpacing, 0);
                }

                //3. wait wave.RepeatCount after each repeat expect final!
                if (wave.DelayRepeat > 0 && r < repeats - 1)
                {
                    await UniTask.Delay(TimeSpan.FromSeconds(wave.DelayRepeat), cancellationToken: token);
                }
            }

            //4. wait wave.DelayAfter
            if (wave.DelayAfter > 0)
            {
                await UniTask.Delay(TimeSpan.FromSeconds(wave.DelayAfter), cancellationToken: token);
            }
        }
    }    
}