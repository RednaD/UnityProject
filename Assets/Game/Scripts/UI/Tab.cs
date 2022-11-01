using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Tab : MonoBehaviour
{
    /*[Header("Refs")]
    [SerializeField] Image bgImage;
    [SerializeField] Image logoImage;
    [Header("Idle")]
    [SerializeField] Sprite idleSprite;
    [SerializeField] Color idleColor = Color.gray;
    [SerializeField] Color idleBGColor = Color.gray;
    [Header("Selected")]
    [SerializeField] Sprite selectedSprite;
    [SerializeField] Color selectedColor = Color.white;
    [SerializeField] Color selectedBGColor = Color.white;
    [SerializeField] GameObject tabCanvas;*/
    [HideInInspector] public Button tabButton;

    void Awake()
    {
        tabButton = GetComponent<Button>();
        //bgImage = GetComponent<Image>();
    }

    public void SetIdle()
    {
        /*logoImage.sprite = idleSprite;
        logoImage.color = idleColor;
        bgImage.color = idleBGColor;
        tabCanvas.SetActive(false);*/
    }
    
    public void SetSelected()
    {
        /*logoImage.sprite = selectedSprite;
        logoImage.color = selectedColor;
        bgImage.color = selectedBGColor;
        tabCanvas.SetActive(true);*/
    }
}