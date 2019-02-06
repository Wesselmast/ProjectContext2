using UnityEngine;

public class Grid : MonoBehaviour {

    public Vector3 GetGridPoint(Vector3 position) {
        position -= transform.position;

        int x = Mathf.RoundToInt(position.x / 1);
        int z = Mathf.RoundToInt(position.z / 1);
        int y = Mathf.RoundToInt(position.y / 1);

        Vector3 result = new Vector3(x, y, z);

        result += transform.position;

        return result;
    }
}
