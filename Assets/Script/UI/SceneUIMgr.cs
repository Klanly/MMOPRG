using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����UI������
/// </summary>
public class SceneUIMgr : Singleton<SceneUIMgr>
{
    /// <summary>
    /// ����UI����
    /// </summary>
    public enum SceneUIType
    {
        /// <summary>
        /// ��¼
        /// </summary>
        LogOn,
        /// <summary>
        /// ����
        /// </summary>
        Loading,
        /// <summary>
        /// ����
        /// </summary>
        MainCity
    }

    /// <summary>
    /// ��ǰ����UI
    /// </summary>
    public UISceneBase CurrentUIScene;

    #region LoadSceneUI ���س���UI
    /// <summary>
    /// ���س���UI
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public GameObject LoadSceneUI(SceneUIType type)
    {
        GameObject obj = null;
        switch (type)
        {
            case SceneUIType.LogOn:
                obj = ResourcesMgr.Instance.Load(ResourcesMgr.ResourceType.UIScene, "UI Root_LogOnScene");
                CurrentUIScene = obj.GetComponent<UISceneLogonCtrl>();
                break;
            case SceneUIType.Loading:
                break;
            case SceneUIType.MainCity:
                obj = ResourcesMgr.Instance.Load(ResourcesMgr.ResourceType.UIScene, "UI Root_City");
                CurrentUIScene = obj.GetComponent<UISceneCityCtrl>();
                break;
        }
        return obj;
    }
    #endregion

}
