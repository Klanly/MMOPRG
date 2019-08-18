using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����UI������
/// </summary>
public class WindowUIMgr : Singleton<WindowUIMgr>
{
    private Dictionary<WindowUIType, UIWindowBase> m_DicWindow = new Dictionary<WindowUIType, UIWindowBase>();

    /// <summary>
    /// �Ѿ��򿪵Ĵ�������
    /// </summary>
    public int OpenWindowCount
    {
        get
        {
            return m_DicWindow.Count;
        }
    }

    #region OpenWindow �򿪴���
    /// <summary>
    /// �򿪴���
    /// </summary>
    /// <param name="type">��������</param>
    /// <returns></returns>
    public GameObject OpenWindow(WindowUIType type)
    {
        if (type == WindowUIType.None) return null;
        GameObject obj = null;

        //������ڲ�����
        if (!m_DicWindow.ContainsKey(type))
        {
            //ö�ٵ�����Ҫ��Ԥ������ƶ�Ӧ
            obj = ResourcesMgr.Instance.Load(ResourcesMgr.ResourceType.UIWindow, string.Format("pan{0}", type.ToString()), cache: true);
            if (obj == null) return null;
            UIWindowBase windowBase = obj.GetComponent<UIWindowBase>();
            if (windowBase == null) return null;

            m_DicWindow.Add(type, windowBase);
            windowBase.CurrentUIType = type;

            Transform transParent = null;

            switch (windowBase.containerType)
            {
                case WindowUiContainerType.Center:
                    transParent = SceneUIMgr.Instance.CurrentUIScene.Container_Center;
                    break;
                default:
                    break;
            }

            obj.transform.parent = transParent;
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localScale = Vector3.one;
            NGUITools.SetActive(obj, false);

            StartShowWindow(windowBase, true);
        }
        else
        {
            obj = m_DicWindow[type].gameObject;
        }
        //�㼶����
        LayerUIMgr.Instance.SetLayer(obj);
        return obj;
    }
    #endregion

    #region CloseWindow �رմ���
    /// <summary>
    /// �رմ���
    /// </summary>
    /// <param name="type"></param>
    public void CloseWindow(WindowUIType type)
    {
        if (m_DicWindow.ContainsKey(type))
        {
            StartShowWindow(m_DicWindow[type], false);
        }
    }
    #endregion

    #region StartShowWindow ��ʼ�򿪴���
    /// <summary>
    /// ��ʼ�򿪴���
    /// </summary>
    /// <param name="windowBase">����Ԥ��</param>
    /// <param name="isOpen">�Ƿ�򿪴���</param>
    private void StartShowWindow(UIWindowBase windowBase, bool isOpen)
    {
        switch (windowBase.showStyle)
        {
            case WindowShowStyle.Normal:
                ShowNormal(windowBase, isOpen);
                break;
            case WindowShowStyle.CenterToBig:
                ShowCenterToBig(windowBase, isOpen);
                break;
            case WindowShowStyle.FromTop:
                ShowFromDir(windowBase, 0, isOpen);
                break;
            case WindowShowStyle.FromDown:
                ShowFromDir(windowBase, 1, isOpen);
                break;
            case WindowShowStyle.FromLeft:
                ShowFromDir(windowBase, 2, isOpen);
                break;
            case WindowShowStyle.FromRigth:
                ShowFromDir(windowBase, 3, isOpen);
                break;
            default:
                break;
        }
    }
    #endregion

    #region ���ִ�Ч��
    private void ShowNormal(UIWindowBase windowBase, bool isOpen)
    {
        if (isOpen)
        {
            NGUITools.SetActive(windowBase.gameObject, true);
        }
        else
        {
            DestroyWindow(windowBase);
        }
    }

    private void ShowCenterToBig(UIWindowBase windowBase, bool isOpen)
    {
        TweenScale ts = windowBase.gameObject.GetOrCreatComponent<TweenScale>();
        ts.animationCurve = GlobalInit.Instance.UIAnimationCurve;
        ts.from = Vector3.zero;
        ts.to = Vector3.one;
        ts.duration = windowBase.duration;//��������Ҫʱ��
        ts.SetOnFinished(() =>//�����¼�
        {
            if (!isOpen)
                DestroyWindow(windowBase);
        });
        NGUITools.SetActive(windowBase.gameObject, true);
        if (!isOpen)
        {
            ts.Play(isOpen);//���򲥷�
        }
    }

    /// <summary>
    /// �Ӳ�ͬ�������
    /// </summary>
    /// <param name="windowBase"></param>
    /// <param name="dirType">0=���� 1=���� 2=���� 3=����</param>
    /// <param name="isOpen"></param>
    private void ShowFromDir(UIWindowBase windowBase, int dirType, bool isOpen)
    {
        TweenPosition tp = windowBase.gameObject.GetOrCreatComponent<TweenPosition>();
        tp.animationCurve = GlobalInit.Instance.UIAnimationCurve;

        Vector3 from = Vector3.zero;
        switch (dirType)
        {
            case 0:
                from = new Vector3(0, 1000, 0);
                break;
            case 1:
                from = new Vector3(0, -1000, 0);
                break;
            case 2:
                from = new Vector3(-1400, 0, 0);
                break;
            case 3:
                from = new Vector3(1400, 0, 0);
                break;
        }
        tp.from = from;

        tp.to = Vector3.one;
        tp.duration = windowBase.duration;//��������Ҫʱ��
        tp.SetOnFinished(() =>//�����¼�
        {
            if (!isOpen)
                DestroyWindow(windowBase);
        });
        NGUITools.SetActive(windowBase.gameObject, true);
        if (!isOpen)
        {
            tp.Play(isOpen);//���򲥷�
        }
    }

    #endregion

    #region DestroyWindow ���ٴ���
    /// <summary>
    /// ���ٴ���
    /// </summary>
    /// <param name="obj"></param>
    private void DestroyWindow(UIWindowBase windowBase)
    {
        m_DicWindow.Remove(windowBase.CurrentUIType);
        Object.Destroy(windowBase.gameObject);
    }
    #endregion
}
