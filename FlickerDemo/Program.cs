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
			var text = new TextElement
			{
				Text = "En garde you guy",
				X = 15,
				Y = 10,
				Width = 20,
				Height = 5,
				Background = ConsoleColor.DarkGray
			};

			flicker.Register(text);
			flicker.Render();

			Task.Run(async () =>
			{
				return;
				while (true)
				{
					await Task.Delay(100);
					flicker.Render();
				}
			});

			Console.ReadKey(false);
		}
	}
}
