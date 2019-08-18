using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// µÇÂ¼³¡¾°UI¿ØÖÆÆ÷
/// </summary>
public class UISceneLogonCtrl : UISceneBase
{
    
    protected override void OnStart()
    {
        base.OnStart();

        StartCoroutine(OpenLogOnWindow());
    }

    private IEnumerator OpenLogOnWindow()
    {
        yield return new WaitForSeconds(0.2f);
        GameObject obj = WindowUIMgr.Instance.OpenWindow(WindowUIType.LogOn);
    }
}
