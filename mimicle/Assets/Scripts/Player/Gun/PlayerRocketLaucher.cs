using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Self.Utility;
using UnityEngine;

namespace Self
{
    [RequireComponent(typeof(AudioSource))]
    public class PlayerRocketLaucher : Bullet
    {
        [SerializeField]
        GameObject fireEffect, explosionEffect;

        [SerializeField]
        AudioClip fireSound, explosionSound;

        AudioSource speaker;

        Vector2 direction;
        (float basis, float Reduction) speeds = (15f, 0.2f);

        (float Range, int basis, float Mult) damage => (
            Range: 5f,
            basis: 25,
            Mult: 5f
        );

        WaveData wdata;

        [SerializeField]
        int damageAmount;

        void Start()
        {
            speaker = GetComponent<AudioSource>();
            speaker.PlayOneShot(fireSound);

            direction = -transform.right;

            wdata = Gobject.GetWithTag<WaveData>(Constant.WaveManager);
        }

        void Update()
        {
            OutOfScreen(gameObject);

            if (speeds.basis >= 0)
            {
                speeds.basis -= speeds.Reduction;
                Move(speeds.basis);

                return;
            }

            Explosion();
        }

        protected override void Move(float speed)
        {
            transform.Translate(speed * direction * Time.deltaTime, Space.World);
        }

        void Explosion()
        {
            var closers = GetClosersArr();
            if (closers is null)
            {
                explosionEffect.Generate(transform.position);
                return;
            }

            foreach (var enemy in closers)
            {
                float distance = damage.Range - Vector3.Distance(enemy.transform.position, transform.position);
                int damageAmount = Numeric.Round((int)(distance * damage.basis * damage.Mult));
                enemy.GetComponent<HP>().Damage(
                    Mathf.Clamp(damageAmount, 1, 500));

                print(damageAmount);
            }

            // 爆発エフェクト生成
            explosionEffect.Generate(transform.position);

            Destroy(gameObject);
        }

        GameObject[] GetClosersArr()
        {
            var enemies = Gobject.Finds(Constant.Enemy);

            // Gobject.TryWithTag<HP>(out var bossHP, tag: Constant.Boss);
            // if (wdata.Now == 2 && !bossHP.IsZero)
            // {
            // }

            if (enemies is null)
            {
                print("pass");
                return null;
            }

            var closers = (
                from enemy in enemies
                where Vector2.Distance(enemy.transform.position, transform.position) < damage.Range
                // HP持ってないやつは除外(SpideとかSpideとかSpideとか)
                where enemy.GetComponent<HP>()
                select enemy
            );

            return closers.ToArray();
        }

        protected override void TakeDamage(Collision2D info)
        {
            explosionEffect.Generate(transform.position);
            info.Get<HP>().Damage(Values.Damage.PlayerRocket);
        }

        void OnCollisionEnter2D(Collision2D info)
        {
            if (info.Compare(Constant.Enemy))
            {
                TakeDamage(info);
            }
        }
    }
}