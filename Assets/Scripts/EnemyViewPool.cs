using UnityEngine;
using Zenject;

namespace ThisProject.Unsorted
{
    public class EnemyViewPool : MonoPoolableMemoryPool<int, Vector2, Vector2, int, EnemyView>
    {
    }
}