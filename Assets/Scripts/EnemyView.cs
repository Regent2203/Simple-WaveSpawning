using UnityEngine;
using Zenject;

namespace ThisProject.Unsorted
{
    public class EnemyView : MonoBehaviour, IPoolable<int, Vector2, Vector2, int>
    {
        [SerializeField]
        private SpriteRenderer _spriteRenderer;

        private int _id;
        private Vector2 _speed;


        public virtual void OnSpawned(int id, Vector2 startPos, Vector2 endPos, int steps)
        {
            _id = id;
            _speed = (endPos - startPos) / steps;
            //todo dotween

            gameObject.SetActive(true);
        }

        public virtual void OnDespawned()
        {
            _id = 0;
            _speed = Vector2.zero;

            gameObject.SetActive(false);
        }

        private void Reset()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }
}