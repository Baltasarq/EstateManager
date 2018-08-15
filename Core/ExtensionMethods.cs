using System;

namespace EstateManager.Core {
    public static class Methods {
        public static double DoubleFromString(this string txt)
        {
            txt = txt.Trim().Replace( ' ', '0' );

            return Convert.ToDouble( txt );
        }

        public static int IntFromString(this string txt)
        {
            txt = txt.Trim().Replace( ' ', '0' );

            return Convert.ToInt32( txt );
        }
    }
}
