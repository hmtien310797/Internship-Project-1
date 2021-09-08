using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class ZoomCamera : MonoBehaviour
    {
        float zoomInView = 90f;
        float zoomOutView = 74f;
        float time = 4f;
        float distanceCameraView;

        // Start is called before the first frame update
        void Start()
        {
            distanceCameraView = zoomInView - zoomOutView;
        }

        public IEnumerator ZoomInCamera()
        {
            while (Camera.main.fieldOfView < zoomInView)
            {
                Camera.main.fieldOfView += distanceCameraView / (time / Time.deltaTime);
                yield return null;
            }
        }

        public IEnumerator ZoomOutCamera()
        {
            while (Camera.main.fieldOfView > zoomOutView)
            {
                Camera.main.fieldOfView -= distanceCameraView / (time / Time.deltaTime);
                yield return null;
            }
        }
    }
}

