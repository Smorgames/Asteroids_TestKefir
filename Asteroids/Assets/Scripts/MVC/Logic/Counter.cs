using System;

namespace MVC.Logic
{
    public class Counter
    {
        public Action OnReloaded;
        
        public bool Reloaded { get; set; } = true;

        private readonly float _reloadTime;
        private float _counter;

        public Counter(float reloadTime) => 
            _reloadTime = reloadTime;
        
        public void CounterTick(float deltaTime)
        {
            if (Reloaded)
                return;

            _counter += deltaTime;

            if (ReloadingCompleted())
            {
                Reloaded = true;
                _counter = 0f;
                OnReloaded?.Invoke();
            }
        }

        private bool ReloadingCompleted() => _counter >= _reloadTime;
    }
}