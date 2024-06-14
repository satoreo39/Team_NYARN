using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private EnemyNearsScripts nearsScripts;//�����n�̃X�N���v�g
    private float _timeElapsed;//�o�ߎ���
    private float stanElapsed = 3f;//�~�܂鎞�ԁ@���X�N���v�g�uHoleScript�v�́udelOneTime�v�Ɠ������Ԃɐݒ肵�Ă�������

    private Vector3 enemyPosition;
    private float ryPg = 1f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask holeLayer;
    private bool hit1;
    private bool hit2;
    void Start()
    {
        nearsScripts = this.gameObject.GetComponent<EnemyNearsScripts>();//�X�N���v�g�擾
    }

    void Update()
    {

        //Physics.Raycast�i���ˈʒu�ARay�̕����A�Փ˂����I�u�W�F�N�g���ARay�̒����j

        //Physics.Raycast(enemyPosition, direction, out hit, Mathf.Infinity)�G

        hit1 = Physics.Raycast(enemyPosition, Vector2.down, ryPg, holeLayer);//������
        Debug.DrawRay(transform.position, Vector2.down * ryPg, new Color(0f, 1f, 1f));

        hit2 = Physics.Raycast(enemyPosition, Vector2.up, ryPg, groundLayer);//�n�ʔ���
        Debug.DrawRay(transform.position, Vector2.up * ryPg, new Color(1f, 1f, 0f));
        if (hit1)
        {
            print("���ɓ�����");

        }
        if (hit2)
        {
            print("����ɒn��");
        }


        if (!nearsScripts.enabled)
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
}
