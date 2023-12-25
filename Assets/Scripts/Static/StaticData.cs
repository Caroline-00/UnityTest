using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 不能继承原来默认的父类
// 静态脚本里的类也必须是静态类
public static class StaticData
{
    //精灵球数量的全局变量 
    public static int BallNum = 5;

    //当前正要捕捉的小精灵在预制体集合中的序号
    public static int CatchingPetIndex;

    public static List<PetSave> PetList = new List<PetSave>();
    //申请列表储存捕捉到的小精灵类

    /// <summary>
    /// 向全局数据的小精灵列表中添加小精灵
    /// </summary>
    /// <param name="petSave">小精灵的属性类</param>
    public static void AddPet(PetSave petSave)
    {
        PetList.Add(petSave);
    }

    /// <summary>
    /// 通过小精灵在预制体集合中的序号获取它的精灵类型
    /// </summary>
    /// <param name="index">小精灵在预制体集合中的序号</param>
    /// <returns>小精灵的类型</returns>
    public static string GetType(int index)
    {
        if (index == 0)
        {
            return "Bear";
        }
        else if (index == 1)
        {
            return "Cattle";
        }
        else if (index == 2)
        {
            return "Rabbit";
        }
        else if (index == 3)
        {
            return "Chick";
        }
        else if (index == 4)
        {
            return "Tiger";
        }
        else if (index == 5)
        {
            return "Monkey";
        }
        else if (index == 6)
        {
            return "Kitty";
        }
        else if (index == 7)
        {
            return "Lion";
        }
        else if (index == 8)
        {
            return "Penguin";
        }
        else if (index == 9)
        {
            return "Rhino";
        }
        else
        {
            return "Puppy";
        }
    }
}
