using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] GameObject DialogueGUI;
    [SerializeField] Text DialogueText;

    void Start()
    {
        DialogueGUI.SetActive(true);
        DialogueText.text = "Find the exit! (WASD + mouse)";
    }

    public void HideInstructions()
    {
        DialogueGUI.SetActive(false);
        DialogueText.text = "You've started your journey.";
    }

    public void ShowEnergyShotMerchText()
    {
        DialogueGUI.SetActive(true);
        DialogueText.text = "Space: Buy Energy Shot (30% HP)";
    }

    public void HideEnergyShotMerchText()
    {
        DialogueGUI.SetActive(false);
        DialogueText.text = "You've left the Energy Shot.";
    }

    public void ShowKeyMerchText()
    {
        DialogueGUI.SetActive(true);
        DialogueText.text = "Space: Buy Exit Key (10% HP)";
    }

    public void HideKeyMerchText()
    {
        DialogueGUI.SetActive(false);
        DialogueText.text = "You've left the Exit Key.";
    }

    public void ShowMinimapMerchText()
    {
        DialogueGUI.SetActive(true);
        DialogueText.text = "Space: Buy Minimap (30% HP)";
    }

    public void HideMinimapMerchText()
    {
        DialogueGUI.SetActive(false);
        DialogueText.text = "You've left the Minimap.";
    }

    public void ShowExitIsClosedText()
    {
        DialogueGUI.SetActive(true);
        DialogueText.text = "You need the Exit Key.";
    }

    public void HideExitIsClosedText()
    {
        DialogueGUI.SetActive(false);
        DialogueText.text = "You've left the Closed Exit.";
    }

    public void ShowExitIsOpenedText()
    {
        DialogueGUI.SetActive(true);
        DialogueText.text = "Space: Exit level! :)";
    }

    public void HideExitIsOpenedText()
    {
        DialogueGUI.SetActive(false);
        DialogueText.text = "You've left the Opened Exit.";
    }

    public void ThanksForPlayingText()
    {
        DialogueGUI.SetActive(true);
        DialogueText.text = "Thanks for playing!";
    }

    public void HideAllBottomText()
    {
        DialogueGUI.SetActive(false);
        DialogueText.text = "Sorry, you've died.";
    }
}
