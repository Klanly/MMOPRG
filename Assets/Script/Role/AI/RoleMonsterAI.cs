using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��AI
/// </summary>
public class RoleMonsterAI : IRoleAI
{
    /// <summary>
    /// ��ǰ��ɫ������
    /// </summary>
    public RoleCtrl CurrRole
    {
        get;
        set;
    }

    /// <summary>
    /// �´�Ѳ��ʱ��
    /// </summary>
    private float m_NextPatrolTime = 0f;

    /// <summary>
    /// �´ι���ʱ��
    /// </summary>
    private float m_NextAttackTime = 0f;

    public RoleMonsterAI(RoleCtrl roleCtrl)
    {
        CurrRole = roleCtrl;
    }

    //ִ��AI
    public void DoAI()
    {
        if(CurrRole.CurrRoleFSMMgr.CurrRoleStateEnum == RoleState.Die) return;
       
        if(CurrRole.LockEnemy == null)
        {
            //����Ǵ���״̬
            if (CurrRole.CurrRoleFSMMgr.CurrRoleStateEnum == RoleState.Idle)
            {
                if (Time.time > m_NextPatrolTime)
                {
                    m_NextPatrolTime = Time.time + Random.Range(5, 10);

                    //����Ѳ��
                    CurrRole.MoveTo(new Vector3(
                        CurrRole.BornPoint.x + Random.Range(CurrRole.PatrolRange * -1, CurrRole.PatrolRange),
                        CurrRole.BornPoint.y,
                        CurrRole.BornPoint.z + Random.Range(CurrRole.PatrolRange * -1, CurrRole.PatrolRange)
                        ));
                }
            }

            //��������ڹֵ���Ұ��Χ��
            if (Vector3.Distance(CurrRole.transform.position, GlobalInit.Instance.CurrPlayer.transform.position) <= CurrRole.ViewRange)
            {
                CurrRole.LockEnemy = GlobalInit.Instance.CurrPlayer;
            }
        }
        else
        {
            if (CurrRole.LockEnemy.CurrRoleInfo.CurrHP <= 0)
            {
                CurrRole.LockEnemy = null;
                return;
            }

            //�������������
            //1.����Һ��������˵ľ��볬���ҵ���Ұ��Χ����ȡ������
            if (Vector3.Distance(CurrRole.transform.position, GlobalInit.Instance.CurrPlayer.transform.position) > CurrRole.ViewRange)
            {
                CurrRole.LockEnemy = null;
                return;
            }

            
            if (Vector3.Distance(CurrRole.transform.position, GlobalInit.Instance.CurrPlayer.transform.position) <= CurrRole.AttackRange)
            {
                //2.����ڹ�����Χ��ֱ�ӹ���
                if (Time.time > m_NextAttackTime && CurrRole.CurrRoleFSMMgr.CurrRoleStateEnum != RoleState.Attack)
                {
                    m_NextAttackTime = Time.time + Random.Range(3f, 5f);
                    CurrRole.ToAttack();
                }
            }
            else
            {
                //3.������ҵ���Ұ��Χ֮�ڣ�����׷��
                if (CurrRole.CurrRoleFSMMgr.CurrRoleStateEnum == RoleState.Idle)
                {
                    CurrRole.MoveTo(new Vector3(
                       CurrRole.LockEnemy.transform.position.x + Random.Range(CurrRole.AttackRange * -1, CurrRole.AttackRange),
                       CurrRole.BornPoint.y,
                       CurrRole.LockEnemy.transform.position.z + Random.Range(CurrRole.AttackRange * -1, CurrRole.AttackRange)
                       ));
                }
            }
        }
    }
}
