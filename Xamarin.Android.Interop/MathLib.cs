using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace Xamarin.Android.Interop
{
	public static class MathLib
	{
		private const string MATHLIB = "math";

		[DllImport(MATHLIB)]
		private static extern int abs_int (int n);

		[DllImport(MATHLIB)]
		private static extern void abs_int_array ( int[] n, int size);

		[DllImport(MATHLIB)]
		private static extern IntPtr range_from_doubles (double start, double end, double step, ref int size);

		[DllImport(MATHLIB)]
		private static extern int release_double_pointer (IntPtr ptr);

		public static int Abs (int n)
		{
			return abs_int(n);
		}

		public static void Abs (int[] n)
		{
			abs_int_array (n, n.Length);
		}

		public static double[] Range(double start, double end, double step)
		{
			int size = 0;
			IntPtr ptr = range_from_doubles (start, end, step, ref size);

			double[] result = new double[size];

			Marshal.Copy (ptr, result, 0, size);

			release_double_pointer (ptr);

			return result;
		}
	}
}

