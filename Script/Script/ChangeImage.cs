using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    public Image targetImage; // �ύX����Image�R���|�[�l���g
    public Sprite[] sprites;  // �؂�ւ���摜���X�g
    private int currentIndex = 0;

    void Start()
    {
        if (sprites.Length > 0 && targetImage != null)
        {
            StartCoroutine(SwitchImage());
        }
    }

    IEnumerator SwitchImage()
    {
        while (true)
        {
            targetImage.sprite = sprites[currentIndex];
            currentIndex = (currentIndex + 1) % sprites.Length;
            yield return new WaitForSeconds(2f);
        }
    }
}
