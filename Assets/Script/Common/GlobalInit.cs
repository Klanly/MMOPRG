using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalInit : MonoBehaviour
{
    #region ����
    /// <summary>
    /// �ǳ�KEY
    /// </summary>
    public const string MMO_NICKNAME = "MMO_NICKNAME";
    /// <summary>
    /// ����KEY
    /// </summary>
    public const string MMO_PWD = "MMO_PWD";
    #endregion

    public static GlobalInit Instance;

    /// <summary>
    /// ���ע��ʱ������
    /// </summary>
    [HideInInspector]
    public string CurrRoleNickName;

    /// <summary>
    /// ��ǰ���
    /// </summary>
    [HideInInspector]
    public RoleCtrl CurrPlayer;

    /// <summary>
    /// UI��������
    /// </summary>
    public AnimationCurve UIAnimationCurve = new AnimationCurve(new Keyframe(0f, 0f, 0f, 1f), new Keyframe(1f, 1f, 1f, 0f));

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start () {
		
	}
	
}
