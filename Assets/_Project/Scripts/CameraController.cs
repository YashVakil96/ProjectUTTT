using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace UltimateTTT
{
    public class CameraController : Singleton<CameraController>
    {
        public CinemachineVirtualCamera Camera;

        public List<Transform> camPoints;

        public Transform[,] camPoint = new Transform[3, 3];

        // Start is called before the first frame update
        public CameraMode currentMode;

        public int currentX, currentY;
        
        void Start()
        {
            int count = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    camPoint[i, j] = camPoints[count];
                    count++;
                }
            }
        }

        // Update is called once per frame


        public IEnumerator JumpToGrid(int x, int y)
        {
            currentX = x;
            currentY = y;
            if (currentMode ==CameraMode.FullBoard)
            {
                yield break;
            }
            yield return new WaitForSeconds(1);
            if (MainBoardController.Instance.mainGridState[x, y] > 0)
            {
                CenterCam();
            }
            else if (MainBoardController.Instance.isGameOver)
            {
                CenterCam();
            }
            else
            {
                
                // Camera.LookAt = camPoint[x, y];
                // Camera.Follow = camPoint[x, y];
                // Camera.m_Lens.OrthographicSize = 1.7f;
                
                Vector3 newPos = new Vector3(camPoint[x, y].position.x,camPoint[x, y].position.y,-10);
                Camera.transform.DOMove(newPos,.5f);
                DOTween.To(() => Camera.m_Lens.OrthographicSize, x => Camera.m_Lens.OrthographicSize = x, 1.7f, 1f);

            }
        }


        [Button("Center cam")]
        public void CenterCam()
        {
            // Camera.LookAt = camPoint[1, 1];
            // Camera.Follow = camPoint[1, 1];
            // Camera.m_Lens.OrthographicSize = 5;
            Vector3 newPos = new Vector3(camPoint[1, 1].position.x,camPoint[1, 1].position.y,-10);
            Camera.transform.DOMove(newPos,.5f);
            DOTween.To(() => Camera.m_Lens.OrthographicSize, x => Camera.m_Lens.OrthographicSize = x, 5, 1f);
        }

        public void ChangeCameraMode(int mode)
        {
            currentMode = (CameraMode)mode;

            if (currentMode == CameraMode.FullBoard)
            {
                CenterCam();
            }
            else
            {
                Vector3 newPos = new Vector3(camPoint[currentX, currentY].position.x,camPoint[currentX, currentY].position.y,-10);
                Camera.transform.DOMove(newPos,.5f);
                DOTween.To(() => Camera.m_Lens.OrthographicSize, x => Camera.m_Lens.OrthographicSize = x, 1.7f, 1f);
            }
        }
    }

    public enum CameraMode
    {
        FullBoard,
        SingleBoard
    }
}