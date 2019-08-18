using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Loading场景UI控制器
/// </summary>
public class UISceneLoadingCtrl : UISceneBase
{
    /// <summary>
    /// 进度条
    /// </summary>
    [SerializeField]
    private UIProgressBar m_Progress;

    /// <summary>
    /// 进度条上的文本
    /// </summary>
    [SerializeField]
    private UILabel m_LblProgerss;

    /// <summary>
    /// 发光图
    /// </summary>
    [SerializeField]
    private UISprite m_SprProgressLight;

    /// <summary>
    /// 设置进度条值
    /// </summary>
    /// <param name="value"></param>
    public void SetProgressValue(float value)
    {
        m_Progress.value = value;
        m_LblProgerss.text = string.Format("{0}%", (int)(value * 100));

        m_SprProgressLight.transform.localPosition = new Vector3(730 * value, 0, 0);
    }
}
