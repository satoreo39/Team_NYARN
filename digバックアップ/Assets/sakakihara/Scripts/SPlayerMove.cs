using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPlayerMove : MonoBehaviour
{
    private float inputX = 0;//キー入力
    private float inputZ = 0;//キー入力

    [SerializeField] private float _speed = 15f;//移動速度

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
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

            case 1:
                transform.rotation
                 = Quaternion.Euler(0, -90, 0); break;
            case -1:
                transform.rotation
                 = Quaternion.Euler(0, 90, 0); break;
        }
        switch (inputZ)
        {
            case 1:
                transform.rotation
                 = Quaternion.Euler(0, 180, 0); break;
            case -1:
                transform.rotation
                 = Quaternion.Euler(0, 0, 0); break;
        }
    }
}
