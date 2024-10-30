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

    public GameManagerController GameManager;

    // パラメータを以下のように作っていく
    // ("public"はこのスクリプト外からこの変数にアクセスする必要がある時につける)
    // 外部からのアクセスが必要になったらつければいい

    float velocityY; // 発射速度
    float durationTime; // 弾の持続時間
    float nowTime;

    int AP; // 弾の攻撃力

    Rigidbody2D myRigidbody;
    //・・・・

    // Start関数は、ゲーム開始直後一回だけ実行される
    void Start()
    {
        // 弾丸の持続時間を設定
        durationTime = 3;
        nowTime = 0;

        // 物理演算コンポーネントを取得
        myRigidbody = GetComponent<Rigidbody2D>();

        myRigidbody.velocity = new Vector2(0, 10);

    }

    // Update関数は毎フレームごとに実行される
    void Update()
    {
        nowTime += Time.deltaTime;
        if(nowTime > durationTime) {
            Destroy(this.gameObject);
        }
    }
    
    // 衝突判定、当たったもののタグで判断する
    // 当たったものの情報がotherに代入されてこの関数が実行される
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Enemy")) {
            
            // 当たった相手のEnemyController.csを取得して、関数を呼ぶ
            other.GetComponent<EnemyController>().DecreaseHP();
        }
        if (other.gameObject.CompareTag("Boss")) {
            
            // 当たった相手のBossController.csを取得して、関数を呼ぶ
            other.GetComponent<BossController>().DecreaseHP();
        }
        
        GameManager.AttackSEPlay();

        // 弾丸自身を削除
        Destroy(this.gameObject);
        
    }
}
