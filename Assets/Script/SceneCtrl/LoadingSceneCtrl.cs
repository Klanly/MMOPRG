using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingSceneCtrl : MonoBehaviour {

    /// <summary>
    /// UI场景控制器
    /// </summary>
    [SerializeField]
    private UISceneLoadingCtrl m_UILoadingCtrl;

    private AsyncOperation m_Async = null;

    /// <summary>
    /// 当前进度
    /// </summary>
    private int m_CurrProgress;

	void Start ()
    {
        LayerUIMgr.Instance.Reset();
        StartCoroutine(LoadingScene());
    }

    private IEnumerator LoadingScene()
    {
        string strSceneName = string.Empty;
        switch (SceneMgr.Instance.CurrentSceneType)
        {
            case SceneType.LogOn:
                strSceneName = "Scene_LogOn";
                break;
            case SceneType.City:
                strSceneName = "GameScene_CunZhuang";
                break;
            default:
                break;
        }

        m_Async = Application.LoadLevelAsync(strSceneName);
        m_Async.allowSceneActivation = false;
        yield return m_Async;
    }
	
	void Update ()
    {
        int toProgress = 0;

        if(m_Async.progress < 0.9f)
        {
            toProgress = Mathf.Clamp((int)m_Async.progress * 100, 1, 100);
        }
        else
        {
            toProgress = 100;
        }

        if(m_CurrProgress < toProgress)
        {
            m_CurrProgress++;
        }
        else
        {
            m_Async.allowSceneActivation = true;
        }

        m_UILoadingCtrl.SetProgressValue(m_CurrProgress*0.01f);
    }
}
