using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecoyScript : MonoBehaviour
{
    //���ɂ���X�N���v�g

    //private BoxCollider boxCollider;
    //private MeshRenderer meshRenderer;

    private void Start()
    {
        //boxCollider = this.gameObject.GetComponent<BoxCollider>();
        //meshRenderer = this.gameObject.GetComponent<MeshRenderer>();

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") ||
            collision.gameObject.CompareTag("Player"))//�G���v���C���[�����������������
        {
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
            //
            //this.tag = ("Untagged");
            //boxCollider.enabled = false;
            //meshRenderer.enabled = false;

        }
    }
    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.CompareTag("HolePosition"))//�v���C���[�̑O�ɗ�����
    //    {
    //        print("aaaaaa");
    //        if (Input.GetMouseButton(2))
    //        {
    //            this.tag = ("Decoy");
    //            boxCollider.enabled = true;
    //            meshRenderer.enabled = true;
    //        }
    //    }

    //}
}
