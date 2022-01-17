namespace classes
{
    public class ChangeRequest : WorkItem 
    {
        protected int OriginalItemID { get; set; }
        public ChangeRequest() { }
        /// <summary> 
        /// Change items in the workItem
        /// </summary> 
        /// <param name="title">
        /// title of the method
        /// </param> 
        /// <param name="desc">
        /// description to change
        /// </param> 
        /// <param name="joblen">
        /// length of job
        /// </param> 
        /// <param name="originalID">
        /// The original id of the workItem
        /// </param> 
        public ChangeRequest(string title, string desc, TimeSpan joblen, int originalID)
        {
            this.ID=GetNextID();
            this.Title=title;
            this.Description=desc;
            this.jobLength=joblen;
            this.OriginalItemID=originalID;
        }
    }
}
