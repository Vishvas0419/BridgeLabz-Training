using System;
using System.Collections.Generic;
using System.Text;

namespace _01Generics
{
    public interface IReadOnlyStorage<out T>
    {
        T GetItemAt(int index);
        int Count { get; }
    }
}
