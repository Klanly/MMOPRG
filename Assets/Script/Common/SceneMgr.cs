using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 场景管理器
/// </summary>
public class SceneMgr : Singleton<SceneMgr>
{
    /// <summary>
    /// 当前场景类型
    /// </summary>
    public SceneType CurrentSceneType
    {
        get;
        private set;
    }

    public void LoadToLonOn()
    {
        CurrentSceneType = SceneType.LogOn;
        
        Application.LoadLevel("Scene_Loading");
    }

    public void LoadToCity()
    {
        CurrentSceneType = SceneType.City;
        Application.LoadLevel("Scene_Loading");
    }
	
}
