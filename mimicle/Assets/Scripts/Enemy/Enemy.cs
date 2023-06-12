using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mimical.Extend;

namespace Mimical
{
    public abstract class Enemy : MonoBehaviour
    {
        protected void Start(HP hp) => hp.SetMax();

        protected abstract void Move();

        protected virtual void Left(GameObject obj, int deadLine = -20)
        {
            if (obj.transform.position.x <= deadLine)
            {
                obj.Remove();
            }
        }

        protected void AddSlainCountAndRemove(GameObject gob)
        {
            var slain = GameObject.Find("Wave").GetComponent<Slain>();
            slain.AddCount();

            gob.Remove();
        }

        protected virtual void OnBecameVisible() {; }

        protected virtual void OnBecameInvisible() {; }
    }
}