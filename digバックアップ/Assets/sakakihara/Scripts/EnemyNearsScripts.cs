using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNearsScripts : MonoBehaviour
{
    //�G�ɂ���X�N���v�g
    Transform playerTr; // �v���C���[��Transform
    Transform decoyTr; // ����Transform
    Transform nearsTr; // �ǂ������鑊���Transform

    [SerializeField] float speed = 2; // �G�̓����X�s�[�h

    private bool enemyFlag = false;//��ʓ��Ȃ�i�Ȃ��Ă������j

    GameObject[] tagObjects;//���̐��擾

    private void Start()
    {
        // �v���C���[��Transform���擾�i�v���C���[�̃^�O��Player�ɐݒ�K�v�j
        playerTr = GameObject.FindGameObjectWithTag("Player").transform;

    }

    private void Update()
    {
        Check();
        if (enemyFlag == true)
        {
            EnemyNears();
        }
    }
    private void OnBecameVisible()
    {
        enemyFlag = true;
    }
    private void OnBecameInvisible()
    {
        enemyFlag = false;
    }
    void EnemyNears()//�߂Â�
    {
        //// �v���C���[�Ƃ̋�����0.1f�����ɂȂ����炻��ȏ���s���Ȃ�
        //if (Vector2.Distance(transform.position, playerTr.position) < 1f)
        //    return;

        // �W�I�Ɍ����Đi��
        transform.position = Vector3.MoveTowards(
            transform.position,
            new Vector3(nearsTr.position.x, 0, nearsTr.position.z),
            speed * Time.deltaTime);


        //// �W�I�Ɍ����Đi�ށ�
        //transform.position = Vector3.MoveTowards(
        //    transform.position,
        //    new Vector3(playerTr.position.x, 0, playerTr.position.z),
        //    speed * Time.deltaTime);
    }

    void Check()//�W�I�؂�ւ�
    {
        tagObjects = GameObject.FindGameObjectsWithTag("Decoy"); //Decoy�̐��擾
        if (tagObjects.Length == 0)
        {
            nearsTr = playerTr;
        }
        else
        {

            // ����Transform���擾�i���̃^�O��Decoy�ɐݒ�K�v�j
            decoyTr = GameObject.FindGameObjectWithTag("Decoy").transform;
            nearsTr = decoyTr;
        }
    }
    //void Check()//�W�I�؂�ւ���
    //{
    //    tagObjects = GameObject.FindGameObjectsWithTag("Decoy"); //Decoy�̐��擾
    //    if (tagObjects.Length == 0)
    //    {
    //        // �v���C���[��Transform���擾�i�v���C���[�̃^�O��Player�ɐݒ�K�v�j
    //        playerTr = GameObject.FindGameObjectWithTag("Player").transform;
    //    }
    //    else
    //    {
    //        // ����Transform���擾�i���̃^�O��Decoy�ɐݒ�K�v�j
    //        playerTr = GameObject.FindGameObjectWithTag("Decoy").transform;
    //    }
    //}
}