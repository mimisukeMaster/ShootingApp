using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 敵のふるまいを制御するスクリプト
// このスクリプトのパラメータ(HP, 移動速度, 攻撃力...)を変え、見た目を変更することで
// 好きな種類だけ敵を用意できる
public class EnemyController : MonoBehaviour
{
    // パラメータを以下のように作っていく
    // ("public"はこのスクリプト外からこの変数にアクセスする必要がある時につける)
    // 外部からのアクセスが必要になったらつければいい

    public float HP;
    float velocityY;

    Rigidbody2D myRigidbody;
    /// ・・・・・

    // Start is called before the first frame update
    void Start()
    {
        // HPの初期値を設定する処理
        HP = 10;

        // 物理演算コンポーネントを取得
        myRigidbody = GetComponent<Rigidbody2D>();

        // 移動速度を設定する処理
        myRigidbody.velocity = new Vector2(-2, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.x > 1.5) {
            myRigidbody.velocity = new Vector2(-2, 0);
        }
        if(this.transform.position.x < -2.5) {
            myRigidbody.velocity = new Vector2(2, 0);
        }
    }

    public void DecreaseHP() {
        // 自分のHPを減らす処理
        HP -= 1;
    }
}
