using UnityEngine;


[CreateAssetMenu(fileName = "Foods", menuName = "ScriptableObject/FoodData")]
public class FoodsData : ScriptableObject
{
    [SerializeField] private FoodSettings foodsSettings;
    public FoodSettings FoodsSettings { get => foodsSettings; }
}
