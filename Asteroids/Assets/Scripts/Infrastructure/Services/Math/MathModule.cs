using UnityEngine;

namespace Infrastructure.Services.Math
{
    public class MathModule : IMathModule
    {
        public float Sqrt(float number) => 
            Mathf.Sqrt(number);
    }
}