namespace MVC.Logic
{
    public class Counter
    {
        public bool Reloaded { get => _reloaded; set => _reloaded = value; }
        
        private readonly float _reloadTime;

        private bool _reloaded = true;
        private float _counter;

        public Counter(float reloadTime) => 
            _reloadTime = reloadTime;
        
        public void CounterTick(float deltaTime)
        {
            if (_reloaded)
                return;

            _counter += deltaTime;

            if (ReloadingCompleted())
            {
                _reloaded = true;
                _counter = 0f;
            }
        }

        private bool ReloadingCompleted() => _counter >= _reloadTime;
    }
}