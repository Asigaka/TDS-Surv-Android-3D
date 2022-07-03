using UnityEngine;

[System.Serializable]
public class ItemWithAmount
{
    [SerializeField] private ItemInfo itemInfo;
    [SerializeField] private int minAmount;
    [SerializeField] private int maxAmount;

    public ItemInfo ItemInfo { get => itemInfo; }
    public int Amount
    {
        get => Random.Range(minAmount, maxAmount);
    }
}
