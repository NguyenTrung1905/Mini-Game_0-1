using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyChar : MonoBehaviour
{
    string charName = "Chưa có tên";
    //int health = 7;
    //float weight = 7.5f;
    //float runSpeed = 15f;

    void Start()
    {
        Debug.Log("Start");
        this.charName = this.GetMyCharName();
        Debug.Log(this.charName);
    }

    void Update()
    {
        Debug.Log("Update");

    }
    string GetMyCharName()
    {
        string newName = "Nghi";
        Debug.Log("GetMyCharName");
        return newName;
    }

}
