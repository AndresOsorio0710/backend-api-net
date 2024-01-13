using Google.Cloud.Firestore;

namespace Backend.Entities.Models
{
    [FirestoreData]
    public class Prueba : FirebaseDocument
    {
        [FirestoreProperty]
        public string Name { get; set; }
    }
}
