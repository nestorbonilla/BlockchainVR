using System.Collections;
using TMPro;
using UnityEngine;

public class TypewriterEffect : MonoBehaviour
{
    public TextMeshPro textMeshPro;
    public float initialDelay = 1.0f; // Initial delay before typing starts
    public float typingSpeed = 0.05f;

    private string[] lines;
    private int currentLineIndex = 0;
    private string currentLine = "";
    private int currentCharacterIndex = 0;

    private void Start()
    {
        var initialText = "Hey Anon!\n" +
                          "Looking for a burner wallet?\n" +
                          "Create a floppy disk account and insert insert it...\n";
        StartTypingNewText(initialText);
    }

    private IEnumerator StartTyping()
    {
        // Wait for the initial delay
        yield return new WaitForSeconds(initialDelay);

        // Start typing the text
        StartCoroutine(TypeText());
    }

    private IEnumerator TypeText()
    {
        // Clear the text
        textMeshPro.text = "";

        // Iterate through each line
        for (int i = 0; i < lines.Length; i++)
        {
            currentLineIndex = i;
            currentLine = lines[i];
            currentCharacterIndex = 0;

            // Type each character of the current line
            while (currentCharacterIndex < currentLine.Length)
            {
                // Add the next character to the text
                textMeshPro.text += currentLine[currentCharacterIndex];

                // Move to the next character
                currentCharacterIndex++;

                // Wait for a brief period of time
                yield return new WaitForSeconds(typingSpeed);
            }

            // Add a newline character if not on the last line
            if (i < lines.Length - 1)
            {
                textMeshPro.text += "\n";
            }
        }
    }

    // Method to start typing with new text
    public void StartTypingNewText(string newText)
    {
        // Split the new text into lines
        lines = newText.Split('\n');

        // Start typing
        StartCoroutine(StartTyping());
    }
}