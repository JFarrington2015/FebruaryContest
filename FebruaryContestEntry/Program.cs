using System;
using System.Dynamic;
using System.Runtime.InteropServices;

namespace FebruaryContestEntry
{
	class Program
	{
		const char block = '▓';

		static void Main(string[] args)
		{
			// The solution implementation goes here

			var boxBuilder = new BoxBuilder()
                .SetDimensions(30, 15)
                .SetBorderColor(ConsoleColor.Green)
                .SetInsetColor(ConsoleColor.Yellow);

            for (var y=1;y<=boxBuilder.Height;y++) {
                for (var x = 1; x <= boxBuilder.Width; x++)
                {
                    Console.ForegroundColor = boxBuilder.SetCoords(x, y).GetBlockColor();
                    Console.Write(block);
                }
                Console.WriteLine();
            }

			Console.ResetColor();
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("Yay, a colorful shape!");
			Console.ReadLine();
		}

        class BoxBuilder
        {
            private int X { get; set; }
            private int Y { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
            private ConsoleColor BorderColor { get; set; }
            private ConsoleColor InsetColor { get; set; }

            public BoxBuilder SetDimensions(int width, int height)
            {
                Width = width;
                Height = height;
                return this;
            }

            public BoxBuilder SetCoords(int x, int y)
            {
                X = x;
                Y = y;
                return this;
            }

            public bool IsBorder()
            {
                return (X == 1 || X == Width || Y ==1 || Y == Height);
            }

            public BoxBuilder SetBorderColor(ConsoleColor color)
            {
                BorderColor = color;
                return this;
            }

            public BoxBuilder SetInsetColor(ConsoleColor color)
            {
                InsetColor = color;
                return this;
            }

            public ConsoleColor GetBlockColor()
            {
                return this.IsBorder() ? BorderColor : InsetColor;
            }
        }
	}
}
