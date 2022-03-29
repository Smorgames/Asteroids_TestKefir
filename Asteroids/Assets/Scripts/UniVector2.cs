using UnityEngine;

[System.Serializable]
public class UniVector2
{
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

    public static UniVector2 operator +(UniVector2 firstUniVector2, UniVector2 secondUniVector2) =>
        new UniVector2(firstUniVector2.X + secondUniVector2.X, firstUniVector2.Y + secondUniVector2.Y);

    public override string ToString() => $"[{X}; {Y}]";
}