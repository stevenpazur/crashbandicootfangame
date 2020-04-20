using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{
    public GameObject scoreText;
    public static int theScore;

    private void Update()
    {
        scoreText.GetComponent<Text>().text = ("Score: " + theScore);
    }
}
