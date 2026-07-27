using UnityEngine;
using Zenject;

namespace ThisProject.Enemies
{
    public class EnemyViewPool : MonoPoolableMemoryPool<int, EnemyType, Vector2, Vector2, int, EnemyView>
    {
    }
}