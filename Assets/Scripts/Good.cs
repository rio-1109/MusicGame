using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Good : MonoBehaviour{

  public Text scoreText;
  public static int x;
  public static string y;

  void Start(){
    x = GameManager.good;
    y = x.ToString();
    scoreText.text = "Good: " + y;
  }

  void Update(){

  }
}
