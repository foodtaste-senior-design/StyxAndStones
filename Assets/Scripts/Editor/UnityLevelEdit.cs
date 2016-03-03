using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LevelEditor))]
public class UnityLevelEdit : Editor {
    LevelEditor grid;

    public void OnEnable() {
        grid = (LevelEditor)target;
    }

    public override void OnInspectorGUI() {
        DrawDefaultInspector();
        // Tile Selection
        GUILayout.Box("", new GUILayoutOption[] {
                GUILayout.ExpandWidth(true),
                GUILayout.Height(1)
            });
        GUILayout.Label("Tile selection");

        if (grid.current_tile < grid.tile_objects.Count) {
            if (grid.tile_objects[grid.current_tile] != null) {
                GUILayout.Label(
                        "Current Tile: " + grid.tile_objects[grid.current_tile].name);
            }
            else {
                GUILayout.Label("Current Tile: None");
            }
        }

        for (int i = 0; i < grid.tile_objects.Count; i++) {
            GUILayout.BeginHorizontal();
            GameObject tile = grid.tile_objects[i];
            GameObject obj = (GameObject) EditorGUILayout.ObjectField(
                    grid.tile_objects[i], typeof(GameObject), true);
            if (obj) {
                grid.tile_objects[i] = obj;
            }
            if (tile != null && i != grid.current_tile && GUILayout.Button("Select")) {
                grid.select_tile(i);
            }
            if (GUILayout.Button("-", GUILayout.Width(20f))) {
                grid.delete_tile(i);
            }
            GUILayout.EndHorizontal();
        }
        if (GUILayout.Button("Add tile object")) {
            grid.add_tile();
        }
        // Danger Zone
        GUILayout.Box("", new GUILayoutOption[] {
                GUILayout.ExpandWidth(true),
                GUILayout.Height(1)
            });
        GUILayout.Label("Danger Zone");
        if (GUILayout.Button("Clear Level") &&
                EditorUtility.DisplayDialog(
                    "Are you sure you want to reset the entire level?",
                    "You seriously can't undo this.",
                    "Sure, dude.", "Nope nope.")) {
            grid.clear_level();
        }
    }

    void clear_level() {
    }

    void OnSceneGUI() {
        handle_input();
    }

    void handle_input() {
        Event e = Event.current;
        int control_id = GUIUtility.GetControlID(FocusType.Passive);
        switch (e.GetTypeForControl(control_id)) {
            case EventType.MouseDown:
                GUIUtility.hotControl = control_id;
                e.Use();
                break;

            case EventType.MouseUp:
                GUIUtility.hotControl = 0;
                on_mouse_event(e.mousePosition, e.button);
                e.Use();
                break;

            case EventType.MouseDrag:
                GUIUtility.hotControl = control_id;
                on_mouse_event(e.mousePosition, e.button);
                e.Use();
                break;

            default: break;
        }
    }

    void on_mouse_event(Vector2 pos, int button) {
        Ray ray = Camera.current.ScreenPointToRay(new Vector3(pos.x, -pos.y + Camera.current.pixelHeight));

        Vector3 mouse_pos = ray.origin;

        float grid_x = grid.width * (Mathf.Floor(mouse_pos.x / grid.width) + 0.5f);
        float grid_y = grid.height * (Mathf.Floor(mouse_pos.y / grid.height) + 0.5f);
        Vector3 snap_pos = new Vector3(grid_x, grid_y, 0.0f);

        if (button == 0) {
            grid.add_game_object(snap_pos);
        }
        else if (button == 1) {
            grid.remove_game_object(snap_pos);
        }
    }

}

