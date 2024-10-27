using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ボスの制御
public class BossController : MonoBehaviour
{
    public float HP;


    void Start()
    {
        // HPの初期値を設定する処理
        HP = 50;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DecreaseHP() {

        // 自分のHPを減らす処理
        HP -= 1f;
        
        //HPが0になったら敵自身を削除
        if(HP <= 0) {
            Destroy(this.gameObject);
        }
    }
}
