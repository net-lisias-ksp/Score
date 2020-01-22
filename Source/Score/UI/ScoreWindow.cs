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
	internal class ScoreWindow : Window
	{
		new internal class Style
		{
			public Window.Style style;

			public GUIStyle datumName;
			public GUIStyle datumValue;
			public GUIStyle datumUnit;
			public GUIStyle score;

			internal void Init(Window.Style style)
			{
				this.style = style;

				this.datumName = new GUIStyle(this.style.skin.label)
				{
					fontSize = 16,
					alignment = TextAnchor.MiddleLeft,
					wordWrap = false,
					margin = new RectOffset(2, 2, 1, 1),
					padding = new RectOffset(1, 1, 1, 1)
				};

				this.datumValue = new GUIStyle(this.style.skin.label)
				{
					fontSize = 16,
					alignment = TextAnchor.MiddleLeft,
					wordWrap = false,
					margin = new RectOffset(2, 2, 1, 1),
					padding = new RectOffset(1, 1, 1, 1)
				};

				this.datumUnit = new GUIStyle(this.style.skin.label)
				{
					fontSize = 13,
					alignment = TextAnchor.MiddleLeft,
					wordWrap = false,
					margin = new RectOffset(2, 2, 1, 1),
					padding = new RectOffset(1, 1, 1, 1)
				};

				this.score = new GUIStyle(this.style.skin.label)
				{
					fontSize = 20,
					alignment = TextAnchor.MiddleCenter,
					wordWrap = false,
					margin = new RectOffset(2, 2, 1, 1),
					padding = new RectOffset(1, 1, 1, 1)
				};
			}
		}

		private readonly Style style = new Style();
		private Challenge challenge;

		public ScoreWindow() : base(200, 320)
		{
		}

		protected override void Init()
		{
			this.style.Init(base.style);
		}

		internal void Show(Challenge challenge)
		{
			this.challenge = challenge;
			this.subtittle = this.challenge.Name;
			base.Show();
		}

		protected override void OnDraw(int windowId, Rect clientArea)
		{
			foreach (string v in this.challenge.GetNames())
			{
				GUILayout.BeginHorizontal();
				GUILayout.Label(v, this.style.datumName);
				GUILayout.Label(this.challenge.GetFormattedValue(v), this.style.datumValue);
				GUILayout.Label(this.challenge.GetUnit(v), this.style.datumUnit);
				GUILayout.EndHorizontal();
			}
			GUILayout.Space(14);
			GUILayout.Label(this.challenge.Score.ToString("G5"), this.style.score);
		}
	}
}
