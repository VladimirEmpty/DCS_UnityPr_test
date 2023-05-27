using UnityEngine;

using Code.GUI;

namespace Code.Shoot
{
    public sealed class PlayerGunUser : IGunUser
    {
        private readonly PlayerInfoScreen PlayerInfoScreen;

        private IShoot[] _playerGuns;        
        private int _currentGunIndex;

        public PlayerGunUser(
            IShoot shootOne, 
            IShoot shootTwo, 
            PlayerInfoScreen playerInfoScreen)
        {
            PlayerInfoScreen = playerInfoScreen;

            _playerGuns = new IShoot[] { shootOne, shootTwo }; // не очень аккуратно, но это чисто для выполнения условия ТЗ
            PlayerInfoScreen.PlayerGunText.text = _playerGuns[_currentGunIndex].GunName;
        }

        public void Use(Transform gunPoint)
        {
            if(Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                SetUseGun(++_currentGunIndex);
            }

            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                SetUseGun(--_currentGunIndex);
            }

            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                SetUseGun(0);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SetUseGun(1);
            }

            if (Input.GetMouseButtonDown(0))
            {
                _playerGuns[_currentGunIndex]?.Shoot(gunPoint);
            }
        }

        private void SetUseGun(int index)
        {
            if(index > _playerGuns.Length - 1)
            {
                index = default;
            }
            if(index < 0)
            {
                index = _playerGuns.Length - 1;
            }

            _currentGunIndex = index;
            PlayerInfoScreen.PlayerGunText.text = _playerGuns[_currentGunIndex].GunName;
        }
    }
}
