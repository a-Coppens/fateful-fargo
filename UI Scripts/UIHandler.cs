using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIHandler : MonoBehaviour
{
    public Player player;
    public TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
       player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        text.SetText("Health: " + player.Health.ToString() + "\nAttack: " + player.Damage.ToString());
    }
}
