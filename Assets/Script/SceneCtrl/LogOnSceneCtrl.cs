using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogOnSceneCtrl : MonoBehaviour {

    private void Awake()
    {
        SceneUIMgr.Instance.LoadSceneUI(SceneUIMgr.SceneUIType.LogOn);
    }

    void Start () {
		
	}
	
	void Update () {
		
	}
}
