using UnityEngine;

public class MenuController : MonoBehaviour
{
    private void Start()
    {
        // Activa el cursor y desbloquea su movimiento
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}