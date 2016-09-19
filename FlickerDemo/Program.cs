using Flicker;
using System;

namespace FlickerDemo
{
	class Program
	{
		static void Main(string[] args)
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
						Method = () =>
						{
							text.Visible = !text.Visible;
						},
						Label = "Toggle text"
					},
					new MenuItem
					{
						Method = () =>
						{
							text.Select();
						},
						Label = "Select text"
					},
					new MenuItem
					{
						Method = () =>
						{
							text.Text = Environment.TickCount.ToString();
						},
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

			flicker.Register(menu);
			flicker.Render();

			flicker.Register(text);
			flicker.Render();
		}
	}
}
