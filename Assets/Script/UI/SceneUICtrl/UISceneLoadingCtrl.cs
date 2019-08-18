using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Loading����UI������
/// </summary>
public class UISceneLoadingCtrl : UISceneBase
{
    /// <summary>
    /// ������
    /// </summary>
    [SerializeField]
    private UIProgressBar m_Progress;

    /// <summary>
    /// �������ϵ��ı�
    /// </summary>
    [SerializeField]
    private UILabel m_LblProgerss;

    /// <summary>
    /// ����ͼ
    /// </summary>
    [SerializeField]
    private UISprite m_SprProgressLight;

    /// <summary>
    /// ���ý�����ֵ
    /// </summary>
    /// <param name="value"></param>
    public void SetProgressValue(float value)
    {
        m_Progress.value = value;
        m_LblProgerss.text = string.Format("{0}%", (int)(value * 100));

        m_SprProgressLight.transform.localPosition = new Vector3(730 * value, 0, 0);
    }
}
