using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HiThere
{
    public class CameraColor : MonoBehaviour
    {
        [SerializeField]
        private Camera cam;

        [SerializeField]
        private Color32 currentColor;

        // Start is called before the first frame update
        void Start()
        {
            cam.backgroundColor = currentColor;
        }

        // Update is called once per frame
        void Update()
        {
            float shiftAmount = Time.deltaTime / 4f;

            currentColor = Utility.HueShift(currentColor, shiftAmount);

            cam.backgroundColor = currentColor;
        }
    }
}