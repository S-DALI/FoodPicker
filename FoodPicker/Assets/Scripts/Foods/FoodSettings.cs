using UnityEngine;

[System.Serializable]
public class FoodSettings
{
    [SerializeField] private GameObject[] food;
    public GameObject[] Food { get => food; }
}
