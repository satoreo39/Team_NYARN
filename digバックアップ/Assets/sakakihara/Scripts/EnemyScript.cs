using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private EnemyNearsScripts nearsScripts;//動く系のスクリプト
    private float _timeElapsed;//経過時間
    private float stanElapsed = 3f;//止まる時間　※スクリプト「HoleScript」の「delOneTime」と同じ時間に設定してください

    private Vector3 enemyPosition;
    private float ryPg = 1f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask holeLayer;
    private bool hit1;
    private bool hit2;
    void Start()
    {
        nearsScripts = this.gameObject.GetComponent<EnemyNearsScripts>();//スクリプト取得
    }

    void Update()
    {

        //Physics.Raycast（発射位置、Rayの方向、衝突したオブジェクト情報、Rayの長さ）

        //Physics.Raycast(enemyPosition, direction, out hit, Mathf.Infinity)；

        hit1 = Physics.Raycast(enemyPosition, Vector2.down, ryPg, holeLayer);//穴判定
        Debug.DrawRay(transform.position, Vector2.down * ryPg, new Color(0f, 1f, 1f));

        hit2 = Physics.Raycast(enemyPosition, Vector2.up, ryPg, groundLayer);//地面判定
        Debug.DrawRay(transform.position, Vector2.up * ryPg, new Color(1f, 1f, 0f));
        if (hit1)
        {
            print("穴に当たる");

        }
        if (hit2)
        {
            print("頭上に地面");
        }


        if (!nearsScripts.enabled)
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
}
