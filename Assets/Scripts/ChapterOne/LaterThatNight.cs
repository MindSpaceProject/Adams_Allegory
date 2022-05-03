using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LaterThatNight : MonoBehaviour
{
     float currentTime = 0f;
    float startingTime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTime>0f) {
        currentTime -= 1 * Time.deltaTime;
        }

        if(currentTime<=0f) {
            SceneManager.LoadScene("Nightmare");
        }
    }
}
