﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IsInstanceHelper.cs" company="">
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
namespace NFluent.Helpers
{
    using System;

    using NFluent.Extensions;

    /// <summary>
    /// Helper class related to Is(Not)Instance methods (used like a traits).
    /// </summary>
    internal static class IsInstanceHelper
    {
        /// <summary>
        /// Checks that an instance is of the given expected type.
        /// </summary>
        /// <param name="instance">The instance to be checked.</param>
        /// <param name="expectedType">The expected type.</param>
        /// <exception cref="FluentAssertionException">The instance is not of the expected type.</exception>
        public static void IsInstanceOf(object instance, Type expectedType)
        {
            if (instance.GetType() != expectedType)
            {
                throw new FluentAssertionException(string.Format("\nThe actual value:\n\t[{0}]\nis not an instance of:\n\t[{1}]\nbut an instance of:\n\t[{2}]\ninstead.", instance.ToStringProperlyFormated(), expectedType, instance.GetType()));
            }
        }

        /// <summary>
        /// Checks that an instance is not of the given expected type.
        /// </summary>
        /// <param name="instance">The instance to be checked.</param>
        /// <param name="typeNotExpected">The type not expected.</param>
        /// <exception cref="FluentAssertionException">The instance is of the type not expected.</exception>
        public static void IsNotInstanceOf(object instance, Type typeNotExpected)
        {
            if (instance.GetType() == typeNotExpected)
            {
                throw new FluentAssertionException(string.Format("\nThe actual value:\n\t[{0}]\nis an instance of:\n\t[{1}]\nwhich is not expected.", instance.ToStringProperlyFormated(), instance.GetType()));
            }
        }

        /// <summary>
        /// Checks that an instance is in the inheritance hierarchy of a specified type.
        /// </summary>
        /// <param name="instance">The instance to be checked.</param>
        /// <param name="expectedBaseType">The Type which is expected to be a base Type of the instance.</param>
        /// <exception cref="FluentAssertionException">The instance is not in the inheritance hierarchy of the specified type.</exception>
        public static void InheritsFrom(object instance, Type expectedBaseType)
        {
            Type instanceType = instance.GetTypeWithoutThrowingException();
            if (!expectedBaseType.IsAssignableFrom(instanceType))
            {
                throw new FluentAssertionException(string.Format("\nThe checked expression is not of part of the inheritance hierarchy, or of the same type than the specified one.\nIndeed, checked expression type:\n\t[{0}]\nis not a derived type of\n\t[{1}].", instanceType.ToStringProperlyFormated(), expectedBaseType.ToStringProperlyFormated()));
            }
        }
    }
}