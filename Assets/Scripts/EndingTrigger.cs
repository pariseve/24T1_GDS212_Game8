using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingTrigger : MonoBehaviour
{
    public string sceneName;

    public void GameComplete()
    {
        if (AllAreasPurified())
        {
            Debug.Log("All areas purified! Loading scene: " + sceneName);
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
        else
        {
            Debug.Log("Not all areas purified yet.");
        }
    }

    // Check if all toxic areas have been purified
    private bool AllAreasPurified()
    {
        GameObject[] toxicAreas = GameObject.FindGameObjectsWithTag("ToxicArea");
        Debug.Log("Toxic areas found: " + toxicAreas.Length);
        return toxicAreas.Length == 0;
    }
}
