using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorColor : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("HolePosition"))//プレイヤーの前に来たら
        {
            //色を変える
            GetComponent<Renderer>().material.color = new Color(0.0f, 0.0f, 1.0f, 1.0f);
        }

    }
    private void OnTriggerExit(Collider other)//プレイヤーの前じゃないとき
    {
        if (other.gameObject.CompareTag("HolePosition"))//
        {
            //色を戻す
            GetComponent<Renderer>().material.color = Color.white;
        }
    }
}
