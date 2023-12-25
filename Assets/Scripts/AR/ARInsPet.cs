using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARInsPet : MonoBehaviour
{
    // 储存预制的生成位置
    public Transform[] traPos;
    // 储存小精灵预制体
    private GameObject[] pets;
    // AR摄像机的位置
    public Transform CameraTra;

    // Use this for initialization
    void Start()
    {
        // 加载小精灵预制体
        pets = Resources.LoadAll<GameObject>("Pets");
        // 在AR场景中生成要捕捉的小精灵
        InsPet();
        //生成要捕捉的小精灵
    }

    // Update is called once per frame
    void Update()
    {
    }

    // 生成小精灵
    public void InsPet()
    {
        // 从预制位置的数量中随机一个序号
        int _index = Random.Range(0, traPos.Length);
        // 得到随机位置
        Transform _tra = traPos[_index];
        // 在随机位置生成小精灵
        // 增加静态变量数据进行全局管理之后不能随便生成了，将pets[0]更改为ets[StaticData.CatchingPetIndex]，即小精灵的生成序号为地图场景传递来的正要捕捉的小精灵序号
        GameObject _pet = Instantiate(pets[StaticData.CatchingPetIndex], _tra.position, _tra.rotation);
        // 设置小精灵的显示大小，这里设置小精灵缩放到0.5倍
        _pet.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        // 让生成的小精灵面朝玩家
        _pet.transform.LookAt(new Vector3(CameraTra.position.x, _pet.transform.position.y, CameraTra.position.z));
    }
}
