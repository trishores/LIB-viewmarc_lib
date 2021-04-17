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
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static marc_common.c_StatusTools;

[assembly: AssemblyKeyFile(@"..\..\signing\keyFile.snk")]

namespace viewmarc_lib
{
    public class c_Engine
    {
        private List<string[]> v_RowsProps = new List<string[]>();
        private List<string[]> v_RowsLeader = new List<string[]>();
        private List<string[]> v_RowsDirectory = new List<string[]>();
        private List<string[]> v_RowsControl = new List<string[]>();
        private List<string[]> v_RowsVarData = new List<string[]>();

        public c_Engine()
        {
        }

        #region mrc to dat

        public int RunMrcToDat(string mrcFilePath, out string[] dat)
        {
            dat = null;

            try
            {
                #region validate args

                if (!File.Exists(mrcFilePath))
                {
                    return (int)c_StatusCode.MarcFileNotFound;
                }

                #endregion

                #region read mrc

                var res = m_ParseMrcFile(mrcFilePath);
                if (res)
                {
                    var lines = new List<string>();
                    v_RowsProps.ForEach(x => lines.Add("PRP\u23F5" + string.Join("\u23F5", x)));
                    v_RowsLeader.ForEach(x => lines.Add("LDR\u23F5" + string.Join("\u23F5", x)));
                    v_RowsDirectory.ForEach(x => lines.Add("DIR\u23F5" + string.Join("\u23F5", x)));
                    v_RowsControl.ForEach(x => lines.Add("CTR\u23F5" + string.Join("\u23F5", x)));
                    v_RowsVarData.ForEach(x => lines.Add("VAR\u23F5" + string.Join("\u23F5", x)));

                    dat = lines.ToArray();
                    return (int)c_StatusCode.Ok;
                }
                else
                {
                    return (int)c_StatusCode.MarcFileParseError;
                }

                #endregion
            }
            catch (Exception e)
            {
                return (int)c_StatusCode.UnknownError;
            }
        }

        #endregion

        #region mrc parsing

        private bool m_ParseMrcFile(string v_mrcFilePath)
        {
            try
            {
                var v_mrcContent = File.ReadAllText(v_mrcFilePath, c_MarcSymbols.c_Machine.v_UTF8EncodingNoBom);

                // parse leader:
                var v_mrcLdr = ParseLeader(v_mrcContent);
                if (v_mrcLdr == null) return false;

                // parse directory:
                var v_mrcDir = ParseDirectory(v_mrcContent, v_mrcLdr);
                if (v_mrcDir == null) return false;

                // parse control fields:
                if (!ParseControlFields(v_mrcLdr, v_mrcDir)) return false;

                // parse variable data fields:
                ParseVarDataFields(v_mrcDir);

                return true;
            }
            catch (c_ParseException e)  // test of custom exception.
            {
                var v_m = e.Message;
                var v_sc = e.v_statusCode;
                return false;
            }
            catch (Exception e) { return false; }
        }

        private MarcLeader ParseLeader(string recordContent)
        {
            var mrcLdr = new MarcLeader(recordContent);
            // Populate leader table:
            v_RowsLeader.AddRange(mrcLdr.GetLdrArray());
            // Populate fixed fields table:
            v_RowsProps.AddRange(mrcLdr.GetPropertyArray());
            return mrcLdr;
        }

        private MarcDirectory ParseDirectory(string mrcContent, MarcLeader mrcLdr)
        {
            const int ldrLength = 24;
            const int dirTerminatorLength = 1;
            var dirLength = int.Parse(mrcLdr.BaseAddressOfData) - ldrLength - dirTerminatorLength;
            var mrcDir = new MarcDirectory(mrcContent, ldrLength, dirLength, mrcLdr);
            v_RowsDirectory.AddRange(mrcDir.GetDirArray());
            return mrcDir;
        }

