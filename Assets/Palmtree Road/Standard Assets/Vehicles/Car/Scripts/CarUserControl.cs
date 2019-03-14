using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof(CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use

        public float movementSpeed;

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }


        private void FixedUpdate()
        {
            // pass the input to the car!
            float v = 0;
            float h = 0;
            if (Input.GetKey((KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Up"))))
            {
                v = Time.deltaTime * movementSpeed * 20f;
            }
            if (Input.GetKey((KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Down"))))
            {
                v = -Time.deltaTime * movementSpeed * 20f;
            }
            if (Input.GetKey((KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right"))))
            {
                h = Time.deltaTime * movementSpeed * 20f * GetComponent<CarController>().m_SteerAngle;
            }
            if (Input.GetKey((KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left"))))
            {
                h = -Time.deltaTime * movementSpeed * 20f * GetComponent<CarController>().m_SteerAngle;
            }
            if (Input.GetKey((KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Reset"))))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
            }
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("Menu", LoadSceneMode.Single);
            }
#if !MOBILE_INPUT
            float handbrake = CrossPlatformInputManager.GetAxis("Jump");
            m_Car.Move(h, v, v, handbrake);
#else
            m_Car.Move(h, v, v, 0f);

#endif
        }
    }
}
