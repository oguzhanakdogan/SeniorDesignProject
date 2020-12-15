using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using DefaultNamespace;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddQuestion : MonoBehaviour
{
    public GameObject WordInputTextPref;
    public GameObject OrderInputTextPref;
    public Transform InputTextContainer;
    public Button AddButton;

    private object[] key;
    private object[] value;

    private int count;

    private List<GameObject> _list;
    // Start is called before the first frame update
    void Start()
    {
        _list = new List<GameObject>();
        count = 0;
        value = new object[2];
        key = new object[2];
        
        
        for (int i = 0; i < 2; i++)
        {
            GameObject wordInput = Instantiate(WordInputTextPref);
            GameObject OrderInput = Instantiate(OrderInputTextPref);
            wordInput.transform.SetParent( InputTextContainer);
            OrderInput.transform.SetParent(InputTextContainer); 
            wordInput.transform.localScale = new Vector3(1, 1, 1);
            OrderInput.transform.localScale = new Vector3(1, 1, 1);
            wordInput.transform.name = count.ToString();
            OrderInput.transform.name = count.ToString();
            OrderInput.transform.GetComponent<TMP_InputField>().onEndEdit.AddListener(delegate{EditOrder( 
                OrderInput.transform.GetComponent<TMP_InputField>().text , OrderInput.transform.GetComponent<TMP_InputField>().name
            );});
            wordInput.transform.GetComponent<TMP_InputField>().onEndEdit.AddListener(delegate{EditWord( 
                wordInput.transform.GetComponent<TMP_InputField>().text, wordInput.transform.GetComponent<TMP_InputField>().name
            );});
            count++;
            
            _list.Add(wordInput);
            _list.Add(OrderInput);
        }
        
    }

    public void AddButtonFunc()
    {
        key = (object[])ResizeArray(key,key.Length + 1);
        value = (object[])ResizeArray(value,value.Length + 1);

        GameObject wordInput = Instantiate(WordInputTextPref);
        GameObject OrderInput = Instantiate(OrderInputTextPref);
        wordInput.transform.SetParent( InputTextContainer);
        OrderInput.transform.SetParent(InputTextContainer); 
        wordInput.transform.localScale = new Vector3(1, 1, 1);
        OrderInput.transform.localScale = new Vector3(1, 1, 1);
        wordInput.transform.name =  count.ToString();
        OrderInput.transform.name = count.ToString();
        OrderInput.transform.GetComponent<TMP_InputField>().onEndEdit.AddListener(delegate{EditOrder( 
            OrderInput.transform.GetComponent<TMP_InputField>().text, OrderInput.transform.GetComponent<TMP_InputField>().name
            );});
        
       
        
        
        
        wordInput.transform.GetComponent<TMP_InputField>().onEndEdit.AddListener(delegate{EditWord( 
            wordInput.transform.GetComponent<TMP_InputField>().text, wordInput.transform.GetComponent<TMP_InputField>().name
        );});
        //  wordInput.GetComponent<InputField>().onEndEdit.AddListener;
        count++;

       _list.Add(wordInput); 
       _list.Add(OrderInput);
    }

   

    // Update is called once per frame
    void Update()
    {
        
    }
    private void EditOrder(object text, string name)
    {
        int index = int.Parse(name);
        this.value[index] = text;
        Debug.Log("eklendi => " + value[index] + " index ise " + index);
    }
    private void EditWord(object text, string name)
    {
        int index = int.Parse(name);
        this.key[index] = text;
        Debug.Log("eklendi => " + key[index] + " index ise " + index);
        if (index >= 1)
        {
            Debug.Log(" bir önceki eklendi => " + key[index - 1] + " index ise " + (index - 1) );
        }
    }

    private void onSelect1(string text)
    {
     //   int index = value.FindIndex(a => a.Equals(text));
        Debug.Log("index is " );

    }
    
    public static System.Array ResizeArray (System.Array oldArray, int newSize)  
    {
        int oldSize = oldArray.Length;
        System.Type elementType = oldArray.GetType().GetElementType();
        System.Array newArray = System.Array.CreateInstance(elementType,newSize);

        int preserveLength = System.Math.Min(oldSize,newSize);

        if (preserveLength > 0)
            System.Array.Copy (oldArray,newArray,preserveLength);

        return newArray; 
    }

    public void toJson()
    {
        string path = "Assets/Data/path.json";
        string jsonString =  File.ReadAllText(path);
        Dictionary<String, object> result = JsonConvert.DeserializeObject<Dictionary<String, object>>(jsonString);
        int count = result.Keys.Count;
        Debug.Log("count => " + count);
        MyJsonDictionary<String, object> Question = new MyJsonDictionary<String, object>();
            result["Question" + (count+1)] = Question;
            int index = 0;
            foreach (object VARIABLE in key)
            {
                Question[VARIABLE.ToString()] = value[index];
                index++;
            }
        
            Question["solved"] = false;
            Debug.Log( Serialize( result ) );
            string data = Serialize(result);
            System.IO.File.WriteAllText("Assets/Data/path.json", data);
            for (int i = 0; i < _list.Count; i++)
            {
                _list.RemoveAt(i);
                
            }
            value = new object[2];
            key = new object[2];
    }
    
    public void toJson1()
    { string path = "Assets/Data/path.json";
     string jsonString =  File.ReadAllText(path);
     MyJsonDictionary<String, object> exactResult = new MyJsonDictionary<String, object>();
    
     Dictionary<String, object> result1 = JsonConvert.DeserializeObject<Dictionary<String, object>>(jsonString);
       // Debug.Log(  "result 1 => " + Serialize( result1["Question"] )  );
       int count = 0;
       foreach (object VARIABLE in result1.Keys)
       {
           object readquestionStr = result1[VARIABLE.ToString()];
           Dictionary<String, object> result2 = JsonConvert.DeserializeObject<Dictionary<String, object>>( readquestionStr.ToString());
           MyJsonDictionary<String, object> forOneQuestion = new MyJsonDictionary<String, object>();
           exactResult["Question" + count] = forOneQuestion;
           foreach (object VARIABLE2 in result2.Keys)
           {
               if (VARIABLE2.ToString().Equals("__type") || VARIABLE2.ToString().Equals("solved"))
               {
                   continue;
               }
               object readquestion2Str = VARIABLE2.ToString();
                Debug.Log("keys => " + readquestion2Str.ToString());
                forOneQuestion[readquestion2Str.ToString()] = result2[VARIABLE2.ToString()];
           }

           count++;

       }
       
       
       
       MyJsonDictionary<String, object> newQuestion = new MyJsonDictionary<String, object>();
       exactResult["Question" + (count)] = newQuestion;
       int index = 0;
       foreach (object VARIABLE in key)
       {
           newQuestion[VARIABLE.ToString()] = value[index];
           index++;
       }
        
       newQuestion["solved"] = false;
       
       
       
       //object readquestion2Str = result1["Question"];
       //Dictionary<String, object> ReadQuestion2 = JsonConvert.DeserializeObject<Dictionary<String, object>>( readquestion2Str.ToString());

        //MyJsonDictionary<String, object> result = new MyJsonDictionary<String, object>();
        
        
        
      //result["foo"] = "bar";
      //result["Name"] = "John Doe";
      //result["Age"] = 32;
     

      Debug.Log( "exact => " +Serialize( exactResult ) );
      string data = Serialize(exactResult);
      System.IO.File.WriteAllText("Assets/Data/path.json", data);
    }      public static  String Serialize( object data ) {
        var serializer = new DataContractJsonSerializer( data.GetType() );
        var ms = new MemoryStream();
        serializer.WriteObject( ms, data );
        
        return Encoding.UTF8.GetString( ms.ToArray() );
    }
    
    
}
