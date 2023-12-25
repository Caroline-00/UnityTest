using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CusUI_Map : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //跳转到地图场景的按钮
    public void Btn_GoMapScn()
    {
        SceneManager.LoadScene("Map_Scn");
    }
}
