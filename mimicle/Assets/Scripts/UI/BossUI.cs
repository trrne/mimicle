using UnityEngine;
using UnityEngine.UI;

namespace Cet
{
    public class BossUI : MonoBehaviour
    {
        [SerializeField]
        GameObject core;
        [SerializeField]
        Image gauge;
        [SerializeField]
        Text text;
        [SerializeField]
        HP bossHp;
        [SerializeField]
        EnemySpawner spawner;

        public void UpdateBossUI()
        {
            gauge.fillAmount = bossHp.Ratio;
            text.text = bossHp.Now.ToString();
        }
    }
}
