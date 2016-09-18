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
		public readonly int X;
		public readonly int Y;
		public readonly int Width;
		public readonly int Height;
		internal Renderer Renderer { get; set; }
		public bool Border { get; set; }
		public int Padding { get; set; } = 1; // Must be at least 1 (to make room for header), TODO enforce this
		public ConsoleColor Foreground { get; set; } = ConsoleColor.White;
		public ConsoleColor Background { get; set; } = ConsoleColor.Black;

		public Element(int x, int y, int width, int height)
		{
			X = x;
			Y = y;
			Width = width;
			Height = height;
		}

		protected abstract void CustomRender();

		/// <summary>
		/// Draw this element
		/// </summary>
		public void Render()
		{
			Console.ForegroundColor = Foreground;
			Console.BackgroundColor = Background;
			Console.CursorLeft = X;
			Console.CursorTop = Y;

			if (Renderer.SelectedItem == this)
			{
				Console.Write('*');
				Console.WriteLine(new string(' ', Width - 1));
			}
			else
			{
				Console.WriteLine(new string(' ', Width));
			}

			for (int i = 1; i < Height; ++i)
			{
				Console.CursorLeft = X;
				Console.WriteLine(new string(' ', Width));
			}

			Console.CursorLeft = X + Padding * 2;
			Console.CursorTop = Y + Padding;

			CustomRender();

			Console.ResetColor();
		}
	}
}
