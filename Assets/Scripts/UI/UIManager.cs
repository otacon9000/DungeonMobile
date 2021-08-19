using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("UIManager is null");
            }
            return _instance;
        }
    }

    public Text playerGemsCountText;
    public Image selectionImg;


    private void Awake()
    {
        _instance = this;
    }

    public void UpdateGemsCount(int gemsCount)
    {
        playerGemsCountText.text = gemsCount.ToString() + "G";
    }


    public void UpdateSelectorPosition(int yPos)
    {
        selectionImg.rectTransform.anchoredPosition = new Vector2(selectionImg.rectTransform.anchoredPosition.x, yPos);
    }
}
