using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssenceDrop : MonoBehaviour
{
    public GameObject essenceDrop;
    EnemyHealthManager enemyHealthManager;
    public Transform transform;
    // Start is called before the first frame update
    void Start()
    {
        enemyHealthManager = GetComponent<EnemyHealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyHealthManager.enemyDead == true)
        {
            DropEssence();
        }
    }

    public void DropEssence()
    {
        Vector2 position = transform.position;
        GameObject essence = Instantiate(essenceDrop, position, Quaternion.identity);
    }
}
