using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.CTe
{
    public static class Expressoes
    {
        public static string ER1 = @"^[0-9]{2}$";
        public static string ER4 = @"^[0-9]{14}$";
        public static string ER6 = @"^[0-9]{0}|[0-9]{14}$";
        public static string ER7 = @"^[0-9]{11}$";
        public static string ER25 = @"^[0-9]{2,14}$";
        public static string ER26 = @"^[0-9]{0,14}|ISENTO|PR[0-9]{4,8}$";
        public static string ER30 = @"^0|[1-9]{1}[0-9]{0,2}$";
        public static string ER32 = @"^[!-ÿ]{1}[ -ÿ]{0,}[!-ÿ]{1}|[!-ÿ]{1}$";
        public static string ER33 = @"^[0-9]{8}$";
        public static string ER36 = @"^[0-9]{7,12}$";
        public static string ER38 = @"^[0-9]{8,9}$";
        public static string ER50 = @"^[A-Z]{3}(([1-9]\d{3})|(0[1-9]\d{2})|(00[1-9]\d)|(000[1-9]))$";
        public static string ER53 = @"^0|[1-9]{1}[0-9]{0,5}$";


    }
}
