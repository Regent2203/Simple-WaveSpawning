using DG.Tweening;
using ThisProject.Installers;
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
        private SignalBus _signalBus;

        const string _emptyName = "Enemy";


        [Inject]
        public void Construct(EnemyViewPool pool, SignalBus signalBus)
        {
            _pool = pool;
            _signalBus = signalBus;
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
            _signalBus.Fire(new EnemyCountChangedSignal { Delta = -1 });
            _pool.Despawn(this);
        }

        private void Reset()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }
}