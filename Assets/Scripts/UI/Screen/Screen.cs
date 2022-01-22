using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]

public abstract class Screen : MonoBehaviour
{
    protected CanvasGroup Group;

    private void Awake()
    {
        Group = GetComponent<CanvasGroup>();
    }

    protected virtual void Open()
    {
        Group.alpha = 1;
        Group.interactable = true;
        Group.blocksRaycasts = true;
    }

    protected virtual void Close()
    {
        Group.alpha = 0;
        Group.interactable = false;
        Group.blocksRaycasts = false;
    }
}
