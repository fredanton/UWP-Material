﻿using System;
using System.Collections.Concurrent;

namespace UWP_Material.Helpers
{
    internal static class Singleton<T>
        where T : new()
    {
        private static readonly ConcurrentDictionary<Type, T> _instances = new ConcurrentDictionary<Type, T>();

        public static T Instance => _instances.GetOrAdd(typeof(T), (t) => new T());
    }
}
