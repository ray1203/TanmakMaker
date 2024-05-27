using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Unity.Editor;
using Firebase.Database;
using Firebase;

public class RealTimeDatabase:MonoBehaviour {
    private static RealTimeDatabase Instance;
    public DatabaseReference reference;


    private void Start() {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://shootinggame1203.firebaseio.com/");

        // Get the root reference location fo Database
        reference = FirebaseDatabase.DefaultInstance.RootReference;

        User user1 = new User("htw", "naver");
        User user2 = new User("ksj", "daum");
        string json = JsonUtility.ToJson(user1);
        string json2 = JsonUtility.ToJson(user2);

        // Using Json
        reference.Child("users").Child("user1").SetRawJsonValueAsync(json);
        // Using Path
        reference.Child("users").Child("user2").Child("name").SetValueAsync(user2.name);
        reference.Child("users").Child("user2").Child("email").SetValueAsync(user2.email);
        // Using Push
        string key = reference.Child("users").Push().Key;
        reference.Child("users").Child(key).Child("email").SetValueAsync("This is Push()");
        // Using Update
        Dictionary<string, object> update = user2.ToDictionary();
        reference.Child("users").Child("user3").SetRawJsonValueAsync(json);
        reference.Child("users").Child("user3").UpdateChildrenAsync(update);
    }
}
class User {
    public string name;
    public string email;

    public User(string name, string email) {
        this.name = name;
        this.email = email;
    }

    public Dictionary<string, object> ToDictionary() {
        Dictionary<string, object> result = new Dictionary<string, object>();
        result["name"] = name;
        result["email"] = email;

        return result;
    }
}

