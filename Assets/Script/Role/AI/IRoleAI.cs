using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�ӿڵ�Ŀ�Ķ���Լ��

/// <summary>
/// ��ɫAI�ӿ�
/// </summary>
public interface IRoleAI
{
    /// <summary>
    /// ��ǰ���ƵĽ�ɫ
    /// </summary>
    RoleCtrl CurrRole
    {
        get;
        set;
    }

    /// <summary>
    /// ִ��AI
    /// </summary>
    void DoAI();
}
