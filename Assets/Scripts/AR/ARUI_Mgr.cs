using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ARUI_Mgr : MonoBehaviour
{

    public static ARUI_Mgr Instance;

    // 储存显示精灵球数量的Text组件
    public Text Tx_BallNum;

    //小精灵捕捉成功的面板
    public GameObject PnCatched;

    //小精灵起名字的Text组件
    public Text InputPetName;



    void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //跳转到地图场景的按钮
    public void Btn_GoMapScn()
    {
        SceneManager.LoadScene("Map_Scn");
    }

    //刷新精灵球UI数量的函数
    public void UpdateUIBallNum()
    {
        Tx_BallNum.text = StaticData.BallNum.ToString();
        //把精灵球数量的全局数据显示在UI中
    }

    //显示小精灵捕捉成功的面板
    public void Show_PnCatched()
    {
        PnCatched.SetActive(true);
    }

    //捕捉小精灵确认保存按钮的函数
    public void Btn_Yes()
    {        
        //从输入框中获取到玩家给小精灵取的名字
        string _name = InputPetName.text;
        //从全局脚本中获取正在捕捉的小精灵在预制体集合中的序号
        int _index = StaticData.CatchingPetIndex;
        //向全局数据的小精灵列表中添加一条小精灵属性类数据
        StaticData.AddPet(new PetSave(_name, _index));
        //跳转到仓库场景
        SceneManager.LoadScene("Store_Scn");
    }

    // 放生按钮的函数
    public void Btn_GiveUp()
    {
        SceneManager.LoadScene("Map_Scn");
    }

    // 进入精灵仓库按钮
    public void Btn_ToStore()
    {
        SceneManager.LoadScene("Store_Scn");
    }
}
