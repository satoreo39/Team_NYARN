using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNearsScripts : MonoBehaviour
{
    //敵につけるスクリプト
    Transform playerTr; // プレイヤーのTransform
    Transform decoyTr; // 囮のTransform
    Transform nearsTr; // 追いかける相手のTransform

    [SerializeField] float speed = 2; // 敵の動くスピード

    private bool enemyFlag = false;//画面内なら（なくてもいい）

    GameObject[] tagObjects;//囮の数取得

    private void Start()
    {
        // プレイヤーのTransformを取得（プレイヤーのタグをPlayerに設定必要）
        playerTr = GameObject.FindGameObjectWithTag("Player").transform;

    }

    private void Update()
    {
        Check();
        if (enemyFlag == true)
        {
            EnemyNears();
        }
    }
    private void OnBecameVisible()
    {
        enemyFlag = true;
    }
    private void OnBecameInvisible()
    {
        enemyFlag = false;
    }
    void EnemyNears()//近づく
    {
        //// プレイヤーとの距離が0.1f未満になったらそれ以上実行しない
        //if (Vector2.Distance(transform.position, playerTr.position) < 1f)
        //    return;

        // 標的に向けて進む
        transform.position = Vector3.MoveTowards(
            transform.position,
            new Vector3(nearsTr.position.x, 0, nearsTr.position.z),
            speed * Time.deltaTime);


        //// 標的に向けて進む★
        //transform.position = Vector3.MoveTowards(
        //    transform.position,
        //    new Vector3(playerTr.position.x, 0, playerTr.position.z),
        //    speed * Time.deltaTime);
    }

    void Check()//標的切り替え
    {
        tagObjects = GameObject.FindGameObjectsWithTag("Decoy"); //Decoyの数取得
        if (tagObjects.Length == 0)
        {
            nearsTr = playerTr;
        }
        else
        {

            // 囮のTransformを取得（囮のタグをDecoyに設定必要）
            decoyTr = GameObject.FindGameObjectWithTag("Decoy").transform;
            nearsTr = decoyTr;
        }
    }
    //void Check()//標的切り替え★
    //{
    //    tagObjects = GameObject.FindGameObjectsWithTag("Decoy"); //Decoyの数取得
    //    if (tagObjects.Length == 0)
    //    {
    //        // プレイヤーのTransformを取得（プレイヤーのタグをPlayerに設定必要）
    //        playerTr = GameObject.FindGameObjectWithTag("Player").transform;
    //    }
    //    else
    //    {
    //        // 囮のTransformを取得（囮のタグをDecoyに設定必要）
    //        playerTr = GameObject.FindGameObjectWithTag("Decoy").transform;
    //    }
    //}
}