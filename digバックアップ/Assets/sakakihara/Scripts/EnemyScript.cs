using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //敵につけるスクリプト
    private EnemyNearsScripts nearsScripts;//動く系のスクリプト
    private float _timeElapsed;//経過時間
    private float stanElapsed = 3f;//止まる時間　※スクリプト「HoleScript」の「delOneTime」と同じ時間に設定してください

    //private CapsuleCollider enemyCollider; //コライダー
    private MeshRenderer enemyMesh;//見た目

    private float resurrectionJump=5f;//復活ジャンプの高さ
    private float OutOfRange = 10f;//死んだときに範囲外に移動

    //private Vector3 enemyPosition;//自分の位置
    //private float ryPg = 0.5f;//レイの長さ
    //[SerializeField] private LayerMask holeLayer;//反応するレイの名前
    //private bool hit1;//レイに当たっているか

    private bool isPitfall=false; //落とし穴に落ちたかどうか

    void Start()
    {
        nearsScripts = this.gameObject.GetComponent<EnemyNearsScripts>();//スクリプト取得
        //enemyCollider = this.gameObject.GetComponent<CapsuleCollider>();//コライダー取得
        enemyMesh = this.gameObject.GetComponent<MeshRenderer>();//コライダー取得
    }

    void Update()
    {
         //bool Raycast(Vector3 enemyPosition, Vector3 down,
         //   float maxDistance = Mathf.Infinity, int layerMask 
         //   = holeLayer, QueryTriggerInteraction 
         //   queryTriggerInteraction = QueryTriggerInteraction.UseGlobal);


        ////reyを発射（引数1:レイの始点,引数2:レイ向き,引数3:レイの距離,引数4:レイヤーマスク）
        //hit1 = Physics.Raycast(enemyPosition, Vector2.down, ryPg, holeLayer);//穴判定
        //Debug.DrawRay(transform.position, Vector2.down * ryPg, new Color(0f, 1f, 1f));
        //if (hit1)
        //{
        //    //Debug.Log(hit1.collider.name);
        //    //if (hit1.collider.CompareTag(""))
        //    print("穴に当たる");
        //    isPitfall = true;
        //}

        if (!nearsScripts.enabled&!isPitfall)
        {
            _timeElapsed += Time.deltaTime;
            if (_timeElapsed >= stanElapsed)//指定時間後動く
            {
                nearsScripts.enabled = true;
                _timeElapsed = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("0"))
        {
            if (isPitfall)//穴に落ちた状態で埋められたら
            {
                enemyMesh.enabled = false;
                nearsScripts.enabled = false;
                this.gameObject.transform.position
= new Vector3(OutOfRange, OutOfRange, OutOfRange);
            }

        }
        if (other.gameObject.CompareTag("1"))//スタン処理
        {
            nearsScripts.enabled = false;//動きを止める
        }
        if (other.gameObject.CompareTag("2"))
        {

        }
        if (other.gameObject.CompareTag("3"))
        {

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("DeathFloor"))//
        {
            print("穴に当たる");
            isPitfall = true;
            nearsScripts.enabled = false;

        }

        if (collision.gameObject.CompareTag("Enemy")& isPitfall)//他の敵に当たったら復活
        {
            this.gameObject.transform.position 
                = new Vector3(transform.position.x, resurrectionJump, transform.position.z);
            isPitfall = false;
            nearsScripts.enabled = true;
        }
    }
    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("DeathFloor"))//
    //    {
    //        isPitfall = false;
    //        nearsScripts.enabled = true;
    //    }
    //}
}
