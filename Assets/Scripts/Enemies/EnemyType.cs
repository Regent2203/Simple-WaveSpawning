using UnityEngine;

namespace ThisProject.Enemies
{
    [CreateAssetMenu(fileName = "EnemyType", menuName = "ThisProject/EnemyType")]
    public class EnemyType : ScriptableObject
    {
        //[SerializeField]
        //private int _id; //todo some inner id or enum?

        [SerializeField]
        private string _name;
        [SerializeField]
        private Sprite _sprite;

        public string Name => _name;
        public Sprite Sprite => _sprite;
    }
}