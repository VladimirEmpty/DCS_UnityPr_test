using UnityEngine;
using TMPro;
using LasyDI;

namespace Code.GUI
{
    public sealed class PlayerInfoScreen : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _playerHPText;
        [SerializeField] private TextMeshProUGUI _playerGunText;

        [Inject]
        public void Contstruct()
        {

        }

        public TextMeshProUGUI PlayerHPText => _playerHPText;
        public TextMeshProUGUI PlayerGunText => _playerGunText;
    }
}
