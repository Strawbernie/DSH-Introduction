using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;
using UnityEngine.InputSystem;
using UnityEngine.Assertions.Must;
using TMPro;

public class SliceObject : MonoBehaviour
{
    public Transform startSlicePoint;
    public Transform endSlicePoint;
    public VelocityEstimator velocityEstimator;
    public LayerMask sliceableLayer;
    public Material CrossMaterial;
    public TMP_Text comboText;
    ComboManager comboManager;
    public float cutforce = 2000f;

    private void Start()
    {
      comboManager=FindObjectOfType<ComboManager>();
    }
    void FixedUpdate()
    {
        bool hasHit= Physics.Linecast(startSlicePoint.position, endSlicePoint.position, out RaycastHit hit, sliceableLayer);
        if (hasHit)
        {
            GameObject target = hit.transform.gameObject;
            Slice(target);
        }
    }
    public void Slice(GameObject target)
    {
        Vector3 velocity = velocityEstimator.GetVelocityEstimate();
        Vector3 planeNormal = Vector3.Cross(endSlicePoint.position - startSlicePoint.position, velocity);
        planeNormal.Normalize();

        SlicedHull hull = target.Slice(endSlicePoint.position, planeNormal);

        if (hull != null)
        {
            GameObject upperHull = hull.CreateUpperHull(target, CrossMaterial);
            SetupSlicedComponent(upperHull);
            GameObject lowerHull = hull.CreateLowerHull(target, CrossMaterial);
            SetupSlicedComponent(lowerHull);
            ScoreManager.Sliced++;
            ScoreManager.currentCombo++;
            if (ScoreManager.currentCombo > 10)
            {
                comboManager.ComboUP();
            }
            Debug.Log("sliced:" + ScoreManager.Sliced);
            Destroy(target);
        }
    }
    public void SetupSlicedComponent(GameObject slicedObject)
    {
        Rigidbody rb = slicedObject.AddComponent<Rigidbody>();
        MeshCollider collider = slicedObject.AddComponent<MeshCollider> ();
        collider.convex = true;
        rb.AddExplosionForce(cutforce, slicedObject.transform.position, 1);
        StartCoroutine(DestroyCooldown(slicedObject));
    }
    IEnumerator DestroyCooldown(GameObject slicedObject)
    {
        yield return new WaitForSeconds(2);
        Destroy(slicedObject);
    }
}
