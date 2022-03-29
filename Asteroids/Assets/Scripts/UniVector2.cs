using UnityEngine;

[System.Serializable]
public class UniVector2
{
    private const float Threshold = 0.00000000000000001f;
    
    public float X, Y;

    private float Magnitude => Mathf.Sqrt(X * X + Y * Y);
    
    public UniVector2(float x, float y)
    {
        X = x;
        Y = y;
    }

    public UniVector2 Normalize()
    {
        var magnitude = Magnitude;
        X /= magnitude;
        Y /= magnitude;
        return this;
    }

    public UniVector2 Copy() => new UniVector2(X, Y);

    public static UniVector2 operator *(UniVector2 uniVector2, float number) =>
        new UniVector2(uniVector2.X * number, uniVector2.Y * number);

    public static UniVector2 operator +(UniVector2 first, UniVector2 second) =>
        new UniVector2(first.X + second.X, first.Y + second.Y);
    

    public override string ToString() => $"[{X}; {Y}]";
}