using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandmeMapGenerate : MonoBehaviour
{
    [Header("床オブジェクト")]
    [SerializeField] private GameObject block;
    [Header("壁オブジェクト")]
    [SerializeField] private GameObject wall;
    [Header("プレイヤーオブジェクト")]
    [SerializeField] private GameObject player;
    [Header("敵オブジェクト")]
    [SerializeField] private GameObject enemy;

    private bool isSpwan = false;

    private int juge = 9;          //生成を判定する数値を格納する変数
    private int enemyCnt = 5;

    //床を生成するための位置を格納している二次元配列
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

    //壁を生成するための位置を格納している二次元配列
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
        //配列を探索するループ文①
        for (int i = 0; i < mapPos.GetLength(0); ++i)
        {
            //配列を探索するループ文②
            for (int j = 0; j < mapPos.GetLength(1); ++j)
            {
                //床の生成位置を決める
                Vector3 blockSpwanPos = new Vector3(mapPos[i, j], 0, mapPos[j, i]);

                //壁の生成位置を決める                
                Vector3 wallSpwanPos = new Vector3(mapPos[i, j], 0.5f, mapPos[j, i]);

                //床を生成
                GameObject childObj = Instantiate(block, blockSpwanPos, Quaternion.identity);

                //二次元配列内の数値が1の時次の処理をする
                if (wallPos[i, j] == 1)
                {
                    //壁を生成
                    Instantiate(wall, wallSpwanPos, Quaternion.identity);
                }

                //床を子オブジェクトにする
                childObj.transform.parent = gameObject.transform;
            }
        }

        //配列を探索するループ文①
        for (int k = 2; k < mapPos.GetLength(0) - 2; ++k)
        {
            //配列を探索するループ文②
            for (int l = 2; l < mapPos.GetLength(1) - 2; ++l)
            {
                //壁の生成位置を決める                
                Vector3 wallSpwanPos = new Vector3(mapPos[k, l], 0.5f, mapPos[l, k]);

                //二次元配列内の数値が0の時次の処理をする
                if (wallPos[k, l] == 0)
                {
                    Juge(k, l);
                }

                //二次元配列内の数値が1の時次の処理をする
                if (wallPos[k, l] == 1)
                {
                    //壁を生成
                    Instantiate(wall, wallSpwanPos, Quaternion.identity);
                }

                //壁がないところにプレイヤー生成
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

        //配列を探索するループ文①
        for (int n = mapPos.GetLength(1) - 2; n > 2; --n)
        {
            //配列を探索するループ文②
            for (int m = mapPos.GetLength(0) - 2; m > 2; --m)
            {
                //二次元配列内の数値が0の時次の処理をする
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
    /// 壁のランダム生成メソッド
    /// </summary>
    private void Juge(int i, int j)
    {
        //ランダムな値を取得
        int k = Random.Range(1, 11);

        //取得した値が判定の値より大きければ次の処理をする
        if (k >= juge)
        {
            wallPos[i, j] = 1;
        }
    }

    /// <summary>
    /// プレイヤー生成メソッド
    /// </summary>
    private void PlayerPos(int i, int j)
    {
        //ランダムな値を取得
        int k = Random.Range(1, 11);

        //取得した値が判定の値より大きければ次の処理をする
        if (k >= juge)
        {
            Instantiate(player, new Vector3(mapPos[i, j], 0.1f, mapPos[j, i]), Quaternion.identity);
            isSpwan = true;
        }
    }

    /// <summary>
    /// 敵生成メソッド
    /// </summary>
    /// <param name="i"></param>
    /// <param name="j"></param>
    private void EnemyPos(int i, int j)
    {
        //ランダムな値を取得
        int k = Random.Range(1, 11);


        //取得した値が判定の値より大きければ次の処理をする
        if (k >= juge)
        {
            Instantiate(enemy, new Vector3(mapPos[i,j], 0.1f, mapPos[j,i]), Quaternion.identity);
            enemyCnt--;
        }
    }

}
