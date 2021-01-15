
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BrightnessRegulator : MonoBehaviour
{
    //Materialを入れる
    Material myMaterial;

    //Emissionの最小値
    private float minEmission = 0.3f;
    //Emissionの強度
    private float magEmission = 2.0f;
    //角度
    private int degree = 0;
    //発行速度
    private int speed = 10;
    //ターゲットのデフォルトの色
    Color defaultColor = Color.white;

    //ゲームオーバを表示するテキスト
    private GameObject scoreText;

    //衝突時の配点（課題）
    private int scoreCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        //タグによって光らせる色を変える
        if(tag == "SmallStarTag")
        {
            this.defaultColor = Color.white;
        }
        else if(tag == "LargeStarTag")
        {
            this.defaultColor = Color.yellow;
        }
        else if (tag == "SmallCloudTag" || tag == "LargeCloudTag")
        {
            this.defaultColor = Color.cyan;
        }

        //オブジェクトにアタッチしているMaterialを取得
        this.myMaterial = GetComponent<Renderer>().material;

        //オブジェクトの最初の色を設定
        myMaterial.SetColor("_EmissionColor", this.defaultColor * minEmission);

        //得点オブジェクトの設定（課題）
        this.scoreText = GameObject.Find("ScoreCountText");
        //初期得点を０に設定（課題）
        this.scoreText.GetComponent<Text>().text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        if(this.degree >= 0)
        {
            //光らせる強度を計算する
            Color emissionColor = this.defaultColor * (this.minEmission + Mathf.Sin(this.degree * Mathf.Deg2Rad) * this.magEmission);

            //エミッションに色を設定する
            myMaterial.SetColor("_EmissionColor", emissionColor);

            //現在の角度を小さくする
            this.degree -= this.speed;



        }   
    }

    //衝突に呼ばれる関数
    void OnCollisionEnter(Collision other)
    {
        //角度を180に設定
        this.degree = 180;


        //下記より得点設定（課題）       
        //タグによって得点の加点判定（課題）
        if (tag == "SmallStarTag")
        {
            this.scoreCount = 10;
        }
        else if (tag == "LargeStarTag")
        {
            this.scoreCount = 50;
        }
        else if (tag == "SmallCloudTag")
        {
            this.scoreCount = 100;
        }
        else if (tag == "LargeCloudTag")
        {
            this.scoreCount = 200;
        }

        //現在のスコアをint型にキャスト（課題）
        int scoreInt = Int32.Parse(scoreText.GetComponent<Text>().text);
        //衝突物の得点を加点（課題）
        scoreInt += scoreCount;
        //スコアテキストに合計点を記載（課題）
        this.scoreText.GetComponent<Text>().text = scoreInt.ToString();
    }
}
