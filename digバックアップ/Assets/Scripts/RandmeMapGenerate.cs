using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandmeMapGenerate : MonoBehaviour
{
    [Header("���I�u�W�F�N�g")]
    [SerializeField] private GameObject block;
    [Header("�ǃI�u�W�F�N�g")]
    [SerializeField] private GameObject wall;
    [Header("�v���C���[�I�u�W�F�N�g")]
    [SerializeField] private GameObject player;
    [Header("�G�I�u�W�F�N�g")]
    [SerializeField] private GameObject enemy;

    private bool isSpwan = false;

    private int juge = 9;          //�����𔻒肷�鐔�l���i�[����ϐ�
    private int enemyCnt = 5;

    //���𐶐����邽�߂̈ʒu���i�[���Ă���񎟌��z��
    private int[,] mapPos = new int[,]
        {
                {-8,-7,-6,-5,-4,-3,-2,-1,0,1,2,3,4,5,6,7,8 },
                {-8,-7,-6,-5,-4,-3,-2,-1,0,1,2,3,4,5,6,7,8 },
                {-8,-7,-6,-5,-4,-3,-2,-1,0,1,2,3,4,5,6,7,8 },
                {-8,-7,-6,-5,-4,-3,-2,-1,0,1,2,3,4,5,6,7,8 },
                {-8,-7,-6,-5,-4,-3,-2,-1,0,1,2,3,4,5,6,7,8 },
                {-8,-7,-6,-5,-4,-3,-2,-1,0,1,2,3,4,5,6,7,8 },
                {-8,-7,-6,-5,-4,-3,-2,-1,0,1,2,3,4,5,6,7,8 },
                {-8,-7,-6,-5,-4,-3,-2,-1,0,1,2,3,4,5,6,7,8 },
                {-8,-7,-6,-5,-4,-3,-2,-1,0,1,2,3,4,5,6,7,8 },
                {-8,-7,-6,-5,-4,-3,-2,-1,0,1,2,3,4,5,6,7,8 },
                {-8,-7,-6,-5,-4,-3,-2,-1,0,1,2,3,4,5,6,7,8 },
                {-8,-7,-6,-5,-4,-3,-2,-1,0,1,2,3,4,5,6,7,8 },
                {-8,-7,-6,-5,-4,-3,-2,-1,0,1,2,3,4,5,6,7,8 },
                {-8,-7,-6,-5,-4,-3,-2,-1,0,1,2,3,4,5,6,7,8 },
                {-8,-7,-6,-5,-4,-3,-2,-1,0,1,2,3,4,5,6,7,8 },
                {-8,-7,-6,-5,-4,-3,-2,-1,0,1,2,3,4,5,6,7,8 },
                {-8,-7,-6,-5,-4,-3,-2,-1,0,1,2,3,4,5,6,7,8 }
        };

    //�ǂ𐶐����邽�߂̈ʒu���i�[���Ă���񎟌��z��
    private int[,] wallPos = new int[,]
        {
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
        };

    private void Awake()
    {
        //�z���T�����郋�[�v���@
        for (int i = 0; i < mapPos.GetLength(0); ++i)
        {
            //�z���T�����郋�[�v���A
            for (int j = 0; j < mapPos.GetLength(1); ++j)
            {
                //���̐����ʒu�����߂�
                Vector3 blockSpwanPos = new Vector3(mapPos[i, j], 0, mapPos[j, i]);

                //�ǂ̐����ʒu�����߂�                
                Vector3 wallSpwanPos = new Vector3(mapPos[i, j], 0.5f, mapPos[j, i]);

                //���𐶐�
                GameObject childObj = Instantiate(block, blockSpwanPos, Quaternion.identity);

                //�񎟌��z����̐��l��1�̎����̏���������
                if (wallPos[i, j] == 1)
                {
                    //�ǂ𐶐�
                    Instantiate(wall, wallSpwanPos, Quaternion.identity);
                }

                //�����q�I�u�W�F�N�g�ɂ���
                childObj.transform.parent = gameObject.transform;
            }
        }

        //�z���T�����郋�[�v���@
        for (int k = 2; k < mapPos.GetLength(0) - 2; ++k)
        {
            //�z���T�����郋�[�v���A
            for (int l = 2; l < mapPos.GetLength(1) - 2; ++l)
            {
                //�ǂ̐����ʒu�����߂�                
                Vector3 wallSpwanPos = new Vector3(mapPos[k, l], 0.5f, mapPos[l, k]);

                //�񎟌��z����̐��l��0�̎����̏���������
                if (wallPos[k, l] == 0)
                {
                    Juge(k, l);
                }

                //�񎟌��z����̐��l��1�̎����̏���������
                if (wallPos[k, l] == 1)
                {
                    //�ǂ𐶐�
                    Instantiate(wall, wallSpwanPos, Quaternion.identity);
                }

                //�ǂ��Ȃ��Ƃ���Ƀv���C���[����
                if (wallPos[k, l] == 0 && !isSpwan)
                {
                    PlayerPos(k, l);
                }
            }
        }


    }
    // Start is called before the first frame update
    void Start()
    {

        //�z���T�����郋�[�v���@
        for (int n = mapPos.GetLength(1) - 2; n > 2; --n)
        {
            //�z���T�����郋�[�v���A
            for (int m = mapPos.GetLength(0) - 2; m > 2; --m)
            {
                //�񎟌��z����̐��l��0�̎����̏���������
                if (wallPos[n,m] == 0 && enemyCnt > 0)
                {
                    EnemyPos(n,m);
                }

            }
        }

        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// �ǂ̃����_���������\�b�h
    /// </summary>
    private void Juge(int i, int j)
    {
        //�����_���Ȓl���擾
        int k = Random.Range(1, 11);

        //�擾�����l������̒l���傫����Ύ��̏���������
        if (k >= juge)
        {
            wallPos[i, j] = 1;
        }
    }

    /// <summary>
    /// �v���C���[�������\�b�h
    /// </summary>
    private void PlayerPos(int i, int j)
    {
        //�����_���Ȓl���擾
        int k = Random.Range(1, 11);

        //�擾�����l������̒l���傫����Ύ��̏���������
        if (k >= juge)
        {
            Instantiate(player, new Vector3(mapPos[i, j], 0.1f, mapPos[j, i]), Quaternion.identity);
            isSpwan = true;
        }
    }

    /// <summary>
    /// �G�������\�b�h
    /// </summary>
    /// <param name="i"></param>
    /// <param name="j"></param>
    private void EnemyPos(int i, int j)
    {
        //�����_���Ȓl���擾
        int k = Random.Range(1, 11);


        //�擾�����l������̒l���傫����Ύ��̏���������
        if (k >= juge)
        {
            Instantiate(enemy, new Vector3(mapPos[i,j], 0.1f, mapPos[j,i]), Quaternion.identity);
            enemyCnt--;
        }
    }

}
