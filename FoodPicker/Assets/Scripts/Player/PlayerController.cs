using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform handController;
    public event Action OnReachingFood;
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            if (Physics.Raycast(ray, out hit, float.MaxValue, LayerMask.GetMask("Food")))
            {
                OnReachingFood?.Invoke();
                handController.transform.SetParent(hit.collider.transform);
            }
        }
    }
}
