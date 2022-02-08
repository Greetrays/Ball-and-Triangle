using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]

public abstract class Screen : MonoBehaviour
{
    protected CanvasGroup Group;

    private Coroutine _changeAlpha;

    private void Awake()
    {
        Group = GetComponent<CanvasGroup>();
    }

    protected virtual void Open()
    {
        Group.interactable = true;
        Group.blocksRaycasts = true;

        if (_changeAlpha != null)
        {
            StopCoroutine(_changeAlpha);
        }

        _changeAlpha = StartCoroutine(ChangeAlpha(1));
    }

    protected virtual void Close()
    {
        Group.interactable = false;
        Group.blocksRaycasts = false;

        if (_changeAlpha != null)
        {
            StopCoroutine(_changeAlpha);
        }

        _changeAlpha = StartCoroutine(ChangeAlpha(0));
    }

    protected IEnumerator ChangeAlpha(float targetValue)
    {
        float timeChanged = 1f;
        float elepsedTime = 0;

        while (elepsedTime < timeChanged)
        {
            Group.alpha = Mathf.MoveTowards(Group.alpha, targetValue, elepsedTime/timeChanged);
            elepsedTime += Time.deltaTime;
            
            yield return null;
        }

        _changeAlpha = null;
    }
}
