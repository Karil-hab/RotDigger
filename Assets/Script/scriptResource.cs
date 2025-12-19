using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class scriptResource : MonoBehaviour
{
    public float resourceHP = 20f;
    private int _countOpenSegment;

    private void Update()
    {
        if (_countOpenSegment <= 0) return;
        
        for (int i = 0; i < _countOpenSegment+1; i++)
        {
            var segment = transform.GetChild(i);
            for (int j = 0; j < segment.childCount; j++)
            {
                segment.GetChild(j).DOShakePosition(1f, 0.1f, 1, 0.1f, false, false);
            }
        }
    }

    public void ShakingResource(int countOpenSegment)
    {
        _countOpenSegment = countOpenSegment;
    }
}
