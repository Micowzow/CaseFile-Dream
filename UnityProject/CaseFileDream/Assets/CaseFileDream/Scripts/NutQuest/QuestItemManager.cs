using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Playables;

public class QuestItemManager : MonoBehaviour
{
    public static QuestItemManager instance;

    public int questItem;
    public TextMeshProUGUI numDisplay;

    [SerializeField] private PlayableDirector playableDirectorItemsCollected;
    //[SerializeField] private PlayableDirector playableDirectorBlueFire;
   // [SerializeField] private PlayableDirector playableDirectorRedFire;
    //[SerializeField] private PlayableDirector playableDirectorPinkFire;

    public ParticleSystem psBlue;
    public ParticleSystem psRed;
    public ParticleSystem psYellow;
    public ParticleSystem psPink;


    // Start is called before the first frame update
    private void Awake()
    {
        if (!instance)
        {
            instance = this;

        }
        
    }

    public void Update()
    {
        
        if (questItem == 0)
        {

            
        }
        if (!psBlue.isPlaying && questItem == 1)
        {
            
            psBlue.Play();
            
        }
        if (!psPink.isPlaying && questItem == 2)
        {
            
            psPink.Play();
            
        }
        if (!psRed.isPlaying && questItem == 3)
        {
            
            psRed.Play();
            
        }
        if (questItem == 4)
        {
            playableDirectorItemsCollected.Play();
            psYellow.Play();
            questItem += 1;
        }


    }

    private void ONGUI()
    {
        numDisplay.text = questItem.ToString();

    }

    public void ChangeItem(int amount)
    {
        questItem += amount;
        numDisplay.text = questItem.ToString();

    }
    
    
}
