using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HandleSlider : MonoBehaviour
{
    [SerializeField] BallsManager ballsManager;
    [SerializeField] HandleCamera handleCamera;
    Slider slider;
    private void Start()
    {
        slider = GetComponent<Slider>();
        if (slider != null)
        {
            // Add a listener to the slider to update the camera position when the slider value changes
            slider.onValueChanged.AddListener(UpdateCameraPosition);
        }
    }

    private void UpdateCameraPosition(float value)
    {
        // Get the lowest ball's position and the initial spawn position
        Vector3 lowestBallPosition = ballsManager.GetLowestBall()?.transform.position ?? Vector3.zero;
        Vector3 initialSpawnPosition = ballsManager.GetPositionSpawnAtFirstTime();

        // Interpolate between the initial spawn position and the lowest ball's position based on the slider value
        float targetY = Mathf.Lerp(initialSpawnPosition.y, lowestBallPosition.y, value);

        // Set the camera's position to the interpolated targetY
        handleCamera.transform.position = new Vector3(handleCamera.transform.position.x, targetY + handleCamera.OffsetY, handleCamera.transform.position.z);

        handleCamera.FollowBall = value == 1;
    }

    void Update()
    {
        if(handleCamera.FollowBall)
        {
            slider.value = 1;
        }
    }

    private void OnDestroy()
    {
        if (slider != null)
        {
            // Remove the listener when the object is destroyed
            slider.onValueChanged.RemoveListener(UpdateCameraPosition);
        }
    }
}
