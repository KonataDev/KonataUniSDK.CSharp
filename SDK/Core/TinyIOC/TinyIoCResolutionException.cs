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
    public class TinyIoCResolutionException : Exception
    {
        private const string ErrorText = "Unable to resolve type: {0}";

        public TinyIoCResolutionException(Type type)
            : base(string.Format(ErrorText, type.FullName))
        {
        }

        public TinyIoCResolutionException(Type type, Exception innerException)
            : base(string.Format(ErrorText, type.FullName), innerException)
        {
        }
    }
}