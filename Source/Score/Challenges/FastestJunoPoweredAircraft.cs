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

using KSPe.Util.Log;

namespace Score.Challenges
{
	public class FastestJunoPoweredAircraft : Challenge
	{
		private static readonly Logger log = Logger.CreateForType<Score>();

		internal static void init()
		{
			log.level =
#if DEBUG
				Level.TRACE
#else
				Level.INFO
#endif
				;
		}

		string Challenge.Name => "Fastest Juno Powered Aircraft";
		string Challenge.Version => "0.0.1.0";
		string Challenge.URL => "https://forum.kerbalspaceprogram.com/index.php?/topic/191034-fastest-juno-powered-airplane/";

		double Challenge.Score => this.current_score;

		// Challenge data
		internal readonly Vessel vessel;
		private int engines_count = -1; // Divisions by Zero are bad!
		private float current_weight = 0;
		private double current_speed = 0;
		private double current_score = 0;

		public FastestJunoPoweredAircraft(Vessel vessel)
		{
			this.vessel = vessel;
			this.engines_count = this.vessel.parts.FindAll((Part p) => p.Modules.Contains("ModuleEnginesFX")).Count;
			this.UpdateVessel();
		}

		void Challenge.Update()
		{
			log.detail("Updating for {0}", this.vessel);
			this.UpdateVessel();
		}

		void Challenge.Finish()
		{
			log.info("Finishing {0}.", this.vessel);
		}

		private void UpdateVessel()
		{
			this.current_weight = this.vessel.GetTotalMass();
			//this.current_speed = this.vessel.horizontalSrfSpeed; // Nope, this diverges from the Surface reading from the NavBall
			//this.current_speed = Math.Sqrt(this.vessel.srfSpeed * this.vessel.srfSpeed - this.vessel.verticalSpeed * this.vessel.verticalSpeed); // Neither. This is a workaround for KSP 1.0.x
			this.current_speed = this.vessel.srfSpeed; // This one works!
			this.current_score = this.current_speed * this.current_weight / this.engines_count;
			log.dbg("Current score for {0} is {1}.", this.vessel, this.current_score);
		}

		private const string MASS = "Mass";
		private const string SPEED = "Speed";
		private const string ENGINE_COUNT = "Engine Count";
		private readonly string[] NAMES = { MASS, SPEED, ENGINE_COUNT };
		string[] Challenge.GetNames()
		{
			return this.NAMES;
		}

		string Challenge.GetFormattedValue(string name)
		{
			// GO HORSE!!! :D
			switch (name)
			{
				case MASS: return this.current_weight.ToString("F3");
				case SPEED: return this.current_speed.ToString("F2");
				case ENGINE_COUNT: return this.engines_count.ToString();
			}
			return "What?";
		}

		object Challenge.GetValue(string name)
		{
			// GO HORSE!!! :D
			switch (name)
			{
				case MASS: return this.current_weight;
				case SPEED: return this.current_speed;
				case ENGINE_COUNT: return this.engines_count;
			}
			return (object)null;
		}

		string Challenge.GetUnit(string name)
		{
			// GO HORSE!!! :D
			switch (name)
			{
				case MASS: return "tons";
				case SPEED: return "m/s";
				case ENGINE_COUNT: return "engines";
			}
			return "What?";
		}
	}
}
