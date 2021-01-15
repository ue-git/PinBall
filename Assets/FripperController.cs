using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{
    //HingeJointコンポネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

    // Start is called before the first frame update
    void Start()
    {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update()
    {
        //左矢印キーまたはAキーを押した時左フリッパーを動かす（発展課題追加）
        if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && tag == "LeftFripperTag" )
        {
            SetAngle(this.flickAngle);
        }

        //右矢印キーまたはDキーを押した時右フリッパーを動かす（発展課題追加）
        if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        //下矢印キーまたはSキーを押した時左右フリッパーを動かす（発展課題追加）
        if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && (tag == "RightFripperTag" || tag == "LeftFripperTag"))
        {
            SetAngle(this.flickAngle);
        }

        //左矢印キーまたはAキーが離された時フリッパーを元に戻す（発展課題追加）
        if ((Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A)) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }

        //右矢印キーまたはDキーが離された時フリッパーを元に戻す（発展課題追加）
        if ((Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D)) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }

        //右矢印キーまたはSキーが離された時フリッパーを元に戻す（発展課題追加）
        if ((Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S)) && (tag == "RightFripperTag" || tag == "LeftFripperTag"))
        {
            SetAngle(this.defaultAngle);
        }

    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}