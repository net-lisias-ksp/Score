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
namespace Score
{
	public interface Challenge
	{
		string Name { get; }
		string Version { get; }
		string URL { get; }

		double Score { get; }

		string[] GetNames();
		string GetFormattedValue(string name);
		object GetValue(string name);
		string GetUnit(string name);

		void Update();
		void Finish();
	}
}
