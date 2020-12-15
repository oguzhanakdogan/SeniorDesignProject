using UnityEditorInternal.Profiling.Memory.Experimental;

namespace DefaultNamespace
{
    public class GenericClass <T>
    {
        private T item;

        public void UpdateItem(T newItem)
        {
            item = newItem;
        }

        public T Item
        {
            get
            {
                return item;
            }
            set
            {
                item = value;
            }
        }
    }
}