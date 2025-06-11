using UnityEngine;
using TMPro;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using System;

public class FirebaseDataDisplay : MonoBehaviour
{
    public TMP_Text dataText;
    public float mass = 60f;
    private DatabaseReference dbRef;
    private float _force = 60f;  // Default fallback
    public float Force => _force; // Public getter

    void Start()
    {
        // Initialize Firebase database
        FirebaseDatabase database = FirebaseDatabase.GetInstance("https://mana-f7db9-default-rtdb.firebaseio.com/");
        dbRef = database.RootReference;

        // Subscribe to real-time updates
        dbRef.ValueChanged += OnDataChanged;
    }

    private void OnDataChanged(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError("Firebase database error: " + args.DatabaseError.Message);
            dataText.text = "Error loading data.";
            return;
        }

        DataSnapshot snapshot = args.Snapshot;

        // Extract values
        string pulse = snapshot.Child("Pulse").Value?.ToString() ?? "N/A";
        string speedRaw = snapshot.Child("Speed").Value?.ToString() ?? "0";
        string temp = snapshot.Child("TEMP").Value?.ToString() ?? "N/A";
        float.TryParse(snapshot.Child("Force").Value?.ToString(), out _force);

        // Parse speed and calculate force
        float speedValue = 0f;
        string[] speedParts = speedRaw.Split(' ');
        float.TryParse(speedParts[0], out speedValue);

        float force = speedValue * mass;

        // Update UI text
        dataText.text =
            $"Pulse: {pulse}\n" +
            $"Speed: {speedValue:F2} m/s²\n" +
            $"Force: {Force:F2} N\n" +
            $"Temperature: {temp}";
    }

    void OnDestroy()
    {
        // Unsubscribe to prevent memory leaks
        if (dbRef != null)
        {
            dbRef.ValueChanged -= OnDataChanged;
        }
    }
}