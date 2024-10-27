using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// ゲームの進行、スコア判定など総括的な処理を行うスクリプト
public class GameManagerController : MonoBehaviour
{
    //スコア表示用テキスト
    public TextMeshProUGUI ScoreUI;

    public Image HPGauge;
    
    float maxHPGauge;
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

    public void SetMaxHP(int maxHP) {

        // プレイヤーの体力の最大値をHPゲージの最大値に設定
        maxHPGauge = maxHP;
    }

    public void DefeatEnemy() {
        // 敵をを倒したときにスコアを加算する処理
        
        //・・・・・・・・・・・・・

        ScoreUI.text = "Score: " + score;
    }

    public void DecreaseHP(float weight) {
        HPGauge.fillAmount = weight / maxHPGauge;
    }
}
