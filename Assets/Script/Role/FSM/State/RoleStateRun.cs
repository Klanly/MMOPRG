using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��״̬
/// </summary>
public class RoleStateRun : RoleStateAbstract
{
    /// <summary>
    /// ת���ٶ�
    /// </summary>
    private float m_RotationSpeed = 0.2f;

    /// <summary>
    /// ת���Ŀ�귽��
    /// </summary>
    private Quaternion m_TargetQuaternion;

    /// <summary>
    /// ���캯��
    /// </summary>
    /// <param name="roleFSMMgr">����״̬������</param>
    public RoleStateRun(RoleFSMMgr roleFSMMgr) : base(roleFSMMgr)
    {
    }

    /// <summary>
    /// ʵ�ֻ��� ����״̬
    /// </summary>
    public override void OnEnter()
    {
        base.OnEnter();

        m_RotationSpeed = 0;
        CurrRoleFSMMgr.CurrRoleCtrl.Animator.SetBool(ToAnimatorCondition.ToRun.ToString(), true);
    }

    /// <summary>
    /// ʵ�ֻ��� ִ��״̬
    /// </summary>
    public override void OnUpdate()
    {
        base.OnUpdate();

        CurrRoleAnimatorStateInfo = CurrRoleFSMMgr.CurrRoleCtrl.Animator.GetCurrentAnimatorStateInfo(0);
        if (CurrRoleAnimatorStateInfo.IsName(RoleAnimatorName.Run.ToString()))
        {
            CurrRoleFSMMgr.CurrRoleCtrl.Animator.SetInteger(ToAnimatorCondition.CurrState.ToString(), (int)RoleState.Run);
        }
        else
        {
            CurrRoleFSMMgr.CurrRoleCtrl.Animator.SetInteger(ToAnimatorCondition.CurrState.ToString(), 0);
        }

        if (Vector3.Distance(new Vector3(CurrRoleFSMMgr.CurrRoleCtrl.TargetPos.x, 0, CurrRoleFSMMgr.CurrRoleCtrl.TargetPos.z), new Vector3(CurrRoleFSMMgr.CurrRoleCtrl.transform.position.x, 0, CurrRoleFSMMgr.CurrRoleCtrl.transform.position.z)) > 0.1f)
        {
            Vector3 direction = CurrRoleFSMMgr.CurrRoleCtrl.TargetPos - CurrRoleFSMMgr.CurrRoleCtrl.transform.position;
            direction = direction.normalized; //��һ��
            direction = direction * Time.deltaTime * CurrRoleFSMMgr.CurrRoleCtrl.Speed;
            direction.y = 0;
            //transform.LookAt(new Vector3(m_TargetPos.x, transform.position.y, m_TargetPos.z));

            //�ý�ɫ����ת��
            if (m_RotationSpeed <= 1)
            {
                m_RotationSpeed += 10f * Time.deltaTime;
                m_TargetQuaternion = Quaternion.LookRotation(direction);
                CurrRoleFSMMgr.CurrRoleCtrl.transform.rotation = Quaternion.Lerp(CurrRoleFSMMgr.CurrRoleCtrl.transform.rotation, m_TargetQuaternion, m_RotationSpeed);

                if (Quaternion.Angle(CurrRoleFSMMgr.CurrRoleCtrl.transform.rotation, m_TargetQuaternion) < 1)
                {
                    m_RotationSpeed = 0;
                }
            }

            CurrRoleFSMMgr.CurrRoleCtrl.CharacterController.Move(direction);
        }
        else
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

        CurrRoleFSMMgr.CurrRoleCtrl.Animator.SetBool(ToAnimatorCondition.ToRun.ToString(), false);
    }
}
