using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPlayerMove : MonoBehaviour
{
    private float inputX = 0;//�L�[����
    private float inputZ = 0;//�L�[����

    [SerializeField] private float animSpeed = 1.5f;              // �A�j���[�V�����Đ����x�ݒ�
    // ���̃X�C�b�`�������Ă��Ȃ��ƃJ�[�u�͎g���Ȃ�
    [SerializeField] private float useCurvesHeight = 0.5f;		// �J�[�u�␳�̗L�������i�n�ʂ����蔲���₷�����ɂ͑傫������j

    // �ړ����x
    [SerializeField] private float _speed = 15f;

    // �v���C���[�̈ʒu�����i�[����
    private Vector3 playerPos;
    // �L�����N�^�[�R���g���[���i�J�v�Z���R���C�_�j�̈ړ���
    private Vector3 velocity;

    // �L�����ɃA�^�b�`�����A�j���[�^�[�ւ̎Q��
    private Animator anim;
    private Rigidbody rb;
//    private CapsuleCollider col;

    void Start()
    {
        //������Ԃ̃v���C���[�ʒu�����i�[
        playerPos = GetComponent<Transform>().position;

        // Animator�R���|�[�l���g���擾����
        anim = GetComponent<Animator>();

        rb = GetComponent<Rigidbody>();
        // CapsuleCollider�R���|�[�l���g���擾����i�J�v�Z���^�R���W�����j
 //       col = GetComponent<CapsuleCollider>();
    }

    private void Update()
    {
        if( inputX >= 0 || inputZ >= 0 )
        {
            anim.SetBool("run", true); // Animator���Őݒ肵�Ă���"run"�p�����^��tuer��n��

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("dig"); // Animator���Őݒ肵�Ă���"horu"�p�����^��Trigger��n��

        }

        //�}�E�X��L�[������������Ă��Ȃ���
        if (!Input.anyKey)
        {
            anim.SetBool("run", false); // Animator���Őݒ肵�Ă���"run"�p�����^��false��n��
            // �����Œ�
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
        else
        {
            rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX |
                RigidbodyConstraints.FreezeRotationZ;
        }

    }
    // Update is called once per frame
    void FixedUpdate()
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

            case -1:
                transform.rotation
                 = Quaternion.Euler(0, -90, 0); break;
            case 1:
                transform.rotation
                 = Quaternion.Euler(0, 90, 0); break;
        }
        switch (inputZ)
        {
            case -1:
                transform.rotation
                 = Quaternion.Euler(0, 180, 0); break;
            case 1:
                transform.rotation
                 = Quaternion.Euler(0, 0, 0); break;
        }

        //���ʈ䂳��̈ړ��X�N���v�g��
        /*
           inputX = Input.GetAxisRaw("Horizontal");
           inputZ = Input.GetAxisRaw("Vertical");

           // �ȉ��A�L�����N�^�[�̈ړ�����
           // �㉺�̃L�[���͂���Z�������̈ړ��ʂ��擾
           velocity = new Vector3(InputX, 0, InputZ);
           velocity *= _speed;

           // �㉺�̃L�[���͂ŃL�����N�^�[���ړ�������
           transform.localPosition += velocity * Time.fixedDeltaTime;

           //�ړ���̃L�����N�^�[���O�񂩂�ǂ̕����ɐi�񂾂��������擾����
           Vector3 diff = transform.position - playerPos;

           if (diff.magnitude > 0.01f)
           {
               //���ق��������ꍇ�ɂ̂݌�����ύX����
               transform.rotation = Quaternion.LookRotation(diff);
           }

           playerPos = transform.position; //�v���C���[�ʒu�����X�V
        */
    }
}
