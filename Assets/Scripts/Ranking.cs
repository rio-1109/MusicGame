using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour {

    [SerializeField,Header("数値")]
    int point;

    string[] ranking = { "1st", "2nd", "3rd", "4th", "5th" };
    int[] rankingValue = new int[5];

    [SerializeField, Header("表示させるテキスト")]
    Text[] rankingText = new Text[5];

    // Use this for initialization
    void Start ()
    {
        GetRanking();

        SetRanking(point);

        for (int i = 0; i < rankingText.Length; i++)
        {
            rankingText[i].text = rankingValue[i].ToString();
        }
    }

    /// <summary>
    /// ランキング呼び出し
    /// </summary>
    void GetRanking()
    {
        //ランキング呼び出し
        for (int i = 0; i < ranking.Length; i++)
        {
            rankingValue[i]=PlayerPrefs.GetInt(ranking[i]);
        }
    }
    /// <summary>
    /// ランキング書き込み
    /// </summary>
    void SetRanking(int _value)
    {
        //書き込み用
        for (int i = 0; i < ranking.Length; i++)
        {
                //取得した値とRankingの値を比較して入れ替え
                if (_value>rankingValue[i])
                {
                    var change = rankingValue[i];
                    rankingValue[i] = _value;
                    _value = change;
                }
        }

        //入れ替えた値を保存
        for (int i = 0; i < ranking.Length; i++)
        {
            PlayerPrefs.SetInt(ranking[i],rankingValue[i]);
        }
    }
}