        private bool ParseControlFields(MarcLeader mrcLdr, MarcDirectory mrcDir)
        {
            var ctrlSupported = new[] { "001", "003", "005", "006", "007", "008" };
            var fieldIdList = mrcDir.DirEntryList.Select(x => x.Id).Where(x => x.StartsWith("00")).ToList();
            var ctrlUnsupported = fieldIdList.Except(ctrlSupported).ToList();
            if (ctrlUnsupported.Count > 0)
            {
                return false;
            }

            // parse 001:
            var dirEntries001 = mrcDir.DirEntryList.SingleOrDefault(x => x.Id == "001")?.DataChars?.SkipLast(1)?.ToList();  // remove field terminator.
            if (dirEntries001 != null)
            {
                if (dirEntries001.Count != 13 || !dirEntries001.ToString().StartsWith("BIB-"))
                {
                    //throw new c_ParseException("Only predictivebib.org records supported.", c_StatusCode.InvalidCredentials);  // custom exception.
                }
                var mrc001 = new Marc001(dirEntries001);
                v_RowsControl.AddRange(mrc001.GetCtrlArray());
                //v_RowsControl.Add(new[] { "\u2009", "\u2009", "\u2009", "\u2009" });
            }

            // parse 003:
            var dirEntries003 = mrcDir.DirEntryList.SingleOrDefault(x => x.Id == "003")?.DataChars?.SkipLast(1)?.ToList();  // remove field terminator.
            if (dirEntries003 != null)
            {
                var mrc003 = new Marc003(dirEntries003);
                v_RowsControl.AddRange(mrc003.GetCtrlArray());
                //v_RowsControl.Add(new[] { "\u2009", "\u2009", "\u2009", "\u2009" });
            }

            // parse 005:
            var dirEntries005 = mrcDir.DirEntryList.SingleOrDefault(x => x.Id == "005")?.DataChars?.SkipLast(1)?.ToList();  // remove field terminator.
            if (dirEntries005 != null)
            {
                var mrc005 = new Marc005(dirEntries005);
                v_RowsControl.AddRange(mrc005.GetCtrlArray());
                //v_RowsControl.Add(new[] { "\u2009", "\u2009", "\u2009", "\u2009" });
            }

            // parse 006 (repeatable):
            foreach (var dirEntries in mrcDir.DirEntryList.Where(x => x.Id == "006"))
            {
                var dirEntries006 = dirEntries.DataChars?.SkipLast(1)?.ToList();  // remove field terminator.
                if (dirEntries006 != null)
                {
                    var mrc006 = new Marc006(dirEntries006);
                    v_RowsControl.AddRange(mrc006.Material.GetCtrlArray());
                    //v_RowsControl.Add(new[] { "\u2009", "\u2009", "\u2009", "\u2009" });
                }
            }

            // parse 007 (repeatable):
            foreach (var dirEntries in mrcDir.DirEntryList.Where(x => x.Id == "007"))
            {
                var dirEntries007 = dirEntries.DataChars?.SkipLast(1)?.ToList();  // remove field terminator.
                if (dirEntries007 != null)
                {
                    var mrc007 = new Marc007(dirEntries007);
                    v_RowsControl.AddRange(mrc007.Material.GetCtrlArray());
                    //v_RowsControl.Add(new[] { "\u2009", "\u2009", "\u2009", "\u2009" });
                }
            }

            // parse 008:
            var dirEntries008 = mrcDir.DirEntryList.SingleOrDefault(x => x.Id == "008")?.DataChars?.SkipLast(1)?.ToList();  // remove field terminator.
            if (dirEntries008 != null)
            {
                var mrc008 = new Marc008(mrcLdr.materialType, dirEntries008);
                v_RowsControl.AddRange(mrc008.GetCtrlArray());
                //v_RowsVarCtrl.Add(new[] { "\u2009", "\u2009", "\u2009", "\u2009" });
            }

            return true;
        }

        private bool ParseVarDataFields(MarcDirectory mrcDir)
        {
            //foreach (var dirEntry in mrcDir.DirEntryList.OrderBy(x => x.Order))
            foreach (var dirEntry in mrcDir.DirEntryList)   // do not reorder LOC mrc files which may have slightly different ordering.
            {
                // skip control fields:
                if (dirEntry.Id.StartsWith("00"))
                    continue;

                var varDataField = MarcViewerTools.GetVariableDataField(dirEntry);
                if (varDataField == null) continue;

                // populate variable data fields table:
                v_RowsVarData.Add(new[] { varDataField.Id, varDataField.ToInd1String(), varDataField.ToInd2String(), varDataField.ToSubfieldString() });
            }

            return true;
        }

        #endregion
    }

    internal class c_ParseException : Exception
    {
        internal c_ParseException() : base() { }
        internal c_ParseException(string v_message) : base(v_message) { }
        internal c_ParseException(string v_message, Exception inner) : base(v_message, inner) { }

        internal c_ParseException(string v_message, c_StatusCode v_statusCode) : base(v_message)
        {
            this.v_statusCode = v_statusCode;
        }

        internal c_StatusCode v_statusCode { get; set; }
    }
}