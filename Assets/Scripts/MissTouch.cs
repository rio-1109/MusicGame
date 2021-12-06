using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MissTouch : MonoBehaviour{

  public Text scoreText;
  public static int x;
  public static string y;

  void Start(){
    x = GameManager.miss;
    y = x.ToString();
    scoreText.text = "Miss: " + y;
  }

  void Update(){
    
  }
}
