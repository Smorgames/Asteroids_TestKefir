using Infrastructure.Interfaces;

namespace Infrastructure.Services
{
    public class Randomizer : IRandomizer
    {
        public float Random(float min, float max) => 
            UnityEngine.Random.Range(min, max);
    }
}