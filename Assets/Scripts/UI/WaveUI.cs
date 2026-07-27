using UnityEngine;
using UnityEngine.UI;

namespace ThisProject.UI
{
    public class WaveUI : MonoBehaviour
    {
        [SerializeField]
        private Text _waveText;
        [SerializeField]
        private Text _enemiesText;

        public void UpdateWave(int waveNumber)
        {
            _waveText.text = $"Wave: {waveNumber}";
        }

        public void UpdateEnemyCount(int count)
        {
            _enemiesText.text = $"Enemies: {count}";
        }
    }
}