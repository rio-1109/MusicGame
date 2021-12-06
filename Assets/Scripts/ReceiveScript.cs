using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ReceiveScript : MonoBehaviour{

  public Text scoreText;
  public static int x;
  public static string y;

  void Start(){
    x = GameManager.score;
    y = x.ToString();
    scoreText.text = y;
    //Debug.Log(y);
  }

  void Update(){
    //int score = this.GetComponent<GameManager>().OnEndEvent2();
  }
}
