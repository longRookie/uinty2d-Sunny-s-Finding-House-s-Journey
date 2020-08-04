using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    /// <summary>
    /// UI管理相关
    /// </summary>
    // Start is called before the first frame update

    public Image healthBar;
    //单例模式
    public static UIManager instance { get; private set; }

    void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// 更新血条
    /// </summary>
    /// <param name="curAmount"></param>
    /// <param name="maxAmount"></param>
    public void UpdateHealthBar(int curAmount, int maxAmount)
    {
        Debug.Log(healthBar.fillAmount);
        healthBar.fillAmount = (float)curAmount / (float)maxAmount;

    }
}
