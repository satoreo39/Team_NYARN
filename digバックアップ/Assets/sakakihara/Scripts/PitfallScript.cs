using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PitfallScript : MonoBehaviour
{
    //���ɂ���X�N���v�g
    [SerializeField] private int nowLayer;//���݂̃��C���[�ԍ�
    [SerializeField, Multiline(5)]//�������i�S�s�j
    private string layerMemo = ("�E0:Default \n�E7:Pitfall \n�E0 \n�E0 ");

    // Start is called before the first frame update
    void Start()
    {
        layerMemo
        = ("�E0:Default \n�E7:Pitfall \n�E0 \n�E0 ");//\n�ŉ��s
        this.gameObject.layer = 0;//���C���[�ύX
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("2") ||
    other.gameObject.CompareTag("3"))
        {
            this.gameObject.layer = 7;//���C���[�ύX
        }

        if (this.gameObject.layer == 0)
        {
            return;
        }
        if (other.gameObject.CompareTag("0")|| 
            other.gameObject.CompareTag("1"))
        {
            this.gameObject.layer = 0;//���C���[�ύX
        }
    }
}
