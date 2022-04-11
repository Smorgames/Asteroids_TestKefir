using System;
using ModelLogic.Data;
using ModelLogic.Gameplay;

namespace ModelLogic.Models
{
    public class LaserGunModel
    {
        public Action<UniVector2, float> OnFire;
        public Action WasFired;
        public Action OnReloaded;
        public Action OnCounterTick;
        
        public int CurrentLaserAmount { get; private set; }
        public int MaxLaserAmount { get; }
        public Counter Counter { get; }

        private readonly PlayerModel _playerModel;

        public LaserGunModel(float reloadTime, int maxLaserAmount, PlayerModel playerModel)
        {
            _playerModel = playerModel;
            MaxLaserAmount = maxLaserAmount;
            CurrentLaserAmount = MaxLaserAmount;
            Counter = new Counter(reloadTime);
            _playerModel.OnUpdate += Update;
            Counter.OnReloaded += ReloadCompleted;
        }

        private void ReloadCompleted()
        {
            CurrentLaserAmount++;
            OnReloaded?.Invoke();

            if (CurrentLaserAmount < MaxLaserAmount)
                Counter.Reloaded = false;
        }

        private void Update()
        {
            Counter.CounterTick(_playerModel.DeltaTime);
            OnCounterTick?.Invoke();
        }

        public void Fire(UniVector2 laserSpawnPosition, float rotation)
        {
            if (CurrentLaserAmount <= 0)
                return;
            
            OnFire?.Invoke(laserSpawnPosition, rotation);
            CurrentLaserAmount--;
            Counter.Reloaded = false;
            WasFired?.Invoke();
        }
    }
}