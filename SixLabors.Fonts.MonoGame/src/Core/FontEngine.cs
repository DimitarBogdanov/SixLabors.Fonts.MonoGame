namespace SixLabors.Fonts.MonoGame.Core;

/// <summary>
/// The font engine is used for working with fonts in SkiLabors.Fonts.Monogame.
/// </summary>
public sealed class FontEngine
{
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="addSystemFonts">Whether system founds should be added.</param>
    public FontEngine(bool addSystemFonts = true)
    {
        FallbackFontFamilies = new List<FontFamily>();
        _fontCollection      = new FontCollection();

        if (addSystemFonts)
        {
            _fontCollection.AddSystemFonts();

            // Just a couple of well-spread fonts across systems.
            // This should suffice.
            TryLoadFallback("Arial");
            TryLoadFallback("Courier");
            TryLoadFallback("Helvetica");
        }
    }

    /// <summary>
    /// The font families in this list will be used when a certain glyph isn't
    /// available when displaying text.
    /// </summary>
    public List<FontFamily> FallbackFontFamilies { get; }


    public string? DefaultFontName { get; set; }

    /// <summary>
    /// Internal font collection.
    /// </summary>
    private readonly FontCollection _fontCollection;

    /// <summary>
    /// Retrieves the specified font family. 
    /// </summary>
    /// <exception cref="FontFamilyNotFoundException">The font family is not loaded.</exception>
    /// <param name="fontName">The name of the font.</param>
    /// <param name="fontSize">The size of the font.</param>
    /// <param name="fontStyle">Font style (bold, italic, etc.). Defaults to Regular.</param>
    public MonogameFont GetFont(string fontName, float fontSize, FontStyle fontStyle = FontStyle.Regular)
    {
        if (!_fontCollection.TryGet(fontName, out FontFamily family))
        {
            throw new FontFamilyNotFoundException($"Font family {fontName} does not exist.");
        }

        Font font = family.CreateFont(fontSize, fontStyle);
        MonogameFont wrapper = new MonogameFont(font, new TextOptions(font)
        {
            FallbackFontFamilies = FallbackFontFamilies.ToArray()
        });

        return wrapper;
    }

    /// <summary>
    /// Invokes <see cref="GetFont(string, float, FontStyle)"/> with <see cref="DefaultFontName"/>.
    /// </summary>
    /// <exception cref="InvalidOperationException"><see cref="DefaultFontName"/> is null.</exception>
    /// <param name="fontSize">The size of the font.</param>
    /// <param name="fontStyle">Font style (bold, italic, etc.). Defaults to Regular.</param>
    public MonogameFont GetDefaultFont(float fontSize, FontStyle fontStyle = FontStyle.Regular)
    {
        if (DefaultFontName == null)
        {
            throw new InvalidOperationException("Default font not set.");
        }

        return GetFont(DefaultFontName, fontSize, fontStyle);
    }

    /// <summary>
    /// Checks whether the engine has a certain font.
    /// </summary>
    public bool HasFont(string fontName)
    {
        return _fontCollection.TryGet(fontName, out FontFamily _);
    }

    /// <summary>
    /// Loads a font into the engine.
    /// </summary>
    /// <param name="fontPath">The path to the font. This is usually a .ttf file.</param>
    public void LoadFont(string fontPath)
    {
        _fontCollection.Add(fontPath);
    }

    /// <summary>
    /// Loads a font collection into the engine.
    /// </summary>
    /// <param name="fontPath">The path to the font collection. This is usually a .ttc file.</param>
    public void LoadFontFamily(string fontPath)
    {
        _fontCollection.AddCollection(fontPath);
    }

    /// <summary>
    /// Internal method to try to load a fallback font.
    /// </summary>
    /// <param name="name"></param>
    private void TryLoadFallback(string name)
    {
        if (_fontCollection.TryGet(name, out FontFamily family))
        {
            FallbackFontFamilies.Add(family);
        }
    }
}