using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Self.Utils;

namespace Self.Game
{
    public class Spide : Enemy
    {
        [SerializeField]
        GameObject[] levels;

        [SerializeField]
        GameObject[] effects;

        SpriteRenderer sr;

        /// <summary>
        /// アクティブなレベル
        /// </summary>
        int activeLevel = 0;

        /// <summary>
        /// 移動速度
        /// </summary>
        float speed = 1f;

        /// <summary>
        /// 回転速度
        /// </summary>
        readonly int[] rotationSpeed = { 50, 90, 120 };

        /// <summary>
        /// 死亡判定フラグ
        /// </summary>
        bool dead = false;

        /// <summary>
        /// 死亡時の透明度調整用
        /// </summary>
        float alpha = 1f;

        /// <summary>
        /// 回復用
        /// </summary>
        HP playerHP;

        void Start()
        {
            sr = GetComponent<SpriteRenderer>();

            playerHP = Gobject.GetWithTag<HP>(Constant.Player);
        }

        readonly Runner deadp = new();
        void Update()
        {
            Move();

            if (transform.position.x <= -14)
            {
                Score.Add(Constant.Point.RedSpide);
                Destroy(gameObject);
            }

            if (!(transform.GetChild(activeLevel).childCount > 0) || dead)
            {
                deadp.RunOnce(() =>
                {
                    Score.Add(Constant.Point.Spide);
                    StartCoroutine(Fade());

                    // 現在HPの20%回復
                    float amount = (1 - playerHP.Ratio) * 100 / 5;
                    playerHP.Healing(Numeric.Cutail(amount));

                    if (sr.color.a <= 0 && speed <= 0)
                    {
                        effects.Generate(transform.position);
                        Destroy(gameObject);
                    }
                });
            }
        }

        IEnumerator Fade()
        {
            while (sr.color.a > 0)
            {
                yield return null;
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, alpha);
                alpha -= 0.02f;
                speed -= 0.02f;
            }
        }



        /// <summary>
        /// レベルをセット
        /// </summary>
        /// <param name="_level">0-2</param>
        public void SetLevel(int _level)
        {
            try
            {
                activeLevel = _level;
                levels[activeLevel].SetActive(true);
            }
            catch (System.IndexOutOfRangeException)
            {
                levels.Last().SetActive(true);
            }

            for (ushort index = 0; index < levels.Length; index++)
            {
                if (activeLevel != index)
                {
                    levels[index].SetActive(false);
                }
            }
        }

        protected override void Move()
        {
            transform.position += Time.deltaTime * speed * Vector3.left;
            transform.Rotate(0, 0, rotationSpeed[activeLevel] * Time.deltaTime);
        }

        void OnCollisionEnter2D(Collision2D info)
        {
            // 弾が中心の丸にあたったら脂肪
            if (info.Compare(Constant.PlayerBullet))
            {
                dead = true;
            }
        }
    }
}
