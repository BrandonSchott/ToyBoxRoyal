using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    Health hpScript;
    // Start is called before the first frame update
    void Start()
    {
        hpScript = player.GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<TextMeshProUGUI>().color = Color.red;
        gameObject.GetComponent<TextMeshProUGUI>().text = $"Health: {hpScript.hp}";
    }
}
