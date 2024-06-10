using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogCell : MonoBehaviour
{


    public void Initial(string playerName, string content)
    {
        TMP_Text nameText = transform.Find("name").GetComponent<TMP_Text>();
        nameText.text = playerName;
        TMP_Text contentText = transform.Find("content").GetComponent<TMP_Text>();
        contentText.text = content;
    }




}
