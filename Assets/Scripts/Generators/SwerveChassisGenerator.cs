using System;
using System.Linq;
using UnityEngine;

[ExecuteInEditMode]
public class SwerveChassisGenerator : MonoBehaviour
{
    [Header("Physical Properties")]

    [Range(17.5f, 27.5f)]
    [Tooltip("Center-to-center distance between horizontal wheels in inches.")]
    public float TrackWidth = 20.75f;

    [Range(17.5f, 27.5f)]
    [Tooltip("Center-to-center distance between vertical wheels in inches.")]
    public float WheelBase = 20.75f;

    [Range(2f, 5f)]
    [Tooltip("Diameter of the wheels in inches.")]
    public float WheelDiameter = 3.5f;

    [Header("Prefabs")]
    [Tooltip("The model to be used for the wheel, should be normalized to 1 inch in diameter.")]
    public GameObject WheelModel;

    private (Vector3, string)[] modules;

    public void Build()
    {
        // Clear previous builds
        while (transform.childCount > 0)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }

        modules = new (Vector3, string)[] {
            (new Vector3(-TrackWidth / 2, 0, WheelBase / 2), "Front Left"),
            (new Vector3(TrackWidth / 2, 0, WheelBase / 2), "Front Right"),
            (new Vector3(-TrackWidth / 2, 0, -WheelBase / 2), "Back Left"),
            (new Vector3(TrackWidth / 2, 0, -WheelBase / 2), "Back Right"),
        };

        var wheels = modules.Select(t =>
        {
            var wheel = Instantiate(WheelModel, t.Item1, Quaternion.Euler(90, 0, 0), transform);
            wheel.name = t.Item2;
            wheel.transform.localScale *= WheelDiameter;

            return wheel;
        }).ToArray();
    }
}
