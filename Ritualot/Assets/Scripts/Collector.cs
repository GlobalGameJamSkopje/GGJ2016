using System.Linq;
using Assets.Scripts.Classes;
using Assets.Scripts.Enums;
using UnityEngine;

namespace Assets.Scripts
{
    public class Collector : MonoBehaviour
    {
        public GameObject[] WallsLeft;
        public GameObject[] WallsRight;
        public GameObject[] Floors;

        private LastParalaxObjectData _lastLeftParalaxObject;
        private LastParalaxObjectData _lastRightParalaxObject;
        private LastParalaxObjectData _lastFloorParalaxObject;

        void Awake()
        {
            var lastLeft = WallsLeft.Last();
            var lastRight = WallsRight.Last();
            var lastFloor = Floors.Last();

            _lastLeftParalaxObject = new LastParalaxObjectData
            {
                Position = lastLeft.transform.position.z,
                Size = lastLeft.GetComponent<Collider>().bounds.size.z / 2f
            };

            _lastRightParalaxObject = new LastParalaxObjectData
            {
                Position = lastRight.transform.position.z,
                Size = lastRight.GetComponent<Collider>().bounds.size.z / 2f
            };

            _lastFloorParalaxObject = new LastParalaxObjectData
            {
                Position = lastFloor.transform.position.z,
                Size = lastFloor.GetComponent<Collider>().bounds.size.z / 2f
            };
        }

        void OnTriggerEnter(Collider target)
        {
            if (target.tag == Tags.WallLeft.ToString())
                MoveTargetAfterParalaxObject(target, _lastLeftParalaxObject);

            else if (target.tag == Tags.WallRight.ToString())
                MoveTargetAfterParalaxObject(target, _lastRightParalaxObject);

            else if (target.tag == Tags.Floor.ToString())
                MoveTargetAfterParalaxObject(target, _lastFloorParalaxObject);

        }

        private void MoveTargetAfterParalaxObject(Collider target, LastParalaxObjectData paralaxObject)
        {
            Vector3 targetPosition = target.transform.position;
            float targetSize = target.bounds.size.z / 2f;

            targetPosition.z = paralaxObject.Position + paralaxObject.Size + targetSize;
            target.transform.position = targetPosition;

            paralaxObject.Position = targetPosition.z;
            paralaxObject.Size = targetSize;
        }
    }
}

