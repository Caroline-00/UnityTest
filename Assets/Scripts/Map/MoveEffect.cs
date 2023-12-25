using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEffect : MonoBehaviour
{
    // 2.设置浮动效果
    // 设置起始的弧度
    private float radian = 0;
    // 设置弧度的变化值
    private float perRad = 0.03f;
    // 储存位移的偏移量 
    private float add = 0f;
    // 储存物体生成时的起始坐标
    private Vector3 posOri;

    // Use this for initialization
    void Start()
    {
        // 记录物体生成时候的起始坐标
        posOri = transform.position;        
    }

    // Update is called once per frame
    void Update()
    {
        // 弧度不断的增加，可以理解为改变sin函数的x
        // 每一帧增加一个变量
        radian += perRad;
        // 求得Y值，即偏移值
        add = Mathf.Sin(radian);        
        // 让物体浮动起来
        transform.position = posOri + new Vector3(0, add, 0);
        // 1. 设置旋转效果，以世界坐标为旋转依据，在Y轴上进行旋转
        transform.Rotate(0, Time.deltaTime * 25f, 0, Space.World);       
    }
}