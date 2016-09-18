﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flicker
{
	public class TextElement : Element
	{
		public string Text { get; set; } = "";
		public bool Wrap { get; set; } = true;

		public TextElement(int x, int y, int width, int height)
			: base(x, y, width, height)
		{ }

		protected override void CustomRender()
		{
			if (!Wrap)
			{
				Console.Write(Text);
				return;
			}

			foreach (var line in Text.Chunks(Width - Padding * 4))
			{
				Console.Write(line);
				++Console.CursorTop;
				Console.CursorLeft = (Console.CursorLeft - Width - Padding * 4).Clamp(0);
			}
		}
	}
}
