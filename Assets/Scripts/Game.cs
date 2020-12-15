using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace DefaultNamespace
{
    public class Game:MonoBehaviour
    {
        
     
        private void Awake()
        {
            
        }

        private void Reset()
        {
        }
        public static  String Serialize( object data ) {
            var serializer = new DataContractJsonSerializer( data.GetType() );
            var ms = new MemoryStream();
            serializer.WriteObject( ms, data );

            return Encoding.UTF8.GetString( ms.ToArray() );
        }


        private void Start()
        {
            Player myPlayer = new Player();
            myPlayer.Experience = 5;
            int x = myPlayer.Experience;
            Debug.Log("x = > " + x + " i => " + myPlayer.İ);
            SomeClass someClass = new SomeClass();
            bool y = someClass.GenericMethod(true);
            Debug.Log("y = > " +y );
            float z = someClass.GenericMethod(new float());
            Debug.Log("z = > " +z );
            someClass.GenericMethod(5);
            Debug.Log("z = > " + someClass.GenericMethod<bool>(true).GetType());
            
            
            IntegerValue integerValue = new IntegerValue();
            int p = integerValue.Values(5);
            GenericClass<int> genericClass = new GenericClass<int>();
            genericClass.Item = p;
            Debug.Log("p => " + genericClass.Item.GetType());
            
            Fruit apple = new Apple();
            apple.Chop();
            apple.Chop1();
            //GameObject goButton = Instantiate(Button);
            
           // goButton.transform.localScale = new Vector3(1, 1, 1);
           
           //realButton.transform.SetParent(this.Button.transform);
      
           PlayerData playerData = new PlayerData();
           string json = JsonUtility.ToJson(playerData);
           
           Debug.Log(json);
           

            MyJsonDictionary<String, object> result = new MyJsonDictionary<String, object>();
            result["foo"] = "bar";
            result["Name"] = "John Doe";
            result["Age"] = 32;
            MyJsonDictionary<String, object> Question = new MyJsonDictionary<String, object>();
            result["Question"] = Question;
            Question["ben"] = 1;
            Question["okula"] = 2;
            Question["gittim"] = 3;
            Question["solved"] = false;


            Debug.Log( Serialize( result ) );

            //Console.ReadLine();
        }
        
       
        private void Update()
        {
        }
    }
    
    
   
}