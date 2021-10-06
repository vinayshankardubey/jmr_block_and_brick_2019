using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JMRSDK.InputModule;

public class Paddle : MonoBehaviour
{
public float speed;
public ScoreScript scoresc;
public int thisTimeScore;
public GameObject controller;

    void Start(){

scoresc = FindObjectOfType<ScoreScript>();
Debug.Log(gameObject.name.ToString());
        thisTimeScore = 000;
                controller = GameObject.Find("JMRPointer(Clone)");


    }

    void Update(){

    float horizontal = Input.GetAxis("Horizontal");
        thisTimeScore++;
        
        Debug.Log(controller.ToString());


       var locationX = controller.transform.position.x;

        Debug.Log($"Location on Controller is    { controller.transform.position.x.ToString()}");
        transform.localPosition = new Vector3(locationX*1000, -399, 0);
    }
}