using System;
using UnityEngine;

public class SelectionManger : MonoBehaviour
{
    [SerializeField] private ImageData firstSelction, secondSelection;
    [SerializeField] private ImageData target;
    private RoundsManager roundsManager;
    [SerializeField] private GameObject gameOverPanel;

    [SerializeField] SliderController sliderController;


    // Start is called before the first frame update
    void Start()
    {
        roundsManager = FindObjectOfType<RoundsManager>();
        sliderController = FindObjectOfType<SliderController>();
        firstSelction = null;
        secondSelection = null;
        target = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            target = (hit.collider) ? hit.collider.gameObject.GetComponent<ImageData>() : null;
            if (target != null && !target.islocked)
            {

                if (!firstSelction)
                {
                    //select first image
                    firstSelction = target;
                    firstSelction.establishConnection();
                }
                else
                {
                    if (target == firstSelction)
                    {
                        //cancel connection
                        firstSelction.cancelConnection();
                        firstSelction = null;

                    }
                    else
                    {

                        secondSelection = target;
                        //its the second selected image
                        if (firstSelction.row != secondSelection.row)
                        {
                            if (String.Equals(firstSelction.nameImage, secondSelection.nameImage))
                            {
                                //correct answer

                                secondSelection.connectToOtherImage(firstSelction.lineRenderer);
                                sliderController.setSlideTarget(1);
                                roundsManager.correctAnswers++;
                                //go for the next round
                                roundsManager.checkEndRound();
                            }
                            else
                            {

                                //wrong answer
                                //user lost
                                firstSelction.init();
                                //show pop up
                                gameOverPanel.SetActive(true);





                            }
                            firstSelction = null;

                        }
                        secondSelection = null;

                    }

                }
            }


        }

        else
        {
            if (Input.GetMouseButtonUp(0) && firstSelction)
            {
                Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
                target = (hit.collider) ? hit.collider.gameObject.GetComponent<ImageData>() : null;
                if (target != null && !target.islocked)
                {
                    secondSelection = target;
                    //its the second selected image
                    if (firstSelction.row != secondSelection.row)
                    {
                        if (String.Equals(firstSelction.nameImage, secondSelection.nameImage))
                        {
                            //correct answer

                            secondSelection.connectToOtherImage(firstSelction.lineRenderer);
                            sliderController.setSlideTarget(1);
                            roundsManager.correctAnswers++;
                            //go for the next round
                            roundsManager.checkEndRound();
                        }
                        else
                        {

                            //wrong answer
                            //user lost
                            firstSelction.init();
                            //show pop up
                            gameOverPanel.SetActive(true);





                        }
                        firstSelction = null;

                    }
                    secondSelection = null;

                }

            }
        }



    }
}
