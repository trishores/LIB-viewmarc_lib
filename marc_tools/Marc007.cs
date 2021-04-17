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
    internal class Marc007
    {
        #region 007

        internal string MaterialCategory;
        internal c_Material Material;

        internal Marc007(List<char> charList)
        {
            MaterialCategory = string.Join("", charList.GetRange(0, 1));    // material category
            if (MaterialCategory == "a") Material = new c_Map(charList);
            else if (MaterialCategory == "c") Material = new c_Electronic(charList);
            else if (MaterialCategory == "d") Material = new c_Globe(charList);
            else if (MaterialCategory == "f") Material = new c_TactileMat(charList);
            else if (MaterialCategory == "g") Material = new c_ProjectedGraphic(charList);
            else if (MaterialCategory == "h") Material = new c_Microform(charList);
            else if (MaterialCategory == "k") Material = new c_NonprojectedGraphic(charList);
            else if (MaterialCategory == "m") Material = new c_MotionPicture(charList);
            else if (MaterialCategory == "o") Material = new c_Kit(charList);
            else if (MaterialCategory == "q") Material = new c_NotatedMusic(charList);
            else if (MaterialCategory == "r") Material = new c_RemoteSensingImage(charList);
            else if (MaterialCategory == "s") Material = new c_SoundRecording(charList);
            else if (MaterialCategory == "t") Material = new c_Text(charList);
            else if (MaterialCategory == "v") Material = new c_VideoRecording(charList);
            else if (MaterialCategory == "z") Material = new c_Unspecified(charList);
        }

        #endregion

        #region map

        internal class c_Map : c_Material
        {
            internal string MaterialCat;
            internal string SpecificMatDesign;
            internal string Undefined1;
            internal string Color;
            internal string PhysicalMedium;
            internal string ReproType;
            internal string ProductionReproDetails;
            internal string PositiveNegativeAspect;

            internal c_Map(List<char> charList)
            {
                MaterialCat = string.Join("", charList.GetRange(0, 1));
                SpecificMatDesign = string.Join("", charList.GetRange(1, 1));
                Undefined1 = string.Join("", charList.GetRange(2, 1));
                Color = string.Join("", charList.GetRange(3, 1));
                PhysicalMedium = string.Join("", charList.GetRange(4, 1));
                ReproType = string.Join("", charList.GetRange(5, 1));
                ProductionReproDetails = string.Join("", charList.GetRange(6, 1));
                PositiveNegativeAspect = string.Join("", charList.GetRange(7, 1));
            }

            internal override string[][] GetCtrlArray()
            {
                var strList = new[]
                {
                    new[] { "007 [0]", "Category of material", "", MaterialCat },
                    new[] { "007 [1]", "Specific material designation", "", SpecificMatDesign },
                    new[] { "007 [2]", "Undefined", "", Undefined1 },
                    new[] { "007 [3]", "Color", "", Color },
                    new[] { "007 [4]", "Physical medium", "", PhysicalMedium },
                    new[] { "007 [5]", "Type of reproduction", "", ReproType },
                    new[] { "007 [6]", "Production/reproduction details", "", ProductionReproDetails },
                    new[] { "007 [7]", "Positive/negative aspect", "", PositiveNegativeAspect },
                };
                return strList;
            }
        }

        #endregion

        #region electronic

        internal class c_Electronic : c_Material
        {
            internal string MaterialCat;
            internal string SpecificMatDesign;
            internal string Undefined1;
            internal string Color;
            internal string Dimensions;
            internal string Sound;
            internal string ImageBitDepth;
            internal string FileFormats;
            internal string QATargets;
            internal string AntecedentSource;
            internal string CompressionLevel;
            internal string ReformattingQuality;

            internal c_Electronic(List<char> charList)
            {
                MaterialCat = string.Join("", charList.GetRange(0, 1));
                SpecificMatDesign = string.Join("", charList.GetRange(1, 1));
                Undefined1 = string.Join("", charList.GetRange(2, 1));
                Color = string.Join("", charList.GetRange(3, 1));
                Dimensions = string.Join("", charList.GetRange(4, 1));
                Sound = string.Join("", charList.GetRange(5, 1));
                ImageBitDepth = string.Join("", charList.GetRange(6, 3));
                FileFormats = string.Join("", charList.GetRange(9, 1));
                QATargets = string.Join("", charList.GetRange(10, 1));
                AntecedentSource = string.Join("", charList.GetRange(11, 1));
                CompressionLevel = string.Join("", charList.GetRange(12, 1));
                ReformattingQuality = string.Join("", charList.GetRange(13, 1));
            }

            internal override string[][] GetCtrlArray()
            {
                var strList = new[]
                {
                    new[] { "007 [0]", "Category of material", "", MaterialCat },
                    new[] { "007 [1]", "Specific material designation", "", SpecificMatDesign },
                    new[] { "007 [2]", "Undefined", "", Undefined1 },
                    new[] { "007 [3]", "Color", "", Color },
                    new[] { "007 [4]", "Dimensions", "", Dimensions },
                    new[] { "007 [5]", "Sound", "", Sound },
                    new[] { "007 [6-8]", "Image bit depth", "", ImageBitDepth },
                    new[] { "007 [9]", "File formats", "", FileFormats },
                    new[] { "007 [10]", "Quality assurance targets", "", QATargets },
                    new[] { "007 [11]", "Antecedent/source", "", AntecedentSource },
                    new[] { "007 [12]", "Level of compression", "", CompressionLevel },
                    new[] { "007 [13]", "Reformatting quality", "", ReformattingQuality },
                };
                return strList;
            }
        }

        #endregion

        #region globe

        internal class c_Globe : c_Material
        {
            internal string MaterialCat;
            internal string SpecificMatDesign;
            internal string Undefined1;
            internal string Color;
            internal string PhysicalMedium;
            internal string ReproType;

            internal c_Globe(List<char> charList)
            {
                MaterialCat = string.Join("", charList.GetRange(0, 1));
                SpecificMatDesign = string.Join("", charList.GetRange(1, 1));
                Undefined1 = string.Join("", charList.GetRange(2, 1));
                Color = string.Join("", charList.GetRange(3, 1));
                PhysicalMedium = string.Join("", charList.GetRange(4, 1));
                ReproType = string.Join("", charList.GetRange(5, 1));
            }

            internal override string[][] GetCtrlArray()
            {
                var strList = new[]
                {
                    new[] { "007 [0]", "Category of material", "", MaterialCat },
                    new[] { "007 [1]", "Specific material designation", "", SpecificMatDesign },
                    new[] { "007 [2]", "Undefined", "", Undefined1 },
                    new[] { "007 [3]", "Color", "", Color },
                    new[] { "007 [4]", "Physical medium", "", PhysicalMedium },
                    new[] { "007 [5]", "Type of reproduction", "", ReproType },
                };
                return strList;
            }
        }

        #endregion

        #region tactile

        internal class c_TactileMat : c_Material
        {
            internal string MaterialCat;
            internal string SpecificMatDesign;
            internal string Undefined1;
            internal string BrailleClass;
            internal string ContractionLevel;
            internal string BraileMusicFormat;
            internal string SpecialPhysicalChar;

            internal c_TactileMat(List<char> charList)
            {
                MaterialCat = string.Join("", charList.GetRange(0, 1));
                SpecificMatDesign = string.Join("", charList.GetRange(1, 1));
                Undefined1 = string.Join("", charList.GetRange(2, 1));
                BrailleClass = string.Join("", charList.GetRange(3, 2));
                ContractionLevel = string.Join("", charList.GetRange(5, 1));
                BraileMusicFormat = string.Join("", charList.GetRange(6, 3));
                SpecialPhysicalChar = string.Join("", charList.GetRange(9, 1));

            }

            internal override string[][] GetCtrlArray()
            {
                var strList = new[]
                {
                    new[] { "007 [0]", "Category of material", "", MaterialCat },
                    new[] { "007 [1]", "Specific material designation", "", SpecificMatDesign },
                    new[] { "007 [2]", "Undefined", "", Undefined1 },
                    new[] { "007 [3-4]", "Class of braille writing", "", BrailleClass },
                    new[] { "007 [5]", "Level of contraction", "", ContractionLevel },
                    new[] { "007 [6-8]", "Braille music format", "", BraileMusicFormat },
                    new[] { "007 [9]", "Special physical characteristics", "", SpecialPhysicalChar },
                };
                return strList;
            }
        }

        #endregion

        #region projected graphic

        internal class c_ProjectedGraphic : c_Material
        {
            internal string MaterialCat;
            internal string SpecificMatDesign;
            internal string Undefined1;
            internal string Color;
            internal string EmulsionBase;
            internal string MediumSepSound;
            internal string SoundMedium;
            internal string Dimensions;
            internal string SecondarySuppMat;

            internal c_ProjectedGraphic(List<char> charList)
            {
                MaterialCat = string.Join("", charList.GetRange(0, 1));
                SpecificMatDesign = string.Join("", charList.GetRange(1, 1));
                Undefined1 = string.Join("", charList.GetRange(2, 1));
                Color = string.Join("", charList.GetRange(3, 1));
                EmulsionBase = string.Join("", charList.GetRange(4, 1));
                MediumSepSound = string.Join("", charList.GetRange(5, 1));
                SoundMedium = string.Join("", charList.GetRange(6, 1));
                Dimensions = string.Join("", charList.GetRange(7, 1));
                SecondarySuppMat = string.Join("", charList.GetRange(8, 1));
            }

            internal override string[][] GetCtrlArray()
            {
                var strList = new[]
                {
                    new[] { "007 [0]", "Category of material", "", MaterialCat },
                    new[] { "007 [1]", "Specific material designation", "", SpecificMatDesign },
                    new[] { "007 [2]", "Undefined", "", Undefined1 },
                    new[] { "007 [3]", "Color", "", Color },
                    new[] { "007 [4]", "Base of emulsion", "", EmulsionBase },
                    new[] { "007 [5]", "Sound on medium or separate", "", MediumSepSound },
                    new[] { "007 [6]", "Medium for sound", "", SoundMedium },
                    new[] { "007 [7]", "Dimensions", "", Dimensions },
                    new[] { "007 [8]", "Secondary support material", "", SecondarySuppMat },
                };
                return strList;
            }
        }

        #endregion

        #region microform

        internal class c_Microform : c_Material
        {
            internal string MaterialCat;
            internal string SpecificMatDesign;
            internal string Undefined1;
            internal string PositiveNegativeAspect;
            internal string Dimensions;
            internal string ReductionRatioRange;
            internal string ReductionRatio;
            internal string Color;
            internal string FilmEmulsion;
            internal string Generation;
            internal string FilmBase;

            internal c_Microform(List<char> charList)
            {
                MaterialCat = string.Join("", charList.GetRange(0, 1));
                SpecificMatDesign = string.Join("", charList.GetRange(1, 1));
                Undefined1 = string.Join("", charList.GetRange(2, 1));
                PositiveNegativeAspect = string.Join("", charList.GetRange(3, 1));
                Dimensions = string.Join("", charList.GetRange(4, 1));
                ReductionRatioRange = string.Join("", charList.GetRange(5, 1));
                ReductionRatio = string.Join("", charList.GetRange(6, 3));
                Color = string.Join("", charList.GetRange(9, 1));
                FilmEmulsion = string.Join("", charList.GetRange(10, 1));
                Generation = string.Join("", charList.GetRange(11, 1));
                FilmBase = string.Join("", charList.GetRange(12, 1));
            }

            internal override string[][] GetCtrlArray()
            {
                var strList = new[]
                {
                    new[] { "007 [0]", "Category of material", "", MaterialCat },
                    new[] { "007 [1]", "Specific material designation", "", SpecificMatDesign },
                    new[] { "007 [2]", "Undefined", "", Undefined1 },
                    new[] { "007 [3]", "Positive/negative aspect", "", PositiveNegativeAspect },
                    new[] { "007 [4]", "Dimensions", "", Dimensions },
                    new[] { "007 [5]", "Reduction ratio range", "", ReductionRatioRange },
                    new[] { "007 [6-8]", "Reduction ratio", "", ReductionRatio },
                    new[] { "007 [9]", "Color", "", Color },
                    new[] { "007 [10]", "Emulsion on film", "", FilmEmulsion },
                    new[] { "007 [11]", "Generation", "", Generation },
                    new[] { "007 [12]", "Base of film", "", FilmBase },
                };
                return strList;
            }
        }

        #endregion

        #region non-projected graphic

        internal class c_NonprojectedGraphic : c_Material
        {
            internal string MaterialCat;
            internal string SpecificMatDesign;
            internal string Undefined1;
            internal string Color;
            internal string PrimarySupportMat;
            internal string SecondarySupportMat;

            internal c_NonprojectedGraphic(List<char> charList)
            {
                MaterialCat = string.Join("", charList.GetRange(0, 1));
                SpecificMatDesign = string.Join("", charList.GetRange(1, 1));
                Undefined1 = string.Join("", charList.GetRange(2, 1));
                Color = string.Join("", charList.GetRange(3, 1));
                PrimarySupportMat = string.Join("", charList.GetRange(4, 1));
                SecondarySupportMat = string.Join("", charList.GetRange(5, 1));
            }

            internal override string[][] GetCtrlArray()
            {
                var strList = new[]
                {
                    new[] { "007 [0]", "Category of material", "", MaterialCat },
                    new[] { "007 [1]", "Specific material designation", "", SpecificMatDesign },
                    new[] { "007 [2]", "Undefined", "", Undefined1 },
                    new[] { "007 [3]", "Color", "", Color },
                    new[] { "007 [4]", "Primary support material", "", PrimarySupportMat },
                    new[] { "007 [5]", "Secondary support material", "", SecondarySupportMat },
                };
                return strList;
            }
        }

        #endregion

        #region motion picture

        internal class c_MotionPicture : c_Material
        {
            internal string MaterialCat;
            internal string SpecificMatDesign;
            internal string Undefined1;
            internal string Color;
            internal string MotionPicRepFormat;
            internal string MediumSepSound;
            internal string SoundMedium;
            internal string Dimensions;
            internal string PlaybackChannelsConfig;
            internal string ProductionElements;
            internal string PositiveNegativeAspect;
            internal string Generation;
            internal string FilmBase;
            internal string ColorRefinedCats;
            internal string ColorStockPrintKind;
            internal string DeteriorationStage;
            internal string Completeness;
            internal string FilmInspectionDate;


            internal c_MotionPicture(List<char> charList)
            {
                MaterialCat = string.Join("", charList.GetRange(0, 1));
                SpecificMatDesign = string.Join("", charList.GetRange(1, 1));
                Undefined1 = string.Join("", charList.GetRange(2, 1));
                Color = string.Join("", charList.GetRange(3, 1));
                MotionPicRepFormat = string.Join("", charList.GetRange(4, 1));
                MediumSepSound = string.Join("", charList.GetRange(5, 1));
                SoundMedium = string.Join("", charList.GetRange(6, 1));
                Dimensions = string.Join("", charList.GetRange(7, 1));
                PlaybackChannelsConfig = string.Join("", charList.GetRange(8, 1));
                ProductionElements = string.Join("", charList.GetRange(9, 1));
                PositiveNegativeAspect = string.Join("", charList.GetRange(10, 1));
                Generation = string.Join("", charList.GetRange(11, 1));
                FilmBase = string.Join("", charList.GetRange(12, 1));
                ColorRefinedCats = string.Join("", charList.GetRange(13, 1));
                ColorStockPrintKind = string.Join("", charList.GetRange(14, 1));
                DeteriorationStage = string.Join("", charList.GetRange(15, 1));
                Completeness = string.Join("", charList.GetRange(16, 1));
                FilmInspectionDate = string.Join("", charList.GetRange(17, 6));

            }

            internal override string[][] GetCtrlArray()
            {
                var strList = new[]
                {
                    new[] { "007 [0]", "Category of material", "", MaterialCat },
                    new[] { "007 [1]", "Specific material designation", "", SpecificMatDesign },
                    new[] { "007 [2]", "Undefined", "", Undefined1 },
                    new[] { "007 [3]", "Color", "", Color },
                    new[] { "007 [4]", "Motion picture presentation format", "", MotionPicRepFormat },
                    new[] { "007 [5]", "Sound on medium or separate", "", MediumSepSound },
                    new[] { "007 [6]", "Medium for sound", "", SoundMedium },
                    new[] { "007 [7]", "Dimensions", "", Dimensions },
                    new[] { "007 [8]", "Configuration of playback channels", "", PlaybackChannelsConfig },
                    new[] { "007 [9]", "Production elements", "", ProductionElements },
                    new[] { "007 [10]", "Positive/negative aspect", "", PositiveNegativeAspect },
                    new[] { "007 [11]", "Generation", "", Generation },
                    new[] { "007 [12]", "Base of film", "", FilmBase },
                    new[] { "007 [13]", "Refined categories of color", "", ColorRefinedCats },
                    new[] { "007 [14]", "Kind of color stock or print", "", ColorStockPrintKind },
                    new[] { "007 [15]", "Deterioration stage", "", DeteriorationStage },
                    new[] { "007 [16]", "Completeness", "", Completeness },
                    new[] { "007 [17-22]", "Film inspection date", "", FilmInspectionDate },

                };
                return strList;
            }
        }

        #endregion

        #region kit

        internal class c_Kit : c_Material
        {
            internal string MaterialCat;
            internal string SpecificMatDesign;

            internal c_Kit(List<char> charList)
            {
                MaterialCat = string.Join("", charList.GetRange(0, 1));
                SpecificMatDesign = string.Join("", charList.GetRange(1, 1));
            }

            internal override string[][] GetCtrlArray()
            {
                var strList = new[]
                {
                    new[] { "007 [0]", "Category of material", "", MaterialCat },
                    new[] { "007 [1]", "Specific material designation", "", SpecificMatDesign },
                };
                return strList;
            }
        }

        #endregion

        #region notated music

        internal class c_NotatedMusic : c_Material
        {
            internal string MaterialCat;
            internal string SpecificMatDesign;

            internal c_NotatedMusic(List<char> charList)
            {
                MaterialCat = string.Join("", charList.GetRange(0, 1));
                SpecificMatDesign = string.Join("", charList.GetRange(1, 1));

            }

            internal override string[][] GetCtrlArray()
            {
                var strList = new[]
                {
                    new[] { "007 [0]", "Category of material", "", MaterialCat },
                    new[] { "007 [1]", "Specific material designation", "", SpecificMatDesign },
                };
                return strList;
            }
        }

        #endregion

        #region remote sensing

        internal class c_RemoteSensingImage : c_Material
        {
            internal string MaterialCat;
            internal string SpecificMatDesign;
            internal string Undefined1;
            internal string SensorAltitude;
            internal string SensorAttitude;
            internal string CloudCover;
            internal string PlatformConstructionType;
            internal string PlatformUseCat;
            internal string SensorType;
            internal string DataType;

            internal c_RemoteSensingImage(List<char> charList)
            {
                MaterialCat = string.Join("", charList.GetRange(0, 1));
                SpecificMatDesign = string.Join("", charList.GetRange(1, 1));
                Undefined1 = string.Join("", charList.GetRange(2, 1));
                SensorAltitude = string.Join("", charList.GetRange(3, 1));
                SensorAttitude = string.Join("", charList.GetRange(4, 1));
                CloudCover = string.Join("", charList.GetRange(5, 1));
                PlatformConstructionType = string.Join("", charList.GetRange(6, 1));
                PlatformUseCat = string.Join("", charList.GetRange(7, 1));
                SensorType = string.Join("", charList.GetRange(8, 1));
                DataType = string.Join("", charList.GetRange(9, 2));
            }

            internal override string[][] GetCtrlArray()
            {
                var strList = new[]
                {
                    new[] { "007 [0]", "Category of material", "", MaterialCat },
                    new[] { "007 [1]", "Specific material designation", "", SpecificMatDesign },
                    new[] { "007 [2]", "Undefined", "", Undefined1 },
                    new[] { "007 [3]", "Altitude of sensor", "", SensorAltitude },
                    new[] { "007 [4]", "Attitude of sensor", "", SensorAttitude },
                    new[] { "007 [5]", "Cloud cover", "", CloudCover },
                    new[] { "007 [6]", "Platform construction type", "", PlatformConstructionType },
                    new[] { "007 [7]", "Platform use category", "", PlatformUseCat },
                    new[] { "007 [8]", "Sensor type", "", SensorType },
                    new[] { "007 [9-10]", "Data type", "", DataType },
                };
                return strList;
            }
        }

        #endregion

        #region sound recording

        internal class c_SoundRecording : c_Material
        {
            internal string MaterialCat;
            internal string SpecificMatDesign;
            internal string Undefined1;
            internal string Speed;
            internal string PlaybackChannelsConfig;
            internal string GrooveWidthPitch;
            internal string Dimensions;
            internal string TapeWidth;
            internal string TapeConfig;
            internal string DiscCylinderTapeKind;
            internal string MaterialKind;
            internal string CuttingKind;
            internal string SpecialPlaybackChar;
            internal string CaptureStorageTech;

            internal c_SoundRecording(List<char> charList)
            {
                MaterialCat = string.Join("", charList.GetRange(0, 1));
                SpecificMatDesign = string.Join("", charList.GetRange(1, 1));
                Undefined1 = string.Join("", charList.GetRange(2, 1));
                Speed = string.Join("", charList.GetRange(3, 1));
                PlaybackChannelsConfig = string.Join("", charList.GetRange(4, 1));
                GrooveWidthPitch = string.Join("", charList.GetRange(5, 1));
                Dimensions = string.Join("", charList.GetRange(6, 1));
                TapeWidth = string.Join("", charList.GetRange(7, 1));
                TapeConfig = string.Join("", charList.GetRange(8, 1));
                DiscCylinderTapeKind = string.Join("", charList.GetRange(9, 1));
                MaterialKind = string.Join("", charList.GetRange(10, 1));
                CuttingKind = string.Join("", charList.GetRange(11, 1));
                SpecialPlaybackChar = string.Join("", charList.GetRange(12, 1));
                CaptureStorageTech = string.Join("", charList.GetRange(13, 1));
            }

            internal override string[][] GetCtrlArray()
            {
                var strList = new[]
                {
                    new[] { "007 [0]", "Category of material", "", MaterialCat },
                    new[] { "007 [1]", "Specific material designation", "", SpecificMatDesign },
                    new[] { "007 [2]", "Undefined", "", Undefined1 },
                    new[] { "007 [3]", "Speed", "", Speed },
                    new[] { "007 [4]", "Configuration of playback channels", "", PlaybackChannelsConfig },
                    new[] { "007 [5]", "Groove width/groove pitch", "", GrooveWidthPitch },
                    new[] { "007 [6]", "Dimensions", "", Dimensions },
                    new[] { "007 [7]", "Tape width", "", TapeWidth },
                    new[] { "007 [8]", "Tape configuration", "", TapeConfig },
                    new[] { "007 [9]", "Kind of disc, cylinder, or tape", "", DiscCylinderTapeKind },
                    new[] { "007 [10]", "Kind of material", "", MaterialKind },
                    new[] { "007 [11]", "Kind of cutting", "", CuttingKind },
                    new[] { "007 [12]", "Special playback characteristics", "", SpecialPlaybackChar },
                    new[] { "007 [13]", "Capture and storage technique", "", CaptureStorageTech },
                };
                return strList;
            }
        }

        #endregion

        #region text

        internal class c_Text : c_Material
        {
            internal string MaterialCat;
            internal string SpecificMatDesign;

            internal c_Text(List<char> charList)
            {
                MaterialCat = string.Join("", charList.GetRange(0, 1));
                SpecificMatDesign = string.Join("", charList.GetRange(1, 1));
            }

            internal override string[][] GetCtrlArray()
            {
                var strList = new[]
                {
                    new[] { "007 [0]", "Category of material", "", MaterialCat },
                    new[] { "007 [1]", "Specific material designation", "", SpecificMatDesign },

                };
                return strList;
            }
        }

        #endregion

        #region video recording

        internal class c_VideoRecording : c_Material
        {
            internal string MaterialCat;
            internal string SpecificMatDesign;
            internal string Undefined1;
            internal string Color;
            internal string VideoRecFormat;
            internal string MediumSepSound;
            internal string SoundMedium;
            internal string Dimensions;
            internal string PlaybackChannelsConfig;

            internal c_VideoRecording(List<char> charList)
            {
                MaterialCat = string.Join("", charList.GetRange(0, 1));
                SpecificMatDesign = string.Join("", charList.GetRange(1, 1));
                Undefined1 = string.Join("", charList.GetRange(2, 1));
                Color = string.Join("", charList.GetRange(3, 1));
                VideoRecFormat = string.Join("", charList.GetRange(4, 1));
                MediumSepSound = string.Join("", charList.GetRange(5, 1));
                SoundMedium = string.Join("", charList.GetRange(6, 1));
                Dimensions = string.Join("", charList.GetRange(7, 1));
                PlaybackChannelsConfig = string.Join("", charList.GetRange(8, 1));
            }

            internal override string[][] GetCtrlArray()
            {
                var strList = new[]
                {
                    new[] { "007 [0]", "Category of material", "", MaterialCat },
                    new[] { "007 [1]", "Specific material designation", "", SpecificMatDesign },
                    new[] { "007 [2]", "Undefined", "", Undefined1 },
                    new[] { "007 [3]", "Color", "", Color },
                    new[] { "007 [4]", "Videorecording format", "", VideoRecFormat },
                    new[] { "007 [5]", "Sound on medium or separate", "", MediumSepSound },
                    new[] { "007 [6]", "Medium for sound", "", SoundMedium },
                    new[] { "007 [7]", "Dimensions", "", Dimensions },
                    new[] { "007 [8]", "Configuration of playback channels", "", PlaybackChannelsConfig },
                };
                return strList;
            }
        }

        #endregion

        #region unspecified

        internal class c_Unspecified : c_Material
        {
            internal string MaterialCat;
            internal string SpecificMatDesign;

            internal c_Unspecified(List<char> charList)
            {
                MaterialCat = string.Join("", charList.GetRange(0, 1));
                SpecificMatDesign = string.Join("", charList.GetRange(1, 1));
            }

            internal override string[][] GetCtrlArray()
            {
                var strList = new[]
                {
                    new[] { "007 [0]", "Category of material", "", MaterialCat },
                    new[] { "007 [1]", "Specific material designation", "", SpecificMatDesign },
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
