using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitySceneCtrl : MonoBehaviour
{
    /// <summary>
    /// ���ǳ�����
    /// </summary>
    [SerializeField]
    private Transform m_PlayerBornPos;

    private void Awake()
    {
        SceneUIMgr.Instance.LoadSceneUI(SceneUIMgr.SceneUIType.MainCity);

        if (FingerEvent.Instance != null)
        {
            FingerEvent.Instance.OnFingerDrag += OnFingerDrag;
            FingerEvent.Instance.OnZoom += OnZoom;
            FingerEvent.Instance.OnPlayerClick += OnPlayerClick;
        }
    }

    private void Start()
    {
        //�������
        GameObject obj = RoleMgr.Instance.LoadRole("Role_MainPlayer", RoleType.MainPlayer);

        obj.transform.position = m_PlayerBornPos.position;

        //����ǰ��Ҹ�ֵ
        GlobalInit.Instance.CurrPlayer = obj.GetComponent<RoleCtrl>();
        GlobalInit.Instance.CurrPlayer.Init(RoleType.MainPlayer, new RoleInfoBase() { NickName = GlobalInit.Instance.CurrRoleNickName, CurrHP =10000, MaxHP = 10000 }, new RoleMainPlayerCityAI(GlobalInit.Instance.CurrPlayer));

        UIPlayerInfo.Instance.SetPlayerInfo();
    }

    #region OnZoom ���������
    /// <summary>
    /// ���������
    /// </summary>
    /// <param name="obj"></param>
    private void OnZoom(FingerEvent.ZoomType obj)
    {
        switch (obj)
        {
            case FingerEvent.ZoomType.In:
                CameraCtrl.Instance.SetCameraZoom(0);
                break;
            case FingerEvent.ZoomType.Out:
                CameraCtrl.Instance.SetCameraZoom(1);
                break;
        }
    }
    #endregion

    #region OnPlayerClickGround ��ҵ������
    /// <summary>
    /// ��ҵ��
    /// </summary>
    private void OnPlayerClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;

        RaycastHit[] hitArr = Physics.RaycastAll(ray, Mathf.Infinity, 1 << LayerMask.NameToLayer("Role"));
        if (hitArr.Length > 0)
        {
            RoleCtrl hitRole = hitArr[0].collider.gameObject.GetComponent<RoleCtrl>();
            if(hitRole.CurRoleType== RoleType.Monster)
            {
                GlobalInit.Instance.CurrPlayer.LockEnemy = hitRole;
            }
        }
        else
        {
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.collider.gameObject.name.Equals("Ground", System.StringComparison.CurrentCultureIgnoreCase))
                {
                    if (GlobalInit.Instance.CurrPlayer != null)
                    {
                        GlobalInit.Instance.CurrPlayer.LockEnemy = null;
                        GlobalInit.Instance.CurrPlayer.MoveTo(hitInfo.point);
                    }
                }
            }
        }
    }
    #endregion

    #region OnFingerDrag ��ָ����
    /// <summary>
    /// ��ָ����
    /// </summary>
    /// <param name="obj"></param>
    private void OnFingerDrag(FingerEvent.FingerDir obj)
    {
        switch (obj)
        {
            case FingerEvent.FingerDir.Left:
                CameraCtrl.Instance.SetCameraRotate(0);
                break;
            case FingerEvent.FingerDir.Right:
                CameraCtrl.Instance.SetCameraRotate(1);
                break;
            case FingerEvent.FingerDir.Up:
                CameraCtrl.Instance.SetCameraUpAndDown(1);
                break;
            case FingerEvent.FingerDir.Down:
                CameraCtrl.Instance.SetCameraUpAndDown(0);
                break;
        }
    }
    #endregion

    #region ����
    /// <summary>
    /// ����
    /// </summary>
    void OnDestroy()
    {
        if (FingerEvent.Instance != null)
        {
            FingerEvent.Instance.OnFingerDrag -= OnFingerDrag;
            FingerEvent.Instance.OnZoom -= OnZoom;
            FingerEvent.Instance.OnPlayerClick -= OnPlayerClick;
        }
    }
    #endregion
}
