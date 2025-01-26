using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    public Button playButton;

    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(Transition);
    }

    private void Transition()
    {
        SceneManager.LoadScene("Alpha");
    }
}
