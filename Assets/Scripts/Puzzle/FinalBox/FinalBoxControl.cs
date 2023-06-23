using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FinalBoxControl : MonoBehaviour
{
    private int[] result, correctCombination;
    public Animator TapaCofre;
    public AudioSource audioSource;
    public GameObject padlock;
    public Camera mainCamera;
    public Animator cameraAnim;
    public float delayBeforeFade = 2f; // Tiempo de espera antes de activar el fade

    private bool isPuzzleCompleted = false;


    public CameraFade cameraFade;
    public GameObject fadeCanvas;

    private void Start()
    {
        result = new int[] { 7, 7, 7 };
        correctCombination = new int[] { 7, 4, 2 };
        WheelFinalBox.Rotated += CheckResults;
    }

    private void CheckResults(string wheelName, int number)
    {

        if (isPuzzleCompleted) return;

        switch (wheelName)
        {
            case "LockWheel1":
                result[0] = number;
                break;
            case "LockWheel2":
                result[1] = number;
                break;
            case "LockWheel3":
                result[2] = number;
                break;
        }

        if (result[0] == correctCombination[0] && result[1] == correctCombination[1] && result[2] == correctCombination[2])
        {
            audioSource.Play();
            TapaCofre.SetBool("Open", true);
            isPuzzleCompleted = true;
            Destroy(padlock);
            ActivateCameraAnimation();
            Invoke("StartFade", delayBeforeFade);

        }
    }

    private void StartFade()
    {
        fadeCanvas.SetActive(true);
        cameraFade.StartFade();
    }

    private void ActivateCameraAnimation()
    {
        mainCamera.enabled = false;
        cameraAnim.SetBool("Play", true);
    }

    private void OnDestroy()
    {
        WheelFinalBox.Rotated -= CheckResults;
    }
}
