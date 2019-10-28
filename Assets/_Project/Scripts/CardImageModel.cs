using UnityEngine;
using UnityEngine.UI;

public class CardImageModel : MonoBehaviour
{
    public Sprite image;
    [SerializeField] private Image img;

    private void Start()
    {
        img.sprite = image;
    }
}