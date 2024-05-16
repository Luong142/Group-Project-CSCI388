using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AnimateReticle : MonoBehaviour
{
    // our task is to animate the reticle
    // step 1: retrieve the reticle from the XR line interactor visual
    // step 2: use scale for reticle

    [SerializeField]
    XRInteractorLineVisual XRInteractorLineVisual;

    private GameObject reticle;

    // Start is called before the first frame update
    void Start()
    {
        XRInteractorLineVisual = GetComponent<XRInteractorLineVisual>();


        if (XRInteractorLineVisual == null)
        {
            // return validation early technique is working.
            //Debug.Log("It is null");
            return;
        }

        if (XRInteractorLineVisual != null)
        {
            // we retrieve the reticle, from the XRInteractorLineVisual reticle game object!
            reticle = XRInteractorLineVisual.reticle;

            // debug purpose
            if (reticle != null)
            {
                //Debug.Log("The reticle is not null");
            }
            else
            {
                // all good, checked
                //Debug.Log("The reticle is null");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // this will update and scale the reticle from 0 to 1
        float scaleAmount = Mathf.PingPong(Time.time, 1.0f);
        reticle.transform.localScale = new Vector3(scaleAmount, scaleAmount, scaleAmount);
    }
}
