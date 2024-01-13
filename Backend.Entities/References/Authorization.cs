namespace Backend.Entities.References
{
    public class Authorization
    {
        /// <summary>
        /// Access token
        /// </summary>
        public string AccessToken { get; set; }

        public Authorization() {
            this.AccessToken = String.Empty;
        }
    }
}
