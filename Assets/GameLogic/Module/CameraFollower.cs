using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace GameLogic
{
    public class CameraFollower : MonoBehaviour
    {
        private Transform target;
        private Vector3 lastPos = Vector3.zero;
        private Vector3 offset = new Vector3(0f, -3f, -4f);

        public void BindTarget(Transform target)
        {
            this.target = target;
            lastPos = target.position;
        }

        public void UpdateOffset(Vector3 offset)
        {
            this.offset = offset;
        }

        private void LateUpdate()
        {
            Vector3 perPos = this.transform.position;
            Vector3 followPos = Vector3.Normalize(perPos - lastPos) * offset.magnitude;
            transform.position = Vector3.Lerp(perPos, followPos, 1 * Time.deltaTime);
            lastPos = this.target.position;
        }
    }
}