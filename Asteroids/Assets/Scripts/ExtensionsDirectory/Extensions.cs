using DataContainers;
using UnityEngine;

namespace ExtensionsDirectory
{
    public static class Extensions
    {
        public static UniVector2 ToUniVector2(this Vector3 vector3) =>
            new UniVector2(vector3.x, vector3.y);
    
        public static Vector2 ToVector2(this UniVector2 uniVector2) =>
            new Vector2(uniVector2.X, uniVector2.Y);
    }
}