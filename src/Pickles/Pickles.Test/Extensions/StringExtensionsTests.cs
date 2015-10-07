﻿//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="StringExtensionsTests.cs" company="PicklesDoc">
//  Copyright 2011 Jeffrey Cameron
//  Copyright 2012-present PicklesDoc team and community contributors
//
//
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0
//
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using System;
using NFluent;
using NUnit.Framework;
using PicklesDoc.Pickles.Extensions;

namespace PicklesDoc.Pickles.Test.Extensions
{
    [TestFixture]
    public class StringExtensionsTests
    {
        [Test]
        public void IsNullOrWhiteSpace_ContentPresent_ReturnsFalse()
        {
            string s = "some text";

            bool result = s.IsNullOrWhiteSpace();

            Check.That(result).IsFalse();
        }

        [Test]
        public void IsNullOrWhiteSpace_EmptyString_ReturnsTrue()
        {
            string s = "";

            bool result = s.IsNullOrWhiteSpace();

            Check.That(result).IsTrue();
        }

        [Test]
        public void IsNullOrWhiteSpace_NullArgument_ReturnsTrue()
        {
            string s = null;

            bool result = s.IsNullOrWhiteSpace();

            Check.That(result).IsTrue();
        }

        [Test]
        public void IsNullOrWhiteSpace_WhiteSpace_ReturnsTrue()
        {
            string s = "  ";

            bool result = s.IsNullOrWhiteSpace();

            Check.That(result).IsTrue();
        }
    }
}