using UnityEngine;
using TMPro;
using Firebase.Database;
using Firebase.Extensions;

public class FirebaseDataDisplay : MonoBehaviour
{
    public TMP_Text dataText;

    private DatabaseReference dbRef;

    void Start()
{
    // Assign your Firebase DB URL
    FirebaseDatabase database = FirebaseDatabase.GetInstance("https://mana-f7db9-default-rtdb.firebaseio.com/");
    dbRef = database.RootReference;

    database.GetReference("/")
        .GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;

                // Read values safely with null checks
                bool detectedForce = bool.Parse(snapshot.Child("Detected Force").Value.ToString());
                string humidity = snapshot.Child("HUMIDITY").Value?.ToString() ?? "N/A";
                string temp = snapshot.Child("TEMP").Value?.ToString() ?? "N/A";

                // Display all in one text box
                dataText.text =
                    $"Force Detected: {detectedForce}\n" +
                    $"Humidity: {humidity}\n" +
                    $"Temperature: {temp}";
            }
            else
            {
                dataText.text = "Failed to load data.";
                Debug.LogError("Firebase read error: " + task.Exception);
            }
        });
}
}
