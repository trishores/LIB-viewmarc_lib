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

using System.Collections.Generic;

namespace viewmarc_lib
{
    internal class Marc003
    {
        internal string ControlNumberIdentifier;

        internal Marc003(List<char> charList)
        {
            ControlNumberIdentifier = string.Join("", charList);
        }

        internal string[][] GetCtrlArray()
        {
            var strList = new[]
            {
                    new[] { "003", "Control number identifier", "", ControlNumberIdentifier },
                };
            return strList;
        }
    }
}
