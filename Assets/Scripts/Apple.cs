using UnityEngine;

namespace DefaultNamespace
{
    public class Apple : Fruit
    {
        public Apple()
        {
            Debug.Log("1st Apple Constructor Called");
        }

        
        public override void Chop1()
        {
            base.Chop1();
            Debug.Log("Chop1 in apple class");        

        }

        public override void SayHello1()
        {
            base.SayHello1();
            Debug.Log("The apple has been chopped.");        

        }

        
        

        
    }
}