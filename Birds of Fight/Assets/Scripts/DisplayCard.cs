using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCard : MonoBehaviour
{
    public ActionCard actionCard;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    public UnityEngine.UI.Image cardImage;

    public bool cardBack;
    public static bool staticCardBack;

    // Start is called before the first frame update
    void Start()
    {
        nameText.text = actionCard.cardName;
        descriptionText.text = actionCard.cardDescription;
        cardImage.sprite = actionCard.cardImage;
    }

    // Update is called once per frame
    void Update()
    {
        staticCardBack = cardBack;
    }
}
