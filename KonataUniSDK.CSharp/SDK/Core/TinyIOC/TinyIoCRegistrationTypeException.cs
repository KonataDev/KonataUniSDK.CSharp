//===============================================================================
// TinyIoC
//
// An easy to use, hassle free, Inversion of Control Container for small projects
// and beginners alike.
//
// https://github.com/grumpydev/TinyIoC
//===============================================================================
// Copyright © Steven Robbins.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

using System;

namespace KonataCSharp.SDK.Core.TinyIOC
{
    [Serializable]
    public class TinyIoCRegistrationTypeException : Exception
    {
        private const string RegisterErrorText =
            "Cannot register type {0} - abstract classes or interfaces are not valid implementation types for {1}.";

        public TinyIoCRegistrationTypeException(Type type, string factory)
            : base(string.Format(RegisterErrorText, type.FullName, factory))
        {
        }
    }
}