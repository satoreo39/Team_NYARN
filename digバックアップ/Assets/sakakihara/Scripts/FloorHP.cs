using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorHP : MonoBehaviour
{
    private int floorCnt;//穴段階

    private bool isInput0 = false;//キー入力フラグ
    private bool isInput1 = false;//キー入力フラグ
                                    //private bool floorCntFlag = false;//ヒットストップフラグ//☆

    [SerializeField] private int nowLayer;//現在のレイヤー番号
    [SerializeField, Multiline(5)]//説明欄（４行）
    private string layerMemo = ("0 \n 0 \n 0 \n 0 \n");

    private float _oneTime = 0.5f;//1段階
    private float _twoTime = 1.5f;//２段階
    private float _threeTime = 3f;//３段階
    private float _timeElapsed;//経過時間

    public Text hpText;//確認用

    // Start is called before the first frame update
    void Start()
    {
        floorCnt = 0;
        layerMemo
        = ("・0 \n・0 \n・0 \n・0 ");//\nで改行
    }

    // Update is called once per frame
    void Update()
    {
        hpText.GetComponent<Text>().text =
            (this.gameObject.name + floorCnt + "cnt" + _timeElapsed + "time").ToString();//プレイヤー体力表示//確認用

        if (Input.GetMouseButton(0))//掘る
        {
            isInput0 = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            //floorCntFlag = false;//☆
            isInput0 = false;
            FixedTime();
        }

        if (Input.GetMouseButton(1))//埋める
        {
            isInput1 = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            isInput1 = false;
            FixedTime();
        }

        switch (floorCnt)//穴段階
        {
            default:
                gameObject.layer = 0;//レイヤー変更
                this.tag = ("Floor");
                GetComponent<Renderer>().material.color = Color.white;
                break;

            case 1:
                gameObject.layer = 1;
                //this.tag = ("1");
                GetComponent<Renderer>().material.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
                break;

            case 2:
                //this.tag = ("2");
                GetComponent<Renderer>().material.color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
                break;

            case 3:
                //this.tag = ("3");
                GetComponent<Renderer>().material.color = new Color(0.0f, 0.0f, 1.0f, 1.0f);
                //this.gameObject.SetActive(false);
                break;
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("HolePosition"))//プレイヤーが前に来たら
        {
            if (isInput0)
            {
                DigtFlag();
            }
            if (isInput1)
            {
                BuryFlag();
            }

            //InputFlag();//☆ //ヒットストップ的なもの
        }
    }
    private void DigtFlag()//掘るとき
    {
        print(this.gameObject.name + floorCnt + "cnt" + _timeElapsed + "time");
        if (isInput0)
        {
            if (_timeElapsed >= _threeTime + 3) return;
            _timeElapsed += Time.deltaTime;//時間をカウントする


            if (_timeElapsed >= _oneTime)
            {
                floorCnt = 1;
            }
            if (_timeElapsed >= _twoTime)
            {
                floorCnt = 2;
            }
            if (_timeElapsed >= _threeTime)
            {
                floorCnt = 3;
            }
        }

    }
    private void BuryFlag()//埋めるとき
    {
        if (isInput1)
        {
            if (_timeElapsed == 0f) return;
            _timeElapsed -= Time.deltaTime;//時間をカウントする

            if (_timeElapsed <= _threeTime)
            {
                floorCnt = 3;
            }
            if (_timeElapsed <= _twoTime)
            {
                floorCnt = 2;
            }
            if (_timeElapsed <= _oneTime)
            {
                floorCnt = 1;
            }
            if (_timeElapsed <= 0)
            {
                floorCnt = 0;
            }
        }
        print(this.gameObject.name + floorCnt + "cnt" + _timeElapsed + "time");
    }
    void FixedTime()//時間固定
    {
        switch (floorCnt)
        {
            default:
                _timeElapsed = 0f;
                break;

            case 1:
                _timeElapsed = _oneTime;
                break;


            case 2:
                _timeElapsed = _twoTime;
                break;


            case 3:
                _timeElapsed = _threeTime;
                break;
        }
    }
    //private void InputFlag()//ヒットストップ的なもの//☆
    //{
    //    if (!floorCntFlag)
    //    {
    //        if (inputFlag)
    //        {
    //            floorCntFlag = true;

    //            if (floorCntFlag)
    //            {
    //                floorCnt++;
    //            }
    //        }
    //        print(this.gameObject.name + floorCnt);
    //    }
    //}
}
