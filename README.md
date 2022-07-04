# SixLabors.Fonts.MonoGame
***Unofficial*** port of SixLabors.Fonts to MonoGame for .NET 6 and above.

![Example](https://i.imgur.com/fqtf8jW.png)

## Please note
This has only been tested on Windows. It should work on other systems, but if it doesn't, please open an issue.
This library is also new and unoptimised. Pull requests are welcome!

## Usage
### Basic usage
The premise is simple: we have a `FontEngine`, which we use to store our fonts. We then use the `FontEngine` to get a loaded font, and we draw with it.
```csharp
// Load up our very epic fonts!!!
FontEngine engine = new();
engine.LoadFont("path/to/some-cool-font.ttf");

// The font name from the truetype file is what we need to use here.
MonoGameFont font = engine.GetFont("some-cool-font", 24f);

// We've got the font! Now we can draw.
// We have an extension method on SpriteBatch just for that.
// It's in SixLabors.Fonts.MonoGame.Utils
batch.DrawText(font, "Hello, world!", new Vector2(10, 10));
```

### Default font name
Presumably, you have one font and you don't want to keep typing its name over and over again. Or, maybe your game has a mod system, and mods can load in their own font and use it as the default for the entire game. In cases as such, you can modify the default font name.
```csharp
// We are using the code from the above example.

// We're setting the DefaultFontName to the font we'll be using
engine.DefaultFontName = "some-cool-font";

// Now we can forget about the name at all!
MonoGameFont defaultFont = engine.GetDefaultFont(24f);
```

### Fallback fonts
For missing glyphs, SixLabors.Fonts provides fallback fonts. This library implements them as well.
You can add a fallback font by adding it to the FallbackFontFamilies list in `FontEngine`.
```csharp
// We are using the code from the above examples.

fontEngine.FallbackFontFamilies.Add(font);
```

If `addSystemFonts` in the `FontEngine` constructor is set to true (which is the default), the fonts `Arial`, `Courier` and `Helvetica` will be added to the fallback fonts list.
