namespace Infrastructure.Services.Randomizing
{
    public class Randomizer : IRandomizer
    {
        public float Random(float min, float max) => 
            UnityEngine.Random.Range(min, max);
    }
}