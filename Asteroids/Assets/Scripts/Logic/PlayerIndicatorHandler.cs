using Logic.Player;
using TMPro;
using UnityEngine;

namespace Logic
{
    public class PlayerIndicatorHandler : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _playerCoordinatesTMP;
        [SerializeField] private TextMeshProUGUI _playerRotationTMP;
        [SerializeField] private TextMeshProUGUI _playerInstantSpeedTMP;
        [SerializeField] private TextMeshProUGUI _laserAmountTMP;
        [SerializeField] private TextMeshProUGUI _laserCooldownTMP;

        private PlayerController _playerController;

        public void Construct(PlayerController playerController)
        {
            _playerController = playerController;

            _playerController.Model.Transform.OnPositionChanged += PlayerPositionChanged;
            _playerController.Model.Transform.OnRotationChanged += PlayerRotationChanged;
            _playerController.Model.LaserGun.OnFired += LaserAmountChanged;
            _playerController.Model.LaserGun.OnReloaded += LaserAmountChanged;
            _playerController.Model.LaserGun.OnCounterTick += TimeToCooldownChanged;

            PlayerRotationChanged();
            LaserAmountChanged();
            TimeToCooldownChanged();
        }

        private void Update()
        {
            SetPlayerInstantSpeed();
        }

        private void PlayerPositionChanged()
        {
            var coordinates = _playerController.Model.Transform.Position;
            _playerCoordinatesTMP.text =
                $"Player coordinates: {coordinates}";
        }

        private void PlayerRotationChanged()
        {
            var angle = _playerController.Model.Transform.Rotation;
            var formattedAngle = Mathf.Abs(angle) % 360f;
            _playerRotationTMP.text = $"Player rotation angle: {formattedAngle:0.}";
        }

        private void SetPlayerInstantSpeed()
        {
            var instantSpeed = _playerController.Model.GetInstantSpeed();
            _playerInstantSpeedTMP.text = $"Player instant speed: {instantSpeed}";
        }

        private void LaserAmountChanged()
        {
            var current = _playerController.Model.GetCurrentLaserAmount();
            var max = _playerController.Model.GetMaxLaserAmount();
            _laserAmountTMP.text = $"Laser amount: {current} / {max}";
        }

        private void TimeToCooldownChanged()
        {
            var current = _playerController.Model.LaserGun.Counter.CurrentReloadTime;
            var max = _playerController.Model.LaserGun.Counter.ReloadTime;

            _laserCooldownTMP.text = $"Reload time: {current:0.0} / {max:0.0}";
        }
    }
}