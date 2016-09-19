using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Flicker
{
	public class Renderer
	{
		private List<IRenderable> RenderItems { get; set; } = new List<IRenderable>();
		private int SelectedIndex { get; set; }
		private bool Exit { get; set; }

		public Renderer()
		{
			// Make buffer the size of the window
			Console.BufferWidth = Console.WindowWidth;
			Console.BufferHeight = Console.WindowHeight;
			Console.CursorVisible = false;
		}

		public void Render()
		{
			while (!Exit)
			{
				Console.ResetColor();
				Console.Clear();

				foreach (var el in RenderItems)
				{
					el.Render(RenderItems[SelectedIndex] == el);
				}

				Poll();
			}
		}

		private void Poll()
		{
			var key = Console.ReadKey(false);

			if ((key.Modifiers & ConsoleModifiers.Control) != 0)
			{
				switch (key.Key)
				{
					case ConsoleKey.RightArrow:
						SelectedIndex = (++SelectedIndex).Wrap(0, RenderItems.Count - 1);
						break;
					case ConsoleKey.LeftArrow:
						SelectedIndex = (--SelectedIndex).Wrap(0, RenderItems.Count - 1);
						break;
				}

				return;
			}

			Debug.WriteLine("Forwarding keypress");
			RenderItems[SelectedIndex].HandleKey(key);
		}

		public bool Register(IRenderable element)
		{
			element.AssociatedRenderer = this;
			RenderItems.Add(element);
			return true;
		}

		public void Select(IRenderable element)
		{
			SelectedIndex = RenderItems.IndexOf(element);
		}

		public void Destroy(IRenderable element)
		{
			RenderItems.Remove(element);
		}
	}
}