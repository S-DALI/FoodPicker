using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JobGenerator : MonoBehaviour
{
    [SerializeField] private FoodsData foodsData;
    [SerializeField] private int minAmountFood;
    [SerializeField] private int maxAmountFood;
    [SerializeField] TMP_Text workText;
    private int amountFood;
    public int AmountFood { get => amountFood; }
    private string tagFood;
    public string TagFood { get => tagFood; }

    public void Start()
    {
        tagFood = foodsData.FoodsSettings.Food[Random.Range(0, foodsData.FoodsSettings.Food.Length )].tag;
        amountFood = Random.Range(minAmountFood, maxAmountFood);
        workText.text ="Collect " + amountFood.ToString() + " " + tagFood;
    }
}
