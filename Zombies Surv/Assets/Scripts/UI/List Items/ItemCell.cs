using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemCell : MonoBehaviour
{
    [SerializeField] private Image itemImage; 
    [SerializeField] private Button button; 
    [SerializeField] private TextMeshProUGUI itemAmountLabel;

    private void Start()
    {
        button.onClick.AddListener(OnClick);
    }

    public void SetItem(ItemEntity item)
    {
        itemImage.sprite = item.ItemInfo.ItemSprite;
        itemAmountLabel.text = item.Amount.ToString();
    }

    private void OnClick()
    {

    }
}
