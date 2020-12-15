using UnityEngine;
using UnityEngine.Assertions.Comparers;

namespace DefaultNamespace
{
    public class IntegerValue
    {

        public T Values<T>(T value) where T : struct
        {
            return value;
        }
    }
}