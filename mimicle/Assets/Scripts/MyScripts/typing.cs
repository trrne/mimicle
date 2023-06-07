using System;

namespace Mimical.Extend
{
    public static class typing
    {
        public static Type type(object obj) => obj.GetType();

        public static float Single(this object obj) => (float)obj;

        public static int Int(this object obj) => (int)obj;

        public static double Double(this object obj) => (double)obj;

        public static void True(this bool boolean) => boolean = true;

        public static void False(this bool boolean) => boolean = false;
    }
}
