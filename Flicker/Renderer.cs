﻿using System;
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

		public Renderer()
		{
			Console.CursorVisible = false;
		}

		public void Render()
		{
			Console.ResetColor();
			Console.Clear();

			foreach(var el in RenderItems)
			{
				el.Render();
			}
		}

		public bool Register(Element element)
		{
			RenderItems.Add(element);
			return true;
		}
	}
}