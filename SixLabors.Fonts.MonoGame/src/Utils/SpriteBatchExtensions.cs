using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SixLabors.Fonts.MonoGame.Core;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using XnaColor = Microsoft.Xna.Framework.Color;

namespace SixLabors.Fonts.MonoGame.Utils;

public static class SpriteBatchExtensions
{
    public static void DrawText(this SpriteBatch batch, MonogameFont font, string text, Vector2 position)
    {
        Vector2 bounds = font.MeasureString(text);

        // Render text
        (int width, int height) = ((int) bounds.X, (int) bounds.Y);
        using Image<Rgba32> image = new(width, height);
        image.Mutate(
            x => x.DrawText(text, font.Font, ImageSharp.Color.White, PointF.Empty)
        );

        // Monogame conversion stuff
        Texture2D tex = new Texture2D(batch.GraphicsDevice, width, height);
        int pixelCount = width * height;
        XnaColor[] data = new XnaColor[pixelCount];

        int x = 0, y = 0;
        for (int i = 0; i < width * height; ++i)
        {
            Rgba32 color = image[x, y];
            data[i] = new XnaColor(color.R, color.G, color.B, color.A);
                
            if (++x == width)
            {
                x = 0;
                y++;
            }
        }
        tex.SetData(data);
        batch.Draw(tex, position, XnaColor.White);
    }
}