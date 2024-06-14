using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleScript : MonoBehaviour
{
    private int holeCnt;//穴段階

    private bool isInput0 = false;//キー入力フラグ
    private bool isInput1 = false;//キー入力フラグ

    //生成するのにかかる時間たち
    private float oneTime = 0.5f;//1段階
    private float twoTime = 1.5f;//２段階
    private float threeTime = 2.5f;//３段階
    private float _timeElapsed;//経過時間

    //穴が消えるまでにかかる時間
    private float delOneTime = 3f;
    private float _delTimeElapsed;

    private BoxCollider oneCollider;//１段階コライダー
    private CapsuleCollider twoCollider;//２段階コライダー
    private CapsuleCollider threeCollider;//３段階コライダー
    private MeshRenderer oneMeshRenderer;//１段階見た目
    private MeshRenderer twoMeshRenderer;//２段階見た目
    private MeshRenderer threeMeshRenderer;//３段階見た目

    [SerializeField] private GameObject oneHole;//穴オブジェクト１段階
    [SerializeField] private GameObject twoHole;//穴オブジェクト２段階
    [SerializeField] private GameObject threeHole;//穴オブジェクト３段階

    // Start is called before the first frame update
    void Start()
    {
        //holeCnt = 0;
        holeCnt = 1;
        oneHole = transform.GetChild(0).gameObject;
        twoHole = transform.GetChild(1).gameObject;
        threeHole = transform.GetChild(2).gameObject;
        oneCollider = oneHole.GetComponent<BoxCollider>();//１段階コライダー
        twoCollider = twoHole.GetComponent<CapsuleCollider>();//２段階コライダー
        threeCollider = threeHole.GetComponent<CapsuleCollider>();//３段階コライダー
        oneMeshRenderer = oneHole.GetComponent<MeshRenderer>();//１段階見た目
        twoMeshRenderer = twoHole.GetComponent<MeshRenderer>();//２段階見た目
        threeMeshRenderer = threeHole.GetComponent<MeshRenderer>();//３段階見た目

        NoHole();//見えない状態にする

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))//掘る
        {
            isInput0 = true;
        }
        if (Input.GetMouseButton(1))//埋める
        {
            isInput1 = true;

        }
        if (Input.GetMouseButtonUp(1) || Input.GetMouseButtonUp(0))//キーを離したときに生成
        {

            NoHole();
            isInput0 = false;
            isInput1 = false;
            FixedTime();
            HoleGenerate(); //落とし穴生成
        }
        print((_delTimeElapsed) + ("+") + (holeCnt));

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))//スタン処理
        {
            switch (holeCnt) 
            {
                default:
                    HoleGenerate();
                    break;
                case 1:
                    if (_delTimeElapsed >= delOneTime + 1)
                    {
                        return;
                    }
                    _delTimeElapsed += Time.deltaTime;
                    if (_delTimeElapsed >= delOneTime)
                    {
                        holeCnt = 0;

                    }
                    break;
            }


   
        }


        if (!isInput0 & !isInput1)//今の穴段階を確認する
        {
            if (other.gameObject.CompareTag("1"))
            {
                holeCnt = 1;
            }
            if (other.gameObject.CompareTag("2"))
            {
                holeCnt = 2;
            }
            if (other.gameObject.CompareTag("3"))
            {
                holeCnt = 3;
            }
            FixedTime();
        }

        if (other.gameObject.CompareTag("HolePosition"))//プレイヤーが前に来たら
        {
            print("当たり判定");
            if (isInput0)
            {
                DigtFlag();
            }
            if (isInput1)
            {
                BuryFlag();
            }
        }

    }

    private void HoleGenerate()
    {
        switch (holeCnt)//穴段階
        {
            default:
                NoHole();
                break;
            case 1:
                _delTimeElapsed = 0;
                oneCollider.enabled = true;
                oneMeshRenderer.enabled = true;
                break;

            case 2:
                NoHole();
                twoCollider.enabled = true;
                twoMeshRenderer.enabled = true;
                break;

            case 3:
                NoHole();
                threeCollider.enabled = true;
                threeMeshRenderer.enabled = true;
                break;
        }
    }


    private void DigtFlag()//掘るとき
    {
        //print(this.gameObject.name + floorCnt + "cnt" + _timeElapsed + "time");
        if (isInput0)
        {
            if (_timeElapsed >= threeTime + 3)
            {
                return;
            }
            _timeElapsed += Time.deltaTime;//時間をカウントする


            if (_timeElapsed >= oneTime)
            {
                holeCnt = 1;
            }
            if (_timeElapsed >= twoTime)
            {
                holeCnt = 2;
            }
            if (_timeElapsed >= threeTime)
            {
                holeCnt = 3;
            }
        }

    }
    private void BuryFlag()//埋めるとき
    {
        if (isInput1)
        {
            if (_timeElapsed == 0f) return;
            _timeElapsed -= Time.deltaTime;//時間をカウントする

            if (_timeElapsed <= threeTime)
            {
                holeCnt = 3;
            }
            if (_timeElapsed <= twoTime)
            {
                holeCnt = 2;
            }
            if (_timeElapsed <= oneTime)
            {
                holeCnt = 1;
            }
            if (_timeElapsed <= 0)
            {
                holeCnt = 0;
            }
        }
        print(this.gameObject.name + holeCnt + "cnt" + _timeElapsed + "time");
    }
    void FixedTime()//時間固定
    {
        switch (holeCnt)
        {
            default:
                _timeElapsed = 0f;
                break;

            case 1:
                _timeElapsed = oneTime;
                break;


            case 2:
                _timeElapsed = twoTime;
                break;


            case 3:
                _timeElapsed = threeTime;
                break;
        }
    }
    void NoHole()//穴なし状態
    {
        oneCollider.enabled = false;
        twoCollider.enabled = false;
        threeCollider.enabled = false;
        oneMeshRenderer.enabled = false;
        twoMeshRenderer.enabled = false;
        threeMeshRenderer.enabled = false;
    }
}
