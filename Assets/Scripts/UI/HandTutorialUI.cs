using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTutorialUI : MonoBehaviour
{
    private void Awake()
    {
        RuntimeCircleClipper.ActionTouch += DisableUI;
    }

    private void DisableUI()
    {
        this.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        RuntimeCircleClipper.ActionTouch -= DisableUI;
    }
}
