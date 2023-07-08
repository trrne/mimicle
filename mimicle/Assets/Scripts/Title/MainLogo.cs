using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Mimical.Extend;

namespace Mimical
{
    public class MainLogo : MonoBehaviour
    {
        [SerializeField]
        Image fadingPanel;
        [SerializeField]
        Text pressT, clickT;
        [SerializeField]
        AudioClip[] presses, clicks;

        AudioSource speaker;
        (Color inactive, Color active) colours = (new(0.311f, 0.196f, 0.157f, 1), new(1, 1, 0, 1));
        bool isActivated = false;
        bool isMouseOverOnLogo = false;
        bool timerFlag = true;
        float clickToTransition = 1;
        float fadingPanelAlpha = 0;
        const float panelFadeSpeed = 0.008f;
        const float logoRotateSpeed = 10;
        const float textColorChangeSpeed = 1;
        const float rotationTolerance = 0.1f;
        Stopwatch transitionTimer = new();
        Vector3 Scale = new(2, 2, 2);

        void Start()
        {
            Time.timeScale = 1;
            speaker = GetComponent<AudioSource>();
            pressT.color = clickT.color = colours.inactive;
        }

        void Update()
        {
            MouseOver();
            Rotation();
        }

        void Rotation()
        {
            if (isMouseOverOnLogo)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), 10 * Time.deltaTime);
                return;
            }
            transform.Rotate(new(0, 0, logoRotateSpeed * Time.deltaTime));
        }

        void MouseOver()
        {
            var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.up, 1);
            if (hit && hit.collider.gameObject.name == Constant.Logo)
            {
                isMouseOverOnLogo = true;
                transform.localScale = Vector3.Lerp(transform.localScale, Scale * 1.1f, 20 * Time.deltaTime);
                if (Mynput.Down(0))
                {
                    speaker.PlayOneShot(clicks.Choice3());
                    ChangeTextsColor(clickT);
                }
            }
            else if (Mynput.Down(KeyCode.Space))
            {
                speaker.PlayOneShot(presses.Choice3());
                ChangeTextsColor(pressT);
            }

            if (!(hit && hit.collider.gameObject.name == Constant.Logo))
            {
                isMouseOverOnLogo = false;
                transform.localScale = Vector3.Lerp(transform.localScale, Scale, 30 * Time.deltaTime);
            }

            if (isActivated)
            {
                transitionTimer.Start();
                if (transitionTimer.SecondF() >= clickToTransition && timerFlag)
                {
                    StartCoroutine(FadingOutPanel());
                    timerFlag = false;
                }
            }

            if (fadingPanel.color.a >= clickToTransition)
            {
                Section.Load(Constant.Main);
            }
        }

        void ChangeTextsColor(Text text)
        {
            text.color = Color.Lerp(colours.inactive, colours.active, textColorChangeSpeed);
            if (text.color.r >= colours.active.r)
            {
                isActivated = true;
            }
        }

        IEnumerator FadingOutPanel()
        {
            while (fadingPanelAlpha <= 1)
            {
                yield return null;
                fadingPanelAlpha = Mathf.Clamp01(fadingPanelAlpha);
                fadingPanel.color = new(0, 0, 0, fadingPanelAlpha += panelFadeSpeed);
            }
        }
    }
}
