using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Flicker
{
	public class Renderer
	{
		private List<IRenderable> RenderItems { get; set; } = new List<IRenderable>();
		private int SelectedIndex { get; set; }

		public Renderer()
		{
			// Make buffer the size of the window
			Console.BufferWidth = Console.WindowWidth;
			Console.BufferHeight = Console.WindowHeight;
			Console.CursorVisible = false;
		}

		public void Render()
		{
			while (true)
			{
				Console.ResetColor();
				Console.Clear();

				try
				{
					foreach (var el in RenderItems)
					{
						el.Render(RenderItems[SelectedIndex] == el);
					}
				}
				catch
				{
					// Nom
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