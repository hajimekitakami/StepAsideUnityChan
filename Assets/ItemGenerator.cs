using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject unityChan;

    public GameObject mainCamera;

    public GameObject [] coins;

    public GameObject [] cones;

    public GameObject [] cars;

    //carPrefabを入れる
    public GameObject carPrefab;

    //coinPrefabを入れる
    public GameObject coinPrefab;
    
    //cornPrefabを入れる
    public GameObject conePrefab;

    //スタート地点
    private int startPos = 80;

    //ゴール地点
    private int goalPos = 360;

    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;

    private int nextItemPos = 80;


    // Start is called before the first frame update
    void Start()
    {
        this.unityChan = GameObject.Find("unitychan");
        this.mainCamera = GameObject.Find("Main Camera");

        //一定の距離ごとにアイテムを生成
        /*for (int i = startPos; i < goalPos; i +=15)
        {
            //どのアイテムを出すのかランダムに設定
            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                //コーンをx軸方向に一直線に生成
                for(float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab);
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
                }
            }
            else
            {
                //レーンごとにアイテムを生成
                for (int j = -1; j <= 1; j++)
                {
                    //アイテムの種類を決める
                    int item = Random.Range(1, 11);
                    //アイテムを置くｚ座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-5, 6);
                    //60%コイン配置：30%車配置：10%何もなし
                    if (1 <= item && item <= 6)
                    {
                        //コインを生成
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
                    }
                }
            }

            this.coins = GameObject.FindGameObjectsWithTag("CoinTag");
            this.cones = GameObject.FindGameObjectsWithTag("TrafficConeTag");
            this.cars = GameObject.FindGameObjectsWithTag("CarTag");
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        GenerateItem();
    }

    void FixedUpdate()
    {
        //DestroyItem();
    }

    private void GenerateItem()
    {

        if((nextItemPos - unityChan.transform.position.z >= 40 && nextItemPos - unityChan.transform.position.z <= 50) && nextItemPos < 360)
        {
            //どのアイテムを出すのかランダムに設定
            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                //コーンをx軸方向に一直線に生成
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab);
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, nextItemPos);
                }
            }
            else
            {
                //レーンごとにアイテムを生成
                for (int j = -1; j <= 1; j++)
                {
                    //アイテムの種類を決める
                    int item = Random.Range(1, 11);
                    //アイテムを置くｚ座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-5, 6);
                    //60%コイン配置：30%車配置：10%何もなし
                    if (1 <= item && item <= 6)
                    {
                        //コインを生成
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, nextItemPos + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, nextItemPos + offsetZ);
                    }
                }
            }

            nextItemPos += 15;
        }

        
    }

    /*private void DestroyItem()
    {
        for (int i = 0; i < coins.Length; i++)
        {
            if (coins[i] != null)
            {
                if (mainCamera.transform.position.z > coins[i].transform.position.z)
                {
                    Destroy(coins[i].gameObject);
                }
            }
        }

        for (int j = 0; j < cones.Length; j++)
        {
            if (cones[j] != null)
            {
                if (mainCamera.transform.position.z > cones[j].transform.position.z)
                {
                    Destroy(cones[j].gameObject);
                }
            }
        }

        for (int k = 0; k < cars.Length; k++)
        {
            if (cars[k] != null)
            {
                if (mainCamera.transform.position.z > cars[k].transform.position.z)
                {
                    Destroy(cars[k].gameObject);
                }
            }
        }
    }*/
    }
