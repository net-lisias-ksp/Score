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

using KSP.UI.Screens;
using Asset = KSPe.IO.File<Score.Score>.Asset;

using ToolbarControl_NS;

namespace Score
{
	[KSPAddon(KSPAddon.Startup.Flight, false)]
	public class Score : MonoBehaviour
	{
		private readonly UI.ScoreWindow scoreWindow = new UI.ScoreWindow();
		private bool is_active = false;
		private Challenge challenge;

		public Score()
		{
		}

		#region Unity Life Cycle Event Handling
		private ToolbarControl toolbarControl;
		private void Start()
		{
			this.toolbarControl = gameObject.AddComponent<ToolbarControl>();
			this.toolbarControl.AddToAllToolbars(
				ToggleOn, ToggleOff,
				ApplicationLauncher.AppScenes.FLIGHT | ApplicationLauncher.AppScenes.MAPVIEW,
				Globals.Toolbar.ID,
				Globals.Toolbar.ID + "_button",
				Asset.Solve("Icons", "icon-38"),
				Asset.Solve("Icons", "icon-24"),
				Globals.Toolbar.NAME
			);
		}

		private void OnDestroy()
		{
			this.toolbarControl.OnDestroy();
			Destroy(toolbarControl);
		}
		#endregion

		#region Unity Game Event Handling
		private void FixedUpdate()
		{
			if (!this.is_active) return;
			this.challenge.Update();
		}
		#endregion

		#region Unity GUI Event Handling
		private void OnGUI()
		{
			if (!this.is_active) return;
			this.scoreWindow.Show(this.challenge);
		}

		private void OnShowUI()
		{
			Log.dbg("OnShowGUI Fired");
			this.scoreWindow.VisibleGUI = true;
		}
		private void OnHideUI()
		{
			Log.dbg("OnHideGUI Fired");
			this.scoreWindow.VisibleGUI = true;
		}
		#endregion

		#region Toolbar Event Handling
		private void ToggleOn()
		{
			Log.dbg("Toggled On");
			this.challenge = new Challenges.FastestJunoPoweredAircraft(FlightGlobals.ActiveVessel);
			this.is_active = true;
		}

		private void ToggleOff()
		{
			Log.dbg("Toggled Off");
			this.challenge.Finish();
			this.is_active = false;
		}
		#endregion
	}
}
