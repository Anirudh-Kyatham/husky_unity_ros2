using UnityEngine;
using TMPro; // Namespace for TextMeshPro

public class DisplayCoordinates : MonoBehaviour
{
    public Transform huskyTransform; // Assign this in the inspector
    public TextMeshProUGUI coordinatesText; // Assign this in the inspector

    void Update()
    {
        // Update the text element with the Husky's current position
        coordinatesText.text = $"Position: {huskyTransform.position.ToString()}";
    }
}

