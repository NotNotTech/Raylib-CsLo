//# raylib 4.0 bindings.   Lgpl Licensed.  Source here: https://github.com/NotNotTech/Raylib-CsLo
//# Find Raylib+docs here:   https://github.com/raysan5/raylib/blob/master/src/raylib.h
//# This file, and it's containing folder are automatically generated.  Do not Modify.
using System;
using System.Diagnostics;

namespace Raylib_CsLo
{
    /// <summary>Defines the base type of a struct as it was in the native signature.</summary>
    [AttributeUsage(AttributeTargets.Struct, AllowMultiple = false, Inherited = true)]
    [Conditional("DEBUG")]
    internal sealed partial class NativeInheritanceAttribute : Attribute
    {
        private readonly string _name;

        /// <summary>Initializes a new instance of the <see cref="NativeInheritanceAttribute" /> class.</summary>
        /// <param name="name">The name of the base type that was inherited from in the native signature.</param>
        public NativeInheritanceAttribute(string name)
        {
            _name = name;
        }

        /// <summary>Gets the name of the base type that was inherited from in the native signature.</summary>
        public string Name => _name;
    }
}
