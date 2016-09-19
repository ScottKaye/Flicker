using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flicker
{
	public class InputElement : Element
	{
		public InputElement(out string result, string label)
			: base(0, 0, 0, 0)
		{
			Visible = false;
			Tools.Console.Fill(0, 1, Console.BufferWidth, Console.BufferHeight - 2, '\u2588');
			Tools.Console.WriteAt(0, 0, label);
			result = Console.ReadLine();
		}
	}
}
