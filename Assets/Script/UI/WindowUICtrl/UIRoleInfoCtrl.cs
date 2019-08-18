using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 角色信息窗口控制器
/// </summary>
public class UIRoleInfoCtrl : UIWindowBase
{
    protected override void OnBtnClick(GameObject go)
    {
        switch (go.name)
        {
            case "btnClose":
                base.Close();
                break;
            default:
                break;
        }
    }

}
