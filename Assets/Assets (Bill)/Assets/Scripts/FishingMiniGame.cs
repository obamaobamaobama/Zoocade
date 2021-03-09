using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingMiniGame : MonoBehaviour
{
    [SerializeField] private Transform topPivot;
    [SerializeField] private Transform bottomPivot;

    [SerializeField] private Transform heart;

    float heartPosition;
    float heartDestination;

    float heartTimer;
    [SerializeField] float timerMultiplicator = 3f;

    float heartSpeed;
    [SerializeField] float smoothMotion = 1f;

    [SerializeField] Transform hook;
    [SerializeField] float hookPosition; //this 
    [SerializeField] float hookSize = 0.1f;
    [SerializeField] float hookPower = 0.5f;
    float hookProgress;
    [SerializeField] float hookPullVelocity;
    [SerializeField] float hookPullPower = 0.01f;
    [SerializeField] float hookGravityPower = 0.005f;
   // [SerializeField] float hookProgressDegradationPower = 0.1f;

    [SerializeField] Transform progressBarContainer;

    [SerializeField] SpriteRenderer hookSprite;
    public string p1orp2;
    public Animator oppositePlayerAnimator;

    static bool pause = false;
    private void Start()
    {
        Resize();
        pause = false;
    }

    private void Resize() // resize the hook area, the calculation need this. also great for tuning.
    {
        Bounds b = hookSprite.bounds;
        float ySize = b.size.y;
        Vector3 ls = hook.localScale;
        float distance = Vector3.Distance(topPivot.position, bottomPivot.position);
        ls.y = (distance / ySize * hookSize);
        hook.localScale = ls;
    }

    void FixedUpdate()
    {
       if (pause) { return; }
        HeartMovement();
        HookMovement();
        ProgressCheck();
    }

    private void ProgressCheck()
    {
        Vector3 scale = progressBarContainer.localScale;
        scale.y = hookProgress;
        progressBarContainer.localScale = scale;

        float min = hookPosition - hookSize / 2;
        float max = hookPosition + hookSize / 2;

        if(min < heartPosition && heartPosition < max) // gain progress
        {
            hookProgress += hookPower * Time.fixedDeltaTime;
        }
        else //lose progress
        {
            //hookProgress -= hookProgressDegradationPower * Time.fixedDeltaTime;
        }
        if(hookProgress >= 1f)
        {
            Win();
        }
        hookProgress = Mathf.Clamp(hookProgress, 0f, 1f);
    }

    private void Win()
    {
       pause = true;
        Debug.Log(p1orp2 + "WIN");
        oppositePlayerAnimator.SetBool("Angry", true);
    }

    void HeartMovement()
    {
        heartTimer -= Time.fixedDeltaTime;
        if (heartTimer < 0)
        {
            heartTimer = UnityEngine.Random.value * timerMultiplicator;
            heartDestination = UnityEngine.Random.value;
        }

        heartPosition = Mathf.SmoothDamp(heartPosition, heartDestination, ref heartSpeed, smoothMotion);
        heart.position = Vector3.Lerp(bottomPivot.position, topPivot.position, heartPosition);
    }
    void HookMovement()
    {
        if(hookPosition - hookSize / 2 <= 0f && hookPullVelocity<0f)
        {
            hookPullVelocity = 0f;
        }
        if(hookPosition + hookSize / 2 >= 0.999f && hookPullVelocity > 0f)
        {
            hookPullVelocity = 0f;
        }
        hookPullVelocity -= hookGravityPower * Time.fixedDeltaTime;
        hookPosition += hookPullVelocity;
        hookPosition = Mathf.Clamp(hookPosition, hookSize / 2, 1 - hookSize/2);
        hook.position = Vector3.Lerp(bottomPivot.position, topPivot.position, hookPosition);

        
    }
    public void zHooking()
    {
        hookPullVelocity += hookPullPower * Time.fixedDeltaTime;
    }
}
