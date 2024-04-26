using UnityEngine;
using TMPro;

public class DiskReader : MonoBehaviour
{
    public TextMeshPro screenText;

    // Called when the collider enters another collider marked as a snap location
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter called!");
        Debug.Log("collider: " + other.name);
        // Check if the collider has the "SnapLocation" tag
        if (other.CompareTag("Disk"))
        {
            Debug.Log("SnapLocation found!");
            // Activate the text on the TextMeshPro component
            // screenText.enabled = true;
            // screenText.text = "Here's your wallet info:";
            CryptoAccount walletObject = other.GetComponent<CryptoAccount>();
            TypewriterEffect typewriter = screenText.GetComponent<TypewriterEffect>();
            typewriter.StartTypingNewText(walletObject.GetAccountInfo());
        }
    }

    // Called when the collider exits a collider marked as a snap location
    private void OnTriggerExit(Collider other)
    {
        // Check if the collider has the "SnapLocation" tag
        if (other.CompareTag("Disk"))
        {
            // Deactivate the text on the TextMeshPro component
            screenText.enabled = false;
        }
    }
}