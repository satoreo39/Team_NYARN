using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorColor : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("HolePosition"))//�v���C���[�̑O�ɗ�����
        {
            //�F��ς���
            GetComponent<Renderer>().material.color = new Color(0.0f, 0.0f, 1.0f, 1.0f);
        }

    }
    private void OnTriggerExit(Collider other)//�v���C���[�̑O����Ȃ��Ƃ�
    {
        if (other.gameObject.CompareTag("HolePosition"))//
        {
            //�F��߂�
            GetComponent<Renderer>().material.color = Color.white;
        }
    }
}
