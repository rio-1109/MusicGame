using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToScene4 : MonoBehaviour{
  private float time;

  void Start(){
    time = 0.0f;
  }

  void Update(){
    time += Time.deltaTime;

    if(time>=3.0f){
      SceneManager.LoadScene("Scene4");
    }
  }
}
