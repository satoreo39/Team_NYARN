using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PitfallScript : MonoBehaviour
{

    [SerializeField] private int nowLayer;//現在のレイヤー番号
    [SerializeField, Multiline(5)]//説明欄（４行）
    private string layerMemo = ("・0:Default \n・7:Pitfall \n・0 \n・0 ");

    // Start is called before the first frame update
    void Start()
    {
        layerMemo
        = ("・0:Default \n・7:Pitfall \n・0 \n・0 ");//\nで改行
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("2") ||
            other.gameObject.CompareTag("3"))
        {
            this.gameObject.layer = 7;//レイヤー変更
        }
        else
        {
            this.gameObject.layer = 0;//レイヤー変更
        }


    }



}
