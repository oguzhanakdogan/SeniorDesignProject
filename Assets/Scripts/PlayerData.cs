using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public Vector3 position;
    public int health;
    public Dictionary<string, int> questionword;
    public string[] mantar = {"mantar"};
    public PlayerData()
    {
        position = new Vector3(10,-5,8);
        questionword = new Dictionary<string, int>();
        questionword.Add("selam",1);
        health = 100;
    }
    
    
}
