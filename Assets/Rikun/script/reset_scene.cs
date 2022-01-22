
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class reset_scene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(() => SceneManager.LoadScene(0));
    }

}
