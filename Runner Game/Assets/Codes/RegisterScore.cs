using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RegisterScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameData.singleton.scoreText = this.GetComponent<TMP_Text>();
        GameData.singleton.UpdateScore(0);
    }

}
