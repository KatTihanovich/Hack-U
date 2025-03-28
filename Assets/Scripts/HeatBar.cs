using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HeatBar : MonoBehaviour
{
    [SerializeField]
    public static Slider heatSlider;  // Reference to the UI slider
    [SerializeField]
    public static float maxHeat = 10f;  // Max heat level
    [SerializeField]
    private static float currentHeat = 7f;  // Current heat value

    void Awake()
    {
        heatSlider = GetComponent<Slider>();
    }
    void Start()
    {
        heatSlider.maxValue = maxHeat;
        heatSlider.value = currentHeat;
    }

public static float GetCurrentHeat()
    {
        return currentHeat;
    }

    // Increase Heat (Call when player loses)
    public static void IncreaseHeat(float amount)
    {
        currentHeat += amount;
        currentHeat = Mathf.Clamp(currentHeat, 0, maxHeat);
        heatSlider.value = currentHeat;

        if (currentHeat >= maxHeat)
        {
             SceneManager.LoadScene("CatSceneEnd");
            //GameOver();
        }
    }

    // Decrease Heat (Call when player wins)
    public static void DecreaseHeat(float amount)
    {
        currentHeat -= amount;
        currentHeat = Mathf.Clamp(currentHeat, 0, maxHeat);
        heatSlider.value = currentHeat;

    }

    // Handle Game Over
    private static void GameOver()
    {
        Debug.Log("You Lose! Heat Overload!");
        // Add your game-over logic here (e.g., restart, display message, etc.)
    }
}
