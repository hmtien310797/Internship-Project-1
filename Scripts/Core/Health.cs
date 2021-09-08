using UnityEngine;
using Player;

namespace Core
{
    public class Health : MonoBehaviour
    {
        [SerializeField] int hitPoints = 100;
        [SerializeField] HealthBar healthBar;
        public void Start()
        {
            try
            {
                healthBar.SetMaxHP(hitPoints);
            }
            catch
            {
                Debug.Log("No Error");

            }
        }

        public int GetHitPoints()
        {
            return hitPoints;
        }

        public void DecreaseHitPoint(int damage)
        {
            hitPoints -= damage;
            if (gameObject.tag == "Player")
            {
                healthBar.SetHP(hitPoints);
            }
        }

    }
}

