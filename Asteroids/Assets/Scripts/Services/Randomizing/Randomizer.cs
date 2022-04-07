namespace Services.Randomizing
{
    public class Randomizer
    {
        public float Random(float min, float max) => 
            UnityEngine.Random.Range(min, max);
    }
}