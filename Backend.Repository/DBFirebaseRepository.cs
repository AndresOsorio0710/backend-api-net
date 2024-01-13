using Backend.Entities.Models;
using Backend.Utilities;
using Google.Cloud.Firestore;

namespace Backend.Repository
{
    public class DBFirebaseRepository<EType>
    {
        private readonly ConfigurationManager configurationManager;
        private readonly string CollectionName;
        public FirestoreDb firestoreDb;

        public DBFirebaseRepository()
        {
            this.CollectionName = typeof(EType).Name;
            this.configurationManager = new ConfigurationManager();
            Environment.SetEnvironmentVariable(this.configurationManager.DBFirebaseValues.Variable, this.configurationManager.DBFirebaseValues.CredentialPath);
            firestoreDb = FirestoreDb.Create(this.configurationManager.DBFirebaseValues.ProjectId);
        }

        public EType Get<EType>(EType record) where EType : FirebaseDocument
        {
            DocumentReference documentReference = firestoreDb.Collection(this.CollectionName).Document(record.Id);
            DocumentSnapshot documentSnapshot = documentReference.GetSnapshotAsync().GetAwaiter().GetResult();
            if (documentSnapshot.Exists)
            {
                EType data = documentSnapshot.ConvertTo<EType>();
                data.Id = documentSnapshot.Id;
                return data;
            }
            return null;
        }

        public EType Add<EType>(EType record) where EType : FirebaseDocument
        {
            try
            {
                CollectionReference collectionReference = firestoreDb.Collection(this.CollectionName);
                DocumentReference documentReference = collectionReference.AddAsync(record).GetAwaiter().GetResult();
                record.Id = documentReference.Id;
                return record;
            }
            catch (Exception ex) { return null; }
        }

        public EType Update<EType>(EType record) where EType : FirebaseDocument
        {
            try
            {
                CollectionReference collectionReference = firestoreDb.Collection(this.CollectionName);
                DocumentReference documentReference = collectionReference.Document(record.Id);
                documentReference.SetAsync(record).GetAwaiter().GetResult();
                return record;
            }
            catch (Exception ex) { return null; }
        }
    }
}
