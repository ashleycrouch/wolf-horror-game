using UnityEngine;
using deVoid.Utils;
using Project.InputSignals;

public class InputManager : MonoBehaviour
{
    public TextMesh directionText;
    public Transform arrow = null;
    public Quaternion initialRotation;
    public Vector3 inputDirection = Vector3.zero;
    public float inputRotation = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Starting Input Manager");
        initialRotation = arrow.rotation;
        directionText.text = "*";
    }

    void OnEnable()
    {
        Debug.Log("Input Manager Enabled");
    }

    void OnDisable()
    {
        Debug.Log("Input Manager Disabled");
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        inputDirection = new Vector3(horizontal, 0f, vertical);
        if(inputDirection.sqrMagnitude > 0.001f)
        {
            inputRotation = Mathf.Atan2(vertical, horizontal) * Mathf.Rad2Deg - 90f;
            arrow.rotation = Quaternion.Euler(0f, 0f, inputRotation);
            string compassDirection = "";
            float verticalSign = Mathf.Sign(vertical);
            float horizontalSign = Mathf.Sign(horizontal);
            if ((vertical * verticalSign) > 0.00001f) compassDirection += verticalSign > 0 ? "N" : "S";
            if ((horizontal * horizontalSign) > 0.00001f) compassDirection += horizontalSign > 0 ? "E" : "W";
            directionText.text = compassDirection;
        } else
        {
            arrow.rotation = initialRotation;
            directionText.text = "*";
        }
    }
}
