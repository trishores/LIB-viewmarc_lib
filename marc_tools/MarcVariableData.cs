/*
Copyright (C) 2020-2021 Tris Shores

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using marc_common;
using System.Collections.Generic;
using System.Linq;

namespace viewmarc_lib
{
    internal class MarcVariableData
    {
        internal string Id;
        internal char Indicator1;
        internal char Indicator2;
        internal List<c_MarcSubfield> SubfieldList = new List<c_MarcSubfield>();

        internal MarcVariableData(string id)
        {
            Id = id;
        }

        internal string ToInd1String()
        {
            return Indicator1.ToString();
        }

        internal string ToInd2String()
        {
            return Indicator2.ToString();
        }

        internal string ToSubfieldString()
        {
            return string.Join(" ", SubfieldList.Select(x => x.v_Human));
        }
    }
}
