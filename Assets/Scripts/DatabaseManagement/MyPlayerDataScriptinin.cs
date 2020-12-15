using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.DatabaseManagement;
using Proyecto26;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class MyPlayerDataScriptinin : MonoBehaviour
{
    public Text scoreText;
    public InputField playerNameText;
    private Random random = new Random();
    public static string playerName;
    public static int playerScore;


    private void Start()
    {
        playerScore = random.Next(1,101);
        scoreText.text = "Score : " + playerScore;
        
    }


    public void OnSubmit()
    {
        playerName =  playerNameText.text;
        PostToDatabase();
    }

    private void PostToDatabase()
    {
        User usr = new User();
        RestClient.Put(
            "https://unity-test-7a83f-default-rtdb.europe-west1.firebasedatabase.app/" + playerName + ".json", usr);
    }
}
