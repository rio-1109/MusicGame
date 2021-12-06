using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReceiveScript : MonoBehaviour{
  GameObject go;
  SendScript ss;

    // Start is called before the first frame update
    public void Start(){
      //Scoreというオブジェクトを探す
      //これ　go = GameObject.Find("Score");

      go = GameObject.Find("ScoreText");
      ss = go.GetComponent<SendScript>();

      Text score = ss.send;
      Debug.Log(score);

    }

    // Update is called once per frame
    void Update(){
      //これ　go.GetComponent<GameManager>().ReturnScore();

      //新しく変数を作って、「SendScript」の変数「ScoreData」を入れる
      //int score = gm.score;
      //Debug.Log ("スコアは" + score);

      //これ　Debug.Log(GetComponent<GameManager>().ReturnScore());
    }
}
