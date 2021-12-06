using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Perfect : MonoBehaviour{

  public Text scoreText;
  public static int x;
  public static string y;

  void Start(){
    x = GameManager.perfect;
    y = x.ToString();
    scoreText.text = "Perfect: " + y;
  }

  void Update(){

  }
}
