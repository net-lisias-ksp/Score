/*
	This file is part of Score!
	(C) 2020 Lisias T : http://lisias.net <support@lisias.net>

	Score! is double licensed, as follows:

	* SKL 1.0 : https://ksp.lisias.net/SKL-1_0.txt
	* GPL 2.0 : https://www.gnu.org/licenses/gpl-2.0.txt

	And you are allowed to choose the License that better suit your needs.

	Score! is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

	You should have received a copy of the SKL Standard License 1.0
	along with Score!. If not, see <https://ksp.lisias.net/SKL-1_0.txt>.

	You should have received a copy of the GNU General Public License 2.0
	along with Score!. If not, see <https://www.gnu.org/licenses/>.

*/
using System;

using UnityEngine;

using GUILayout = KSPe.UI.GUILayout;

namespace Score.UI
{
	internal abstract class Window
	{
		internal class Style
		{
			public GUISkin skin;

			public GUIStyle window;
			public GUIStyle tittle;
			public GUIStyle subtittle;

			internal void Init()
			{
				this.skin = GUI.skin;

				this.window = new GUIStyle(this.skin.window)
				{
					fontSize = 22,
					fontStyle = FontStyle.Bold,
					alignment = TextAnchor.UpperCenter,
					wordWrap = false,
					margin = new RectOffset(2, 2, 1, 1),
					padding = new RectOffset(1, 1, 1, 1)
				};

				this.tittle = new GUIStyle(this.skin.label)
				{
					fontSize = 22,
					alignment = TextAnchor.MiddleCenter,
					wordWrap = false,
					margin = new RectOffset(2, 2, 1, 1),
					padding = new RectOffset(1, 1, 1, 1)
				};

				this.subtittle = new GUIStyle(this.skin.label)
				{
					fontSize = 20,
					alignment = TextAnchor.MiddleCenter,
					wordWrap = false,
					margin = new RectOffset(2, 2, 1, 1),
					padding = new RectOffset(1, 1, 1, 1)
				};
			}
		}

		private static bool initialized = false;

		internal bool VisibleGUI { get; set; } = true;

		protected readonly Style style = new Style();
		private readonly string tittle;
		private readonly int maxHeight;
		private readonly int maxWidth;
		protected readonly int window_id;

		protected string subtittle;

		private Rect windowRect;

		public Window(int maxHeight, int maxWidth)
		{
			this.tittle = "Score!";
			this.subtittle = "";
			this.maxHeight = maxHeight;
			this.maxWidth = maxWidth;
			this.window_id = (int)System.DateTime.Now.Ticks;
		}

		protected void Show()
		{
			if (this.IsDeactivated()) return;
			Log.dbg("Window.Show");
			this.windowRect = GUILayout.Window(this.window_id, this.windowRect, this.Draw, this.tittle, this.style.window);
		}

		protected bool IsDeactivated()
		{
			if (!Window.initialized) this.Initialise();

			return !this.VisibleGUI;
		}

		private void Initialise()
		{
			Log.dbg("Window.Initialize");
			this.style.Init();
			this.Init();

			this.windowRect = this.calculateWindow();

			initialized = true;
		}

		private void Draw(int windowId)
		{
			Log.dbg("Window.Draw {0}", windowId);
			const int border = 10;
			const int width = 50;
			const int height = 25;
			const int spacing = 10;

			Rect l = new Rect(
					border, border + spacing,
					this.windowRect.width - border * 2, this.windowRect.height - border * 2 - height - spacing
				);

			GUILayout.Label(this.subtittle, this.style.subtittle);

			Rect b = new Rect(
				this.windowRect.width - width - border,
				this.windowRect.height - height - border,
				width,
				height);

			this.OnDraw(windowId, b);
			GUI.DragWindow();
		}

		protected abstract void Init();
		protected abstract void OnDraw(int windowId, Rect clientArea);

		private Rect calculateWindow()
		{
			int width = Mathf.Min(this.maxWidth, Screen.width - 20);
			int height = Mathf.Min(this.maxHeight, Screen.height - 20);

			return new Rect(
				(Screen.width - width) / 2, (Screen.height - height) / 2,
				width, height
			);

		}
	}
}
