namespace SixLabors.Fonts.MonoGame.Core;

/// <summary>
/// Wraps a <see cref="MonoGameFont"/> to provide support for any wanted size and style.
/// </summary>
public sealed class DynamicMonoGameFont
{
    internal DynamicMonoGameFont(string fontName, FontEngine fontEngine)
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

    private MonoGameFont GetFont(float size, FontStyle style = FontStyle.Regular)
    {
        MonoGameFont font = _fontEngine.GetFont(FontName, size, style);
        return font;
    }
}