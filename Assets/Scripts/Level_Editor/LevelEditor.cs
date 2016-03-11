using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class LevelEditor : MonoBehaviour {
    public float height = 4;
    public float width = 4;

    public Color grid_color = new Color(1.0F, 1.0F, 1.0F, 0.5F);
    public bool grid_visible = true;

    public GameObject player_character = null;

    public List<GameObject> tile_objects = new List<GameObject>();
    public int current_tile = 0;

    private List<GameObject> level_objects = new List<GameObject>();
    public bool set_character = false;

    void OnDrawGizmos() {
        init_grid();
    }

    private void init_grid() {
        Vector3 view = Camera.current.transform.position;
        grid_color.a = grid_visible ? 1f : 0f;
        Gizmos.color = grid_color;
        // Arbitrary large number
        float inf = 2 << 16;
        float bounds = 2 << 10;
        float y_pos, x_pos;
        for (float y = view.y - bounds; y < view.y + bounds; y += this.height) {
            y_pos = this.height * Mathf.Floor(y / this.height);
            Gizmos.DrawLine(new Vector3((-1) * inf, y_pos, 0.0f),
                            new Vector3(inf, y_pos, 0.0f));
        }
        for (float x = view.x - bounds; x < view.x + bounds; x += this.width) {
            x_pos = this.width * Mathf.Floor(x / this.width);
            Gizmos.DrawLine(new Vector3(x_pos, (-1) * inf, 0.0f),
                            new Vector3(x_pos, inf, 0.0f));
        }
    }

    public void delete_character() {
        DestroyImmediate(player_character);
    }

    public void add_game_object(Vector3 pos) {
        if (set_character) {
            if (player_character != null) {
                delete_character();
            }
            GameObject pc = (GameObject)Instantiate(Resources.Load("PlayerCharacter"));
            pc.transform.position = pos;
            pc.transform.SetParent(transform);
            player_character = pc;
            return;
        }
        if (tile_objects.Count == 0) {
            return;
        }
        foreach(GameObject obj in level_objects) {
            if (obj.transform.position == pos) {
                return;
            }
        }


        GameObject new_obj =
                Instantiate<GameObject>(tile_objects[current_tile]) as GameObject;
        new_obj.transform.position = pos;
        new_obj.transform.SetParent(transform);
        level_objects.Add(new_obj);
    }

    public void place_character() {
        set_character = true;
    }

    public void remove_game_object(Vector3 pos) {
        foreach (GameObject obj in level_objects) {
            if (obj.transform.position == pos) {
                GameObject.DestroyImmediate(obj);
                level_objects.Remove(obj);
                break;
            }
        }
    }

    public void select_tile(int n) {
        set_character = false;
        current_tile = n >= tile_objects.Count ? 0 : n;
    }

    public void add_tile() {
        tile_objects.Add(null);
    }

    public void delete_tile(int n) {
        tile_objects.RemoveAt(n);
    }

    public void clear_level() {
        foreach (Transform child in gameObject.GetComponentInChildren<Transform>()) {
            if (!(child.gameObject.Equals(gameObject))) {
                DestroyImmediate(child.gameObject);
            }
        }
        level_objects.Clear();
    }

}
