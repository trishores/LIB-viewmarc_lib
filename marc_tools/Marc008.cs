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
    internal class Marc008
    {
        internal string DateCreated;
        internal string DateTypePublicationStatus;
        internal string PublicationYear;
        internal string CopyrightYear;
        internal string PublicationCountry;
        internal c_Material Material;
        internal string LanguageCode;
        internal string ModifiedRecord;
        internal string CatalogingSource;

        #region marc 008

        internal Marc008(MarcLeader.MaterialType materialType, List<char> charList)
        {
            // common fields:
            DateCreated = string.Join("", charList.GetRange(0, 6));
            DateTypePublicationStatus = string.Join("", charList.GetRange(6, 1));
            PublicationYear = string.Join("", charList.GetRange(7, 4));
            CopyrightYear = string.Join("", charList.GetRange(11, 4));
            PublicationCountry = string.Join("", charList.GetRange(15, 3));

            // specific material fields:
            if (materialType == MarcLeader.MaterialType.Book) Material = new c_Book(charList);
            else if (materialType == MarcLeader.MaterialType.ComputerFile) Material = new c_ComputerFile(charList);
            else if (materialType == MarcLeader.MaterialType.ContinuingResource) Material = new c_ContinuingResource(charList);
            else if (materialType == MarcLeader.MaterialType.Map) Material = new c_Map(charList);
            else if (materialType == MarcLeader.MaterialType.MixedMaterial) Material = new c_MixedMaterial(charList);
            else if (materialType == MarcLeader.MaterialType.Music) Material = new c_Music(charList);
            else if (materialType == MarcLeader.MaterialType.VisualMaterial) Material = new c_VisualMaterial(charList);

            // common fields:
            LanguageCode = string.Join("", charList.GetRange(35, 3));
            ModifiedRecord = string.Join("", charList.GetRange(38, 1));
            CatalogingSource = string.Join("", charList.GetRange(39, 1));
        }

        internal string[][] GetCtrlArray()
        {
            var strList = new List<string[]>();

            strList.Add(new[] { "008 [0-5]", "Date created", "Entered", DateCreated });
            strList.Add(new[] { "008 [6]", "Type of date / publication status", "DtSt", DateTypePublicationStatus });
            strList.Add(new[] { "008 [7-10]", "Date 1", "Dates", PublicationYear });
            strList.Add(new[] { "008 [11-14]", "Date 2", "Dates", CopyrightYear });
            strList.Add(new[] { "008 [15-17]", "Country of publication etc.", "Ctry", PublicationCountry });
            strList.AddRange(Material.GetCtrlArray());
            strList.Add(new[] { "008 [35-37]", "Language code", "Lang", LanguageCode });
            strList.Add(new[] { "008 [38]", "Modified record", "MRec", ModifiedRecord });
            strList.Add(new[] { "008 [39]", "Cataloging source", "Srce", CatalogingSource });

            return strList.ToArray();
        }

        #endregion

        #region book

        private class c_Book : c_Material
        {
            internal string Illustrations;
            internal string TargetAudience;
            internal string ItemForm;
            internal string ContentNature;
            internal string GovernmentPublication;
            internal string ConferencePublication;
            internal string Festschrift;
            internal string Index;
            internal string Undefined1;
            internal string LiteraryForm;
            internal string Biography;

            public c_Book(List<char> charList)
            {
                Illustrations = string.Join("", charList.GetRange(18, 4));
                TargetAudience = string.Join("", charList.GetRange(22, 1));
                ItemForm = string.Join("", charList.GetRange(23, 1));
                ContentNature = string.Join("", charList.GetRange(24, 4));
                GovernmentPublication = string.Join("", charList.GetRange(28, 1));
                ConferencePublication = string.Join("", charList.GetRange(29, 1));
                Festschrift = string.Join("", charList.GetRange(30, 1));
                Index = string.Join("", charList.GetRange(31, 1));
                Undefined1 = string.Join("", charList.GetRange(32, 1));
                LiteraryForm = string.Join("", charList.GetRange(33, 1));
                Biography = string.Join("", charList.GetRange(34, 1));
            }

            internal override string[][] GetCtrlArray()
            {
                var strList = new[]
                {
                    new[] { "008 [18-21]", "Illustrations", "Ills", Illustrations },
                    new[] { "008 [22]", "Target audience", "Audn", TargetAudience },
                    new[] { "008 [23]", "Form of item", "Form", ItemForm },
                    new[] { "008 [24-27]", "Nature of contents", "Cont", ContentNature },
                    new[] { "008 [28]", "Government publication", "GPub", GovernmentPublication },
                    new[] { "008 [29]", "Conference publication", "Conf", ConferencePublication },
                    new[] { "008 [30]", "Festschrift", "Fest", Festschrift },
                    new[] { "008 [31]", "Index", "Indx", Index },
                    new[] { "008 [32]", "Undefined", "", Undefined1 },
                    new[] { "008 [33]", "Literary form", "LitF", LiteraryForm },
                    new[] { "008 [34]", "Biography", "Biog", Biography },
                };
                return strList;
            }
        }

        #endregion

        #region computer file

        private class c_ComputerFile : c_Material
        {
            internal string Undefined1;
            internal string TargetAudience;
            internal string FormOfItem;
            internal string Undefined2;
            internal string TypeOfComputerFile;
            internal string Undefined3;
            internal string GovernmentPublication;
            internal string Undefined4;

            public c_ComputerFile(List<char> charList)
            {
                Undefined1 = string.Join("", charList.GetRange(18, 4));
                TargetAudience = string.Join("", charList.GetRange(22, 1));
                FormOfItem = string.Join("", charList.GetRange(23, 1));
                Undefined2 = string.Join("", charList.GetRange(24, 2));
                TypeOfComputerFile = string.Join("", charList.GetRange(26, 1));
                Undefined3 = string.Join("", charList.GetRange(27, 1));
                GovernmentPublication = string.Join("", charList.GetRange(28, 1));
                Undefined4 = string.Join("", charList.GetRange(29, 6));
            }

            internal override string[][] GetCtrlArray()
            {
                var strList = new[]
                {
                    new[] { "008 [18-21]","Undefined", "", Undefined1 },
                    new[] { "008 [22]","Target audience", "Audn", TargetAudience },
                    new[] { "008 [23]","Form of item", "Form", FormOfItem },
                    new[] { "008 [24-25]","Undefined", "", Undefined2 },
                    new[] { "008 [26]","Type of computer file", "File", TypeOfComputerFile },
                    new[] { "008 [27]","Undefined", "", Undefined3 },
                    new[] { "008 [28]","Government publication", "GPub", GovernmentPublication },
                    new[] { "008 [29-34]","Undefined", "", Undefined4 },
                };
                return strList;
            }
        }

        #endregion

        #region continuing resource (serial)

        private class c_ContinuingResource : c_Material
        {
            internal string Frequency;
            internal string Regularity;
            internal string Undefined1;
            internal string TypeOfContinuingResource;
            internal string FormOfOriginalItem;
            internal string FormOfItem;
            internal string NatureOfEntireWork;
            internal string NatureOfContents;
            internal string GovernmentPublication;
            internal string ConferencePublication;
            internal string Undefined2;
            internal string OriginalAlphabetOrScriptOfTitle;
            internal string EntryConvention;

            public c_ContinuingResource(List<char> charList)
            {
                Frequency = string.Join("", charList.GetRange(18, 1));
                Regularity = string.Join("", charList.GetRange(19, 1));
                Undefined1 = string.Join("", charList.GetRange(20, 1));
                TypeOfContinuingResource = string.Join("", charList.GetRange(21, 1));
                FormOfOriginalItem = string.Join("", charList.GetRange(22, 1));
                FormOfItem = string.Join("", charList.GetRange(23, 1));
                NatureOfEntireWork = string.Join("", charList.GetRange(24, 1));
                NatureOfContents = string.Join("", charList.GetRange(25, 3));
                GovernmentPublication = string.Join("", charList.GetRange(28, 1));
                ConferencePublication = string.Join("", charList.GetRange(29, 1));
                Undefined2 = string.Join("", charList.GetRange(30, 3));
                OriginalAlphabetOrScriptOfTitle = string.Join("", charList.GetRange(33, 1));
                EntryConvention = string.Join("", charList.GetRange(34, 1));
            }

            internal override string[][] GetCtrlArray()
            {
                var strList = new[]
                {
                    new[] { "008 [18]","Frequency", "Freq", Frequency },
                    new[] { "008 [19]","Regularity", "Regl", Regularity },
                    new[] { "008 [20]","Undefined", "", Undefined1 },
                    new[] { "008 [21]","Type of continuing resource", "SrTp", TypeOfContinuingResource },
                    new[] { "008 [22]","Form of original item", "Orig", FormOfOriginalItem },
                    new[] { "008 [23]","Form of item", "Form", FormOfItem },
                    new[] { "008 [24]","Nature of entire work", "EntW", NatureOfEntireWork },
                    new[] { "008 [25-27]","Nature of contents", "Cont", NatureOfContents },
                    new[] { "008 [28]","Government publication", "GPub", GovernmentPublication },
                    new[] { "008 [29]","Conference publication", "Conf", ConferencePublication },
                    new[] { "008 [30-32]","Undefined", "", Undefined2 },
                    new[] { "008 [33]","Original alphabet or script of title", "Alph", OriginalAlphabetOrScriptOfTitle },
                    new[] { "008 [34]","Entry convention", "S/L", EntryConvention },
                };
                return strList;
            }
        }

        #endregion

        #region map

        private class c_Map : c_Material
        {
            internal string Relief;
            internal string Projection;
            internal string Undefined1;
            internal string TypeOfCartographicMaterial;
            internal string Undefined2;
            internal string GovernmentPublication;
            internal string FormOfItem;
            internal string Undefined3;
            internal string Index;
            internal string Undefined4;
            internal string SpecialFormatCharacteristics;

            public c_Map(List<char> charList)
            {
                Relief = string.Join("", charList.GetRange(18, 4));
                Projection = string.Join("", charList.GetRange(22, 2));
                Undefined1 = string.Join("", charList.GetRange(24, 1));
                TypeOfCartographicMaterial = string.Join("", charList.GetRange(25, 1));
                Undefined2 = string.Join("", charList.GetRange(26, 2));
                GovernmentPublication = string.Join("", charList.GetRange(28, 1));
                FormOfItem = string.Join("", charList.GetRange(29, 1));
                Undefined3 = string.Join("", charList.GetRange(30, 1));
                Index = string.Join("", charList.GetRange(31, 1));
                Undefined4 = string.Join("", charList.GetRange(32, 1));
                SpecialFormatCharacteristics = string.Join("", charList.GetRange(33, 2));
            }

            internal override string[][] GetCtrlArray()
            {
                var strList = new[]
                {
                    new[] { "008 [18-21]","Relief", "Relf", Relief },
                    new[] { "008 [22-23]","Projection", "Proj", Projection },
                    new[] { "008 [24]","Undefined", "", Undefined1 },
                    new[] { "008 [25]","Type of cartographic material", "CrTp", TypeOfCartographicMaterial },
                    new[] { "008 [26-27]","Undefined", "", Undefined2 },
                    new[] { "008 [28]","Government publication", "GPub", GovernmentPublication },
                    new[] { "008 [29]","Form of item", "Form", FormOfItem },
                    new[] { "008 [30]","Undefined", "", Undefined3 },
                    new[] { "008 [31]","Index", "Indx", Index },
                    new[] { "008 [32]","Undefined", "", Undefined4 },
                    new[] { "008 [33-34]","Special format characteristics", "SpFm", SpecialFormatCharacteristics },
                };
                return strList;
            }
        }

        #endregion

        #region mixed material

        private class c_MixedMaterial : c_Material
        {
            internal string Undefined1;
            internal string FormOfItem;
            internal string Undefined2;

            public c_MixedMaterial(List<char> charList)
            {
                Undefined1 = string.Join("", charList.GetRange(18, 5));
                FormOfItem = string.Join("", charList.GetRange(23, 1));
                Undefined2 = string.Join("", charList.GetRange(24, 11));
            }

            internal override string[][] GetCtrlArray()
            {
                var strList = new[]
                {
                    new[] { "008 [18-22]","Undefined", "", Undefined1 },
                    new[] { "008 [23]","Form of item", "Form", FormOfItem },
                    new[] { "008 [24-34]","Undefined", "", Undefined2 },
                };
                return strList;
            }
        }

        #endregion

        #region music

        private class c_Music : c_Material
        {
            internal string FormOfComposition;
            internal string FormatOfMusic;
            internal string MusicParts;
            internal string TargetAudience;
            internal string FormOfItem;
            internal string AccompanyingMatter;
            internal string LiteraryTextForSoundRecordings;
            internal string Undefined1;
            internal string TranspositionAndArrangement;
            internal string Undefined2;

            public c_Music(List<char> charList)
            {
                FormOfComposition = string.Join("", charList.GetRange(18, 2));
                FormatOfMusic = string.Join("", charList.GetRange(20, 1));
                MusicParts = string.Join("", charList.GetRange(21, 1));
                TargetAudience = string.Join("", charList.GetRange(22, 1));
                FormOfItem = string.Join("", charList.GetRange(23, 1));
                AccompanyingMatter = string.Join("", charList.GetRange(24, 6));
                LiteraryTextForSoundRecordings = string.Join("", charList.GetRange(30, 2));
                Undefined1 = string.Join("", charList.GetRange(32, 1));
                TranspositionAndArrangement = string.Join("", charList.GetRange(33, 1));
                Undefined2 = string.Join("", charList.GetRange(34, 1));
            }

            internal override string[][] GetCtrlArray()
            {
                var strList = new[]
                {
                    new[] { "008 [18-19]","Form of composition", "Comp", FormOfComposition },
                    new[] { "008 [20]","Format of music", "FMus", FormatOfMusic },
                    new[] { "008 [21]","Music parts", "Part", MusicParts },
                    new[] { "008 [22]","Target audience", "Audn", TargetAudience },
                    new[] { "008 [23]","Form of item", "Form", FormOfItem },
                    new[] { "008 [24-29]","Accompanying matter", "AccM", AccompanyingMatter },
                    new[] { "008 [30-31]","Literary text for sound recordings", "LTxt", LiteraryTextForSoundRecordings },
                    new[] { "008 [32]","Undefined", "", Undefined1 },
                    new[] { "008 [33]","Transposition and arrangement", "TrAr", TranspositionAndArrangement },
                    new[] { "008 [34]","Undefined", "", Undefined2 },
                };
                return strList;
            }
        }

        #endregion

        #region visual material (film)

        private class c_VisualMaterial : c_Material
        {
            internal string RunningTimeForMotionPicturesAndVideorecordings;
            internal string Undefined1;
            internal string TargetAudience;
            internal string Undefined2;
            internal string GovernmentPublication;
            internal string FormOfItem;
            internal string Undefined3;
            internal string TypeOfVisualMaterial;
            internal string Technique;

            public c_VisualMaterial(List<char> charList)
            {
                RunningTimeForMotionPicturesAndVideorecordings = string.Join("", charList.GetRange(18, 3));
                Undefined1 = string.Join("", charList.GetRange(21, 1));
                TargetAudience = string.Join("", charList.GetRange(22, 1));
                Undefined2 = string.Join("", charList.GetRange(23, 5));
                GovernmentPublication = string.Join("", charList.GetRange(28, 1));
                FormOfItem = string.Join("", charList.GetRange(29, 1));
                Undefined3 = string.Join("", charList.GetRange(30, 3));
                TypeOfVisualMaterial = string.Join("", charList.GetRange(33, 1));
                Technique = string.Join("", charList.GetRange(34, 1));
            }

            internal override string[][] GetCtrlArray()
            {
                var strList = new[]
                {
                    new[] { "008 [18-20]","Running time", "Time", RunningTimeForMotionPicturesAndVideorecordings },
                    new[] { "008 [21]","Undefined", "", Undefined1 },
                    new[] { "008 [22]","Target audience", "Audn", TargetAudience },
                    new[] { "008 [23-27]","Undefined", "", Undefined2 },
                    new[] { "008 [28]","Government publication", "GPub", GovernmentPublication },
                    new[] { "008 [29]","Form of item", "Form", FormOfItem },
                    new[] { "008 [30-32]","Undefined", "", Undefined3 },
                    new[] { "008 [33]","Type of visual material", "TMat", TypeOfVisualMaterial },
                    new[] { "008 [34]","Technique", "Tech", Technique },
                };
                return strList;
            }
        }

        #endregion

        #region material

        internal abstract class c_Material
        {
            internal virtual string[][] GetCtrlArray() { return null; }
        }

        #endregion
    }
}
