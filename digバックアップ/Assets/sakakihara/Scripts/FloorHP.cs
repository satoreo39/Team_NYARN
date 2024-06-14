using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorHP : MonoBehaviour
{
    private int floorCnt;//���i�K

    private bool isInput0 = false;//�L�[���̓t���O
    private bool isInput1 = false;//�L�[���̓t���O
                                    //private bool floorCntFlag = false;//�q�b�g�X�g�b�v�t���O//��

    [SerializeField] private int nowLayer;//���݂̃��C���[�ԍ�
    [SerializeField, Multiline(5)]//�������i�S�s�j
    private string layerMemo = ("0 \n 0 \n 0 \n 0 \n");

    private float _oneTime = 0.5f;//1�i�K
    private float _twoTime = 1.5f;//�Q�i�K
    private float _threeTime = 3f;//�R�i�K
    private float _timeElapsed;//�o�ߎ���

    public Text hpText;//�m�F�p

    // Start is called before the first frame update
    void Start()
    {
        floorCnt = 0;
        layerMemo
        = ("�E0 \n�E0 \n�E0 \n�E0 ");//\n�ŉ��s
    }

    // Update is called once per frame
    void Update()
    {
        hpText.GetComponent<Text>().text =
            (this.gameObject.name + floorCnt + "cnt" + _timeElapsed + "time").ToString();//�v���C���[�̗͕\��//�m�F�p

        if (Input.GetMouseButton(0))//�@��
        {
            isInput0 = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            //floorCntFlag = false;//��
            isInput0 = false;
            FixedTime();
        }

        if (Input.GetMouseButton(1))//���߂�
        {
            isInput1 = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            isInput1 = false;
            FixedTime();
        }

        switch (floorCnt)//���i�K
        {
            default:
                gameObject.layer = 0;//���C���[�ύX
                this.tag = ("Floor");
                GetComponent<Renderer>().material.color = Color.white;
                break;

            case 1:
                gameObject.layer = 1;
                //this.tag = ("1");
                GetComponent<Renderer>().material.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
                break;

            case 2:
                //this.tag = ("2");
                GetComponent<Renderer>().material.color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
                break;

            case 3:
                //this.tag = ("3");
                GetComponent<Renderer>().material.color = new Color(0.0f, 0.0f, 1.0f, 1.0f);
                //this.gameObject.SetActive(false);
                break;
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("HolePosition"))//�v���C���[���O�ɗ�����
        {
            if (isInput0)
            {
                DigtFlag();
            }
            if (isInput1)
            {
                BuryFlag();
            }

            //InputFlag();//�� //�q�b�g�X�g�b�v�I�Ȃ���
        }
    }
    private void DigtFlag()//�@��Ƃ�
    {
        print(this.gameObject.name + floorCnt + "cnt" + _timeElapsed + "time");
        if (isInput0)
        {
            if (_timeElapsed >= _threeTime + 3) return;
            _timeElapsed += Time.deltaTime;//���Ԃ��J�E���g����


            if (_timeElapsed >= _oneTime)
            {
                floorCnt = 1;
            }
            if (_timeElapsed >= _twoTime)
            {
                floorCnt = 2;
            }
            if (_timeElapsed >= _threeTime)
            {
                floorCnt = 3;
            }
        }

    }
    private void BuryFlag()//���߂�Ƃ�
    {
        if (isInput1)
        {
            if (_timeElapsed == 0f) return;
            _timeElapsed -= Time.deltaTime;//���Ԃ��J�E���g����

            if (_timeElapsed <= _threeTime)
            {
                floorCnt = 3;
            }
            if (_timeElapsed <= _twoTime)
            {
                floorCnt = 2;
            }
            if (_timeElapsed <= _oneTime)
            {
                floorCnt = 1;
            }
            if (_timeElapsed <= 0)
            {
                floorCnt = 0;
            }
        }
        print(this.gameObject.name + floorCnt + "cnt" + _timeElapsed + "time");
    }
    void FixedTime()//���ԌŒ�
    {
        switch (floorCnt)
        {
            default:
                _timeElapsed = 0f;
                break;

            case 1:
                _timeElapsed = _oneTime;
                break;


            case 2:
                _timeElapsed = _twoTime;
                break;


            case 3:
                _timeElapsed = _threeTime;
                break;
        }
    }
    //private void InputFlag()//�q�b�g�X�g�b�v�I�Ȃ���//��
    //{
    //    if (!floorCntFlag)
    //    {
    //        if (inputFlag)
    //        {
    //            floorCntFlag = true;

    //            if (floorCntFlag)
    //            {
    //                floorCnt++;
    //            }
    //        }
    //        print(this.gameObject.name + floorCnt);
    //    }
    //}
}
