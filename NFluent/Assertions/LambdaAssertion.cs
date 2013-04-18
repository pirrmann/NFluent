﻿// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="LambdaAssertion.cs" company="">
// //   Copyright 2013 Cyrille DUPUYDAUBY
// //   Licensed under the Apache License, Version 2.0 (the "License");
// //   you may not use this file except in compliance with the License.
// //   You may obtain a copy of the License at
// //       http://www.apache.org/licenses/LICENSE-2.0
// //   Unless required by applicable law or agreed to in writing, software
// //   distributed under the License is distributed on an "AS IS" BASIS,
// //   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// //   See the License for the specific language governing permissions and
// //   limitations under the License.
// // </copyright>
// // --------------------------------------------------------------------------------------------------------------------

namespace NFluent
{
    using System;
    using System.Diagnostics;

    using NFluent.Helpers;

    /// <summary>
    /// Implements lambda/action specific assertion.
    /// </summary>
    public class LambdaAssertion : ILambdaAssertion
    {
        private Exception exception;

        private double durationInNs;

        /// <summary>
        /// Initializes a new instance of the <see cref="LambdaAssertion"/> class. 
        /// </summary>
        /// <param name="action">
        /// Action to be assessed.
        /// </param>
        public LambdaAssertion(Action action)
        {
            this.Value = action;
            this.Execute();
        }

        /// <summary>
        /// Gets the value to be tested (provided for any extension method to be able to test it).
        /// </summary>
        /// <value>
        /// The value to be tested by any fluent assertion extension method.
        /// </value>
        public Action Value { get; private set; }

        /// <summary>
        /// Checks that the execution time is below a specified threshold.
        /// </summary>
        /// <param name="threshold">The threshold.</param>
        /// <param name="timeUnit">The time unit of the given threshold.</param>
        /// <returns>
        /// A chainable assertion.
        /// </returns>
        /// <exception cref="FluentAssertionException">Execution was strictly above limit.</exception>
        public IChainableFluentAssertion<ILambdaAssertion> LastsLessThan(double threshold, TimeUnit timeUnit)
        {
            double comparand = TimeHelper.GetInNanoSeconds(threshold, timeUnit);
            if (this.durationInNs > comparand)
            {
                throw new FluentAssertionException(string.Format("\nThe actual code execution lasted more than {0} {1}.", threshold, timeUnit));
            }

            return new ChainableFluentAssertion<ILambdaAssertion>(this);
        }

        /// <summary>
        /// Check that the code does not throw an exception.
        /// </summary>
        /// <returns>
        /// A chainable assertion.
        /// </returns>
        /// <exception cref="FluentAssertionException">The code raised an exception.</exception>
        public IChainableFluentAssertion<ILambdaAssertion> DoesNotThrow()
        {
            if (this.exception != null)
            {
                throw new FluentAssertionException(string.Format("\nThe actual code raised the exception:\n----\n[{0}]\n----", this.exception));
            }

            return new ChainableFluentAssertion<ILambdaAssertion>(this);
        }

        /// <summary>
        /// Checks that the code did throw an exception of a specified type.
        /// </summary>
        /// <typeparam name="T">Expected exception type.</typeparam>
        /// <returns>
        /// A chainable assertion.
        /// </returns>
        /// <exception cref="FluentAssertionException">The code did not raised an exception of the specified type, or did not raised an exception at all.</exception>
        public IChainableFluentAssertion<ILambdaAssertion> Throws<T>()
        {
            if (this.exception == null)
            {
                throw new FluentAssertionException(string.Format("\nThe actual code did not raise an exception of type:\n\t[{0}]\nas expected.", typeof(T)));
            }

            if (!(this.exception is T))
            {
                throw new FluentAssertionException(string.Format("\nThe actual code thrown exception of type:\n\t[{0}]\ninstead of the expected exception type:\n\t[{1}].\nThrown exception was:\n----\n[{2}]\n----", this.exception.GetType(), typeof(T), this.exception));
            }

            return new ChainableFluentAssertion<ILambdaAssertion>(this);
        }

        /// <summary>
        /// Checks that the code did throw an exception of any type.
        /// </summary>
        /// <returns>
        /// A chainable assertion.
        /// </returns>
        /// <exception cref="FluentAssertionException">The code did not raised an exception of any type.</exception>
        public IChainableFluentAssertion<ILambdaAssertion> ThrowsAny()
        {
            if (this.exception == null)
            {
                throw new FluentAssertionException("\nThe actual code did not raise an exception as expected.");
            }

            return new ChainableFluentAssertion<ILambdaAssertion>(this);
        }

        private void Execute()
        {
            var watch = new Stopwatch();
            try
            {
                watch.Start();
                this.Value();
            }
            catch (Exception e)
            {
                this.exception = e;
            }
            finally
            {
                watch.Stop();
            }
            // ReSharper disable PossibleLossOfFraction
            this.durationInNs = watch.ElapsedTicks * 1000000000 / Stopwatch.Frequency;
        }
    }
}