using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Mgr_02 : MonoBehaviour
{
    // 储存显示精灵球数量的 Text组件
    public Text Tx_BallNum;
    //储存显示食物数量的 Text组件
    public Text Tx_FoodNum;
    //申请静态公有脚本类变量
    public static UI_Mgr_02 Instance;
    // 储存捕捉面板
    public GameObject Im_Catch;


    void Awake()
    {
        // this表示目前这个脚本
        Instance = this;
    }
    void Start()
    {
        Tx_BallNum.text = StaticData.BallNum.ToString();
    }
    //增加精灵球数量显示的函数
    public void AddBallNum()
    {
        //// 将从Text组件中获取的字符串转化为数字储存在局部变量_num中
        //int _num = Int32.Parse(Tx_BallNum.text);
        //// 在原有的数字基础上加1
        //_num++;
        //// 把增加后的数字转化为字符串显示在Text组件上
        //Tx_BallNum.text = _num.ToString();

        // 小球的数量增加1
        StaticData.BallNum++;
        // 把增加后的数字转化为字符串显示在Text组件上
        Tx_BallNum.text = StaticData.BallNum.ToString();        
    }

    //增加食物的显示数量的函数
    public void AddFoodNum()
    {
        // 将从Text组件中获取的字符串强制转化为数字储存在局部变量_num中
        int _num = Int32.Parse(Tx_FoodNum.text);
        // 在原有的数字基础上加1
        _num++;
        // 把增加后的数字转化为字符串显示在Text组件上
        Tx_FoodNum.text = _num.ToString();        
    }

    //设置捕捉面板的激活状态
    // 使用传入参数的状态来进行设置，不直接使用false/True
    public void SetIm_Catch(bool bl)
    {
        // 通过调用函数时传入的bool类型参数bl来设置面板状态
        Im_Catch.SetActive(bl);
    }
    // 跳转AR场景的按钮函数
    public void Btn_GoARScn()
    {
        SceneManager.LoadScene("AR_Scn");
    }
    // 跳转仓库
    public void Btn_ToStore()
    {
        SceneManager.LoadScene("Store_Scn");
    }
    // 跳转商店
    public void Btn_ToShop()
    {
        SceneManager.LoadScene("Shop_Scn");
    }
    // 跳转到换装的按钮
    public void Btn_ToCustome()
    {
        SceneManager.LoadScene("Custome_Scn");
    }
}
