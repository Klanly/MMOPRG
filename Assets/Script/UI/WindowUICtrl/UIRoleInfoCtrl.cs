using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��ɫ��Ϣ���ڿ�����
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
