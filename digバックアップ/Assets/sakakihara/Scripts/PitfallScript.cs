using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PitfallScript : MonoBehaviour
{

    [SerializeField] private int nowLayer;//���݂̃��C���[�ԍ�
    [SerializeField, Multiline(5)]//�������i�S�s�j
    private string layerMemo = ("�E0:Default \n�E7:Pitfall \n�E0 \n�E0 ");

    // Start is called before the first frame update
    void Start()
    {
        layerMemo
        = ("�E0:Default \n�E7:Pitfall \n�E0 \n�E0 ");//\n�ŉ��s
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
            this.gameObject.layer = 7;//���C���[�ύX
        }
        else
        {
            this.gameObject.layer = 0;//���C���[�ύX
        }


    }



}
