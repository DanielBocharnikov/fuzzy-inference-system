﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FuzzyInferenceSystem.SeedWork
{
  public abstract class Enumeration : IComparable
  {
    public static int AbsoluteDifference(Enumeration firstValue, Enumeration secondValue)
      => Math.Abs(firstValue.Id - secondValue.Id);

    public static T FromValue<T>(int value) where T : Enumeration
      => Parse<T, int>(value, "value", item => item.Id == value);

    public static T FromDisplayName<T>(string displayName) where T : Enumeration
      => Parse<T, string>(displayName, "display name", item => item.Name == displayName);

    private static T Parse<T, K>(K value, string description, Func<T, bool> predicate) where T : Enumeration
    {
      T matchingItem = GetAll<T>().FirstOrDefault(predicate);

      return matchingItem
        ?? throw new InvalidOperationException($"'{value}' is not a valid {description} in {typeof(T)}");
    }

    public string Name { get; private set; }

    public int Id { get; private set; }

    protected Enumeration(int id, string name) => (Id, Name) = (id, name);

    public override string ToString() => Name;

    public static IEnumerable<T> GetAll<T>() where T : Enumeration
      => typeof(T)
        .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
        .Select(field => field.GetValue(null))
        .Cast<T>();

    public override bool Equals(object obj)
    {
      if (obj is not Enumeration otherValue)
      {
        return false;
      }

      bool typeMatches = GetType().Equals(obj.GetType());
      bool valueMatches = Id.Equals(otherValue.Id);

      return typeMatches && valueMatches;
    }

    public override int GetHashCode() => Id.GetHashCode();

    public int CompareTo(object other) => Id.CompareTo((other as Enumeration)?.Id);
  }
}
