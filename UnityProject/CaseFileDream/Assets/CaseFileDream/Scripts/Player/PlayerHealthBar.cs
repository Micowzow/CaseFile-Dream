using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerController
{
    public class PlayerHealthBar : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Image totalhealthBar;
    public Image currentHealthBar;

    public void Start()
    {
        totalhealthBar.fillAmount = playerHealth.currentHealth / 3;
    }

    public void Update()
    {
        currentHealthBar.fillAmount = playerHealth.currentHealth / 3;
    }
} 
}
