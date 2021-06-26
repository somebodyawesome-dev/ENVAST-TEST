using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageData : MonoBehaviour
{
    public enum ROW { LEFT,RIGHT};
    
    public string nameImage;
    public ROW row;
    public bool isConnected;
    public LineRenderer lineRenderer;
    public LineRendrerFollowMouse follower;
    public bool islocked;
    public Text text;
    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        follower = GetComponent<LineRendrerFollowMouse>();
        init();
        
    }

    public void init()
    {
        islocked = false;
        isConnected = false;
        follower.enabled = false;
        lineRenderer.SetPosition(0, transform.Find("connection point").position);
        lineRenderer.SetPosition(1, transform.Find("connection point").position);
        lineRenderer.enabled = false;
        if (text)
        {
            text.text = nameImage;
        }
    }
    public void establishConnection()
    {
        isConnected = true;
        lineRenderer.enabled = true;
        follower.enabled = true;
    }
    public void connectToOtherImage(LineRenderer otherImageLineRendrer)
    {
        isConnected = true;
        islocked = true;
        otherImageLineRendrer.GetComponent<ImageData>().islocked = true;
        otherImageLineRendrer.GetComponent<LineRendrerFollowMouse>().enabled = false;
        otherImageLineRendrer.SetPosition(1, transform.Find("connection point").position);
    }
    public void cancelConnection()
    {

        init();
        
    }

}
