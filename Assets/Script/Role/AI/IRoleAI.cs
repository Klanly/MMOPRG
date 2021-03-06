using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//接口的目的定义约束

/// <summary>
/// 角色AI接口
/// </summary>
public interface IRoleAI
{
    /// <summary>
    /// 当前控制的角色
    /// </summary>
    RoleCtrl CurrRole
    {
        get;
        set;
    }

    /// <summary>
    /// 执行AI
    /// </summary>
    void DoAI();
}
