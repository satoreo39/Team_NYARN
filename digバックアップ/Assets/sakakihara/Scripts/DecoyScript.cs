using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecoyScript : MonoBehaviour
{
    //囮につけるスクリプト

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
            collision.gameObject.CompareTag("Player"))//敵がプレイヤーが当たったら消える
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
    //    if (other.gameObject.CompareTag("HolePosition"))//プレイヤーの前に来たら
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
