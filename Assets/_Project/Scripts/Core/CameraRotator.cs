using System.Collections;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    public float rotationStep = 90f; // Angle de rotation en degrès
    public float rotationSpeed = 180f; // Vitesse de rotation (degrès par seconde)

    public bool isRotating = false; 

    public void RotateLeft()
    {
        if (!isRotating)
        {
            StartCoroutine(Rotate(rotationStep));
        }
    }

    public void RotateRight()
    {
        if (!isRotating)
        {
            StartCoroutine(Rotate(-rotationStep));
        }
    }

    private IEnumerator Rotate(float angle)
    {
        isRotating = true;

        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(0, transform.eulerAngles.y + angle, 0);

        float elapsedTime = 0f;
        float duration = Mathf.Abs(angle) / rotationSpeed; // Durée de la rotation

        while (elapsedTime < duration)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null; // Attendre la prochaine frame
        }

        transform.rotation = endRotation; // Assurer que la rotation finale est correcte

        isRotating = false;
    }
}   
