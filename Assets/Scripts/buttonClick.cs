using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using DefaultNamespace;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class buttonClick : MonoBehaviour
{
    public GameObject buttonPrefab;
    public Transform buttonContainer;
    public Transform answerContainer;
    private int questionCount = 0;
    public GameObject Menu;
    public Button true_Button;
    public Button false_Button;
    public Button exit_Button;
    private List<GameObject> _button_array;
    private LinkedList<int> _linkedListButton;
    public Sprite trueImage;
    public Sprite falseImage;

    private void Start()
    {
        _linkedListButton = new LinkedList<int>();
        _button_array = new List<GameObject>();
       //WriteQuestion();
     exit_Button.onClick.AddListener(ToMenu);
       string path = "Assets/Data/path.json";
       string jsonString =  File.ReadAllText(path);
       Dictionary<string, object> ReadQuestion1 = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonString);

            GenerateQuestion(ReadQuestion1);
            

        //true_Button.onClick.AddListener((() => GenerateQuestionInButton(ReadQuestion1)));
        false_Button.onClick.AddListener((() => GenerateQuestionInButton(ReadQuestion1)));
        true_Button.gameObject.SetActive(false);
       //  WriteQuestion();



       // MyJsonDictionary<String, object> ReadQuestion = JsonConvert.DeserializeObject<MyJsonDictionary<String, object>>(jsonString);
       // Debug.Log( "json string" +jsonString);

       // object readquestion1Str = ReadQuestion1["Question"];
       // Debug.Log(readquestion1Str.ToString());

       //writeFile(data);




    }

    private void GenerateQuestionInButton(Dictionary<string, object> ReadQuestion1)
    {
        _linkedListButton = new LinkedList<int>();
        true_Button.gameObject.SetActive(false);
        foreach (GameObject VAR in _button_array)
        {
            Destroy(VAR);
        }
        _button_array = new List<GameObject>();
        questionCount++;
    GenerateQuestion(ReadQuestion1);        
    } 
   
    
    private void GenerateQuestion(Dictionary<string, object> ReadQuestion1)
    {
        int count = 0;
        foreach (object VARIABLE0 in ReadQuestion1.Keys)
        {
            if (count != questionCount)
            {
                count++;
                continue;
            }
            object readquestion2Str = ReadQuestion1[VARIABLE0.ToString()];
            Dictionary<string, object> ReadQuestion2 = JsonConvert.DeserializeObject<Dictionary<string, object>>( readquestion2Str.ToString());
       
            Debug.Log("Variable 0 => " + VARIABLE0);
            
            foreach (object VARIABLE in ReadQuestion2.Keys)
            {
                if (VARIABLE.ToString().Equals("__type") || VARIABLE.ToString().Equals("solved"))
                {
                    continue;
                }
                GameObject go = Instantiate(buttonPrefab) as GameObject;
                //go.transform.position = new Vector3(-9.75f,4.49f,0);
                //go.transform.localScale = new Vector3(1,1,1);
                _button_array.Add(go);
                go.transform.SetParent(buttonContainer);
                go.GetComponent<Button>().transform.localScale = new Vector3(1, 1, 1);
                go.GetComponent<Button>().onClick.AddListener(() => onClickListener(go.GetComponent<Button>(),
                     ReadQuestion2[VARIABLE.ToString()]  ));
                go.GetComponent<Button>().GetComponentInChildren<Text>().text = VARIABLE.ToString();
            }
            return;
        }
       
        
    }

    private void onClickListener(Button i, object id)
    {
        int id1 = Convert.ToInt32(id);
        Debug.Log("mantar " + i);
        Debug.Log("button name" + i.GetComponent<Button>().GetComponentInChildren<Text>().text);
        if (i.transform.parent == answerContainer)
        {
            _linkedListButton.Remove(id1);
            i.transform.SetParent(buttonContainer);
        }
        else
        {
            _linkedListButton.AddLast(id1);
            i.transform.SetParent(answerContainer);
        } //Destroy(i.gameObject);
    }
    
    public static  String Serialize( object data ) {
        var serializer = new DataContractJsonSerializer( data.GetType() );
        var ms = new MemoryStream();
        serializer.WriteObject( ms, data );
        
        return Encoding.UTF8.GetString( ms.ToArray() );
    }

    public void WriteQuestion()
    {
        MyJsonDictionary<String, object> result = new MyJsonDictionary<String, object>();
        //result["foo"] = "bar";
        //result["Name"] = "John Doe";
        //result["Age"] = 32;
        MyJsonDictionary<String, object> Question = new MyJsonDictionary<String, object>();
        result["Question"] = Question;
        Question["okula"] = 2;
        Question["ben"] = 1;
        Question["gittim"] = 3;
        Question["solved"] = false;
        MyJsonDictionary<String, object> Question1 = new MyJsonDictionary<String, object>();
        result["Question1"] = Question1;
        Question1["gideceğimi"] = 4;
        Question1["zaman"] = 2;
        Question1["bilmiyorum"] = 5;
        Question1["ne"] = 1;
        Question1["eve"] = 3;
        Question1["solved"] = false;

        Debug.Log( Serialize( result ) );
        string data = Serialize(result);
        System.IO.File.WriteAllText("Assets/Data/path.json", data);
    }
    
    private void ToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }

    public void Check()
    {
        int count = 1;
        foreach (var VARIABLE in _linkedListButton)
        {
            if (VARIABLE == count ||VARIABLE == 0)
            {
                
            }
            else
            {
                true_Button.gameObject.SetActive(true);
                true_Button.GetComponent<Image>().sprite = falseImage;
                Debug.Log("yanlis" + VARIABLE);
                
                return;
            }

            count++;
        }

        if (count-1 != _button_array.Count)
        {
            true_Button.gameObject.SetActive(true);
            true_Button.GetComponent<Image>().sprite = falseImage;
            Debug.Log("AOOOWWW Bişeyler ters gitti" + _button_array.Count);
            return;
        }
        true_Button.gameObject.SetActive(true);
        true_Button.GetComponent<Image>().sprite = trueImage;
        Debug.Log("Doğru");
    }
    
}