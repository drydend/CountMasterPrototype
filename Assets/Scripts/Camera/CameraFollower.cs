using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class CameraFollower : MonoBehaviour
    {
        [SerializeField]
        private Camera _camera;
        private Transform _position;

        public void SetFollowingPosition(Transform position)
        {
            _position = position;
        }

        private void LateUpdate()
        {
            if(_position == null)
            {
                return;
            }

            transform.position = _position.position;
        }
    }
}
