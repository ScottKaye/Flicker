using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flicker;
using System.Diagnostics;

namespace FlickerDemo
{
	class Program
	{
		static void Main(string[] args)
		{
			var flicker = new Renderer();
			var text = new TextElement(15, 10, 20, 5)
			{
				Background = ConsoleColor.DarkBlue
			};

			var text2 = new TextElement(0, 0, 40, 4)
			{
				Text = "Test text",
				Background = ConsoleColor.Gray
			};

			flicker.Register(text);
			flicker.Register(text2);
			flicker.Render();

			Task.Run(async () =>
			{
				while (true)
				{
					await Task.Delay(100);
					text.Text = Environment.TickCount.ToString();
					text.Render();
				}
			});

			Task.Run(async () =>
			{
				while (true)
				{
					await Task.Delay(1000);
					text2.Text = Environment.TickCount.ToString();
					text2.Render();

					flicker.Render();
				}
			});

			Console.ReadKey(false);
		}
	}
}
