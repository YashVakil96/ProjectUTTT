using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace UltimateTTT
{
    public class CameraController : Singleton<CameraController>
    {
        public CinemachineVirtualCamera Camera;

        public List<Transform> camPoints;
        public Transform[,]camPoint = new Transform[3,3];
        // Start is called before the first frame update
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
            
            yield return new WaitForSeconds(1);
            if (MainBoardController.Instance.mainGridState[x,y]>0)
            {
                CenterCam();
            }
            else if(MainBoardController.Instance.isGameOver)
            {
                CenterCam();
            }
            else
            {
                Camera.LookAt = camPoint[x, y];
                Camera.Follow = camPoint[x, y];
                Camera.m_Lens.OrthographicSize = 1.7f;    
            }
            
        }
        

        [Button("Center cam")]
        public void CenterCam()
        {
            Camera.LookAt = camPoint[1, 1];
            Camera.Follow = camPoint[1, 1];
            Camera.m_Lens.OrthographicSize = 5;
        }
    }
}
