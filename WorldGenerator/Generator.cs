using System;

namespace WorldGenerator
{
	public class Generator
	{
		private StoogeWorld.StoogeWorld World { get; set; }

		public Generator(StoogeWorld.StoogeWorld world)
		{
			World = world;
		}

		public float[,] GenerateArea(int seed)
		{
			var random = new Random(seed);
			var width = random.Next(10, 20);
			var height = random.Next(10, 20);

			var pn = new PerlinNoise(width, height, seed);
			var heights = new float[width, height];
			for ( var x = 0; x < width; x++ )
			{
				for ( var y = 0; y < height; y++ )
				{
					var value = pn.GetRandomHeight(x, y, 1, 0.8f, 0.2f, 0.1f, 2);
					heights[x, y] = value;
				}
			}

			return heights;
		}
	}

	
}
