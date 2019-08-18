using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����������
/// </summary>
public class SceneMgr : Singleton<SceneMgr>
{
    /// <summary>
    /// ��ǰ��������
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
