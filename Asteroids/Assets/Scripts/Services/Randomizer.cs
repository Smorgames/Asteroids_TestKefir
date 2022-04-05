namespace Services
{
    public class Randomizer
    {
        public static float Random(float min, float max) => 
            UnityEngine.Random.Range(min, max);
    }
}