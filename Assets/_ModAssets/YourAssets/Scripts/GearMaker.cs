using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarblePhysics.Modding
{
    [ExecuteAlways]
    public class GearMaker : MonoBehaviour
    {
        [SerializeField]
        private GameObject toothTemplate = default;

        [SerializeField]
        private int toothCount = default;

        [SerializeField]
        private List<GameObject> toothCopies = default;

        [SerializeField]
        private bool update = false;
        
        private void Update()
        {

            if (update)
            {
                update = false;
                UpdateTeeth();
            }
        }

        private void UpdateTeeth()
        {
            if (toothCount > 0 && toothTemplate != null)
            {
                foreach (GameObject toothCopy in toothCopies)
                {
                    if (toothCopy != null)
                    {
                        DestroyImmediate(toothCopy);
                    }
                }
                toothCopies.Clear();

                float degreeOffset = 360f / toothCount;
                toothTemplate.transform.localEulerAngles = Vector3.zero;
                float nextAngle = degreeOffset;
                for (int i = 0; i < toothCount - 1; i++)
                {
                    GameObject copy = Instantiate(toothTemplate, transform);
                    toothCopies.Add(copy);
                    copy.transform.ClearLocal();
                    copy.transform.localEulerAngles = new Vector3(0, 0, nextAngle);
                    nextAngle += degreeOffset;
                }
            }
        }
    }
}
