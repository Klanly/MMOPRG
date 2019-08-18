using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��ɫ״̬�ĳ������
/// </summary>
public abstract class RoleStateAbstract
{
    /// <summary>
    /// ��ǰ��ɫ����״̬��������
    /// </summary>
    public RoleFSMMgr CurrRoleFSMMgr { get; private set; }

    /// <summary>
    /// ��ǰ����״̬��Ϣ
    /// </summary>
    public AnimatorStateInfo CurrRoleAnimatorStateInfo { get; set; }

    /// <summary>
    /// ���캯��
    /// </summary>
    /// <param name="roleFSMMgr"></param>
    public RoleStateAbstract(RoleFSMMgr roleFSMMgr)
    {
        CurrRoleFSMMgr = roleFSMMgr;
    }

    /// <summary>
    /// ����״̬
    /// </summary>
    public virtual void OnEnter() { }

    /// <summary>
    /// ִ��״̬
    /// </summary>
    public virtual void OnUpdate() { }

    /// <summary>
    /// �뿪״̬
    /// </summary>
    public virtual void OnLeave() { }
}
