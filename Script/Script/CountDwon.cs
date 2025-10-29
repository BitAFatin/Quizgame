using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDwon : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI limitTimeText;

    [SerializeField]
    private int changeFrame = 3600; // ��: 60FPS �~ 60�b

    [SerializeField]
    private GameObject timeUpImage;

    [SerializeField]
    private AudioSource currentBGM;      // ���܂ł�BGM
    [SerializeField]
    private AudioSource newBGM;          // �V��������BGM

    private float timeValue = 0f;
    private bool changingOrder = false;

    void Start()
    {
        if (timeUpImage != null)
            timeUpImage.SetActive(false);

        if (newBGM != null)
            newBGM.Stop(); // �O�̂���
    }

    void FixedUpdate()
    {
        timeValue += 0.017f;

        if (!changingOrder)
        {
            int remainingSeconds = Mathf.Max(0, (int)(changeFrame / 60 - timeValue));
            limitTimeText.text = $"�̂���<size=0.6><color=yellow>{remainingSeconds}</color></size>�т傤";

            if (remainingSeconds == 0)
            {
                changingOrder = true;

                if (timeUpImage != null)
                    timeUpImage.SetActive(true);

                // BGM �؂�ւ�
                if (currentBGM != null && currentBGM.isPlaying)
                    currentBGM.Stop();

                if (newBGM != null)
                    newBGM.Play();

                timeValue = -1f;
            }
        }
    }
}