namespace ClientSI_Config
{
    public class IdentificationSettings
    {


        /// <summary>
        /// TokenRequestURL 
        /// </summary>
        public string TokenRequestURL { get; set; }
        /// <summary>
        /// Id of the app to use
        /// </summary>
        public string AppId { get; set; }
        /// <summary>
        /// Secret of the apps
        /// </summary>
        public string Secret { get; set; }
        /// <summary>
        /// url of the service of recognition
        /// </summary>
        public string IdentificationEndpointURL { get; set; }
        /// <summary>
        /// ID of project to use recognition 
        /// </summary>
        public string[] ProjectIds { get; set; }
        /// <summary>
        /// Unit of measure project
        /// </summary>
        public string UnitOfMeasure { get; set; }
        /// <summary>
        /// File .obj that contains the surface to recognize
        /// </summary>
        public string Filename { get; set; }

        /// <summary>
        /// Instance name sending to server
        /// </summary>
        public string InstanceName { get; set; }

    }
}
