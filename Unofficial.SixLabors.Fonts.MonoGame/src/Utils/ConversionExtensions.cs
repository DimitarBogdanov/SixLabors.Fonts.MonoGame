using XnaVector2 = Microsoft.Xna.Framework.Vector2;
using CoreVector2 = System.Numerics.Vector2;
using XnaColor = Microsoft.Xna.Framework.Color;

namespace SixLabors.Fonts.MonoGame.Utils;

public static class ConversionExtensions
{
    public static XnaVector2 Convert(this CoreVector2 vector)
    {
        return new XnaVector2(vector.X, vector.Y);
    }

    public static CoreVector2 Convert(this XnaVector2 vector)
    {
        return new CoreVector2(vector.X, vector.Y);
    }

    public static XnaColor Convert(this GlyphColor color)
    {
        return new XnaColor(color.Red, color.Green, color.Blue, color.Alpha);
    }
}