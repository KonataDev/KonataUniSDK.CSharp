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

namespace KonataCSharp.SDK.Core.TinyIOC
{
    public sealed class ResolveOptions
    {
        public UnregisteredResolutionActions UnregisteredResolutionAction { get; set; } =
            UnregisteredResolutionActions.AttemptResolve;

        public NamedResolutionFailureActions NamedResolutionFailureAction { get; set; } =
            NamedResolutionFailureActions.Fail;

        /// <summary>
        ///     Gets the default options (attempt resolution of unregistered types, fail on named resolution if name not found)
        /// </summary>
        public static ResolveOptions Default { get; } = new();
    }
}