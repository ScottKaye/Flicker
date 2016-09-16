using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flicker
{
	public class TextElement : Element
	{
		public string Text { get; set; }
		public bool Wrap { get; set; } = true;

		protected override void CustomRender()
		{
			if (!Wrap)
			{
				Console.Write(Text);
				return;
			}

			foreach(var line in Text.Chunks(Width))
			{
				Console.Write(line);
				++Console.CursorTop;
				Console.CursorLeft -= Width;
			}
		}
	}
}
