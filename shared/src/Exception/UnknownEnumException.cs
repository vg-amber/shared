// Copyright 2021-2023 Vg-Amber Project
// Licensed under Apache License 2.0 or any later version
// Refer to the LICENSE file included.

using System;
using System.Diagnostics.CodeAnalysis;

namespace Amber.Shared.Exception;

/// <summary>
/// Exception thrown when an unknown enumeration value is encountered
/// </summary>
/// <typeparam name="T">Enumeration type</typeparam>
public class UnknownEnumException<T> : System.Exception where T : Enum {
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="value">Unknown value</param>
    [SetsRequiredMembers]
    public UnknownEnumException(T value) : base($"Unknown {typeof(T).Name}: {value}") => Value = value;

    /// <summary>
    /// Unknown value
    /// </summary>
    public required T Value { get; init; }
}