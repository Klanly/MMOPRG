using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��ɫ����״̬��������
/// </summary>
public class RoleFSMMgr
{
    /// <summary>
    /// ��ǰ��ɫ������
    /// </summary>
    public RoleCtrl CurrRoleCtrl { get; private set; }

    /// <summary>
    /// ��ǰ��ɫ״̬ö��
    /// </summary>
    public RoleState CurrRoleStateEnum { get; private set; }

    /// <summary>
    /// ��ǰ��ɫ״̬
    /// </summary>
    private RoleStateAbstract m_CurrRoleState = null;

    private Dictionary<RoleState, RoleStateAbstract> m_RoleStateDic;

    /// <summary>
    /// ���캯��
    /// </summary>
    /// <param name="currRoleCtrl"></param>
	public RoleFSMMgr(RoleCtrl currRoleCtrl)
    {
        CurrRoleCtrl = currRoleCtrl;
        m_RoleStateDic = new Dictionary<RoleState, RoleStateAbstract>();
        m_RoleStateDic[RoleState.Idle] = new RoleStateIdle(this);
        m_RoleStateDic[RoleState.Run] = new RoleStateRun(this);
        m_RoleStateDic[RoleState.Attack] = new RoleStateAttack(this);
        m_RoleStateDic[RoleState.Hurt] = new RoleStateHurt(this);
        m_RoleStateDic[RoleState.Die] = new RoleStateDie(this);

        if (m_RoleStateDic.ContainsKey(CurrRoleStateEnum))
        {
            m_CurrRoleState = m_RoleStateDic[CurrRoleStateEnum];
        }
    }

    #region OnUpdate ÿִ֡��
    /// <summary>
    /// ÿִ֡��
    /// </summary>
    public void OnUpdate()
    {
        if (m_CurrRoleState != null)
        {
            m_CurrRoleState.OnUpdate();
        }
    }
    #endregion

    #region ChangState �л�״̬
    /// <summary>
    /// �л�״̬
    /// </summary>
    /// <param name="newState">��״̬</param>
    public void ChangState(RoleState newState)
    {
        if (CurrRoleStateEnum == newState) return;

        //������ǰ״̬���뿪����
        if(m_CurrRoleState != null)
        {
            m_CurrRoleState.OnLeave();
        }

        //���ĵ�ǰ״̬ö��
        CurrRoleStateEnum = newState;

        //���ĵ�ǰ״̬
        m_CurrRoleState = m_RoleStateDic[newState];

        //������״̬�Ľ��뷽��
        m_CurrRoleState.OnEnter();
    }
    #endregion
}
