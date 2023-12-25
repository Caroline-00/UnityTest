using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsPoint : MonoBehaviour
{
    // 公有变量首字母大写
    // 私有变量首字母小写
    // 局部变量首字母小写且首字母前加下划线'_'

    // 储存地图角色
    public GameObject Ava;
    // 储存事件点预制体
    public GameObject PrePoint;
    // 储存距离范围的最小值,最小值3m，f：浮点数
    public float MinDis = 3f;
    // 储存距离范围的最大值
    public float MaxDis = 50f;
    // 储存当前角色位置的坐标
    private Vector3 v3Ava;
    

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // 生成事件点预制体
    public void InsPointFuc()
    {
        // 获取角色当前的坐标位置
        v3Ava = Ava.transform.position;
        // 从距离范围中取一个随机距离值，使用局部变量来存储
        float _dis = Random.Range(MinDis, MaxDis);
        // 从原点为（0，0）的坐标上获取任意一个方向的向量，只需要方向不需要大小，因为要使用随机距离当做大小
        Vector2 _pOri = Random.insideUnitCircle;
        // 因此获取到向量的单位向量，大小为1
        Vector2 _pNor = _pOri.normalized;
        // 算出随机点的位置
        // _pNor.x*_dis随机向量的x值
        // _pNor.y*_dis随机向量的y值
        Vector3 _v3Point = new Vector3(v3Ava.x + _pNor.x * _dis, 0, v3Ava.z + _pNor.y * _dis);
        //生成预制体
        GameObject _poiMark = Instantiate(PrePoint, _v3Point, transform.rotation);

    }
}
