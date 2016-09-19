using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flicker
{
	public interface IRenderable
	{
		Renderer AssociatedRenderer { get; set; }

		void Render(bool selected);
		void HandleKey(ConsoleKeyInfo key);
		void Select();
		void Destroy();
	}
}
