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
using System.Collections.Generic;
using System.Linq;

namespace viewmarc_lib
{
    internal class MarcLeader
    {
        internal string RecordLength;
        internal string RecordStatus;
        internal string TypeOfRecord;
        internal string BibliographicLevel;
        internal string TypeOfControl;
        internal string CharacterEncodingScheme;
        internal string IndicatorCount;
        internal string SubfieldCodeCount;
        internal string BaseAddressOfData;
        internal string EncodingLevel;
        internal string DescriptiveCatalogingForm;
        internal string MultipartResourceRecordLevel;
        internal string LengthOfLengthOfFieldPortion;
        internal string LengthOfStartingCharacterPositionPortion;
        internal string LengthOfImplementationDefinedPortion;
        internal string Undefined1;

        internal enum MaterialType { Book, ComputerFile, Map, Music, ContinuingResource, VisualMaterial, MixedMaterial }
        internal MaterialType materialType;

        internal MarcLeader(string mrcContent)
        {
            var charList = mrcContent.ToCharArray().ToList().GetRange(0, 24);

            RecordLength = string.Join("", charList.GetRange(0, 5));
            RecordStatus = string.Join("", charList.GetRange(5, 1));
            TypeOfRecord = string.Join("", charList.GetRange(6, 1));
            BibliographicLevel = string.Join("", charList.GetRange(7, 1));
            TypeOfControl = string.Join("", charList.GetRange(8, 1));
            CharacterEncodingScheme = string.Join("", charList.GetRange(9, 1));
            IndicatorCount = string.Join("", charList.GetRange(10, 1));
            SubfieldCodeCount = string.Join("", charList.GetRange(11, 1));
            BaseAddressOfData = string.Join("", charList.GetRange(12, 5));
            EncodingLevel = string.Join("", charList.GetRange(17, 1));
            DescriptiveCatalogingForm = string.Join("", charList.GetRange(18, 1));
            MultipartResourceRecordLevel = string.Join("", charList.GetRange(19, 1));
            LengthOfLengthOfFieldPortion = string.Join("", charList.GetRange(20, 1));
            LengthOfStartingCharacterPositionPortion = string.Join("", charList.GetRange(21, 1));
            LengthOfImplementationDefinedPortion = string.Join("", charList.GetRange(22, 1));
            Undefined1 = string.Join("", charList.GetRange(23, 1));
        }

        internal string[][] GetLdrArray()
        {
            var strList = new[]
            {
                new[] { "LDR [0-4]", "Record length", "", RecordLength },
                new[] { "LDR [5]", "Record status", "Rec stat", RecordStatus },
                new[] { "LDR [6]", "Type of record", "Type", TypeOfRecord },
                new[] { "LDR [7]", "Bibliographic level", "BLvl", BibliographicLevel },
                new[] { "LDR [8]", "Type of control", "Ctrl", TypeOfControl },
                new[] { "LDR [9]", "Character coding scheme", "", CharacterEncodingScheme },
                new[] { "LDR [10]", "Indicator count", "", IndicatorCount },
                new[] { "LDR [11]", "Subfield code count", "", SubfieldCodeCount },
                new[] { "LDR [12-16]", "Base address of data", "", BaseAddressOfData },
                new[] { "LDR [17]", "Encoding level", "ELvl", EncodingLevel },
                new[] { "LDR [18]", "Descriptive cataloging form", "Desc", DescriptiveCatalogingForm },
                new[] { "LDR [19]", "Multipart resource record level", "", MultipartResourceRecordLevel },
                new[] { "LDR [20]", "Length of length-of-field portion", "", LengthOfLengthOfFieldPortion },
                new[] { "LDR [21]", "Length of starting-character-position portion", "", LengthOfStartingCharacterPositionPortion },
                new[] { "LDR [22]", "Length of implementation-defined portion", "", LengthOfImplementationDefinedPortion },
                new[] { "LDR [23]", "Undefined", "", Undefined1 },
            };
            return strList;
        }

        internal string[][] GetPropertyArray()
        {
            // detect material type:
            if ((TypeOfRecord == "a" || TypeOfRecord == "t") && (BibliographicLevel == "a" || BibliographicLevel == "c" || BibliographicLevel == "d" || BibliographicLevel == "m")) materialType = MaterialType.Book;
            else if (TypeOfRecord == "m") materialType = MaterialType.ComputerFile;
            else if ((TypeOfRecord == "a") && (BibliographicLevel == "b" || BibliographicLevel == "i" || BibliographicLevel == "s")) materialType = MaterialType.ContinuingResource;
            else if (TypeOfRecord == "e" || TypeOfRecord == "f") materialType = MaterialType.Map;
            else if (TypeOfRecord == "p") materialType = MaterialType.MixedMaterial;
            else if (TypeOfRecord == "c" || TypeOfRecord == "d" || TypeOfRecord == "i" || TypeOfRecord == "j") materialType = MaterialType.Music;
            else if (TypeOfRecord == "g" || TypeOfRecord == "k" || TypeOfRecord == "o" || TypeOfRecord == "r") materialType = MaterialType.VisualMaterial;

            var strList = new[]
            {
                new[] { "MaterialType", materialType.ToString() },
            };
            return strList;
        }
    }
}
