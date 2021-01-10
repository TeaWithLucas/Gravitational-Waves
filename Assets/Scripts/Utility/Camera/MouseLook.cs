using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace Game.Utility.Cameras {
    [Serializable]
    public class MouseLook {
        public float XSensitivity = 2f;
        public float YSensitivity = 2f;
        public bool ClampVerticalRotation = true;
        public float MinimumX = -90F;
        public float MaximumX = 90F;
        public bool Smooth;
        public float SmoothTime = 5f;

        public bool LockCursor { get; set; }
        public KeyCode LockKey { get; set; }

        public bool CursorIsLocked { get; protected set; }

        private Quaternion m_CharacterTargetRot;
        private Quaternion m_CameraTargetRot;

        public void Init(Transform character, Transform camera) {
            m_CharacterTargetRot = character.localRotation;
            m_CameraTargetRot = camera.localRotation;

            LockCursor = false;
            UpdateCursorLock();
        }

        public void Init(Transform character, Transform camera, bool lockCursor) {
            m_CharacterTargetRot = character.localRotation;
            m_CameraTargetRot = camera.localRotation;

            LockCursor = lockCursor;
            UpdateCursorLock();
        }

        public void Init(Transform character, Transform camera, KeyCode lockKey = KeyCode.None) {
            m_CharacterTargetRot = character.localRotation;
            m_CameraTargetRot = camera.localRotation;

            LockKey = lockKey;
            LockCursor = LockKey != KeyCode.None;
            UpdateCursorLock();
        }


        public void LookRotation(Transform character, Transform camera) {
            UpdateCursorLock();

            float yRot = 0;
            float xRot = 0;
            if (CursorIsLocked) {
                yRot = CrossPlatformInputManager.GetAxis("Mouse X") * XSensitivity;
                xRot = CrossPlatformInputManager.GetAxis("Mouse Y") * YSensitivity;
            }

            m_CharacterTargetRot *= Quaternion.Euler(0f, yRot, 0f);
            m_CameraTargetRot *= Quaternion.Euler(-xRot, 0f, 0f);

            if (ClampVerticalRotation)
                m_CameraTargetRot = ClampRotationAroundXAxis(m_CameraTargetRot);

            if (Smooth) {
                character.localRotation = Quaternion.Slerp(character.localRotation, m_CharacterTargetRot,
                    SmoothTime * Time.deltaTime);
                camera.localRotation = Quaternion.Slerp(camera.localRotation, m_CameraTargetRot,
                    SmoothTime * Time.deltaTime);
            } else {
                character.localRotation = m_CharacterTargetRot;
                camera.localRotation = m_CameraTargetRot;
            }


        }

        public void SetCursorLock(bool value) {
            LockCursor = value;
            if (!LockCursor) {//we force unlock the cursor if the user disable the cursor locking helper
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }

        public void SetCursorLock(KeyCode key) {
            LockKey = key;
            LockCursor = false;
            InternalLockUpdate();
        }

        public void UpdateCursorLock() {
            //if the user set "lockCursor" we check & properly lock the cursos
            if (LockCursor || LockKey != KeyCode.None) {
                InternalLockUpdate();
            }
        }

        private void InternalLockUpdate() {
            if (LockKey != KeyCode.None) {
                //Debug.Log(LockKey);
                if (Input.GetKey(LockKey)) {
                    CursorIsLocked = true;
                } else {
                    CursorIsLocked = false;
                }
            } else {
                if (Input.GetKeyUp(KeyCode.Escape)) {
                    CursorIsLocked = false;
                } else if (LockKey < 0 && Input.GetMouseButtonUp(0)) {
                    CursorIsLocked = true;
                }
            }


            if (CursorIsLocked) {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            } else if (!CursorIsLocked) {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }

        Quaternion ClampRotationAroundXAxis(Quaternion q) {
            q.x /= q.w;
            q.y /= q.w;
            q.z /= q.w;
            q.w = 1.0f;

            float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);

            angleX = Mathf.Clamp(angleX, MinimumX, MaximumX);

            q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

            return q;
        }

    }
}