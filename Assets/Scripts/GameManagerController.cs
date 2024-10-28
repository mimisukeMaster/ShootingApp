using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

// ゲームの進行、スコア判定など総括的な処理を行うスクリプト
public class GameManagerController : MonoBehaviour
{
    //スコア表示用テキスト
    public TextMeshProUGUI ScoreUI;

    public Image HPGauge;
    public GameObject Enemy;
    public GameObject Boss;
    public AudioSource AudioSource;
    public AudioClip LaunchSE;
    public AudioClip HitSE;
    public AudioClip AttackSE;
    public AudioClip ButtonSE;


    float maxHPGauge;
    Transform BossHPMask;
    float maxBossHPGauge;

    int score;

    int enemyNum;

    // Start関数は、ゲーム開始直後一回だけ実行される
    void Start()
    {
        // スコアの初期値を設定
        score = 0;
        
        // 敵の生成
        enemyNum = 10;

        for (int i = 0; i < enemyNum; i++)
        {
            // x軸方向はランダムな位置に、方向は6とびずつ生成していく
            float randomX = UnityEngine.Random.Range(-2.5f, 1.5f);
            Instantiate(Enemy, new Vector2(randomX, 4 + 6 * i), Quaternion.Euler(0, 0, -90));
        }

        // ボスを生成
        // 生成する位置は、雑魚キャラを生成しきった先なので Vector2(0, 4 + 6 * enemyNum) の位置にする(最後の雑魚キャラのy座標のさらに奥)
        GameObject boss = Instantiate(Boss, new Vector2(0, 4 + 6 * enemyNum), Quaternion.Euler(0, 0, 90));

        BossHPMask = boss.transform.Find("BossHPMask");
    }

    // Update関数は毎フレームごとに実行される
    void Update()
    {
        
    }

    public void SetMaxHP(int maxHP) {

        // プレイヤーの体力の最大値をHPゲージの最大値に設定
        maxHPGauge = maxHP;
    }

    public void SetMaxBossHP(int maxHP) {
        maxBossHPGauge = maxHP;
    }

    public void DefeatEnemy() {
        // 敵をを倒したときにスコアを加算する処理
        
        //・・・・・・・・・・・・・

        ScoreUI.text = "Score: " + score;
    }

    public void DecreaseHP(float weight) {
        HPGauge.fillAmount = weight / maxHPGauge;
    }

    public void DecreaseBossHP(float weight) {
        Debug.Log(weight / maxBossHPGauge * 5);
        
        BossHPMask.position = new Vector3(
         (weight - 1) / maxBossHPGauge * 3.9f - 3.9f, BossHPMask.position.y, 0);
    }

    // 各効果音を鳴らす処理
    public void LaunchSEPlay() => AudioSource.PlayOneShot(LaunchSE);
    public void AttackSEPlay() => AudioSource.PlayOneShot(AttackSE);
    public void ButtonSEPlay() => AudioSource.PlayOneShot(ButtonSE);


}
