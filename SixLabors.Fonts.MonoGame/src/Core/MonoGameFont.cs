using Microsoft.Xna.Framework;

namespace SixLabors.Fonts.MonoGame.Core;

/// <summary>
/// Wraps any <see cref="Font"/> instance for usage with Monogame.
/// </summary>
public sealed class MonoGameFont
{
    internal MonoGameFont(Font font, TextOptions options)
    {
        Font        = font;
        TextOptions = options;
    }
        
    /// <summary>
    /// The font from the font family.
    /// </summary>
    public Font Font { get; }
        
    /// <summary>
    /// The text options to use.
    /// </summary>
    public TextOptions TextOptions { get; }

    /// <summary>
    /// Measures the size of the given text.
    /// </summary>
    public Vector2 MeasureString(string text)
    {
        FontRectangle result = TextMeasurer.Measure(text, TextOptions);
        return new Vector2(result.Width, result.Height);
    }
        
    /// <summary>
    /// Measures the size of the given text.
    /// </summary>
    public Vector2 MeasureString(ReadOnlySpan<char> text)
    {
        FontRectangle result = TextMeasurer.Measure(text, TextOptions);
        return new Vector2(result.Width, result.Height);
    }

    /// <summary>
    /// Measures the bounds of the given text.
    /// </summary>
    public Vector2 MeasureBounds(string text)
    {
        FontRectangle result = TextMeasurer.MeasureBounds(text, TextOptions);
        return new Vector2(result.Width, result.Height);
    }

    /// <summary>
    /// Measures the bounds of the given text.
    /// </summary>
    public Vector2 MeasureBounds(ReadOnlySpan<char> text)
    {
        FontRectangle result = TextMeasurer.MeasureBounds(text, TextOptions);
        return new Vector2(result.Width, result.Height);
    }
}