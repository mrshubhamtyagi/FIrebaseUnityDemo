using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FirestoreHandler : MonoBehaviour
{
    public TMP_InputField collectionPathInputField;
    public TMP_InputField documentIdInputField;
    public TMP_InputField valueInputField;

    public TMP_InputField fieldIdInputField;
    public Toggle includeMetadataUpdatesToggle;
    public TMP_InputField incrementInputField;

    public TextMeshProUGUI outputText;

    private void Start()
    {
        if (Application.platform != RuntimePlatform.WebGLPlayer)
            DisplayError("The code is not running on a WebGL build; as such, the Javascript functions will not be recognized.");
    }

    public void GetDocument() =>
        FirebaseFirestoreLibrary.GetDocument(collectionPathInputField.text, documentIdInputField.text, gameObject.name, "DisplayData", "DisplayErrorObject");

    public void GetDocumentsInCollection() =>
        FirebaseFirestoreLibrary.GetDocumentsInCollection(collectionPathInputField.text, gameObject.name, "DisplayData", "DisplayErrorObject");

    public void SetDocument() =>
        FirebaseFirestoreLibrary.SetDocument(collectionPathInputField.text, documentIdInputField.text, valueInputField.text, gameObject.name,
        "DisplayInfo", "DisplayErrorObject");

    public void AddDocument() =>
        FirebaseFirestoreLibrary.AddDocument(collectionPathInputField.text, valueInputField.text, gameObject.name, "DisplayInfo", "DisplayErrorObject");

    public void UpdateDocument() =>
        FirebaseFirestoreLibrary.UpdateDocument(collectionPathInputField.text, documentIdInputField.text, valueInputField.text, gameObject.name, "DisplayInfo", "DisplayErrorObject");

    public void DeleteDocument() =>
        FirebaseFirestoreLibrary.DeleteDocument(collectionPathInputField.text, documentIdInputField.text, gameObject.name, "DisplayInfo", "DisplayErrorObject");

    public void DeleteField() =>
        FirebaseFirestoreLibrary.DeleteField(collectionPathInputField.text, documentIdInputField.text, fieldIdInputField.text, gameObject.name, "DisplayInfo", "DisplayErrorObject");

    public void AddElementInArrayField() =>
        FirebaseFirestoreLibrary.AddElementInArrayField(collectionPathInputField.text, documentIdInputField.text, fieldIdInputField.text, valueInputField.text, gameObject.name, "DisplayInfo", "DisplayErrorObject");

    public void RemoveElementInArrayField() =>
        FirebaseFirestoreLibrary.RemoveElementInArrayField(collectionPathInputField.text, documentIdInputField.text, fieldIdInputField.text, valueInputField.text, gameObject.name, "DisplayInfo", "DisplayErrorObject");

    public void IncrementFieldValue() =>
        FirebaseFirestoreLibrary.IncrementFieldValue(collectionPathInputField.text, documentIdInputField.text, fieldIdInputField.text, int.Parse(incrementInputField.text), gameObject.name, "DisplayInfo", "DisplayErrorObject");

    public void ListenForDocumentChange() =>
        FirebaseFirestoreLibrary.ListenForDocumentChange(collectionPathInputField.text, documentIdInputField.text, includeMetadataUpdatesToggle.isOn, gameObject.name, "DisplayData", "DisplayErrorObject");

    public void StopListeningForDocumentChange() => FirebaseFirestoreLibrary.StopListeningForDocumentChange(collectionPathInputField.text, documentIdInputField.text, gameObject.name, "DisplayInfo", "DisplayErrorObject");

    public void ListenForCollectionChange() =>
        FirebaseFirestoreLibrary.ListenForCollectionChange(collectionPathInputField.text, includeMetadataUpdatesToggle.isOn, gameObject.name, "DisplayData", "DisplayErrorObject");

    public void StopListeningForCollectionChange() =>
        FirebaseFirestoreLibrary.StopListeningForCollectionChange(collectionPathInputField.text, gameObject.name, "DisplayInfo", "DisplayErrorObject");

    public void DisplayData(string data)
    {
        outputText.color = outputText.color == Color.green ? Color.blue : Color.green;
        outputText.text = data;
        Debug.Log(data);
    }

    public void DisplayInfo(string info)
    {
        outputText.color = Color.white;
        outputText.text = info;
        Debug.Log(info);
    }

    public void DisplayErrorObject(string error)
    {
        var parsedError = JsonUtility.FromJson<FirebaseError>(error);
        DisplayError(parsedError.message);
    }

    public void DisplayError(string error)
    {
        outputText.color = Color.red;
        outputText.text = error;
        Debug.LogError(error);
    }
}
