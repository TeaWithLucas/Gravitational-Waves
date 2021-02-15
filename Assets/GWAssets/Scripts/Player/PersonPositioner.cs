using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonPositioner : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float PlayerSpeed = 2.0f;
    public float JumpHeight = 1.0f;
    // Color32 packs to 4 bytes
    public Color32 PlayerColor = Color.green;
    private float gravityValue = -9.81f;

    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
        this.SetColor(PlayerColor);
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * PlayerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(JumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    // Unity clones the material when GetComponent<Renderer>().material is called
    // Cache it here and destroy it in OnDestroy to prevent a memory leak
    Material cachedMaterial;

    void SetColor(Color32 newColor)
    {
        if (cachedMaterial == null) cachedMaterial = GetComponentInChildren<Renderer>().material;
        cachedMaterial.color = newColor;
    }

    void OnDestroy()
    {
        Destroy(cachedMaterial);
    }
}
