using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ボスの制御
public class BossController : MonoBehaviour
{
    public int HP;
    public GameObject Bullet;
    GameManagerController gameManager;

    SpriteRenderer spriteRenderer;
    bool isLaunching;

    void Start()
    {
        // HPの初期値を設定する処理
        HP = 50;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerController>();
        
        gameManager.SetMaxBossHP(HP);

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // 弾を一定時間ごとに発射させる
        if(spriteRenderer.isVisible && !isLaunching) {
            StartCoroutine(nameof(LaunchBullet));
            isLaunching = true;
        }
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

    IEnumerator LaunchBullet() {
        while(true) {
            Vector2 spawnPos = new Vector2(Random.Range(-2.7f, 2.5f), transform.position.y);
            GameObject spawnedBullet = Instantiate(Bullet, spawnPos, Quaternion.Euler(0f, 0f, -90f));

            spawnedBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5);
            yield return new WaitForSeconds(2f);
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
