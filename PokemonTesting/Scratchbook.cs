using System;
using System.Collections;
using Microsoft.AspNetCore.Http.Features;
using static PokemonTesting.EnumeratorTestingClass;

namespace PokemonTesting;

public class EnumeratorTestingClass
{

    public class PokemonList<T> : IEnumerable<T>
    {
        private readonly List<T> _items = new List<T>();

        public void Add(T item) => _items.Add(item);

        public void AddRange(T[] items)
        {
            foreach (T item in items)
            {
                Add(item);
            }

        }


        public IEnumerator<T> GetEnumerator() //=> _items.GetEnumerator();
        {
            return _items.GetEnumerator();
        }


        IEnumerator IEnumerable.GetEnumerator() //=> GetEnumerator();
        {
            return GetEnumerator();
        }
    }



}
        public static class PokemonListExtensions
        {
            //Adds a method to the PokemonList Class.
            public static string ExtendedMethodExample<T>(this PokemonList<T> list)
    {
        return "Pokemon list currently contains" + list.Count() + "Pokemon.";
    }
        }

