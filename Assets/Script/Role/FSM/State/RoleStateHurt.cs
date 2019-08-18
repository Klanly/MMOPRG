using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����״̬
/// </summary>
public class RoleStateHurt : RoleStateAbstract
{
    /// <summary>
    /// ���캯��
    /// </summary>
    /// <param name="roleFSMMgr">����״̬������</param>
    public RoleStateHurt(RoleFSMMgr roleFSMMgr) : base(roleFSMMgr)
    {
    }

    /// <summary>
    /// ʵ�ֻ��� ����״̬
    /// </summary>
    public override void OnEnter()
    {
        base.OnEnter();

        CurrRoleFSMMgr.CurrRoleCtrl.Animator.SetBool(ToAnimatorCondition.ToHurt.ToString(), true);
    }

    /// <summary>
    /// ʵ�ֻ��� ִ��״̬
    /// </summary>
    public override void OnUpdate()
    {
        base.OnUpdate();

        CurrRoleAnimatorStateInfo = CurrRoleFSMMgr.CurrRoleCtrl.Animator.GetCurrentAnimatorStateInfo(0);
        if (CurrRoleAnimatorStateInfo.IsName(RoleAnimatorName.Hurt.ToString()))
        {
            CurrRoleFSMMgr.CurrRoleCtrl.Animator.SetInteger(ToAnimatorCondition.CurrState.ToString(), (int)RoleState.Hurt);
        }

        //�������ִ����һ�飬���л�����
        if (CurrRoleAnimatorStateInfo.normalizedTime > 1)
        {
            CurrRoleFSMMgr.CurrRoleCtrl.ToIdle();
        }
    }

    /// <summary>
    /// ʵ�ֻ��� �뿪״̬
    /// </summary>
    public override void OnLeave()
    {
        base.OnLeave();

        CurrRoleFSMMgr.CurrRoleCtrl.Animator.SetBool(ToAnimatorCondition.ToHurt.ToString(), false);
    }
}
