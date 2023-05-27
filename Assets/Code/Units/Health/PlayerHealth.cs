using UnityEngine.SceneManagement;
using Code.GUI;

namespace Code.UnitHealth
{
    public sealed class PlayerHealth : IUnitHealth
    {
        private readonly PlayerInfoScreen PlayerInfoScreen;
        private int _health;

        public PlayerHealth(PlayerInfoScreen playerInfoScreen)
        {
            PlayerInfoScreen = playerInfoScreen;
        }

        public int Health 
        {
            get => _health;
            set
            {
                _health = value;
                PlayerInfoScreen.PlayerHPText.text = value.ToString();
            }
        }

        public bool IsDead => Health <= 0;

        public void TakeDamage(int damage)
        {
            Health -= damage;

            if(Health < 0)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
