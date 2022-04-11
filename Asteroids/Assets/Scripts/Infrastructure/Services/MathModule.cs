using ModelLogic.Interfaces;
using UnityEngine;

namespace Infrastructure.Services
{
    public class MathModule : IMathModule
    {
        public float Sqrt(float number) => 
            Mathf.Sqrt(number);
    }
}