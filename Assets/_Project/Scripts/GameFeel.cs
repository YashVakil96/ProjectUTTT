using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UnityEngine;

namespace UltimateTTT
{
    public class GameFeel : MonoBehaviour
    {

        public MMF_Player subgridFeedback;
        public MMF_Scale subGridScale;


        void Awake()
        {
            subgridFeedback.Initialization();
        }

        public void PlayCell()
        {
            // cellFeedback.FeedbacksList[0].RequiredTarget.
        }

        public void PlaySubgrid()
        {
        }
    }
}