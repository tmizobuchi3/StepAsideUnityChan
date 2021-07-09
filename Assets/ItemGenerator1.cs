using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator1 : MonoBehaviour
{
    public GameObject carPrefab;

    public GameObject coinPrefab;

    public GameObject conePrefab;

    //スタート地点
    private int startPos = 80;

    //ゴール地点
    private int goalPos = 360;

    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;

    //Unityちゃんの位置★
    Vector3 uniPosi;

    //最後にアイテムを配置した位置★
    Vector3 itemPosi;


    // Start is called before the first frame update
    void Start()
    {
        itemPosi = new Vector3();

        itemPosi = uniPosi;

    }

    // Update is called once per frame
    void Update()
    {
        uniPosi = GameObject.Find("unitychan").transform.position;


        if (uniPosi.z - itemPosi.z > 30)
        {
            //どのアイテムを出すのかをランダムに設定
            int num = Random.Range(1, 11);

            if (num <= 2)
            {
                //コーンをx軸方向に一直線に生成
                for (float j = -1.4f; j <= 1.4f; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab);
                    cone.transform.position = new Vector3(3 * j, cone.transform.position.y, uniPosi.z + 40);
                }
            }

            else
            {
                //レーンごとにアイテムを生成
                for (int j = -1; j <= 1; j++)
                {
                    //アイテムの種類を決める
                    int item = Random.Range(1, 11);
                    //アイテムを置くz座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-5, 6);
                    //60%コイン配置：30%車配置：10%何もなし
                    if (1 <= item && item <= 6)
                    {
                        //コインを生成
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, uniPosi.z + 40 + offsetZ);

                    }
                    else if (7 <= item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, uniPosi.z + 40 + offsetZ);

                    }
                }

            }
        itemPosi = uniPosi;

        }
    }
}
