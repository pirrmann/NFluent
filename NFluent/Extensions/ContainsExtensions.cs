﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContainsExtensions.cs" company="">
//   Copyright 2013 Thomas PIERRAIN
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//       http://www.apache.org/licenses/LICENSE-2.0
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace NFluent
{
    // TODO : delete this file.

    /// <summary>
    /// Extension methods for exploiting enumerable content in a fluent manner (i.e. with auto completion support and in an english readable way).
    /// </summary>
    public static class ContainsExtensions
    {
        ///// <summary>
        ///// Verifies that the actual enumerable contains only the given expected values and nothing else, in order.
        ///// This assertion should only be used with IEnumerable that have a consistent iteration order 
        ///// (i.e. don't use it with <see cref="Hashtable"/>, prefer <see cref="ContainsOnly"/> in that case).
        ///// </summary>
        ///// <typeparam name="T">Type of the elements contained in the <see cref="expectedValues"/> array.</typeparam>
        ///// <param name="enumerable">The enumerable to verify.</param>
        ///// <param name="expectedValues">The expected values to be searched.</param>
        ///// <returns>
        /////   <c>true</c> if the enumerable contains exactly the specified expected values; throws a <see cref="FluentAssertionException"/> otherwise.
        ///// </returns>
        ///// <exception cref="NFluent.FluentAssertionException">The specified enumerable does not contains exactly the specified expected values.</exception>
        //public static bool ContainsExactly<T>(this IEnumerable enumerable, params T[] expectedValues)
        //{
        //    long i = 0;
        //    foreach (var obj in enumerable)
        //    {
        //        if (!object.Equals(obj, expectedValues[i]))
        //        {
        //            var expectedNumberOfItemsDescription = FormatItemCount(expectedValues.LongLength);

        //            var enumerableCount = 0;
        //            foreach (var item in enumerable)
        //            {
        //                enumerableCount++;
        //            }

        //            var foundNumberOfItemsDescription = string.Format(enumerableCount <= 1 ? "{0} item" : "{0} items", enumerableCount);

        //            throw new FluentAssertionException(string.Format("Found: [{0}] ({1}) instead of the expected [{2}] ({3}).", enumerable.ToEnumeratedString(), foundNumberOfItemsDescription, expectedValues.ToEnumeratedString(), expectedNumberOfItemsDescription));
        //        }

        //        i++;
        //    }
         
        //    return true;
        //}

        ///// <summary>
        ///// Determines whether the specified enumerable contains exactly some expected values.
        ///// </summary>
        ///// <param name="enumerable">The enumerable.</param>
        ///// <param name="otherEnumerable">The other enumerable.</param>
        ///// <returns>
        /////   <c>true</c> if the specified enumerable contains exactly the specified expected values; throws a <see cref="FluentAssertionException" /> otherwise, <c>false</c>.
        ///// </returns>
        ///// <exception cref="NFluent.FluentAssertionException">The specified enumerable does not contains exactly the specified expected values.</exception>
        //public static bool ContainsExactly(this IEnumerable enumerable, IEnumerable otherEnumerable)
        //{
        //    // TODO: Refactor this implementation
        //    if (otherEnumerable == null)
        //    {
        //        long foundCount;
        //        var foundItems = enumerable.ToEnumeratedString(out foundCount);
        //        var foundItemsCount = FormatItemCount(foundCount);
        //        throw new FluentAssertionException(string.Format("Found: [{0}] ({1}) instead of the expected [] (0 item).", foundItems, foundItemsCount));
        //    }

        //    var first = enumerable.GetEnumerator();
        //    var second = otherEnumerable.GetEnumerator();

        //    while (first.MoveNext())
        //    {
        //        if (!second.MoveNext() || !object.Equals(first.Current, second.Current))
        //        {
        //            long foundCount;
        //            var foundItems = enumerable.ToEnumeratedString(out foundCount);
        //            var formatedFoundCount = FormatItemCount(foundCount);

        //            long expectedCount;
        //            object expectedItems = otherEnumerable.ToEnumeratedString(out expectedCount);
        //            var formatedExpectedCount = FormatItemCount(expectedCount);

        //            throw new FluentAssertionException(string.Format("Found: [{0}] ({1}) instead of the expected [{2}] ({3}).", foundItems, formatedFoundCount, expectedItems, formatedExpectedCount));
        //        }
        //    }

        //    return true;
        //}
    }
}