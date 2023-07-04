using UnityEngine;
using Mimical.Extend;

namespace Mimical
{
    public class SmokeFx : MonoBehaviour
    {
        Stopwatch sw_fx = new(true);

        void Update()
        {
            if (sw_fx.sf >= 1.5f)
            {
                GetComponent<ParticleSystem>().Stop();
            }
        }
    }
}