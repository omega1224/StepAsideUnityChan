using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
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

    // 追加

    //Unityちゃんのオブジェクト
    private GameObject unitychan;

    private GameObject Goal;

    // ユニティちゃんのZ座標を保存
    private float Z_position;

    private float goal;
    // Use this for initialization
    void Start()
    {
        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");

        //ゴールのオブジェクトを取得
        this.Goal = GameObject.Find("Goal");


        // ユニティちゃんの現在のZ座標を得る
        Z_position = this.unitychan.transform.position.z;

        //ゴールのZ座標を取得
        goal = this.Goal.transform.position.z;

    }

    // Update is called once per frame
    void Update()
    {
        if (goal-20 >= Z_position + 70)
        {
            // トリガー
            if (this.unitychan.transform.position.z - Z_position > 15.0f)
            {
                //　デバッグ
                Debug.Log("15メートル離れた: " + this.unitychan.transform.position.z);
                //どのアイテムを出すのかをランダムに設定
                int num = Random.Range(1, 11);
                if (num <= 2)
                {
                    //コーンをx軸方向に一直線に生成
                    for (float j = -1; j <= 1; j += 0.4f)
                    {
                        GameObject cone = Instantiate(conePrefab);
                        cone.transform.position = new Vector3(4 * j, cone.transform.position.y, Z_position + 70);
                    }
                }
                else
                {

                    //レーンごとにアイテムを生成
                    for (int j = -1; j <= 1; j++)
                    {
                        //アイテムの種類を決める
                        int item = Random.Range(1, 11);
                        //アイテムを置くZ座標のオフセットをランダムに設定
                        int offsetZ = Random.Range(-5, 6);
                        //60%コイン配置:30%車配置:10%何もなし
                        if (1 <= item && item <= 6)
                        {
                            //コインを生成
                            GameObject coin = Instantiate(coinPrefab);
                            coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, Z_position + 70);
                        }
                        else if (7 <= item && item <= 9)
                        {
                            //車を生成
                            GameObject car = Instantiate(carPrefab);
                            car.transform.position = new Vector3(posRange * j, car.transform.position.y, Z_position + 70);
                        }
                    }
                }
                // 保存しているZ座標を更新
                Z_position = this.unitychan.transform.position.z;
            }
        }
    }
}