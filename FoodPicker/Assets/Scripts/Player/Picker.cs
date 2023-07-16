using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class Picker : MonoBehaviour
{
    [SerializeField] private JobGenerator jobGenerator;
    [SerializeField] private Transform basket;
    [SerializeField] private MultiAimConstraint constraint;
    [SerializeField] private Transform handController;
    [SerializeField] private float timeThrow;
    [SerializeField] private float timeCollect;
    private int collectedFood;

    public event Action OnWinDance;
    public event Action OnTakeFood;
    public event Action OnThrow;
    public event Action OnCollectedFood;

    private void Start()
    {
        collectedFood = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Food") && !collision.gameObject.GetComponent<Food>().IsTaked)
        {
            OnTakeFood?.Invoke();

            handController.SetParent(null);
            handController.position = Vector3.zero;

            constraint.weight = 0f;

            collision.gameObject.GetComponent<Food>().IsTaked = true;
            collision.gameObject.transform.SetParent(transform);
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            if (collision.gameObject.CompareTag(jobGenerator.TagFood))
            {
                collectedFood++;

                CheckPlaceBasket(collectedFood);

                StartCoroutine(PutFood(collision.gameObject));

                OnCollectedFood?.Invoke();
            }
            else
            {
                OnThrow?.Invoke();

                StartCoroutine(ThrowFood(collision.gameObject));
                StartCoroutine(EnableConstraint(timeThrow));
            }
        }
    }
    IEnumerator PutFood(GameObject food)
    {
        yield return new WaitForSeconds(timeCollect);

        food.transform.SetParent(basket);
        food.GetComponent<Rigidbody>().isKinematic = false;
        food.GetComponent<Rigidbody>().freezeRotation = false;
    }
    IEnumerator ThrowFood(GameObject food)
    {
        yield return new WaitForSeconds(timeThrow);

        food.GetComponent<Rigidbody>().isKinematic = false;
    }
    IEnumerator EnableConstraint(float time)
    {
        yield return new WaitForSeconds(time + 1f);
        constraint.weight = 1f;
    }
    private void CheckPlaceBasket(int collectedFood)
    {
        if (collectedFood >= jobGenerator.AmountFood)
        {
            constraint.weight = 0f;
            OnWinDance?.Invoke();
            Debug.Log("Win");
        }
        else { StartCoroutine(EnableConstraint(timeCollect)); }
    }
}
