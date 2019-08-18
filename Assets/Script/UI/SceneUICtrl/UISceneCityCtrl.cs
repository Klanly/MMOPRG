using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ö÷³ÇUI¿ØÖÆÆ÷
/// </summary>
public class UISceneCityCtrl : UISceneBase
{
    protected override void OnBtnClick(GameObject go)
    {
        switch (go.name)
        {
            case "btnHead":
                OpenRoleInfo();
                break;
            default:
                break;
        }
    }

    private void OpenRoleInfo()
    {
        WindowUIMgr.Instance.OpenWindow(WindowUIType.RoleInfo);
    }
}
