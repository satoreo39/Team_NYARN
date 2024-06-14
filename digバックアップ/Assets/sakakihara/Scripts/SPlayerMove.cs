using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPlayerMove : MonoBehaviour
{
    private float inputX = 0;//�L�[����
    private float inputZ = 0;//�L�[����

    [SerializeField] private float _speed = 15f;//�ړ����x

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        //�L�[���͂̎�t
        inputX = Input.GetAxisRaw("Horizontal");//a��-1
        inputZ = Input.GetAxisRaw("Vertical");//���O�i1
        //print(inputX + "," + inputZ);//�m�F�p

        //�v���C���[�̈ړ�
        this.GetComponent<Rigidbody>().velocity
           = new Vector3(inputX * _speed, 0, inputZ * _speed);

        //�v���C���[����
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
