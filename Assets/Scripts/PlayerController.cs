using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float autoMoveSpeed;
    public GameObject hookPrefab;
    public float hookThrowPower;
    public float hookOffset;
    private bool isThrowingHook = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown("space") && !isThrowingHook) {
            ThrowHook(transform.up + transform.right);
        }
        
    }

    void FixedUpdate() {
        transform.Translate(transform.right * Time.deltaTime * autoMoveSpeed);
    }

    void ThrowHook(Vector3 direction) {
        direction = direction.normalized;
        GameObject hookObj = Instantiate(hookPrefab, transform.position + hookOffset * transform.right, transform.rotation);
        hookObj.GetComponent<Rigidbody2D>().AddForce(direction * hookThrowPower, ForceMode2D.Impulse);
        hookObj.GetComponent<Hook>().m_HookCollisionEvent.AddListener(GoToWall);
    }

    void GoToWall(Collision2D wallColl) {
        Debug.Log(wallColl.contacts[0].normal);

    }
}
