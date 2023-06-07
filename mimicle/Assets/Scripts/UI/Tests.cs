using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Mimical.Extend;

namespace Mimical
{
    public class Tests : MonoBehaviour
    {
        [SerializeField]
        Text timeT;

        [SerializeField]
        Text nowWaveT;

        [SerializeField]
        Text maxWaveT;

        [SerializeField]
        Wave wave;

        [SerializeField]
        Text ammoT;

        [SerializeField]
        Ammo ammo;

        [SerializeField]
        Image hpImage;

        [SerializeField]
        HP playerHp;

        [SerializeField]
        Text fpsT;

        [SerializeField]
        Image reloadImage;

        [SerializeField]
        Player player;

        [SerializeField]
        Text scoreT;

        [SerializeField]
        Score score;

        void Update()
        {
            Text();

            Image();
        }

        void Image()
        {
            hpImage.fillAmount = playerHp.Ratio;

            reloadImage.fillAmount = player.ReloadProgress;
        }

        void Text()
        {
            timeT.text = Score.Time().ToString();

            nowWaveT.text = wave.Now.ToString();

            maxWaveT.text = wave.Max.ToString();

            ammoT.text = ammo.Remain.ToString();

            fpsT.text = visual.Fps().ToString();

            scoreT.text = score.Now.ToString();
        }
    }
}
