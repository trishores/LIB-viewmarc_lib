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
using System.Linq;
using System.Text;

namespace viewmarc_lib
{
    internal class MarcDirectory
    {
        internal List<DirFieldEntry> DirEntryList = new List<DirFieldEntry>();

        internal MarcDirectory(string mrcContent, int ldrLength, int dirLength, MarcLeader marcLeader)
        {
            var charList = mrcContent.ToCharArray().ToList().GetRange(ldrLength, dirLength);

            var i = 0;
            string GetNextField(int num)
            {
                var str = string.Join("", charList.GetRange(i, num));
                i += num;
                return str;
            }

            while (i < charList.Count)
            {
                var entry = new DirFieldEntry();

                //  field tag (3):
                entry.Id = GetNextField(3);

                //  field length (4):
                entry.Length = GetNextField(4);

                //  field start position (5):
                entry.Start = GetNextField(5);

                // get field data ensuring that the length of each extracted field is it's UTF8 byte length not unicode char length. Failure to do this will result in subsequent fields having invalid data:
                var bytes = Encoding.UTF8.GetBytes(mrcContent).ToList().GetRange(int.Parse(marcLeader.BaseAddressOfData) + int.Parse(entry.Start), int.Parse(entry.Length)).ToArray();
                var str = Encoding.UTF8.GetString(bytes);
                entry.DataChars = str.ToCharArray().ToList();

                DirEntryList.Add(entry);
            }
        }

        internal string[][] GetDirArray()
        {
            var strList = new List<string[]>();

            var i = 0;
            foreach (var entry in DirEntryList)
            {
                // Populate directory table:
                strList.Add(new[] { $"DIR [{i}-{i + 11}]", entry.Id, entry.Length, entry.Start });
                i += 12;
            }

            return strList.ToArray();
        }

        internal class DirFieldEntry
        {
            private string _id;
            internal int Order;
            internal string Length;
            internal string Start;
            internal List<char> DataChars;

            internal string Id
            {
                get
                {
                    return _id;
                }
                set
                {
                    _id = value;
                    Order = int.Parse(_id);
                }
            }
        }
    }
}
