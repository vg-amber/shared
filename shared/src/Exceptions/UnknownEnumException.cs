using System;

namespace Amber.Shared.Exceptions {
    /// <summary>
    /// Exception thrown when an unknown enumeration value is encountered
    /// </summary>
    /// <typeparam name="T">Enumeration type</typeparam>
    public class UnknownEnumException<T> : Exception where T : Enum {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value">Unknown enumeration value</param>
        public UnknownEnumException(T value) : base($"Unknown {typeof(T).Name}: {value}") { }
    }
}