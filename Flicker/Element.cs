using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Flicker
{
	public abstract class Element : IRenderable
	{
		public int X { get; set; }
		public int Y { get; set; }
		public int Width { get; set; } = 1;
		public int Height { get; set; } = 1;
		public bool Border { get; set; }
		public int Padding { get; set; }
		public ConsoleColor Foreground { get; set; } = ConsoleColor.White;
		public ConsoleColor Background { get; set; } = ConsoleColor.Black;

		protected abstract void CustomRender();

		/// <summary>
		/// Draw this element
		/// </summary>
		void IRenderable.Render()
		{
			Console.SetCursorPosition(0, 0);
			Console.ForegroundColor = Foreground;
			Console.BackgroundColor = Background;
			Console.CursorLeft = X;
			Console.CursorTop = Y;
			for (int i = 0; i < Height; ++i)
			{
				Console.WriteLine(new string(' ', Width));
				Console.CursorLeft = X;
			}

			Console.CursorLeft = X;
			Console.CursorTop = Y;

			CustomRender();

			Console.ResetColor();
		}
	}
}
