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
    internal class Marc006
    {
        internal string MaterialForm;
        internal c_Material Material;

        #region 006

        internal Marc006(List<char> charList)
        {
            if (charList == null) return;

            MaterialForm = string.Join("", charList.GetRange(0, 1));    // Form of material
            if (MaterialForm == "a" || MaterialForm == "t") Material = new c_Books(charList);
            else if (MaterialForm == "m") Material = new c_Electronic(charList);
            else if (MaterialForm == "e" || MaterialForm == "f") Material = new c_Maps(charList);
            else if (MaterialForm == "p") Material = new c_MixedMat(charList);
            else if (MaterialForm == "c" || MaterialForm == "d" || MaterialForm == "i" || MaterialForm == "j") Material = new c_Music(charList);
            else if (MaterialForm == "s") Material = new c_ContResource(charList);
            else if (MaterialForm == "g" || MaterialForm == "k" || MaterialForm == "o" || MaterialForm == "r") Material = new c_VisualMat(charList);
        }

        #endregion

        #region book

        internal class c_Books : c_Material
        {
            internal string MaterialForm;
            internal string Illustrations;
            internal string TargetAudience;
            internal string ItemForm;
            internal string ContNature;
            internal string GovtPub;
            internal string ConfPub;
            internal string Festschrift;
            internal string Index;
            internal string Undefined1;
            internal string LiteraryForm;
            internal string Biography;

            internal c_Books(List<char> charList)
            {
                MaterialForm = string.Join("", charList.GetRange(0, 1));
                Illustrations = string.Join("", charList.GetRange(1, 4));
                TargetAudience = string.Join("", charList.GetRange(5, 1));
                ItemForm = string.Join("", charList.GetRange(6, 1));
                ContNature = string.Join("", charList.GetRange(7, 4));
                GovtPub = string.Join("", charList.GetRange(11, 1));
                ConfPub = string.Join("", charList.GetRange(12, 1));
                Festschrift = string.Join("", charList.GetRange(13, 1));
                Index = string.Join("", charList.GetRange(14, 1));
                Undefined1 = string.Join("", charList.GetRange(15, 1));
                LiteraryForm = string.Join("", charList.GetRange(16, 1));
                Biography = string.Join("", charList.GetRange(17, 1));
            }

            internal override string[][] GetCtrlArray()
            {
                var strList = new[]
                {
                    new[] { "006 [0]", "Form of material", "", MaterialForm },
                    new[] { "006 [1-4]", "Illustrations", "Ills", Illustrations },
                    new[] { "006 [5]", "Target audience", "Audn", TargetAudience },
                    new[] { "006 [6]", "Form of item", "Form", ItemForm },
                    new[] { "006 [7-10]", "Nature of contents", "Cont", ContNature },
                    new[] { "006 [11]", "Government publication", "Gpub", GovtPub },
                    new[] { "006 [12]", "Conference publication", "Conf", ConfPub },
                    new[] { "006 [13]", "Festschrift", "Fest", Festschrift },
                    new[] { "006 [14]", "Index", "Indx", Index },
                    new[] { "006 [15]", "Undefined", "", Undefined1 },
                    new[] { "006 [16]", "Literary form", "LitF", LiteraryForm },
                    new[] { "006 [17]", "Biography", "Biog", Biography },
                };
                return strList;
            }
        }

        #endregion

        #region electronic

        internal class c_Electronic : c_Material
        {
            internal string MaterialForm;
            internal string Undefined1;
            internal string TargetAudience;
            internal string ItemForm;
            internal string Undefined2;
            internal string CompFileType;
            internal string Undefined3;
            internal string GovtPub;
            internal string Undefined4;

            internal c_Electronic(List<char> charList)
            {
                MaterialForm = string.Join("", charList.GetRange(0, 1));
                Undefined1 = string.Join("", charList.GetRange(1, 4));
                TargetAudience = string.Join("", charList.GetRange(5, 1));
                ItemForm = string.Join("", charList.GetRange(6, 1));
                Undefined2 = string.Join("", charList.GetRange(7, 2));
                CompFileType = string.Join("", charList.GetRange(9, 1));
                Undefined3 = string.Join("", charList.GetRange(10, 1));
                GovtPub = string.Join("", charList.GetRange(11, 1));
                Undefined4 = string.Join("", charList.GetRange(12, 6));
            }

            internal override string[][] GetCtrlArray()
            {
                var strList = new[]
                {
                    new[] { "006 [0]", "Form of material", "", MaterialForm },
                    new[] { "006 [1-4]", "Undefined", "", Undefined1 },
                    new[] { "006 [5]", "Target audience", "Audn", TargetAudience },
                    new[] { "006 [6]", "Form of item", "Form", ItemForm },
                    new[] { "006 [7-8]", "Undefined", "", Undefined2 },
                    new[] { "006 [9]", "Type of computer file", "File", CompFileType },
                    new[] { "006 [10]", "Undefined", "", Undefined3 },
                    new[] { "006 [11]", "Government publication", "GPub", GovtPub },
                    new[] { "006 [12-17]", "Undefined", "", Undefined4 },
                };
                return strList;
            }
        }

        #endregion

        #region map

        internal class c_Maps : c_Material
        {
            internal string MaterialForm;
            internal string Relief;
            internal string Projection;
            internal string Undefined1;
            internal string CartographMat;
            internal string Undefined2;
            internal string GovPub;
            internal string ItemForm;
            internal string Undefined3;
            internal string Index;
            internal string Undefined4;
            internal string SpecFormat;

            internal c_Maps(List<char> charList)
            {
                MaterialForm = string.Join("", charList.GetRange(0, 1));
                Relief = string.Join("", charList.GetRange(1, 4));
                Projection = string.Join("", charList.GetRange(5, 2));
                Undefined1 = string.Join("", charList.GetRange(7, 1));
                CartographMat = string.Join("", charList.GetRange(8, 1));
                Undefined2 = string.Join("", charList.GetRange(9, 2));
                GovPub = string.Join("", charList.GetRange(11, 1));
                ItemForm = string.Join("", charList.GetRange(12, 1));
                Undefined3 = string.Join("", charList.GetRange(13, 1));
                Index = string.Join("", charList.GetRange(14, 1));
                Undefined4 = string.Join("", charList.GetRange(15, 1));
                SpecFormat = string.Join("", charList.GetRange(16, 2));
            }

            internal override string[][] GetCtrlArray()
            {
                var strList = new[]
                {
                    new[] { "006 [0]", "Form of material", "", MaterialForm },
                    new[] { "006 [1-4]", "Relief", "Relf", Relief },
                    new[] { "006 [5-6]", "Projection", "Proj", Projection },
                    new[] { "006 [7]", "Undefined", "", Undefined1 },
                    new[] { "006 [8]", "Type of cartographic material", "CrTp", CartographMat },
                    new[] { "006 [9-10]", "Undefined", "", Undefined2 },
                    new[] { "006 [11]", "Government publication", "GPub", GovPub },
                    new[] { "006 [12]", "Form of item", "Form", ItemForm },
                    new[] { "006 [13]", "Undefined", "", Undefined3 },
                    new[] { "006 [14]", "Index", "Indx", Index },
                    new[] { "006 [15]", "Undefined", "", Undefined4 },
                    new[] { "006 [16-17]", "Special format characteristics", "SpFm", SpecFormat },
                };
                return strList;
            }
        }

        #endregion

        #region mixed material

        internal class c_MixedMat : c_Material
        {
            internal string MaterialForm;
            internal string Undefined1;
            internal string ItemForm;
            internal string Undefined2;


  
            internal c_MixedMat(List<char> charList)
            {
                MaterialForm = string.Join("", charList.GetRange(0, 1));
                Undefined1 = string.Join("", charList.GetRange(1, 5));
                ItemForm = string.Join("", charList.GetRange(6, 1));
                Undefined2 = string.Join("", charList.GetRange(7, 11));
            }

            internal override string[][] GetCtrlArray()
            {
                var strList = new[]
                {
                    new[] { "006 [0]", "Form of material", "", MaterialForm },
                    new[] { "006 [1-5]", "Undefined", "", Undefined1 },
                    new[] { "006 [6]", "Form of item", "Form", ItemForm },
                    new[] { "006 [7-17]", "Undefined", "", Undefined2 },
                };
                return strList;
            }
        }

        #endregion

        #region music

        internal class c_Music : c_Material
        {
            internal string MaterialForm;
            internal string CompositionForm;
            internal string MusicFormat;
            internal string MusicParts;
            internal string TargetAudience;
            internal string ItemForm;
            internal string AccompMat;
            internal string LitTextSoundRec;
            internal string Undefined1;
            internal string TranspArrangement;
            internal string Undefined2;
            
            internal c_Music(List<char> charList)
            {
                MaterialForm = string.Join("", charList.GetRange(0, 1));
                CompositionForm = string.Join("", charList.GetRange(1, 2));
                MusicFormat = string.Join("", charList.GetRange(3, 1));
                MusicParts = string.Join("", charList.GetRange(4, 1));
                TargetAudience = string.Join("", charList.GetRange(5, 1));
                ItemForm = string.Join("", charList.GetRange(6, 1));
                AccompMat = string.Join("", charList.GetRange(7, 6));
                LitTextSoundRec = string.Join("", charList.GetRange(13, 2));
                Undefined1 = string.Join("", charList.GetRange(15, 1));
                TranspArrangement = string.Join("", charList.GetRange(16, 1));
                Undefined2 = string.Join("", charList.GetRange(17, 1));
            }

            internal override string[][] GetCtrlArray()
            {
                var strList = new[]
                {
                    new[] { "006 [0]", "Form of material", "", MaterialForm },
                    new[] { "006 [1-2]", "Form of composition", "Comp", CompositionForm },
                    new[] { "006 [3]", "Format of music", "FMus", MusicFormat },
                    new[] { "006 [4]", "Music parts", "Part", MusicParts },
                    new[] { "006 [5]", "Target audience", "Audn", TargetAudience },
                    new[] { "006 [6]", "Form of item", "Form", ItemForm },
                    new[] { "006 [7-12]", "Accompanying matter", "AccM", AccompMat },
                    new[] { "006 [13-14]", "Literary text for sound recordings", "LTxt", LitTextSoundRec },
                    new[] { "006 [15]", "Undefined", "", Undefined1 },
                    new[] { "006 [16]", "Transposition and arrangement", "TrAr", TranspArrangement },
                    new[] { "006 [17]", "Undefined", "", Undefined2 },
                };
                return strList;
            }
        }

        #endregion

        #region continuing resources

        internal class c_ContResource : c_Material
        {
            internal string MaterialForm;
            internal string Frequency;
            internal string Regularity;
            internal string Undefined1;
            internal string ContResourceType;
            internal string OrigItemForm;
            internal string ItemForm;
            internal string EntireWorkNature;
            internal string ContentsNature;
            internal string GovPub;
            internal string ConfPub;
            internal string Undefined2;
            internal string OrigAlphTitleScript;
            internal string EntryConvention;

            internal c_ContResource(List<char> charList)
            {
                MaterialForm = string.Join("", charList.GetRange(0, 1));
                Frequency = string.Join("", charList.GetRange(1, 1));
                Regularity = string.Join("", charList.GetRange(2, 1));
                Undefined1 = string.Join("", charList.GetRange(3, 1));
                ContResourceType = string.Join("", charList.GetRange(4, 1));
                OrigItemForm = string.Join("", charList.GetRange(5, 1));
                ItemForm = string.Join("", charList.GetRange(6, 1));
                EntireWorkNature = string.Join("", charList.GetRange(7, 1));
                ContentsNature = string.Join("", charList.GetRange(8, 3));
                GovPub = string.Join("", charList.GetRange(11, 1));
                ConfPub = string.Join("", charList.GetRange(12, 1));
                Undefined2 = string.Join("", charList.GetRange(13, 3));
                OrigAlphTitleScript = string.Join("", charList.GetRange(16, 1));
                EntryConvention = string.Join("", charList.GetRange(17, 1));
            }

            internal override string[][] GetCtrlArray()
            {
                var strList = new[]
                {
                    new[] { "006 [0]", "Form of material", "", MaterialForm },
                    new[] { "006 [1]", "Frequency", "Freq", Frequency },
                    new[] { "006 [2]", "Regularity", "Regl", Regularity },
                    new[] { "006 [3]", "Undefined", "", Undefined1 },
                    new[] { "006 [4]", "Type of continuing resource", "SrTp", ContResourceType },
                    new[] { "006 [5]", "Form of original item", "Orig", OrigItemForm },
                    new[] { "006 [6]", "Form of item", "Form", ItemForm },
                    new[] { "006 [7]", "Nature of entire work", "EntW", EntireWorkNature },
                    new[] { "006 [8-10]", "Nature of contents", "Cont", ContentsNature },
                    new[] { "006 [11]", "Government publication", "GPub", GovPub },
                    new[] { "006 [12]", "Conference publication", "Conf", ConfPub },
                    new[] { "006 [13-15]", "Undefined", "", Undefined2 },
                    new[] { "006 [16]", "Original alphabet or script of title", "Alph", OrigAlphTitleScript },
                    new[] { "006 [17]", "Entry convention", "S/L", EntryConvention },
                };
                return strList;
            }
        }

        #endregion

        #region visual material

        internal class c_VisualMat : c_Material
        {
            internal string MaterialForm;
            internal string RunningTime;
            internal string Undefined1;
            internal string TargetAudience;
            internal string Undefined2;
            internal string GovtPub;
            internal string ItemForm;
            internal string Undefined3;
            internal string VisualMaterialType;
            internal string Technique;

            internal c_VisualMat(List<char> charList)
            {
                MaterialForm = string.Join("", charList.GetRange(0, 1));
                RunningTime = string.Join("", charList.GetRange(1, 3));
                Undefined1 = string.Join("", charList.GetRange(4, 1));
                TargetAudience = string.Join("", charList.GetRange(5, 1));
                Undefined2 = string.Join("", charList.GetRange(6, 5));
                GovtPub = string.Join("", charList.GetRange(11, 1));
                ItemForm = string.Join("", charList.GetRange(12, 1));
                Undefined3 = string.Join("", charList.GetRange(13, 3));
                VisualMaterialType = string.Join("", charList.GetRange(16, 1));
                Technique = string.Join("", charList.GetRange(17, 1));
            }

            internal override string[][] GetCtrlArray()
            {
                var strList = new[]
                {
                    new[] { "006 [0]", "Form of material", "", MaterialForm },
                    new[] { "006 [1-3]", "Running time", "Time", RunningTime },
                    new[] { "006 [4]", "Undefined", "", Undefined1 },
                    new[] { "006 [5]", "Target audience", "Audn", TargetAudience },
                    new[] { "006 [6-10]", "Undefined", "", Undefined2 },
                    new[] { "006 [11]", "Government publication", "GPub", GovtPub },
                    new[] { "006 [12]", "Form of item", "Form", ItemForm },
                    new[] { "006 [13-15]", "Undefined", "", Undefined3 },
                    new[] { "006 [16]", "Type of visual material", "TMat", VisualMaterialType },
                    new[] { "006 [17]", "Technique", "Tech", Technique },
                };
                return strList;
            }
        }

        #endregion

        #region material

        internal abstract class c_Material 
        {
            internal abstract string[][] GetCtrlArray();
        }

        #endregion
    }
}
