using UnityEngine;
using System.Collections;

public class Damagable : MonoBehaviour
{
    public float MaxHp;

    private float _hp;

    public float Hp
    {
        get { return _hp; }
        set
        {
            _hp = value;

            // Make sure we die when we should
            if (_hp <= 0) {
                Die();
            }
        }
    }

    private void Start()
    {
        _hp = MaxHp;
    }

    /// <summary>
    /// Called when the object dies, handles event broadcasting
    /// </summary>
    public void Die()
    {
        BroadcastMessage("OnDeath", SendMessageOptions.DontRequireReceiver);
        Destroy(gameObject);
    }

    /// <summary>
    /// Deal damage to this game object
    /// </summary>
    /// <param name="damage">The amount of hp this gameobject should lose</param>
    public void TakeDamage(float damage)
    {
        Hp -= damage;
    }
}