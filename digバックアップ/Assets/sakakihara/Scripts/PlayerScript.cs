using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    //プレイヤーにつけるスクリプト
    //穴掘り処理

    private int playerHp;//プレイヤー体力

    private bool isInput0 = false;//キー入力フラグ掘る
    private bool isInput2 = false;//キー入力フラグ囮
    private bool isHpCnt = false;//ヒットストップフラグ//☆
    private bool isHoleCnt = false;//ヒットストップフラグ//☆
    private bool isHole = false;//落とし穴があるかどうか

    private float floorPgX;//当たった床のXposを格納する
    private float floorPgZ;//当たった床のZposを格納する
    private float decoyPgY = 0.9f;//生成位置のYposを指定する
    [SerializeField] private GameObject decoyPrefab;//囮オブジェクトを入れる
    [SerializeField] private GameObject holePrefab;//落とし穴オブジェクトを入れる

    GameObject[] sEnemyTag;
    GameObject[] enemyTag;

    public Text hpText;//確認用

    // Start is called before the first frame update
    void Start()
    {
        playerHp = 3;
        sEnemyTag = GameObject.FindGameObjectsWithTag("Enemy"); //Enemyの数取得
    }

    // Update is called once per frame
    void Update()
    {
        hpText.GetComponent<Text>().text = playerHp.ToString();//プレイヤー体力表示//確認用

        PlayerKeyInput();

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Floor"))//床の前にいるとき
        {
            Vector3 floorPg = other.transform.position;//当たった床の位置取得
            floorPgX = floorPg.x;//当たった床のXposを格納する
            floorPgZ = floorPg.z;//当たった床のZposを格納する

            if (playerHp <= 0) return;
            ResidueGeneration();//☆//・囮生成＆㏋減らす

            if (isHole)//落とし穴があったら生成しない
            {
                return;
            }
            HoleFeneration();//落とし穴生成
        }
        if (other.gameObject.CompareTag("Hole"))//落とし穴がある時
        {
            isHole = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Hole"))//落とし穴がないとき
        {
            isHole = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Decoy"))//囮に触れたら回復
        {
            playerHp++;
        }
    }
    void PlayerKeyInput()
    {
        if (Input.GetMouseButton(0))//掘る
        {
            isInput0 = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isHoleCnt = false;
            isInput0 = false;
        }

        if (Input.GetMouseButton(2))//囮生成
        {
            isInput2 = true;
        }
        if (Input.GetMouseButtonUp(2))
        {
            isHpCnt = false;//☆
            isInput2 = false;
        }
    }
    void HoleFeneration()//落とし穴生成
    {
        if (!isHoleCnt)
        {
            if (isInput0)
            {
                isHoleCnt = true;
                if (isHoleCnt)
                {
                    Instantiate(holePrefab,
new Vector3(floorPgX, 0, floorPgZ),
Quaternion.identity);//生成物・位置の指定
                }
            }
        }



    }
    void ResidueGeneration()//☆ヒットストップ的なもの・囮生成＆㏋減らす
    {
        if (!isHpCnt)
        {
            if (isInput2)
            {
                isHpCnt = true;

                if (isHpCnt)
                {
                    playerHp--;
                    Instantiate(decoyPrefab,
                        new Vector3(floorPgX, decoyPgY, floorPgZ),
                        Quaternion.identity);//生成物・位置の指定
                }
            }
        }
    }
    void HpAbsorption()
    {
        enemyTag = GameObject.FindGameObjectsWithTag("Enemy"); //Enemyの数取得
        //if (enemyTag > sEnemyTag)
        //{

        //}

    }
}
