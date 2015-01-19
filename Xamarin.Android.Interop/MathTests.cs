using System;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace Xamarin.Android.Interop
{
	[TestFixture]
	public class MathTests
	{
		[Test]
		public void Math_int_Abs()
		{
			int n = -46;
			int r = MathLib.Abs (n);
			Assert.That (r, Is.EqualTo (Math.Abs (n)));
		}

		[Test]
		public void Math_int_Array_Abs()
		{
			int[] n = new int[] { -35, 36, -65, -99 };
			var expected = n.Select ((i) => Math.Abs (i)).ToArray();

			MathLib.Abs (n); // modify inplace

			Assert.That (n, Is.EquivalentTo (expected));
		}

		[Test]
		public void Range_from_doubles()
		{
			double start = 0.1,
				   end = 0.9,
				   step = 0.1;

			var expected = Enumerable.Range(1,9);

			int[] result = MathLib.Range (start, end, step).Select((d) => (int)(d * 10)).ToArray();

			Assert.That (result, Is.EquivalentTo (expected));
		}
	}
}

