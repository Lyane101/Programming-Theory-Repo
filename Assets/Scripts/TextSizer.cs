using System.Collections;
using TMPro;
using UnityEngine;

public class TextSizer : MonoBehaviour
{
    public TextMeshPro textMesh; // Reference to the TextMeshPro component
    private float startSize = 0f; // Starting font size
    private float endSize = 2f; // Ending font size
    private float duration = 0.5f; // Time taken for the animation (in seconds)

    IEnumerator SizeUpText()
    {
        float timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            float progress = timeElapsed / duration;
            textMesh.fontSize = Mathf.Lerp(startSize, endSize, progress);
            timeElapsed += Time.deltaTime;
            yield return null; // Wait for the next frame
        }
    }
	
	public void StartTextSizerCoroutine()
	{
		StartCoroutine(SizeUpText());
	}
}
