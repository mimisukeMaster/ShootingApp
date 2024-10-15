using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// プレイヤーの行動の制御を行うスクリプト
public class PlayerController : MonoBehaviour
{
    // 弾丸のゲームオブジェクト
    // GameObject型は、その変数(=Bullet)に代入されたものの全ての情報にアクセスできる
    public GameObject Bullet;

    // 各スクリプト情報
    // ex) GameManagerController.csのある関数を呼び出したいときには
    //     GameManager.関数名() とする
    public GameManagerController GameManager;

    // 以下のようにパラメータを作成していく
    // ("public"はこのスクリプト外からこの変数にアクセスする必要がある時につける)
    // 外部からのアクセスが必要になったらつければいい

    public int HP;

    Rigidbody2D myRigidbody;

    // Start関数は、ゲーム開始直後一回だけ実行される
    void Start()
    {
        // HPの初期値（最大値）を設定する処理

        // 体力ゲージの最大値を設定する関数を呼ぶ
        GameManager.SetMaxHP(HP);

        // 物理演算コンポーネントを取得
        myRigidbody = GetComponent<Rigidbody2D>();

        // 前に進む速度を設定する処理


    }

    // Update関数は毎フレームごとに実行される
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            LeftButtonDown();
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            RightButtonDown();
        }
    }


    // 衝突判定、当たったもののタグで判断する
    // 当たったものの情報がotherに代入されてこの関数が実行される
    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "enemy") {
            // 自分のHPを減らす処理

            // UIを更新するためGameManagerController.csのDecreaseHP()関数を呼ぶ
        
        }
    }

    // ここに左ボタン押したときの処理を書く
    public void LeftButtonDown() {
        
    }

    // ここに右ボタン押したときの処理を書く
    public void RightButtonDown() {

    }

    // ここに弾丸発射ボタン押したときの処理を書く
    public void BulletButtonDown() {
        // 弾丸を生成するには、Instantiate(***)関数を使う
        // 引数には、生成するもの、生成される座標、角度を指定する

        // Instantiate(Bullet, 生成する位置, Quaternion.identity);
    }
}
