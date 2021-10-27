using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour{

  public GameObject score_object = null;
  public int score_num = 0;

  void Start(){
    score_num = PlayerPrefs.GetInt("SCORE",0);
  }

  void OnDestroy(){
    PlayerPrefs.SetInt("SCORE",score_num);
    PlayerPrefs.Save();
  }

  void Update(){
    Text score_text = score_object.GetComponent<Text>();
    score_text.text = "Score:"+score_num;
    score_num += 1;
  }
}
