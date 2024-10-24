using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 弾丸のふるまいを制御するスクリプト
// このスクリプトのパラメータ(発射速度, 持続時間, 攻撃力...)を変え、見た目を変更することで
// 好きな種類だけ弾を用意できる
public class BulletController : MonoBehaviour
{

    // 敵のゲームオブジェクト
    public EnemyController enemy;

    // パラメータを以下のように作っていく
    // ("public"はこのスクリプト外からこの変数にアクセスする必要がある時につける)
    // 外部からのアクセスが必要になったらつければいい

    float velocityY; // 発射速度
    float durationTime; // 弾の持続時間
    int AP; // 弾の攻撃力

    Rigidbody2D myRigidbody;
    //・・・・

    // Start関数は、ゲーム開始直後一回だけ実行される
    void Start()
    {
        // 弾丸の持続時間を設定


        // 物理演算コンポーネントを取得
        myRigidbody = GetComponent<Rigidbody2D>();

        myRigidbody.velocity = new Vector2(0, 10);

    }

    // Update関数は毎フレームごとに実行される
    void Update()
    {
        
    }
    
    // 衝突判定、当たったもののタグで判断する
    // 当たったものの情報がotherに代入されてこの関数が実行される
    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Enemy") {
            // 当たった相手のEnemtController.csを取得して、関数を呼ぶ
            enemy.DecreaseHP();

            // 弾丸自身を削除
            Destroy(this.gameObject);
        }
    }
}
