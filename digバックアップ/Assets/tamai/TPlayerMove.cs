using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPlayerMove : MonoBehaviour
{
    private float inputX = 0;//キー入力
    private float inputZ = 0;//キー入力

    [SerializeField] private float animSpeed = 1.5f;              // アニメーション再生速度設定
    // このスイッチが入っていないとカーブは使われない
    [SerializeField] private float useCurvesHeight = 0.5f;		// カーブ補正の有効高さ（地面をすり抜けやすい時には大きくする）

    // 移動速度
    [SerializeField] private float _speed = 15f;

    // プレイヤーの位置情報を格納する
    private Vector3 playerPos;
    // キャラクターコントローラ（カプセルコライダ）の移動量
    private Vector3 velocity;

    // キャラにアタッチされるアニメーターへの参照
    private Animator anim;
    private Rigidbody rb;
//    private CapsuleCollider col;

    void Start()
    {
        //初期状態のプレイヤー位置情報を格納
        playerPos = GetComponent<Transform>().position;

        // Animatorコンポーネントを取得する
        anim = GetComponent<Animator>();

        rb = GetComponent<Rigidbody>();
        // CapsuleColliderコンポーネントを取得する（カプセル型コリジョン）
 //       col = GetComponent<CapsuleCollider>();
    }

    private void Update()
    {
        if( inputX >= 0 || inputZ >= 0 )
        {
            anim.SetBool("run", true); // Animator側で設定している"run"パラメタにtuerを渡す

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("dig"); // Animator側で設定している"horu"パラメタにTriggerを渡す

        }

        //マウスやキーが何も押されていない時
        if (!Input.anyKey)
        {
            anim.SetBool("run", false); // Animator側で設定している"run"パラメタにfalseを渡す
            // 向き固定
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
        else
        {
            rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX |
                RigidbodyConstraints.FreezeRotationZ;
        }

    }
    // Update is called once per frame
    void FixedUpdate()
    {

        //キー入力の受付
        inputX = Input.GetAxisRaw("Horizontal");//a←-1
        inputZ = Input.GetAxisRaw("Vertical");//ｗ前進1
        //print(inputX + "," + inputZ);//確認用

        //プレイヤーの移動
        this.GetComponent<Rigidbody>().velocity
           = new Vector3(inputX * _speed, 0, inputZ * _speed);

        //プレイヤー向き
        switch (inputX)
        {
            //            default:
            //                transform.rotation
            //= Quaternion.Euler(0, 0, 0); break;

            case -1:
                transform.rotation
                 = Quaternion.Euler(0, -90, 0); break;
            case 1:
                transform.rotation
                 = Quaternion.Euler(0, 90, 0); break;
        }
        switch (inputZ)
        {
            case -1:
                transform.rotation
                 = Quaternion.Euler(0, 180, 0); break;
            case 1:
                transform.rotation
                 = Quaternion.Euler(0, 0, 0); break;
        }

        //＜玉井さんの移動スクリプト＞
        /*
           inputX = Input.GetAxisRaw("Horizontal");
           inputZ = Input.GetAxisRaw("Vertical");

           // 以下、キャラクターの移動処理
           // 上下のキー入力からZ軸方向の移動量を取得
           velocity = new Vector3(InputX, 0, InputZ);
           velocity *= _speed;

           // 上下のキー入力でキャラクターを移動させる
           transform.localPosition += velocity * Time.fixedDeltaTime;

           //移動後のキャラクターが前回からどの方向に進んだか差分を取得する
           Vector3 diff = transform.position - playerPos;

           if (diff.magnitude > 0.01f)
           {
               //差異があった場合にのみ向きを変更する
               transform.rotation = Quaternion.LookRotation(diff);
           }

           playerPos = transform.position; //プレイヤー位置情報を更新
        */
    }
}
