using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region SceneType ��������
/// <summary>
/// ��������
/// </summary>
public enum SceneType
{
    LogOn,
    City
}
#endregion

#region WindowUIType ��������
/// <summary>
/// ��������
/// </summary>
public enum WindowUIType
{
    /// <summary>
    /// δ����
    /// </summary>
    None,
    /// <summary>
    /// ��¼����
    /// </summary>
    LogOn,
    /// <summary>
    /// ע�ᴰ��
    /// </summary>
    Reg,
    /// <summary>
    /// ��ɫ��Ϣ����
    /// </summary>
    RoleInfo
}
#endregion

#region WindowUiContainerType UI��������
/// <summary>
/// UI��������
/// </summary>
public enum WindowUiContainerType
{
    /// <summary>
    /// ����
    /// </summary>
    TopLeft,
    /// <summary>
    /// ����
    /// </summary>
    TopRight,
    /// <summary>
    /// ����
    /// </summary>
    BottomLeft,
    /// <summary>
    /// ����
    /// </summary>
    BottomRight,
    /// <summary>
    /// ����
    /// </summary>
    Center
}
#endregion

#region WindowShowStyle ���ڴ򿪷�ʽ
/// <summary>
/// ���ڴ򿪷�ʽ
/// </summary>
public enum WindowShowStyle
{
    /// <summary>
    /// ������
    /// </summary>
    Normal,
    /// <summary>
    /// ���м�Ŵ�
    /// </summary>
    CenterToBig,
    /// <summary>
    /// ��������
    /// </summary>
    FromTop,
    /// <summary>
    /// ��������
    /// </summary>
    FromDown,
    /// <summary>
    /// ��������
    /// </summary>
    FromLeft,
    /// <summary>
    /// ��������
    /// </summary>
    FromRigth
}
#endregion

#region RoleType ��ɫ����
/// <summary>
/// ��ɫ����
/// </summary>
public enum RoleType
{
    /// <summary>
    /// δ����
    /// </summary>
    None = 0,
    /// <summary>
    /// ��ǰ���
    /// </summary>
    MainPlayer = 1,
    /// <summary>
    /// ��
    /// </summary>
    Monster = 2
}
#endregion

#region RoleState ��ɫ״̬
/// <summary>
/// ��ɫ״̬
/// </summary>
public enum RoleState
{
    /// <summary>
    /// δ����
    /// </summary>
    None = 0,
    /// <summary>
    /// ����
    /// </summary>
    Idle = 1,
    /// <summary>
    /// ����
    /// </summary>
    Run = 2,
    /// <summary>
    /// ����
    /// </summary>
    Attack = 3,
    /// <summary>
    /// ����
    /// </summary>
    Hurt = 4,
    /// <summary>
    /// ����
    /// </summary>
    Die = 5
}
#endregion

#region RoleAnimatorName ��ɫ����״̬����
/// <summary>
/// ��ɫ����״̬����
/// </summary>
public enum RoleAnimatorName
{
    Idle_Normal,
    Idle_Fight,
    Run,
    Hurt,
    Die,
    PhyAttack1,
    PhyAttack2,
    PhyAttack3
}
#endregion

#region 
/// <summary>
/// ״̬�л�����
/// </summary>
public enum ToAnimatorCondition
{
    ToIdleNormal,
    ToIdleFight,
    ToRun,
    ToPhyAttack,
    ToHurt,
    ToDie,
    CurrState
}
#endregion