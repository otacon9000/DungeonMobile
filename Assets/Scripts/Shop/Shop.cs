using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{

    public GameObject shopPanel;
    private int _itemSelected;
    private int _currentItemCost;
    private Player _player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _player = other.GetComponent<Player>();
            UIManager.Instance.UpdateGemsCount(_player.GetGems());
           
            shopPanel.SetActive(true);

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            shopPanel.SetActive(false);
        }
    }

    public void SelectedItem(int item)
    {
       //Debug.Log("item selected: " + item);

        switch (item)
        {
            case 0:
                UIManager.Instance.UpdateSelectorPosition(80);
                _itemSelected = 0;
                _currentItemCost = 200;
                break;
            case 1:
                UIManager.Instance.UpdateSelectorPosition(-31);
                _itemSelected = 1;
                _currentItemCost = 400;
                break;
            case 2:
                UIManager.Instance.UpdateSelectorPosition(-139);
                _itemSelected = 2;
                _currentItemCost = 100;
                break;

        }
    }

    public void BuyItem()
    {


        if (_player.GetGems() >= _currentItemCost)
        {

            if(_itemSelected == 2)
            {
                GameManager.Instance.HasKeyToCastle = true;
            }
            Debug.Log("you bought item " + _itemSelected);
            _player.AddGems(-_currentItemCost);
            UIManager.Instance.UpdateGemsCount(_player.GetGems());

            shopPanel.SetActive(false);
        }
        else
        {
            shopPanel.SetActive(false);
            Debug.Log("no money");
        }

    }
}

