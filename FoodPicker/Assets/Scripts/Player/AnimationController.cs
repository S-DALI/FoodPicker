using System;
using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Picker picker;
    [SerializeField] private UIController controllerUI;
    [SerializeField] private GameObject text;
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform targetCamera;
    [SerializeField] private float smoothSpeed = 1.0f;

    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();

        playerController.OnReachingFood += OnReachingFood;

        picker.OnWinDance += Win;
        picker.OnTakeFood += OnTakeFood;
        picker.OnCollectedFood += OnCollectedFood;
        picker.OnThrow += OnThrow;
    }

    private void OnReachingFood()
    {
        animator.SetTrigger("Reaching");
    }

    private void OnTakeFood()
    {
        animator.SetTrigger("Take");
    }
    private void OnCollectedFood()
    {
        animator.SetTrigger("Collected");
        Instantiate(text, picker.transform.position, Quaternion.identity);
    }
    private void OnThrow()
    {
        animator.SetTrigger("Throw");
    }
    private void Win()
    {
        animator.SetTrigger("Win");
        controllerUI.PlayerWin();
        StartCoroutine(CameraMove());
    }
    IEnumerator CameraMove()
    {
        while (true)
        {
            Vector3 desiredPosition = Vector3.Lerp(_camera.position, targetCamera.position, smoothSpeed * Time.deltaTime);

            _camera.position = desiredPosition;

            yield return null;
        }
    }
}
