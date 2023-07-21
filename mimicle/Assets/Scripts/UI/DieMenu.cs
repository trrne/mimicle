using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MyGame.Utils;

namespace MyGame
{
    public class DieMenu : MonoBehaviour
    {
        [SerializeField]
        BlurUI blur;

        [SerializeField]
        Text stateT, scoreT, timeT;

        CanvasGroup canvas;
        float a = 0f;

        void Start()
        {
            canvas = GetComponent<CanvasGroup>();
            canvas.alpha = 0;
        }

        void Update()
        {
            this.stateT.text = "Dit it !";
            this.scoreT.text = "Score: " + Score.Now;
            this.timeT.text = "Time: " + Score.Time;
            // ブラーがマックスになったらスコア表示
            if (!blur.Max)
            {
                return;
            }

            a = Mathf.Clamp(a, 0, 1);
            a += Time.unscaledDeltaTime * 10;
            canvas.alpha = a;

            if (Numeric.Twins(1, a))
            {
                a = 1;
                // blur.Reblur();
            }
        }
    }
}