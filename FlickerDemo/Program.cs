using System;
using Flicker;

namespace FlickerDemo
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			var flicker = new Renderer();
			var text = new TextElement(15, 10, 20, 5)
			{
				Background = ConsoleColor.DarkBlue,
				Text = "Nothing"
			};

			var menu = new MenuElement(5, 5, 15, 6)
			{
				Border = '@',
				Items =
				{
					new MenuItem
					{
						Method = () => { text.Visible = !text.Visible; },
						Label = "Toggle text"
					},
					new MenuItem
					{
						Method = () => { text.Select(); },
						Label = "Select text"
					},
					new MenuItem
					{
						Method = () => { text.Text = Environment.TickCount.ToString(); },
						Label = "Update text"
					},
					new MenuItem
					{
						Method = () =>
						{
							string result;
							new InputElement(out result, "Enter your name: ");

							text.Text = $"Hello, {result}!";
						},
						Label = "Prompt"
					}
				}
			};

			var half1 = new TextElement(.5f, .5f, .5f, .5f)
			{
				Background = ConsoleColor.Blue
			};

			var half2 = new TextElement(0, 0, .5f, .5f)
			{
				Background = ConsoleColor.Green
			};

			flicker.Register(half1);
			flicker.Register(half2);
			flicker.Register(menu);
			flicker.Register(text);
			menu.Select();
			flicker.Render();
		}
	}
}