using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleScript : MonoBehaviour
{
    //Hole�ɂ���X�N���v�g
    //Hole(�e)��Hole0(�q)�����Ɠ����傫���ɂ��Ă�������

    private int holeCnt;//���i�K

    private int enemyCnt;//�G��
    private int twoEnemyCnt;//
    private int threeEnemyCnt;//

    private bool isInput0 = false;//�L�[���̓t���O
    private bool isInput1 = false;//�L�[���̓t���O

    //��������̂ɂ����鎞�Ԃ���
    private float oneTime = 0.5f;//1�i�K
    private float twoTime = 1.5f;//�Q�i�K
    private float threeTime = 2.5f;//�R�i�K
    private float _timeElapsed;//�o�ߎ���

    //����������܂łɂ����鎞��
    private float delOneTime = 3f;
    private float _delTimeElapsed;

    private BoxCollider zeroCollider;//0�i�K�R���C�_�[
    private BoxCollider oneCollider;//�P�i�K�R���C�_�[
    private CapsuleCollider twoCollider;//�Q�i�K�R���C�_�[
    private CapsuleCollider threeCollider;//�R�i�K�R���C�_�[
    private MeshRenderer oneMeshRenderer;//�P�i�K������
    private MeshRenderer twoMeshRenderer;//�Q�i�K������
    private MeshRenderer threeMeshRenderer;//�R�i�K������

    [SerializeField] private GameObject zeroHole;//���I�u�W�F�N�g�P�i�K
    [SerializeField] private GameObject oneHole;//���I�u�W�F�N�g�P�i�K
    [SerializeField] private GameObject twoHole;//���I�u�W�F�N�g�Q�i�K
    [SerializeField] private GameObject threeHole;//���I�u�W�F�N�g�R�i�K

    // Start is called before the first frame update
    void Start()
    {
        //holeCnt = 0;
        holeCnt = 1;
        zeroHole = transform.GetChild(0).gameObject;
        oneHole = transform.GetChild(1).gameObject;
        twoHole = transform.GetChild(2).gameObject;
        threeHole = transform.GetChild(3).gameObject;
        zeroCollider = zeroHole.GetComponent<BoxCollider>();//�P�i�K�R���C�_�[
        oneCollider = oneHole.GetComponent<BoxCollider>();//�P�i�K�R���C�_�[
        twoCollider = twoHole.GetComponent<CapsuleCollider>();//�Q�i�K�R���C�_�[
        threeCollider = threeHole.GetComponent<CapsuleCollider>();//�R�i�K�R���C�_�[
        oneMeshRenderer = oneHole.GetComponent<MeshRenderer>();//�P�i�K������
        twoMeshRenderer = twoHole.GetComponent<MeshRenderer>();//�Q�i�K������
        threeMeshRenderer = threeHole.GetComponent<MeshRenderer>();//�R�i�K������

        NoHole();//�����Ȃ���Ԃɂ���
        _delTimeElapsed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))//�@��
        {
            isInput0 = true;
        }
        if (Input.GetMouseButton(1))//���߂�
        {
            isInput1 = true;

        }
        if (Input.GetMouseButtonUp(1) || Input.GetMouseButtonUp(0))//�L�[�𗣂����Ƃ��ɐ���
        {

            NoHole();
            isInput0 = false;
            isInput1 = false;
            FixedTime();
            HoleGenerate(); //���Ƃ�������
        }
        print((_delTimeElapsed) + ("+") + (holeCnt));

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))//�X�^������
        {
            if (holeCnt==1)
            {
                if (_delTimeElapsed >= delOneTime + 1)
                {
                    return;
                }
                _delTimeElapsed += Time.deltaTime;

                if (_delTimeElapsed >= delOneTime )
                {
                    holeCnt = 0;
                    HoleGenerate();
                }
            }
            if (holeCnt == 2)
            {

            }
            if (holeCnt == 3)
            {

            }
        }


        if (!isInput0 & !isInput1)//���̌��i�K���m�F����
        {
            if (other.gameObject.CompareTag("1"))
            {
                holeCnt = 1;
            }
            if (other.gameObject.CompareTag("2"))
            {
                holeCnt = 2;
            }
            if (other.gameObject.CompareTag("3"))
            {
                holeCnt = 3;
            }
            FixedTime();
        }

        if (other.gameObject.CompareTag("HolePosition"))//�v���C���[���O�ɗ�����
        {
            print("�����蔻��");
            if (isInput0)
            {
                DigtFlag();
            }
            if (isInput1)
            {
                BuryFlag();
            }
        }

    }
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Enemy"))
    //    {
    //        HoleGenerate();
    //    }
    //}
    private void HoleGenerate()
    {
        switch (holeCnt)//���i�K
        {
            default:
                NoHole();
                zeroCollider.enabled = true;
                _delTimeElapsed = 0;
                break;
            case 1:
                oneCollider.enabled = true;
                oneMeshRenderer.enabled = true;
                break;

            case 2:
                NoHole();
                twoCollider.enabled = true;
                twoMeshRenderer.enabled = true;
                break;

            case 3:
                NoHole();
                threeCollider.enabled = true;
                threeMeshRenderer.enabled = true;
                break;
        }
    }


    private void DigtFlag()//�@��Ƃ�
    {
        //print(this.gameObject.name + floorCnt + "cnt" + _timeElapsed + "time");
        if (isInput0)
        {
            if (_timeElapsed >= threeTime + 3)
            {
                return;
            }
            _timeElapsed += Time.deltaTime;//���Ԃ��J�E���g����


            if (_timeElapsed >= oneTime)
            {
                holeCnt = 1;
            }
            if (_timeElapsed >= twoTime)
            {
                holeCnt = 2;
            }
            if (_timeElapsed >= threeTime)
            {
                holeCnt = 3;
            }
        }

    }
    private void BuryFlag()//���߂�Ƃ�
    {
        if (isInput1)
        {
            if (_timeElapsed == 0f) return;
            _timeElapsed -= Time.deltaTime;//���Ԃ��J�E���g����

            if (_timeElapsed <= threeTime)
            {
                holeCnt = 3;
            }
            if (_timeElapsed <= twoTime)
            {
                holeCnt = 2;
            }
            if (_timeElapsed <= oneTime)
            {
                holeCnt = 1;
            }
            if (_timeElapsed <= 0)
            {
                holeCnt = 0;
            }
        }
        print(this.gameObject.name + holeCnt + "cnt" + _timeElapsed + "time");
    }
    void FixedTime()//���ԌŒ�
    {
        switch (holeCnt)
        {
            default:
                _timeElapsed = 0f;
                break;

            case 1:
                _timeElapsed = oneTime;
                break;


            case 2:
                _timeElapsed = twoTime;
                break;


            case 3:
                _timeElapsed = threeTime;
                break;
        }
    }
    void NoHole()//���Ȃ����
    {
        zeroCollider.enabled = false;
        oneCollider.enabled = false;
        twoCollider.enabled = false;
        threeCollider.enabled = false;
        oneMeshRenderer.enabled = false;
        twoMeshRenderer.enabled = false;
        threeMeshRenderer.enabled = false;
    }
}
