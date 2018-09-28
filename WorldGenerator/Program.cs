using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace WorldGenerator
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			var world = new StoogeWorld.StoogeWorld();
			var gen = new Generator(world);

			var arr = gen.GenerateArea(3);

			var rowLength = arr.GetLength(0);
			var colLength = arr.GetLength(1);

			var bmp = new Bitmap(rowLength, colLength);
			using( var graph = Graphics.FromImage(bmp) )
			{
				for ( var i = 0; i < rowLength; i++ )
				{
					for ( var j = 0; j < colLength; j++ )
					{
						var value = (int)Math.Round(0.5f * (1 + arr[i, j]) * 255);
						bmp.SetPixel(i, j, Color.FromArgb(value, value, value));
					}
				}
			}
			bmp.Save("TestImage.png", ImageFormat.Png);
		}

		private Bitmap DrawFilledRectangle(int x, int y)
		{
			var bmp = new Bitmap(x, y);
			using ( var graph = Graphics.FromImage(bmp) )
			{
				var imageSize = new Rectangle(0, 0, x, y);
				graph.FillRectangle(Brushes.White, imageSize);
			}
			return bmp;
		}
	}
}
