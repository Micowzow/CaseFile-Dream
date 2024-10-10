using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafBudKnockBack : MonoBehaviour
{
    public Transform playerHit;
    public Transform leafBud;

    public Vector2 knockback;

    public Rigidbody2D rb;

    public float respawnDistance;

    public Vector2 RespawnPos;

    public Transform respawnPoint;

    public float strength;

    // Start is called before the first frame update
    void Start()
    {
        RespawnPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(playerHit.position, leafBud.position) < 2.5f && Input.GetAxis("Fire3") == 1) //&& GameObject.Find("GrabItem").GetComponent<LanternItemController>().isLanternBlue == true && gameObject.tag == "BlueInteract")
        {
            Vector2 direction = (transform.position - playerHit.transform.position).normalized;
            rb.AddForce(direction * strength, ForceMode2D.Impulse);
            FindObjectOfType<AudioManager>().Play("LeafBudHit");
        }

        if (Vector2.Distance(leafBud.position, respawnPoint.position) > respawnDistance)
        {
            StartCoroutine(RespawnBud(1.5f));
        }
    }

    IEnumerator RespawnBud(float duration)
    {
        FindObjectOfType<AudioManager>().Play("LeafBudRespawn");
        rb.simulated = false;
        rb.velocity = new Vector2(0, 0);
        transform.localScale = new Vector3(0, 0, 0);
        transform.rotation = Quaternion.identity;
        yield return new WaitForSeconds(duration);
        transform.position = RespawnPos;
        transform.localScale = new Vector3(1, 1, 1);
        rb.simulated = true;
        


    }
}
