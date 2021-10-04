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

    //carPrefab������
    public GameObject carPrefab;

    //coinPrefab������
    public GameObject coinPrefab;
    
    //cornPrefab������
    public GameObject conePrefab;

    public float PastunityChanPos = 0.0f;

    //�X�^�[�g�n�_
    private int startPos = 80;

    //�S�[���n�_
    private int goalPos = 360;

    //�A�C�e�����o��x�����͈̔�
    private float posRange = 3.4f;


    // Start is called before the first frame update
    void Start()
    {
        this.unityChan = GameObject.Find("unitychan");
        this.mainCamera = GameObject.Find("Main Camera");

        //���̋������ƂɃA�C�e���𐶐�
        /*for (int i = startPos; i < goalPos; i +=15)
        {
            //�ǂ̃A�C�e�����o���̂������_���ɐݒ�
            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                //�R�[����x�������Ɉ꒼���ɐ���
                for(float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab);
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
                }
            }
            else
            {
                //���[�����ƂɃA�C�e���𐶐�
                for (int j = -1; j <= 1; j++)
                {
                    //�A�C�e���̎�ނ����߂�
                    int item = Random.Range(1, 11);
                    //�A�C�e����u�������W�̃I�t�Z�b�g�������_���ɐݒ�
                    int offsetZ = Random.Range(-5, 6);
                    //60%�R�C���z�u�F30%�Ԕz�u�F10%�����Ȃ�
                    if (1 <= item && item <= 6)
                    {
                        //�R�C���𐶐�
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        //�Ԃ𐶐�
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
        DestroyItem();
    }

    private void GenerateItem()
    {
        float CurrentunityChanPos = unityChan.transform.position.z;
        if (CurrentunityChanPos - PastunityChanPos > 50.0f && CurrentunityChanPos <= 270.0f || CurrentunityChanPos == 0.0f)
        {
            //���̋������ƂɃA�C�e���𐶐�
            for (float i = CurrentunityChanPos + 50.0f; i < CurrentunityChanPos + 90.0f; i += 15.0f)
            {
                //�ǂ̃A�C�e�����o���̂������_���ɐݒ�
                int num = Random.Range(1, 11);
                if (num <= 2)
                {
                    //�R�[����x�������Ɉ꒼���ɐ���
                    for (float j = -1; j <= 1; j += 0.4f)
                    {
                        GameObject cone = Instantiate(conePrefab);
                        cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
                    }
                }
                else
                {
                    //���[�����ƂɃA�C�e���𐶐�
                    for (int j = -1; j <= 1; j++)
                    {
                        //�A�C�e���̎�ނ����߂�
                        int item = Random.Range(1, 11);
                        //�A�C�e����u�������W�̃I�t�Z�b�g�������_���ɐݒ�
                        int offsetZ = Random.Range(-5, 6);
                        //60%�R�C���z�u�F30%�Ԕz�u�F10%�����Ȃ�
                        if (1 <= item && item <= 6)
                        {
                            //�R�C���𐶐�
                            GameObject coin = Instantiate(coinPrefab);
                            coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
                        }
                        else if (7 <= item && item <= 9)
                        {
                            //�Ԃ𐶐�
                            GameObject car = Instantiate(carPrefab);
                            car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
                        }
                    }
                }               

                this.coins = GameObject.FindGameObjectsWithTag("CoinTag");
                this.cones = GameObject.FindGameObjectsWithTag("TrafficConeTag");
                this.cars = GameObject.FindGameObjectsWithTag("CarTag");
            }
            PastunityChanPos = CurrentunityChanPos;
        }
        
    }

    private void DestroyItem()
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
    }
}
