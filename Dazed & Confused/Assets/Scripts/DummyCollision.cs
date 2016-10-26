using UnityEngine;
using System.Collections;

public class DummyCollision : MonoBehaviour
{
    public bool stun;
    public float stunTime;

    private float stunEnd;

    void Start() {
        stun = false;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Bullet(Clone)")
        {
            Destroy(coll.gameObject);
            if (!stun)
            {
                stun = true;
                stunEnd = Time.time + stunTime;
            };
        }
    }

    void Update() {
        if (Time.time > stunEnd)
        {
            stun = false;
        }
    }
}