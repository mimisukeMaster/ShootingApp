using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ボスの制御
public class BossController : MonoBehaviour
{
    public int HP;
    GameManagerController gameManager;


    void Start()
    {
        // HPの初期値を設定する処理
        HP = 50;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerController>();
        
        gameManager.SetMaxBossHP(HP);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DecreaseHP() {

        // 自分のHPを減らす処理
        HP -= 1;

        // 体力ゲージを更新
        gameManager.DecreaseBossHP(HP);

        // 点滅させる
        StartCoroutine(nameof(FlushBoss));
        
        //HPが0になったら敵自身を削除
        if(HP <= 0) {
            Destroy(this.gameObject);

            gameManager.ClearProcess();
        }
    }

    IEnumerator FlushBoss() {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        for (int i = 0; i < 5; i++){ 
            sprite.enabled = false;
            yield return new WaitForSeconds(0.05f);
            sprite.enabled = true;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
