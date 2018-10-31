using System.Collections.Generic;

namespace Flagomaniak.Continents
{
    /// <summary>
    /// Klasa zawierająca zbiór wszystkich kontynentów dostępnych w grze.
    /// </summary>
    class ContinentCollection
    {
        /// <summary>
        /// Kolekcja wszystkich kontynentów w grze.
        /// </summary>
        private readonly List<Continent> _continents;

        ///<value>Zwraca wszystkie kontynenty w grze.</value>
        public List<Continent> Continents => _continents;

        /// <summary>
        /// Konstruktor klasy. Inicjalizuje wszystkie kontynenty dostępne w grze.
        /// </summary>
        public ContinentCollection()
        {
            _continents = new List<Continent>
            {
                new Continent("Europa", @"./Resources/Images/Maps/Europe.png", new List<Country> {
                        //new Country("Albania", @"./Resources/Images/Flags/Europe/Albania.png"),
                        //new Country("Andora", @"./Resources/Images/Flags/Europe/Andora.png"),
                        //new Country("Austria", @"./Resources/Images/Flags/Europe/Austria.png"),
                        //new Country("Belgia", @"./Resources/Images/Flags/Europe/Belgia.png"),
                        //new Country("Białoruś", @"./Resources/Images/Flags/Europe/Białoruś.png"),
                        //new Country("Bośnia i Hercegowina", @"./Resources/Images/Flags/Europe/BosniaHercegowina.png"),
                        //new Country("Bułgaria", @"./Resources/Images/Flags/Europe/Bulgaria.png"),
                        //new Country("Chorwacja", @"./Resources/Images/Flags/Europe/Chorwacja.png"),
                        //new Country("Czarnogóra", @"./Resources/Images/Flags/Europe/Czarnogora.png"),
                        //new Country("Dania", @"./Resources/Images/Flags/Europe/Dania.png"),
                        //new Country("Estonia", @"./Resources/Images/Flags/Europe/Estonia.png"),
                        //new Country("Finlandia", @"./Resources/Images/Flags/Europe/Finlandia.png"),
                        //new Country("Francja", @"./Resources/Images/Flags/Europe/Francja.png"),
                        //new Country("Grecja", @"./Resources/Images/Flags/Europe/Grecja.png"),
                        //new Country("Hiszpania", @"./Resources/Images/Flags/Europe/Hiszpania.png"),
                        //new Country("Holandia", @"./Resources/Images/Flags/Europe/Holandia.png"),
                        //new Country("Irlandia", @"./Resources/Images/Flags/Europe/Irlandia.png"),
                        //new Country("Islandia", @"./Resources/Images/Flags/Europe/Islanida.png"),
                        //new Country("Kosowo", @"./Resources/Images/Flags/Europe/Kosowo.png"),
                        //new Country("Lichtenstain", @"./Resources/Images/Flags/Europe/Lichtenstain.png"),
                        //new Country("Litwa", @"./Resources/Images/Flags/Europe/Litwa.png"),
                        //new Country("Luksemburg", @"./Resources/Images/Flags/Europe/Luksemburg.png"),
                        //new Country("Łotwa", @"./Resources/Images/Flags/Europe/Lotwa.png"),
                        //new Country("Macedonia", @"./Resources/Images/Flags/Europe/Macedonia.png"),
                        //new Country("Malta", @"./Resources/Images/Flags/Europe/Malta.png"),
                        //new Country("Belgia", @"./Resources/Images/Flags/Europe/Belgia.png"),
                        //new Country("Mołdawia", @"./Resources/Images/Flags/Europe/Moldawia.png"),
                        //new Country("Monako", @"./Resources/Images/Flags/Europe/Monako.png"),
                        //new Country("Niemcy", @"./Resources/Images/Flags/Europe/Niemcy.png"),
                        //new Country("Norwegia", @"./Resources/Images/Flags/Europe/Norwegia.png"),
                        new Country("Polska", @"./Resources/Images/Flags/Europe/Polska.png", "F1 M 825.363,665.374C 824.708,665.5 825.363,666.708 825.363,667.375C 825.363,668.041 825.281,668.713 825.363,669.375C 825.72,672.23 826.863,674.999 826.863,677.876C 826.863,678.543 826.863,679.21 826.863,679.876C 826.863,680.543 827.28,681.356 826.863,681.877C 826.434,682.413 825.391,681.937 824.863,682.377C 824.29,682.854 824.196,683.71 823.863,684.377C 823.53,685.044 823.258,685.745 822.863,686.377C 821.714,688.215 819.602,690.349 820.362,692.378C 822.604,698.354 830.623,700.904 832.864,706.88C 834.041,710.017 831.052,713.631 831.864,716.882C 832.915,721.086 836.865,724.549 836.865,728.883C 836.865,735.886 836.496,742.937 837.365,749.886C 837.614,751.878 836.611,754.32 837.865,755.887C 839.948,758.49 845.509,753.53 847.866,755.887C 850.224,758.244 845.784,763.285 847.866,765.888C 849.184,767.535 852.151,766.663 853.867,767.889C 854.545,768.373 854.735,769.347 855.367,769.889C 855.933,770.374 856.64,770.727 857.368,770.889C 861.592,771.828 865.817,772.87 869.869,774.39C 870.513,774.631 871.188,774.804 871.87,774.89C 872.531,774.972 873.47,774.356 873.87,774.89C 875.174,776.628 869.772,778.301 870.369,780.39C 871.34,783.787 877.304,782.139 880.371,783.891C 881.094,784.304 881.282,785.302 881.871,785.891C 882.46,786.481 883.091,787.099 883.871,787.391C 886.663,788.438 885.763,781.499 887.872,779.39C 889.445,777.818 892.29,780.11 894.373,780.891C 896.87,781.827 899.877,779.954 902.374,780.891C 906.81,782.554 907.778,788.808 911.375,791.892C 915.704,795.603 922.346,795.01 927.878,796.393C 931.087,797.195 932.419,801.414 935.379,802.894C 939.794,805.101 945.092,807.091 949.881,805.894C 950.604,805.713 951.354,805.421 951.881,804.894C 952.408,804.367 952.486,803.526 952.881,802.894C 953.323,802.187 954.008,801.639 954.381,800.893C 954.689,800.279 954.345,799.322 954.881,798.893C 955.402,798.476 956.215,798.893 956.882,798.893C 957.548,798.893 958.41,798.422 958.882,798.893C 959.353,799.365 958.799,800.232 958.882,800.893C 959.133,802.906 959.882,804.866 959.882,806.894C 959.882,807.561 959.466,808.374 959.882,808.894C 960.311,809.431 961.2,809.48 961.882,809.395C 962.622,809.302 963.469,809.015 963.883,808.394C 965.362,806.175 962.216,802.476 963.883,800.393C 965.136,798.826 967.876,799.893 969.883,799.893C 972.55,799.893 975.569,798.57 977.885,799.893C 980.358,801.306 978.661,806.115 980.885,807.894C 981.406,808.311 982.224,807.977 982.885,807.894C 983.567,807.809 984.219,807.561 984.885,807.394C 985.552,807.228 986.219,807.061 986.886,806.894C 987.552,806.727 988.358,806.834 988.886,806.394C 991.729,804.025 991.714,797.852 995.387,797.393C 998.332,797.025 999.733,801.566 1002.39,802.894C 1007.86,805.631 1012.45,810.411 1018.39,811.895C 1020.33,812.38 1022.52,811.193 1024.39,811.895C 1025.17,812.188 1025.57,813.532 1026.39,813.395C 1027.13,813.272 1027.21,812.118 1027.39,811.395C 1027.55,810.748 1027.31,810.056 1027.39,809.395C 1027.66,807.238 1027.89,805.067 1027.89,802.894C 1027.89,798.152 1028.73,793.331 1030.39,788.892C 1031.1,787.012 1029.78,784.561 1030.89,782.891C 1031.31,782.271 1032.23,782.224 1032.89,781.891C 1033.56,781.557 1034.37,781.418 1034.89,780.891C 1038.78,776.999 1039.99,770.691 1044.39,767.389C 1047.31,765.204 1052.1,766.719 1054.9,764.388C 1055.47,763.911 1055.56,763.055 1055.9,762.388C 1056.23,761.721 1056.71,761.111 1056.9,760.388C 1057.54,757.795 1057.73,755.038 1057.4,752.387C 1057.3,751.647 1056.92,750.913 1056.4,750.386C 1055.87,749.859 1054.81,750.006 1054.4,749.386C 1054.03,748.831 1054.4,748.053 1054.4,747.386C 1054.4,746.719 1054.47,746.048 1054.4,745.386C 1054.11,742.862 1052.8,740.497 1051.39,738.385C 1049.03,734.832 1045.3,732.202 1043.39,728.383C 1040.33,722.263 1041.54,714.67 1042.39,707.88C 1042.72,705.229 1044.78,701.769 1042.89,699.879C 1041.05,698.034 1036.53,698.91 1035.89,696.379C 1035.26,693.853 1040.05,693.219 1041.89,691.378C 1047.21,686.06 1047.83,676.838 1046.89,669.375C 1046.42,665.567 1042.3,663.206 1040.39,659.874C 1038.95,657.346 1037.91,654.598 1036.89,651.872C 1035.15,647.232 1033.63,642.511 1031.89,637.871C 1030.93,635.297 1031.49,632.107 1029.89,629.869C 1026.81,625.561 1019.91,625.814 1015.89,622.368C 1012.13,619.143 1011.5,613.284 1010.89,608.366C 1010.81,607.705 1010.97,607.028 1010.89,606.366C 1010.8,605.684 1010.79,604.925 1010.39,604.366C 1008.1,601.165 1004.57,598.746 1000.89,597.365C 997.38,596.05 994.23,600.928 991.386,603.366C 989.785,604.738 987.478,605.104 985.385,605.366C 980.355,605.995 976.285,595.85 971.884,598.365C 969.528,599.711 970.72,603.674 970.383,606.366C 970.044,609.079 968.035,612.204 965.383,612.867C 964.736,613.029 964.044,612.784 963.383,612.867C 962.701,612.952 961.997,613.674 961.382,613.367C 959.568,612.46 961.507,609.054 960.382,607.366C 959.273,605.702 955.9,606.065 954.381,607.366C 952.167,609.264 951.426,612.395 949.881,614.867C 949.381,615.667 948.446,616.113 947.88,616.868C 947.433,617.464 946.675,618.151 946.88,618.868C 947.109,619.669 948.135,619.995 948.88,620.368C 949.495,620.675 950.321,620.469 950.881,620.868C 952.559,622.067 953.525,625.154 952.381,626.869C 951.967,627.489 951.079,627.607 950.381,627.869C 949.737,628.11 948.94,627.97 948.38,628.369C 947.702,628.854 947.38,629.703 946.88,630.37C 946.38,631.036 945.753,631.624 945.38,632.37C 944.411,634.308 944.818,637.402 942.88,638.371C 942.283,638.669 941.546,638.371 940.879,638.371C 940.213,638.371 939.526,638.209 938.879,638.371C 938.156,638.551 937.602,639.19 936.879,639.371C 936.232,639.532 935.35,639.842 934.878,639.371C 934.407,638.899 934.796,638.032 934.878,637.37C 934.964,636.689 935.732,635.96 935.379,635.37C 935.025,634.781 934.01,634.599 933.378,634.87C 932.612,635.198 932.467,636.281 931.878,636.87C 931.289,637.46 930.585,637.929 929.878,638.371C 927.047,640.14 922.237,641.231 919.876,638.871C 916.075,635.07 921.677,626.67 917.876,622.868C 915.472,620.464 911.058,619.674 907.875,620.868C 905.706,621.681 904.172,624.081 901.874,624.369C 897.89,624.867 893.631,621.959 889.872,623.369C 886.215,624.74 884.262,628.932 880.871,630.87C 877.887,632.575 873.299,630.94 870.87,633.37C 867.785,636.455 865.568,640.559 861.868,642.871C 859.453,644.381 856.415,644.598 853.867,645.872C 853.122,646.244 852.534,646.872 851.867,647.372C 851.2,647.872 850.647,648.579 849.867,648.872C 844.476,650.894 837.211,650.688 833.864,655.373C 831.521,658.654 834.601,664.02 832.364,667.375C 831.251,669.045 827.783,669.294 826.363,667.875C 825.729,667.24 826.245,665.205 825.363,665.374 Z"),
                        //new Country("Portugalia", @"./Resources/Images/Flags/Europe/Portugalia.png"),
                        //new Country("Czechy", @"./Resources/Images/Flags/Europe/Czechy.png"),
                        //new Country("Rosja", @"./Resources/Images/Flags/Europe/Rosja.png"),
                        //new Country("Rumunia", @"./Resources/Images/Flags/Europe/Rumunia.png"),
                        //new Country("San Marino", @"./Resources/Images/Flags/Europe/SanMarino.png"),
                        //new Country("Serbia", @"./Resources/Images/Flags/Europe/Serbia.png"),
                        //new Country("Słowacja", @"./Resources/Images/Flags/Europe/Slowacja.png"),
                        //new Country("Słowenia", @"./Resources/Images/Flags/Europe/Slowenia.png"),
                        //new Country("Szwajcaria", @"./Resources/Images/Flags/Europe/Szwajcaria.png"),
                        //new Country("Szwecja", @"./Resources/Images/Flags/Europe/Szwecja.png"),
                        //new Country("Turcja", @"./Resources/Images/Flags/Europe/Turcja.png"),
                        //new Country("Ukraina", @"./Resources/Images/Flags/Europe/Ukraina.png"),
                        //new Country("Watykan", @"./Resources/Images/Flags/Europe/Watykan.png"),
                        //new Country("Węgry", @"./Resources/Images/Flags/Europe/Wegry.png"),
                        //new Country("Wielka Brytania", @"./Resources/Images/Flags/Europe/WielkaBrytania.png"),
                        //new Country("Włochy", @"./Resources/Images/Flags/Europe/Wlochy.png"),
                    })
            };
        }
    }
}
