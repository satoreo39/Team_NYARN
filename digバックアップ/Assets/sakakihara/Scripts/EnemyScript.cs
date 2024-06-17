using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //�G�ɂ���X�N���v�g
    private EnemyNearsScripts nearsScripts;//�����n�̃X�N���v�g
    private float _timeElapsed;//�o�ߎ���
    private float stanElapsed = 3f;//�~�܂鎞�ԁ@���X�N���v�g�uHoleScript�v�́udelOneTime�v�Ɠ������Ԃɐݒ肵�Ă�������

    //private CapsuleCollider enemyCollider; //�R���C�_�[
    private MeshRenderer enemyMesh;//������

    private float resurrectionJump=5f;//�����W�����v�̍���
    private float OutOfRange = 10f;//���񂾂Ƃ��ɔ͈͊O�Ɉړ�

    //private Vector3 enemyPosition;//�����̈ʒu
    //private float ryPg = 0.5f;//���C�̒���
    //[SerializeField] private LayerMask holeLayer;//�������郌�C�̖��O
    //private bool hit1;//���C�ɓ������Ă��邩

    private bool isPitfall=false; //���Ƃ����ɗ��������ǂ���

    void Start()
    {
        nearsScripts = this.gameObject.GetComponent<EnemyNearsScripts>();//�X�N���v�g�擾
        //enemyCollider = this.gameObject.GetComponent<CapsuleCollider>();//�R���C�_�[�擾
        enemyMesh = this.gameObject.GetComponent<MeshRenderer>();//�R���C�_�[�擾
    }

    void Update()
    {
         //bool Raycast(Vector3 enemyPosition, Vector3 down,
         //   float maxDistance = Mathf.Infinity, int layerMask 
         //   = holeLayer, QueryTriggerInteraction 
         //   queryTriggerInteraction = QueryTriggerInteraction.UseGlobal);


        ////rey�𔭎ˁi����1:���C�̎n�_,����2:���C����,����3:���C�̋���,����4:���C���[�}�X�N�j
        //hit1 = Physics.Raycast(enemyPosition, Vector2.down, ryPg, holeLayer);//������
        //Debug.DrawRay(transform.position, Vector2.down * ryPg, new Color(0f, 1f, 1f));
        //if (hit1)
        //{
        //    //Debug.Log(hit1.collider.name);
        //    //if (hit1.collider.CompareTag(""))
        //    print("���ɓ�����");
        //    isPitfall = true;
        //}

        if (!nearsScripts.enabled&!isPitfall)
        {
            _timeElapsed += Time.deltaTime;
            if (_timeElapsed >= stanElapsed)//�w�莞�Ԍ㓮��
            {
                nearsScripts.enabled = true;
                _timeElapsed = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("0"))
        {
            if (isPitfall)//���ɗ�������ԂŖ��߂�ꂽ��
            {
                enemyMesh.enabled = false;
                nearsScripts.enabled = false;
                this.gameObject.transform.position
= new Vector3(OutOfRange, OutOfRange, OutOfRange);
            }

        }
        if (other.gameObject.CompareTag("1"))//�X�^������
        {
            nearsScripts.enabled = false;//�������~�߂�
        }
        if (other.gameObject.CompareTag("2"))
        {

        }
        if (other.gameObject.CompareTag("3"))
        {

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("DeathFloor"))//
        {
            print("���ɓ�����");
            isPitfall = true;
            nearsScripts.enabled = false;

        }

        if (collision.gameObject.CompareTag("Enemy")& isPitfall)//���̓G�ɓ��������畜��
        {
            this.gameObject.transform.position 
                = new Vector3(transform.position.x, resurrectionJump, transform.position.z);
            isPitfall = false;
            nearsScripts.enabled = true;
        }
    }
    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("DeathFloor"))//
    //    {
    //        isPitfall = false;
    //        nearsScripts.enabled = true;
    //    }
    //}
}
