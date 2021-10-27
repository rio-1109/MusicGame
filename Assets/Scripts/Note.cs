using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    //下に落ちる
    //todo:落ちる速度を曲と判定場所との距離から設定する必要がある
    //音を１小節分遅らせて鳴らす＝＞ノーツは１小節分早く生成される
    //判定場所に来た時に音がなればいい＝＞速度：判定場所までの距離/１小節の長さ

    float speed;

    //1小節の長さ:BPM120から計算する（４＊６０/BPM）
    //BPM120
    //=> 60秒間に120回音が入る
    //=>1回あたり0.5秒(60/120)
    //=>1小節：音が4回なる　=> 4*0.5 = 2秒 => 1小節の長さ＝２秒

    //判定場所までの距離はいくらか
    //10-(-50) => 60
    private void Start()
    {
      speed = 30;
    }
    void Update()
    {
        transform.Translate(0,-speed * Time.deltaTime, 0);
    }
}
