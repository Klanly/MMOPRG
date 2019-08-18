using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleHeadBarCtrl : MonoBehaviour
{
    /// <summary>
    /// �ǳ�
    /// </summary>
    [SerializeField]
    private UILabel lblNickName;

    /// <summary>
    /// ƮѪ��ʾ
    /// </summary>
    [SerializeField]
    private bl_HUDText hudText;

    /// <summary>
    /// Ѫ��
    /// </summary>
    [SerializeField]
    private UISlider pbHP;


    /// <summary>
    /// �����Ŀ���
    /// </summary>
    private Transform m_Target;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        if (Camera.main == null || UICamera.mainCamera == null || m_Target == null) return;

        //���������ת��Ϊ�ӿ�����
        Vector3 pos = Camera.main.WorldToViewportPoint(m_Target.position);

        //ת����UI���������������
        Vector3 uiPos = UICamera.mainCamera.ViewportToWorldPoint(pos);

        gameObject.transform.position = uiPos;
	}

    /// <summary>
    /// 
    /// </summary>
    /// <param name="target"></param>
    /// <param name="nickName"></param>
    /// <param name="isShowHPBar">�Ƿ���ʾѪ��</param>
    public void Init(Transform target, string nickName, bool isShowHPBar = false)
    {
        m_Target = target;
        lblNickName.text = nickName;

        NGUITools.SetActive(pbHP.gameObject, isShowHPBar);
    }

    /// <summary>
    /// �ϵ��˺�����
    /// </summary>
    /// <param name="hurtValue"></param>
    public void Hurt(int hurtValue, float pbHPValue = 0)
    {
        //hudText.NewText("- 10", GlobalInit.Instance.CurrPlayer.transform, Color.red, 8, 20f, -1f, 2.2f, bl_Guidance.RightDown);
        pbHP.value = pbHPValue;
    }
}
