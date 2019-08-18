using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 所有UI基类
/// </summary>
public class UIBase : MonoBehaviour {

    private void Awake()
    {
        OnAwake();
    }

    private void Start()
    {
        UIButton[] btnArr = GetComponentsInChildren<UIButton>(true);
        for (int i = 0; i < btnArr.Length; i++)
        {
            UIEventListener.Get(btnArr[i].gameObject).onClick = BtnClick;
        }

        OnStart();
    }

    private void OnDestroy()
    {
        BeforeOnDestroy();
    }

    private void BtnClick(GameObject go)
    {
        OnBtnClick(go);
    }

    private void Update()
    {
        OnUpdate();
    }

    protected virtual void OnAwake() { }
    protected virtual void OnStart() { }
    protected virtual void BeforeOnDestroy() { }
    protected virtual void OnUpdate() { }
    protected virtual void OnBtnClick(GameObject go) { }
}
