using System;
using ThisProject.Installers;
using ThisProject.UI;
using Zenject;

namespace ThisProject.Waves
{
    public class WavePresenter : IInitializable, IDisposable
    {
        private readonly WaveUI _ui;
        private readonly SignalBus _signalBus;

        private int _currentEnemyCount;


        public WavePresenter(WaveUI ui, SignalBus signalBus)
        {
            _ui = ui;
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<WaveChangedSignal>(OnWaveChanged);
            _signalBus.Subscribe<EnemyCountChangedSignal>(OnEnemyCountChanged);

            _ui.UpdateWave(0);
            _ui.UpdateEnemyCount(0);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<WaveChangedSignal>(OnWaveChanged);
            _signalBus.Unsubscribe<EnemyCountChangedSignal>(OnEnemyCountChanged);
        }

        private void OnWaveChanged(WaveChangedSignal signal)
        {
            _ui.UpdateWave(signal.WaveNumber);
        }

        private void OnEnemyCountChanged(EnemyCountChangedSignal signal)
        {
            _currentEnemyCount += signal.Delta;

            if (_currentEnemyCount < 0) 
                _currentEnemyCount = 0;

            _ui.UpdateEnemyCount(_currentEnemyCount);
        }

    }
}
