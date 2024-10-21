using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreen;


    public static int numberOfCoins;
    public TextMeshProUGUI coinsText;
    private void Awake()
    {
        
        numberOfCoins = PlayerPrefs.GetInt("NumberOfCoins", 0);
        isGameOver = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinsText.text =  numberOfCoins.ToString();
        if (isGameOver) 
        {
            gameOverScreen.SetActive(true);
        }
        
    }

    public void ReplayLovel() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ResetScore()
    {
        PlayerPrefs.DeleteAll();
        numberOfCoins = 0;
    }
}
