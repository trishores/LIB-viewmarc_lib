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

using System;
using System.Linq;
using marc_common;

namespace viewmarc_lib
{
    internal class MarcViewerTools
    {
        internal static MarcVariableData GetVariableDataField(MarcDirectory.DirFieldEntry dirEntry)
        {
            var field = new MarcVariableData(dirEntry.Id);

            var parts = string.Join("", dirEntry.DataChars).Split(new[] { c_MarcSymbols.c_Machine.v_Delimiter, c_MarcSymbols.c_Machine.v_FieldTerminator }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 2 || parts[0].Length != 2 || parts[1].Length < 2) return null;

            // parse indicator:
            field.Indicator1 = parts[0][0];
            field.Indicator2 = parts[0][1];

            // parse subfields:
            foreach (var part in parts.Skip(1))
            {
                var subfield = new c_MarcSubfield(part[0].ToString(), part.Substring(1));
                field.SubfieldList.Add(subfield);
            }

            return field;
        }
    }
}