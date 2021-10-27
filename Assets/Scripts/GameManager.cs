using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
  //TODO:UIの作成
  //カウントダウンのテキスト
  [SerializeField] Text countDownText = default;
  //ゲーム終了時のリザルトパネル
  [SerializeField] GameObject resultPanel = default;
  //ゲーム中のスコア表示
  [SerializeField] Text scoreText = default;

  [SerializeField] PlayableDirector playableDirector;

  int score;
    void Start()
    {
      StartCoroutine(GameMain());
    }
    IEnumerator GameMain()
    {
      countDownText.text = "3";
      yield return new WaitForSeconds(1);
      countDownText.text = "2";
      yield return new WaitForSeconds(1);
      countDownText.text = "1";
      yield return new WaitForSeconds(1);
      countDownText.text = "GO!";
      yield return new WaitForSeconds(0.5f);
      countDownText.text = "";
      playableDirector.Play();
    }

    //どのタイミングでSCOREを上昇させるか
    public void AddScore(int point)
    {
      score += point;
      scoreText.text = score.ToString();
    }

    public void OnEndEvent()
    {
      Debug.Log("ゲーム終了：結果表示");
      resultPanel.SetActive(true);
    }
    public void OnRetry()
    {
      SceneManager.LoadScene("SampleScene");
    }
}
