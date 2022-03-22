public class UniVector2
{
    public float X, Y;

    public UniVector2(float x, float y)
    {
        X = x;
        Y = y;
    }

    public static UniVector2 operator *(UniVector2 uniVector2, float number) =>
        new UniVector2(uniVector2.X * number, uniVector2.Y * number);
    
    public static UniVector2 operator +(UniVector2 firstUniVector2, UniVector2 secondUniVector2) =>
        new UniVector2(firstUniVector2.X + secondUniVector2.X, firstUniVector2.Y + secondUniVector2.Y);

    public override string ToString() => $"[{X}; {Y}]";
}