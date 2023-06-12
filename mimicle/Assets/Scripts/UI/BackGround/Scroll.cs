using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mimical.Extend;

namespace Mimical
{
    public class Scroll : MonoBehaviour
    {
        [SerializeField]
        GameManager manager;

        [SerializeField]
        GameObject[] cores;

        [SerializeField]
        float scrolling = 3;

        public static float Left = 20.48f;

        void Update()
        {
            ScrollBackground();
        }

        void ScrollBackground()
        {
            if (!manager.BackGroundScrollable)
            {
                return;
            }

            foreach (var i in cores)
            {
                i.transform.Translate(Vector2.left * scrolling * Time.deltaTime);

                if (i.transform.position.x <= -Left)
                {
                    i.transform.position = new(Left, 0);
                }
            }
        }
    }
}