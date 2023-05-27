using UnityEngine;

namespace Code.Settings
{
    [CreateAssetMenu(fileName = nameof(UnitSetting), menuName = "Setting/UnitSetting")]
    public sealed class UnitSetting : ScriptableObject
    {
        [SerializeField] private float _speed;
        [SerializeField] private int _health;

        public float Speed => _speed;
        public int Health => _health;
    }
}
