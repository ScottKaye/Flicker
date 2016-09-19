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
		public bool Visible { get; set; } = true;
		public char Border { get; set; } = ' ';
		public int Padding { get; set; } = 1; // Must be at least 1 (to make room for header), TODO enforce this
		public ConsoleColor Foreground { get; set; } = ConsoleColor.White;
		public ConsoleColor Background { get; set; } = ConsoleColor.Black;
		public Renderer AssociatedRenderer { get; set; }

		public Element(int x, int y, int width, int height)
		{
			X = x;
			Y = y;
			Width = width;
			Height = height;
		}

		protected virtual void CustomRender()
		{
			return;
		}

		public virtual void HandleKey(ConsoleKeyInfo key)
		{
			return;
		}

		/// <summary>
		/// Draw this element
		/// </summary>
		void IRenderable.Render(bool selected)
		{
			if (!Visible) return;

			Console.ForegroundColor = Foreground;
			Console.BackgroundColor = Background;
			Console.CursorLeft = X;
			Console.CursorTop = Y;

			Tools.Console.Fill(
				X,
				Y,
				Width,
				Height,
				Border
			);

			if (Border != ' ')
			{
				Tools.Console.Fill(
					X + 1,
					Y + 1,
					Width - 2,
					Height - 2,
					' '
				);
			}

			if (selected)
			{
				Tools.Console.WriteAt(
					X, Y,
					new string('\u2580', Width),
					ConsoleColor.Red
				);
			}

			Console.CursorLeft = X + Padding * 2;
			Console.CursorTop = Y + Padding;

			CustomRender();

			Console.ResetColor();
		}

		public void Select() => AssociatedRenderer.Select(this);
		public void Destroy() => AssociatedRenderer.Destroy(this);
	}
}
