using UnityEngine;
using Self.Utils;

namespace Self.Game
{
    public class SpideFeet : MonoBehaviour
    {
        void OnCollisionEnter2D(Collision2D info)
        {
            if (info.Compare(Constant.Player) && !info.Get<Parry>().IsParry)
            {
                info.Get<HP>().Damage(Constant.Damage.Spide);
                Destroy(gameObject);
            }

            if (info.Compare(Constant.PlayerBullet))
            {
                Destroy(info.gameObject);
                Destroy(gameObject);
            }
        }
    }
}