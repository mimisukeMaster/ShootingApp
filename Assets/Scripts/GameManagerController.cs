using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// ゲームの進行、スコア判定など総括的な処理を行うスクリプト
public class GameManagerController : MonoBehaviour
{
    //スコア表示用テキスト
    public TextMeshPro ScoreUI;
    
    int score;

    // Start関数は、ゲーム開始直後一回だけ実行される
    void Start()
    {
        // スコアの初期値を設定
        score = 0;
    }

    // Update関数は毎フレームごとに実行される
    void Update()
    {
        
    }

    public void DefeatEnemy() {
        // 適尾を倒したときにスコアを加算する処理
        
        //・・・・・・・・・・・・・

        ScoreUI.text = "Score: " + score;
    }
}
