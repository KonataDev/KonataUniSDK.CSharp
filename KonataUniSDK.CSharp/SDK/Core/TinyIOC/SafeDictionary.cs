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
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace KonataCSharp.SDK.Core.TinyIOC
{
    public class SafeDictionary<TKey, TValue> : IDisposable
    {
        private readonly Dictionary<TKey, TValue> _dictionary = new();
        private readonly ReaderWriterLockSlim _padlock = new();

        public TValue this[TKey key]
        {
            set
            {
                _padlock.EnterWriteLock();

                try
                {
                    if (_dictionary.TryGetValue(key, out var current))
                        if (current is IDisposable disposable)
                            disposable.Dispose();

                    _dictionary[key] = value;
                }
                finally
                {
                    _padlock.ExitWriteLock();
                }
            }
        }

        public void Dispose()
        {
            _padlock.EnterWriteLock();

            try
            {
                var disposableItems = from item in _dictionary.Values
                    where item is IDisposable
                    select item as IDisposable;

                foreach (var item in disposableItems) item.Dispose();
            }
            finally
            {
                _padlock.ExitWriteLock();
            }

            GC.SuppressFinalize(this);
        }


        public bool TryGetValue(TKey key, out TValue value)
        {
            _padlock.EnterReadLock();
            try
            {
                return _dictionary.TryGetValue(key, out value);
            }
            finally
            {
                _padlock.ExitReadLock();
            }
        }
    }
}