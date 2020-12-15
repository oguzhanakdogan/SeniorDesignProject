using UnityEditor;
using UnityEngine;

namespace DefaultNamespace
{
    public class Fruit
    {
        public Fruit()
        {
        Debug.Log("Fruit is created");    
        }

        public void Chop()
        {
            Debug.Log("Chop method called in Fruit Clas");
        }

        public void SayHello()
        {
            Debug.Log("SayHello method called in Fruit Clas");
        }
        
        public virtual void Chop1 ()
        {
            Debug.Log("Chop1 method called in Fruit Clas");        
        }

        public virtual void SayHello1 ()
        {
            Debug.Log("SayHello1 method called in Fruit Clas");
        }
    }
}