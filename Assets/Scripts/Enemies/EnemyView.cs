using DG.Tweening;
using UnityEngine;
using Zenject;

namespace ThisProject.Enemies
{
    public class EnemyView : MonoBehaviour, IPoolable<int, EnemyType, Vector2, Vector2, int>
    {
        [SerializeField]
        private SpriteRenderer _spriteRenderer;

        private int _id;
        private EnemyType _enemyType;

        private Tween _moveTween;
        private EnemyViewPool _pool;

        const string _emptyName = "Enemy";


        [Inject]
        public void Construct(EnemyViewPool pool)
        {
            _pool = pool;
        }
        
        public virtual void OnSpawned(int id, EnemyType enemyType, Vector2 startPos, Vector2 endPos, int steps)
        {
            _id = id;
            transform.position = startPos;            

            SetType(enemyType);
            SetTarget(endPos, steps);

            gameObject.SetActive(true);
        }

        public virtual void OnDespawned()
        {
            _moveTween?.Kill();
            _moveTween = null;

            _id = 0;
            transform.position = Vector2.zero;
            gameObject.name = _emptyName;
            _enemyType = null;

            gameObject.SetActive(false);
        }

        public void SetType(EnemyType enemyType)
        {
            _enemyType = enemyType;

            _spriteRenderer.sprite = enemyType.Sprite;
            gameObject.name = $"{enemyType.Name}_{_id}";
        }

        public void SetTarget(Vector2 endPos, int steps)
        {
            _moveTween = transform.DOMove(endPos, steps).OnComplete(OnTargetReached);
        }

        private void OnTargetReached()
        {
            //some animation?
            //Debug.Log($"{name} has reached target.");

            _pool.Despawn(this);
        }

        private void Reset()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }
}