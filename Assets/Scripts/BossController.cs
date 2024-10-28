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
        
        //HPが0になったら敵自身を削除
        if(HP <= 0) {
            Destroy(this.gameObject);
        }
    }
}
