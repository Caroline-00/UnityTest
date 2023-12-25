using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopMgr : MonoBehaviour {

	// Use this for initialization
	void Start () {		
	}
	
	// Update is called once per frame
	void Update () {		
	}
    // 跳转到地图的按钮
    public void Btn_ToMap()
    {
        SceneManager.LoadScene("Map_Scn");
    }
    // 跳转到换装的按钮
    public void Btn_ToCustome()
    {
        SceneManager.LoadScene("Custome_Scn");
    }
}
