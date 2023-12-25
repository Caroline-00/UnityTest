using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARBallCtrl : MonoBehaviour
{
    public static ARBallCtrl Instance;
    //储存生成精灵球的位置
    public Transform PosInsBall;

    //储存精灵球预制体
    private GameObject[] balls;

    void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start()
    {
        // 加载所有路径在 “Resources/Balls”中的预制体
        balls = Resources.LoadAll<GameObject>("Balls");
        // 刷新精灵球的数量
        ARUI_Mgr.Instance.UpdateUIBallNum();        
        InsNewBall();
    }

    // Update is called once per frame
    void Update()
    {
    }

    //生成精灵球
    public void InsNewBall()
    {
        if (StaticData.BallNum > 0) {
            //生成精灵球
            GameObject _ball = Instantiate(balls[0], PosInsBall.position, PosInsBall.rotation);
            //设置精灵球的父级物体 为了保证发射前始终在屏幕的固定位置
            _ball.transform.SetParent(PosInsBall);
            //给精灵球增加球形碰撞器
            _ball.gameObject.AddComponent<SphereCollider>();
            _ball.gameObject.AddComponent<ARShootBall>();
            // 把精灵球的大小设置为25倍 （预制体是250倍，所以这里等于是缩小）
            _ball.transform.localScale = new Vector3(25f, 25f, 25f);
            // 获取碰撞器，并更改球形碰撞器的大小 使碰撞器与模型大小保持匹配，更改半径大小为0.01
            _ball.GetComponent<SphereCollider>().radius = 0.01f;
        }        
    }
}

