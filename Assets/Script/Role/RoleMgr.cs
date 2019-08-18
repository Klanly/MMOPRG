using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleMgr : Singleton<RoleMgr>
{

    #region LoadRole ���ݽ�ɫԤ������ ���ؽ�ɫ
    /// <summary>
    /// ���ݽ�ɫԤ������ ���ؽ�ɫ
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public GameObject LoadRole(string name, RoleType type)
    {
        string path = string.Empty;

        switch (type)
        {
            case RoleType.MainPlayer:
                path = "Player";
                break;
            case RoleType.Monster:
                path = "Monster";
                break;
            default:
                break;
        }

        return ResourcesMgr.Instance.Load(ResourcesMgr.ResourceType.Role, string.Format("{0}/{1}", path, name), cache: true);
    }
    #endregion

    public override void Dispose()
    {
        base.Dispose();
    }

}
