namespace SixLabors.Fonts.MonoGame.Core;

/// <summary>
/// Wraps a <see cref="MonogameFont"/> to provide support for any wanted size.
/// </summary>
public sealed class DynamicSizeMonogameFont
{
    internal DynamicSizeMonogameFont(string fontName, FontEngine fontEngine)
    {
        FontName    = fontName;
        _fontEngine = fontEngine;
    }

    /// <summary>
    /// The name of the font.
    /// </summary>
    public string FontName { get; }

    /// <summary>
    /// Reference to the font engine.
    /// </summary>
    private readonly FontEngine _fontEngine;

    private MonogameFont GetFont(float size, FontStyle style = FontStyle.Regular)
    {
        MonogameFont font = _fontEngine.GetFont(FontName, size, style);
        return font;
    }
}