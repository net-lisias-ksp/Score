﻿/*
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
using UnityEngine;

using ToolbarControl_NS;

namespace Score
{
	[KSPAddon(KSPAddon.Startup.Instantly, true)]
	internal class Startup : MonoBehaviour
	{
		private void Start()
		{
			Log.init();
			Log.force("Version {0}", Version.Text);

			try
			{
				//KSPe.Util.Compatibility.Check<Startup>(typeof(Version), typeof(Configuration));
				KSPe.Util.Installation.Check<Startup>(typeof(Version));
			}
			catch (KSPe.Util.InstallmentException e)
			{
				Log.error(e.ToShortMessage());
				KSPe.Common.Dialogs.ShowStopperAlertBox.Show(e);
			}
		}
	}

	[KSPAddon(KSPAddon.Startup.MainMenu, true)]
	internal class ToolbarRegistration : MonoBehaviour
	{
		private void Start()
		{
			ToolbarControl.RegisterMod(Globals.Toolbar.ID, Globals.Toolbar.NAME);
		}
	}
}
