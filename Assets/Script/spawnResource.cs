using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnResource : MonoBehaviour
{
    private float _positionY;
    private float _rotationY;


    private crasher _crasher;
    private collector _collector;
    private scriptResource _resourceSettings;
    private float _resourceHP = 20f;
    
    public Transform resourceSegmentPrefab;
    private int _countSegment = 1;
    
    public List<Transform> segments;

    private float _distanceWall = -3.5f; 
    private void Awake()
    {
        _crasher = FindObjectOfType<crasher>();
        _collector = FindObjectOfType<collector>();
        resourceSegmentPrefab.GetChild(0).GetComponent<BoxCollider>().center = new Vector3(_distanceWall,1f,0f);
        for (int i = 2; i < resourceSegmentPrefab.childCount; i++)
        {
            resourceSegmentPrefab.GetChild(i).gameObject.SetActive(false);
        }
    }
                                            
    private void Start()
    {
        for (var i = 0; i < 180; i++)
        {
            NewResourcePiece();
        }
    }

    public void NewResourcePiece()
    {
        var resourceSegment = Instantiate(resourceSegmentPrefab,transform);
        var resourceSettings = resourceSegment.GetComponent<scriptResource>();

        resourceSettings.resourceHP = _resourceHP;
        resourceSegment.transform.position = new Vector3(40,_positionY,40);
        resourceSegment.transform.rotation = Quaternion.Euler(new Vector3(0f, _rotationY, 0));
        
        segments.Add(resourceSegment);

        _resourceHP += 2f;
        _positionY += -0.05f;
        _rotationY += -20f;
    }
    
    public void ButtonAddSegment()
    {
        _countSegment++;
        _distanceWall--;
        
        resourceSegmentPrefab.GetChild(_countSegment).gameObject.SetActive(true);
        resourceSegmentPrefab.GetChild(0).GetComponent<BoxCollider>().center = new Vector3(_distanceWall,1f,0f);

        foreach (Transform segment in segments)
        {
            segment.GetChild(_countSegment).gameObject.SetActive(true);
            segment.GetChild(0).GetComponent<BoxCollider>().center = new Vector3(_distanceWall,1f,0f);
        }
    }
}
