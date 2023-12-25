using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pet_Find : MonoBehaviour
{

    // 储存小精灵的序号
    public int Pet_Index;

    // Use this for initialization
    void Start()
    {
        // 让小精灵面朝角色的位置
        transform.LookAt(GameObject.FindGameObjectWithTag("Avatar").transform);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        // 如果碰撞到的物体是角色
        if (other.tag == "Avatar")
        {
            // 显示捕捉面板 
            UI_Mgr_02.Instance.SetIm_Catch(true);
            // 当碰到角色时 把小精灵的序号赋值给静态数据中正要捕捉的小精灵序号
            StaticData.CatchingPetIndex = Pet_Index;
            // 销毁物体
            Destroy(gameObject);
        }
        // 如果碰撞到的物体是精灵球
        if (other.tag == "Ball")
        {
            //播放动画
            playCatched();
            // 延迟播放
            StartCoroutine(ShowCatchedPn());
        }
    }

    // 延迟显示面板并销毁小精灵
    IEnumerator ShowCatchedPn()
    {
        // 延迟2秒显示
        yield return new WaitForSeconds(2f);
        // 显示捕捉成功面板
        ARUI_Mgr.Instance.Show_PnCatched();
        // 销毁小精灵本身
        Destroy(transform.gameObject);
    }

    // 播放被捕捉到的动画
    private void playCatched()
    {
        // 找到动画控制器，激活Trigger参数(在动画控制器里设置的)
        transform.GetComponent<Animator>().SetTrigger("Catched");
    }
}
