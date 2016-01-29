using UnityEngine;
using System.Linq;
using Assets.Scripts.Classes;
using Assets.Scripts.Enums;
using System;

public class Collector : MonoBehaviour
{

    public GameObject[] WallsLeft;
    public GameObject[] WallsRight;
    public GameObject[] Floors;

    private Foo lastLeft;
    private Foo lastRight;
    private Foo lastFloor;

    void Awake()
    {
        var lastLeftWall = WallsLeft.Last();
        var lastRightWall = WallsRight.Last();
        var lastFloorBotom = Floors.Last();

        lastLeft = new Foo
        {
            Position = lastLeftWall.transform.position.z,
            Size = lastLeftWall.GetComponent<Collider>().bounds.size.z / 2f
        };

        lastRight = new Foo
        {
            Position = lastRightWall.transform.position.z,
            Size = lastRightWall.GetComponent<Collider>().bounds.size.z / 2f
        };

        lastFloor = new Foo
        {
            Position = lastFloorBotom.transform.position.z,
            Size = lastFloorBotom.GetComponent<Collider>().bounds.size.z / 2f
        };
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider target)
    {
        Debug.Log(target.tag);
        if (target.tag == Tags.WallLeft.ToString())
            DoSomethingWithFoo(target, lastLeft);
        else if (target.tag == Tags.WallRight.ToString())
            DoSomethingWithFoo(target, lastRight);
        else if (target.tag == Tags.Floor.ToString())
            DoSomethingWithFoo(target, lastFloor);

    }

    private void DoSomethingWithFoo(Collider target, Foo lastElement)
    {
        Vector3 targetPosition = target.transform.position;
        float targetSize = target.bounds.size.z / 2f;

        targetPosition.z = lastElement.Position + lastElement.Size + targetSize;
        target.transform.position = targetPosition;

        lastElement.Position = targetPosition.z;
        lastElement.Size = targetSize;
    }
}

