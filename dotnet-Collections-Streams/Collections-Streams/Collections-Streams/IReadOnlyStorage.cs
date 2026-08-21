using System;
using System.Collections.Generic;
using System.Text;

namespace Collections_Streams
{
    public interface IReadOnlyStorage<out T>
    {
        T GetItemAt(int index);
        int Count { get; }
    }
}
