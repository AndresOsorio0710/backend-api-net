namespace Backend.Entities.Configs
{
    public class DBFirebaseValues
    {
        public string CredentialPath { get; set; }
        public string Variable { get; set; }
        public string ProjectId { get; set; }

        public DBFirebaseValues(string CredentialPath,string Variable ,string ProjectId) {
            this.CredentialPath = CredentialPath;
            this.Variable = Variable;
            this.ProjectId = ProjectId;
        }
    }
}
